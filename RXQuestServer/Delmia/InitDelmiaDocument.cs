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
using DNBDevice;
using DNBRobot;
using DNBIgpTagPath;

namespace RXQuestServer.Delmia
{
    public partial class InitDelmiaDocument : Form
    {
        DataType.Dsystem DStype = new DataType.Dsystem();
        public InitDelmiaDocument()
        {
            InitializeComponent();
            timer.Enabled = true;
            GloalForDelmia GFD = new GloalForDelmia();
            DStype = GFD.InitCatEnv(this);
            if (DStype.Revalue == -1)
            {
                MessageBox.Show("未检测到已打开的Delmia 自动读取目录失败，请先打开软件后手动选择目录！");
            }
            else
            {
                SavePath.Text = DStype.DSActiveDocument.Path;
            }
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
        public void NewProduct(Product PPRProduct,string Name,bool NeedSave)
        {
            if (CheckRepeatByPartNumber(PPRProduct, Name))
            {
                return;
            }
            Product NwP = PPRProduct.Products.AddNewProduct(Name);
            SetAttrValue(NwP);
            if (NeedSave)
            {
                NewStationInit(NwP);
                SaveProduct(NwP);
            }
        }
        public void NewResourseInit()
        {
            ProcessDocument DSActiveDocument = DStype.DSActiveDocument;
            PPRDocument PPRD = (PPRDocument)DSActiveDocument.PPRDocument;
            PPRProducts PPRS = (PPRProducts)PPRD.Resources;//读取资源列表
            PPRProducts PPRSM = (PPRProducts)PPRD.Products;//读取产品列表
            var RF=DStype.DSApplication.RefreshDisplay;
            if (PPRSM.Count>0) //初始化产品数模
            {
                Product PPRProduct = PPRSM.Item(1);
                for (int i = 1; i <=Convert.ToInt16(StationNum.Text); i++)
                {
                    NewProduct(PPRProduct, "ST" + i * 10,false);
                }
            }
            for (int i = 1; i <= PPRS.Count; i++) //初始化资源列表
            {
                Product PPRProduct = PPRS.Item(i);
                switch (PPRProduct.get_PartNumber())
                {
                    case "Layout":
                        {
                            if (CheckRepeatByPartNumber(PPRProduct, "Layout_2D"))
                            {
                                continue;
                            }
                            NewProduct(PPRProduct, "01_Layout_2D",false);
                            NewProduct(PPRProduct, "02_Layout_3D", false);
                            NewProduct(PPRProduct, "03_Fence", false);
                            NewProduct(PPRProduct, "04_Platform", false);
                            break;
                        }
                    case "Station":
                        {
                            for (int j = 1; j <= Convert.ToInt16(StationNum.Text); j++)
                            {
                                String NWTP = "ST" + j * 10;
                                if (CheckRepeatByPartNumber(PPRProduct, NWTP))
                                {
                                    continue;
                                }
                                Product NwP = PPRProduct.Products.AddNewComponent("Product", NWTP);
                                PPRProduct.Update();
                                SetAttrValue(NwP);
                                NewStationInit(NwP);
                                SaveProduct(NwP);
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 查询选定的Product中是否存在指定的对象
        /// </summary>
        /// <param name="FatherList">被查询Product最高级</param>
        /// <param name="Name">被查询对象</param>
        /// <returns></returns>
        public bool CheckRepeatByName(Product FatherList, String Name)
        {
            ProcessDocument DSActiveDocument = DStype.DSActiveDocument;
            Selection CheckProduct = DSActiveDocument.Selection;
            CheckProduct.Clear();
            CheckProduct.Add(FatherList);
            string Sc = "Name =" + Name + ",all";
            CheckProduct.Search(Sc);
            if (CheckProduct.Count > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 查询选定的Product中是否存在指定的对象
        /// </summary>
        /// <param name="FatherList">被查询Product最高级</param>
        /// <param name="PartNumber">被查询对象</param>
        /// <returns></returns>
        public bool CheckRepeatByPartNumber(Product FatherList, String PartNumber)
        {
            foreach (Product Pitem in FatherList.Products)
            {
                Pitem.set_Name(Pitem.get_PartNumber());
                string CPartNumber = Pitem.get_PartNumber();
                if (CPartNumber == PartNumber)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 保存Product 到文件夹
        /// </summary>
        /// <param name="Tproduct">需要保存的Product</param>
        public void SaveProduct(Product Tproduct)
        {
            if (DStype.DSActiveDocument == null)
            {
                GloalForDelmia GFD = new GloalForDelmia();
                DStype = GFD.InitCatEnv(this);
                if (DStype.Revalue == -1)
                {
                    return;
                }
            }
            DStype.DSApplication.DisplayFileAlerts = false; //关闭提示
            Documents CatDocuments = DStype.DSDocument;
            String Path = string.Empty;
            String Name = Tproduct.get_PartNumber();
            //String NwProductName = Name + "_Fixture";
            ProductDocument DSPD = (ProductDocument)CatDocuments.Item(Name + ".CATProduct");
            if (DSPD.Saved)
            {
                return;
            }
            //string FN = DSPD.FullName; //读取零件全名称 如果没有保存则为Name+.Product
            //string FP = DSPD.Path;//读取零件所在路径 如果没有保存则为null
            Path = SavePath.Text + "\\03_Station" + "\\" + Name+"\\";
            CreatePath(Path);
            Path= Path+ Name + ".CATProduct";
            DSPD.SaveAs(Path);
            DStype.DSApplication.DisplayFileAlerts = true; //恢复提示
        }
        public void SetAttrValue(Product Prodt)
        {
            Prodt.set_Revision("V01");//版本号
            Prodt.set_Definition("安徽瑞祥工业自动化产品定义");//产品定义
            Prodt.set_Nomenclature("安徽瑞祥工业自动化产品术语");//产品术语
            Prodt.set_DescriptionInst("安徽瑞祥工业自动化部件描述");//部件描述
            Prodt.set_DescriptionRef("安徽瑞祥工业自动化产品描述,创建于:"+DateTime.Now);//产品描述
            Prodt.Source = CatProductSource.catProductMade;//默认自制
            Prodt.Update();
            string PartNumber = Prodt.get_PartNumber();
            Prodt.set_Name(PartNumber);
            //Prodt.set_PartNumber(Prodt.get_Name());
        }
        public void NewStationInit(Product UserSelectedProduct)
        {
            String Name = UserSelectedProduct.get_PartNumber();
            Product PD = UserSelectedProduct.Products.AddNewProduct(Name + "_Fixture");
            SetAttrValue(PD);
            PD = UserSelectedProduct.Products.AddNewProduct(Name + "_Robots");
            SetAttrValue(PD);
            PD = UserSelectedProduct.Products.AddNewProduct(Name + "_Gun");
            SetAttrValue(PD);
            PD = UserSelectedProduct.Products.AddNewProduct(Name + "_Gripper");
            SetAttrValue(PD);
            PD = UserSelectedProduct.Products.AddNewProduct(Name + "_Peripheral");
            SetAttrValue(PD);
            PD = UserSelectedProduct.Products.AddNewProduct(Name + "_RobotSlide");
            SetAttrValue(PD);
            PD = UserSelectedProduct.Products.AddNewProduct(Name + "_GripperStander");
            SetAttrValue(PD);
            PD = UserSelectedProduct.Products.AddNewProduct(Name + "_TagList");
            SetAttrValue(PD);
            NwTagGroup(PD, Name);
            UserSelectedProduct.Update();
        }
        public void NwTagGroup(Product PD,String Name)
        {
            TagGroupFactory TGF = (TagGroupFactory)PD.GetTechnologicalObject("TagGroupFactory"); //创建TagGroupFactory 工厂
            TagGroup NwTagGroup = null; //创建TagGroup指针
            TGF.CreateTagGroup(Name + "_R1_01", true, PD, out NwTagGroup);//创建TagGroupFactory
            TGF.CreateTagGroup(Name + "_R1_02", true, PD, out NwTagGroup);//创建TagGroupFactory
            TGF.CreateTagGroup(Name + "_R2_01", true, PD, out NwTagGroup);//创建TagGroupFactory
            TGF.CreateTagGroup(Name + "_R2_02", true, PD, out NwTagGroup);//创建TagGroupFactory
            TGF.CreateTagGroup(Name + "_R3_01", true, PD, out NwTagGroup);//创建TagGroupFactory
            TGF.CreateTagGroup(Name + "_R3_02", true, PD, out NwTagGroup);//创建TagGroupFactory
            TGF.CreateTagGroup(Name + "_R4_01", true, PD, out NwTagGroup);//创建TagGroupFactory
            TGF.CreateTagGroup(Name + "_R4_02", true, PD, out NwTagGroup);//创建TagGroupFactory
            TGF.CreateTagGroup(Name + "_R5_01", true, PD, out NwTagGroup);//创建TagGroupFactory
            TGF.CreateTagGroup(Name + "_R5_02", true, PD, out NwTagGroup);//创建TagGroupFactory
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
            if (string.IsNullOrEmpty(SavePath.Text))
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
            }
            String MPath = SavePath.Text;
            String CPath = MPath + "//01_SM";
            CreatePath(CPath);
            CPath = MPath + "//02_Layout";
            CreatePath(CPath);
            CreatePath(CPath + "//01_3DLayout");
            CreatePath(CPath + "//02_2DLayout");
            CreatePath(CPath + "//03_Fence");
            CreatePath(CPath + "//04_Platform");

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

            string Path = string.Empty;
            System.Threading.Thread importThread = new System.Threading.Thread(new ThreadStart(InitSimDocument));
            importThread.SetApartmentState(ApartmentState.STA); //重点
            importThread.Start();

        }

        private void Fullint_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            if (string.IsNullOrEmpty(SavePath.Text))
            {
                MessageBox.Show("请设置工作目录后重试！");
                System.Threading.Thread importThread = new System.Threading.Thread(new ThreadStart(GetDocument));
                importThread.SetApartmentState(ApartmentState.STA); //重点
                importThread.Start();
                return;
            }
            GloalForDelmia GFD = new GloalForDelmia();
            DStype = GFD.InitCatEnv(this);
            if (DStype.Revalue == -1)
            {
                return;
            }
            NewResourseInit();
            MessageBox.Show("初始化完成！");
        }

        private void InitDelmiaDocument_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            System.Environment.Exit(0);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Text = "InitDelmiaDocument_本技术由瑞祥工业数字化_叶朝成提供|SystemTime:"+DateTime.Now;
        }
    }
}
