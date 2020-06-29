using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CATIA_APP_ITF;
using SURFACEMACHINING;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Diagnostics;
using INFITF;
using MECMOD;
using PARTITF;
using ProductStructureTypeLib;
using SPATypeLib;
using NavigatorTypeLib;
using KnowledgewareTypeLib;
using HybridShapeTypeLib;
using System.IO;
using DNBPert;
using CATMat;
using FittingTypeLib;
using DNBASY;
using PPR;
using PROCESSITF;

namespace RXQuestServer.Delmia
{
    public partial class InitDelmiaDocument : Form
    {
        DataType.Dsystem DStype = new DataType.Dsystem();
        public InitDelmiaDocument()
        {
            InitializeComponent();
        }

        private void SelectInit_Click(object sender, EventArgs e)
        {
            GloalForDelmia GFD = new GloalForDelmia();
            DStype = GFD.InitCatEnv(this);
            if (DStype.Revalue == -1)
            {
                return;
            }
            Selection Uselect = GFD.GetInitTargetProduct(this, DStype);
            try
            {
                Product Usp = (Product)Uselect.Item2(1).Value;
                NewStationInit(Usp);
            }
            catch (Exception)
            {
                throw;
            }
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public void NewResourseInit()
        {
            ProcessDocument DSActiveDocument = DStype.DSActiveDocument;
            PPRDocument PPRD = (PPRDocument)DSActiveDocument.PPRDocument;
            PPRProducts PPRS = (PPRProducts)PPRD.Resources;
            for (int i = 1; i <= PPRS.Count; i++)
            {
                Product PPRProduct = PPRS.Item(i);
                switch (PPRProduct.get_PartNumber())
                {
                    case "Layout":
                        {
                            PPRProduct.Products.AddNewProduct("Layout_2D");
                            PPRProduct.Products.AddNewProduct("Layout_3D");
                            PPRProduct.Products.AddNewProduct("Fence");
                            break;
                        }
                    case "Station":
                        {
                            for (int j =1; j <=Convert.ToInt16(StationNum.Text); j++)
                            {
                                Product NwP=PPRProduct.Products.AddNewComponent("Product", "ST" + j * 10);
                                NwP.set_Revision("V01");//版本号
                                NwP.set_Definition("安徽瑞祥工业自动化产品定义");//产品定义
                                NwP.set_Nomenclature("安徽瑞祥工业自动化产品术语");//产品术语
                                NwP.set_DescriptionInst("安徽瑞祥工业自动化部件描述");//部件描述
                                NwP.set_DescriptionRef("安徽瑞祥工业自动化产品描述");//产品描述
                                NwP.Source = CatProductSource.catProductBought;
                                NewStationInit(NwP);
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            //Product PPRProduct = PPRS.Item("Station.2");
            //Products PPRProducts = PPRProduct.Products;
            //PPRProduct = PPRProducts.Item("ST10.1");
            //PPRProducts = PPRProduct.Products;
            //PPRProduct = PPRProducts.AddNewProduct("01_Fixture");
        }
        public void NewStationInit(Product UserSelectedProduct)
        {
            String Name = UserSelectedProduct.get_PartNumber();
            Product PD=UserSelectedProduct.Products.AddNewProduct(Name + "_Fixture");
            //UserSelectedProduct.Source = CatProductSource.catProductBought;//定义为自制件
            UserSelectedProduct.Products.AddNewProduct(Name + "_Robots");
            UserSelectedProduct.Products.AddNewProduct(Name + "_Gun");
            UserSelectedProduct.Products.AddNewProduct(Name + "_Gripper");
            UserSelectedProduct.Products.AddNewProduct(Name + "_Peripheral");
            UserSelectedProduct.Products.AddNewProduct(Name + "_RobotSlide");
            UserSelectedProduct.Products.AddNewProduct(Name + "_GripperStander");
            UserSelectedProduct.Products.AddNewProduct(Name + "_TagList");
            UserSelectedProduct.Update();
        }
        public void GetDocument()
        {
            FolderBrowserDialog GetDocument = new FolderBrowserDialog();
            string Path = string.Empty;
            GetDocument.Description = "选择仿真存储最高级.CatProcess所在文件夹";
            //GetDocument.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            if (GetDocument.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(GetDocument.SelectedPath))
                {
                    MessageBox.Show("选择的文件夹为空！");
                }
                Path = GetDocument.SelectedPath;
                SavePath.Text = GetDocument.SelectedPath;
            }
            else
            {
                MessageBox.Show("未知错误00A！");
                return;
            }
            return;
        }
        public void InitSimDocument()
        {
            CheckForIllegalCrossThreadCalls = false;
            FolderBrowserDialog GetDocument = new FolderBrowserDialog();
            GetDocument.Description = "选择仿真存储最高级.CatProcess所在文件夹";
            if (GetDocument.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(GetDocument.SelectedPath))
                {
                    MessageBox.Show("选择的文件夹为空！");
                }
                SavePath.Text = GetDocument.SelectedPath;
            }
            else
            {
                MessageBox.Show("未知错误00A！");
                return;
            }
            String MPath = SavePath.Text;
            String CPath = MPath + "//01_SM";
            CreatePath(CPath);
            CPath = MPath + "//02_Layout";
            CreatePath(CPath);
            CreatePath(CPath + "//01_3DLayout");
            CreatePath(CPath + "//02_2DLayout");
            CreatePath(CPath + "//03_Fence");
            CreatePath(CPath + "//04_3DLayout");

            CPath = MPath + "//03_Station";
            CreatePath(CPath);
            for (int i = 1; i <= Convert.ToInt16(StationNum.Text); i++)
            {
                string StationPath = i > 10 ? CPath + "//ST" + i * 10 : CPath + "//ST" + i * 10;
                CreatePath(StationPath);
                CreatePath(StationPath + "//01_Fixture");
                CreatePath(StationPath + "//02_Gripper");
                CreatePath(StationPath + "//03_GripperStander");
                CreatePath(StationPath + "//04_GunStander");
                CreatePath(StationPath + "//05_Buffer");
                CreatePath(StationPath + "//06_ROBOTSLIDE&Stander");
            }
            CPath = MPath + "//04_Resourse";
            CreatePath(CPath);
            CreatePath(CPath + "//01_Robot");
            CreatePath(CPath + "//02_Gun");
            CreatePath(CPath + "//03_ATC");
            CreatePath(CPath + "//04_Dress");
            CreatePath(CPath + "//05_Riser");
            CreatePath(CPath + "//06_Box");
            CreatePath(CPath + "//07_Water unit");
            CreatePath(CPath + "//08_GlueMachine");
        }
        public void CreatePath(string Dpath)
        {
            if (!Directory.Exists(Dpath))//如果不存在就创建 dir 文件夹 
            {
                Directory.CreateDirectory(Dpath);
            }

        }

        private void FolderInit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SavePath.Text))
            {
                string Path = string.Empty;
                System.Threading.Thread importThread = new System.Threading.Thread(new ThreadStart(InitSimDocument));
                importThread.SetApartmentState(ApartmentState.STA); //重点
                importThread.Start();
            }
        }

        private void Fullint_Click(object sender, EventArgs e)
        {
            GloalForDelmia GFD = new GloalForDelmia();
            DStype = GFD.InitCatEnv(this);
            if (DStype.Revalue == -1)
            {
                return;
            }
            NewResourseInit();
        }
    }
}
