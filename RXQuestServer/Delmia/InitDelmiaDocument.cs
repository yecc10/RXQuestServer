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
using MANUFACTURING;

namespace RXQuestServer.Delmia
{
    public partial class InitDelmiaDocument : Form
    {
        DataType.SimulationDir SimulationDir = new DataType.SimulationDir();
        DataType.Dsystem DStype = new DataType.Dsystem();
        /// <summary>
        /// 自动化布局主要区域类型
        /// </summary>
        enum LayoutType { MB, SBL, SBR, FR, RR, UB, ST }
        public InitDelmiaDocument()
        {
            InitializeComponent();
            INITCtrol();
        }
        /// <summary>
        /// 初始化环境
        /// </summary>
        public void INITCtrol()
        {
            this.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
            try
            {
                ModelName.Text = Properties.Settings.Default.ModelName;
                RobotID.Text = Properties.Settings.Default.RobotID;
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
            catch (Exception)
            {
                FolderInit.Enabled = false;
                MessageBox.Show("您可能打开了超过1个Delmia或者打开的Delmia为空文档！请核实！");
                return;
            }
            if (!string.IsNullOrEmpty(SavePath.Text))
            {
                string[] dirst = Directory.GetDirectories(SavePath.Text);//读取文件夹中文件夹数量
                if (dirst.Length > 0)
                {
                    FolderInit.Enabled = false;
                }
                else
                {
                    FolderInit.Enabled = true;
                }
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
            if (Uselect.Count < 1)
            {
                return;
            }
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
        /// <summary>
        /// 创建新Product.CatProduct
        /// </summary>
        /// <param name="PPRProduct">父级</param>
        /// <param name="Name">子名称</param>
        /// <param name="NeedSave">是否需要保存</param>
        /// <returns></returns>
        public Product NewProduct(Product PPRProduct, string Name, bool NeedSave)
        {
            if (CheckRepeatByPartNumber(PPRProduct, Name))
            {
                return null;
            }
            Product NwP = PPRProduct.Products.AddNewProduct(Name);
            SetAttrValue(NwP);
            if (NeedSave)
            {
                NewStationInit(NwP);
                SaveProduct(NwP,null);
            }
            return NwP;
        }
        public Product NewPPRProduct(PPRProducts Product, string Name)
        {
            ProductDocument TeDocument = (ProductDocument)DStype.DSApplication.Documents.Add("Product");
            Product Teproduct = TeDocument.Product;
            SetAttrValue(Teproduct);
            Product.Add(Teproduct);
            TeDocument.Close();
            Product NWResProduct = Product.Item(Product.Count);
            NWResProduct.set_Name(Name);
            NWResProduct.set_PartNumber(Name);
            SaveProduct(NWResProduct,null);
            return NWResProduct;
        }
        /// <summary>
        /// 获取用户需求添加哪些区域
        /// </summary>
        /// <returns>返回用户选择的区域列表</returns>
        public List<string> GetZeroList()
        {
            List<string> ZeroList = new List<string>();
            if (MB.Checked)
            {
                ZeroList.Add("MB");
            }
            if (SBL.Checked)
            {
                ZeroList.Add("SBL");
            }
            if (SBR.Checked)
            {
                ZeroList.Add("SBR");
            }
            if (FR.Checked)
            {
                ZeroList.Add("FR");
            }
            if (RR.Checked)
            {
                ZeroList.Add("RR");
            }
            if (UB.Checked)
            {
                ZeroList.Add("UB");
            }
            if (ST.Checked)
            {
                ZeroList.Add("ST");
            }
            return ZeroList;
        }
        public void NewResourseInit()
        {
            this.TopMost = false;
            List<string> ZeroList = GetZeroList();
            InitSimDocument();
            ProcessDocument DSActiveDocument = DStype.DSActiveDocument;
            PPRDocument PPRD = (PPRDocument)DSActiveDocument.PPRDocument;
            PPRProducts PPRS = (PPRProducts)PPRD.Resources;//读取资源列表
            PPRProducts PPRSM = (PPRProducts)PPRD.Products;//读取产品列表
            var RF = DStype.DSApplication.RefreshDisplay;
            if (PPRSM.Count < 1 || PPRS.Count < 1) //初始化产品数模
            {
                try
                {
                    //String SMPath = Path.GetFullPath("SM.CATProduct");
                    //String StationPath = Path.GetFullPath("Station.CATProduct");
                    //String LayoutPath = Path.GetFullPath("Layout.CATProduct");
                    for (int i = 0; i < ZeroList.Count; i++)
                    {
                        Product PPRSMProduct = NewPPRProduct(PPRSM, ZeroList[i]+"_SM"); //初始化产品数模
                        for (int j = 1; j <= Convert.ToInt16(StationNum.Text); j++)
                        {
                            NewProduct(PPRSMProduct, ZeroList[i] + j * 10 + "_SM", false);
                        }
                        Product CNewProduct = null;
                        if (ZeroList[i] == "ST")
                        {
                            CNewProduct = NewPPRProduct(PPRS, "Station");
                        }
                        else
                        {
                            CNewProduct = NewPPRProduct(PPRS, ZeroList[i]);
                        }
                        for (int j = 1; j <= Convert.ToInt16(StationNum.Text); j++)
                        {
                            String NWTP = ZeroList[i] + j * 10;
                            if (CheckRepeatByPartNumber(CNewProduct, NWTP))
                            {
                                continue;
                            }
                            Product NwP = CNewProduct.Products.AddNewComponent("Product", NWTP);
                            CNewProduct.Update();
                            SetAttrValue(NwP);
                            NewStationInit(NwP);
                            SaveProduct(NwP, ZeroList[i]);
                        }
                    }
                    Product CLayoutProduct=  NewPPRProduct(PPRS, "Layout");
                    if (!CheckRepeatByPartNumber(CLayoutProduct, "Layout_2D"))
                    {
                        NewProduct(CLayoutProduct, "01_Layout_2D", false);
                        NewProduct(CLayoutProduct, "02_Layout_3D", false);
                        NewProduct(CLayoutProduct, "03_Fence", false);
                        NewProduct(CLayoutProduct, "04_Platform", false);
                        NewProduct(CLayoutProduct, "05_Human", false);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("当前环境非标准环境，或解密软件未登陆，无法执行初始化！");
                    //throw;
                }
                // MessageBox.Show("当前环境非标准环境，已执行初始化！");
            }
            MessageBox.Show("初始化完成！");
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
        public Product GetProductByPartNumber(Product FatherList, String PartNumber)
        {
            foreach (Product Pitem in FatherList.Products)
            {
                Pitem.set_Name(Pitem.get_PartNumber());
                string CPartNumber = Pitem.get_PartNumber();
                if (CPartNumber == PartNumber)
                {
                    return Pitem;
                }
            }
            return null;
        }


        /// <summary>
        /// 保存StationProduct 到文件夹
        /// </summary>
        /// <param name="Tproduct">需要保存的Product</param>
        public void SaveProduct(Product Tproduct,String DLayouType)
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
            String SPath = string.Empty;
            String Name = Tproduct.get_PartNumber();
            //String NwProductName = Name + "_Fixture";
            ProductDocument DSPD = (ProductDocument)CatDocuments.Item(Name + ".CATProduct");
            if (DSPD.Saved)
            {
                return;
            }
            //string FN = DSPD.FullName; //读取零件全名称 如果没有保存则为Name+.Product
            //string FP = DSPD.Path;//读取零件所在路径 如果没有保存则为null
            if (!string.IsNullOrEmpty(DLayouType))
            {
                Name = DLayouType;
            }
            switch (Name)
            {
                case "SM":
                    {
                        Path = SimulationDir.SMPath;
                        break;
                    }
                case "Station":
                    {
                        Path = SimulationDir.STPath;
                        break;
                    }
                case "MB":
                    {
                        Path = SimulationDir.MBPath;
                        break;
                    }
                case "SBL":
                    {
                        Path = SimulationDir.SBLPath;
                        break;
                    }
                case "SBR":
                    {
                        Path = SimulationDir.SBRPath;
                        break;
                    }
                case "FR":
                    {
                        Path = SimulationDir.FRPath;
                        break;
                    }
                case "RR":
                    {
                        Path = SimulationDir.RRPath;
                        break;
                    }
                case "UB":
                    {
                        Path = SimulationDir.UBPath;
                        break;
                    }
                case "ST":
                    {
                        Path = SimulationDir.STPath;
                        break;
                    }
                case "Layout":
                    {
                        Path = SimulationDir.LayoutPath;
                        break;
                    }
                default:
                    Path = SimulationDir.SMPath;
                    break;
            }
            if (!string.IsNullOrEmpty(DLayouType))
            {
                Path = Path  + Tproduct.get_PartNumber() + "\\";
            }
            CreatePath(Path);
            Path = Path + Name + ".CATProduct";
            DSPD.SaveAs(Path);
            DStype.DSApplication.DisplayFileAlerts = true; //恢复提示
        }
        public void SetAttrValue(Product Prodt)
        {
            Prodt.set_Revision("V01");//版本号
            Prodt.set_Definition("安徽瑞祥工业自动化产品定义");//产品定义
            Prodt.set_Nomenclature("安徽瑞祥工业自动化产品术语");//产品术语
            Prodt.set_DescriptionInst("安徽瑞祥工业自动化部件描述");//部件描述
            Prodt.set_DescriptionRef("安徽瑞祥工业自动化产品描述,创建于:" + DateTime.Now);//产品描述
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
            if (NSTagGroup.Checked)
            {
                NwTagGroup(PD, Name);
            }
            UserSelectedProduct.Update();
        }
        public void NwTagGroup(Product PD, String Name)
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
        /// <summary>
        /// 创建单个TagGroup
        /// </summary>
        /// <param name="PD">TagGroup Product父级</param>
        /// <param name="Name">TagGroup名称</param>
        public void NwSingleTagGroup(Product PD, String Name)
        {
            Product NPD = null;
            NPD = GetProductByPartNumber(PD, PD.get_PartNumber() + "_TagList");
            if (NPD == null)
            {
                NPD = PD.Products.AddNewProduct(Name + "_TagList");
                SetAttrValue(PD);
            }
            else
            {
                TagGroupFactory TGF = (TagGroupFactory)NPD.GetTechnologicalObject("TagGroupFactory"); //创建TagGroupFactory 工厂
                TagGroup NwTagGroup = null; //创建TagGroup指针
                TGF.CreateTagGroup(Name, true, NPD, out NwTagGroup);//创建TagGroupFactory
            }
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
        /// <summary>
        /// 文件夹初始化
        /// </summary>
        public void InitSimDocument()
        {
            List<string> ZeroList = GetZeroList();
            if (ZeroList.Count < 1)
            {
                MessageBox.Show("当前您未选中任何Layout类型请核实！");
                return;
            }
            FolderBrowserDialog GetDocument = new FolderBrowserDialog();
            if (string.IsNullOrEmpty(SavePath.Text))
            {
                CheckForIllegalCrossThreadCalls = false;
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
                    //return;
                }
            }
            String MPath = SavePath.Text;
            String CPath = MPath + "\\01_SM";
            SimulationDir.SMPath = CPath + "\\";
            CreatePath(CPath);
            CreatePath(CPath + "\\01_Model");
            CreatePath(CPath + "\\02_Model");
            CreatePath(CPath + "\\03_Model");
            CreatePath(CPath + "\\04_Model");
            CPath = MPath + "\\02_Layout";
            SimulationDir.LayoutPath = CPath + "\\";
            CreatePath(CPath);
            CreatePath(CPath + "\\01_3DLayout");
            CreatePath(CPath + "\\02_2DLayout");
            CreatePath(CPath + "\\03_Fence");
            CPath = CPath + "\\04_Platform";//---------平台
            CreatePath(CPath);
            CreatePath(CPath + "\\01_SteelPlatForm"); //钢平台
            CreatePath(CPath + "\\02_RobotPlatForm");//机器人平台
            int StationID = 3;

            for (int i = 0; i < ZeroList.Count; i++)
            {
                switch (ZeroList[i])
                {
                    case "ST":
                        {
                            CPath = MPath + (StationID < 10 ? "\\0" + StationID : "\\" + StationID) + "_Station";
                            SimulationDir.STPath = CPath + "\\";
                            break;
                        }
                    case "MB":
                        {
                            CPath = MPath + (StationID < 10 ? "\\0" + StationID : "\\" + StationID) + "_" + ZeroList[i];
                            SimulationDir.MBPath = CPath + "\\";
                            break;
                        }
                    case "SBR":
                        {
                            CPath = MPath + (StationID < 10 ? "\\0" + StationID : "\\" + StationID) + "_" + ZeroList[i];
                            SimulationDir.SBRPath = CPath + "\\";
                            break;
                        }
                    case "SBL":
                        {
                            CPath = MPath + (StationID < 10 ? "\\0" + StationID : "\\" + StationID) + "_" + ZeroList[i];
                            SimulationDir.SBLPath = CPath + "\\";
                            break;
                        }
                    case "UB":
                        {
                            CPath = MPath + (StationID < 10 ? "\\0" + StationID : "\\" + StationID) + "_" + ZeroList[i];
                            SimulationDir.UBPath = CPath + "\\";
                            break;
                        }
                    case "FR":
                        {
                            CPath = MPath + (StationID < 10 ? "\\0" + StationID : "\\" + StationID) + "_" + ZeroList[i];
                            SimulationDir.FRPath = CPath + "\\";
                            break;
                        }
                    case "RR":
                        {
                            CPath = MPath + (StationID < 10 ? "\\0" + StationID : "\\" + StationID) + "_" + ZeroList[i];
                            SimulationDir.RRPath = CPath + "\\";
                            break;
                        }
                    default:
                        MessageBox.Show("类型错误！请查询initDelmiaDocument.CS源码");
                        break;
                }
                CreatePath(CPath);
                for (int j = 1; j <= Convert.ToInt16(StationNum.Text); j++)
                {
                    string StationPath = j > 10 ? CPath + "//" + ZeroList[i] + j * 10 : CPath + "//" + ZeroList[i] + j * 10;
                    CreatePath(StationPath);
                    CreatePath(StationPath + "//01_Fixture");
                    CreatePath(StationPath + "//02_Gripper");
                    CreatePath(StationPath + "//03_GripperStander");
                    CreatePath(StationPath + "//04_GunStander");
                    CreatePath(StationPath + "//05_Buffer");
                    CreatePath(StationPath + "//06_ROBOTSLIDE&Stander");
                }
                StationID += 1;
            }
            CPath = MPath + (StationID < 10 ? "//0" + StationID : "//" + StationID) + "_Resourse";
            CreatePath(CPath);
            CreatePath(CPath + "//01_Robot");
            CreatePath(CPath + "//02_RobotBase");
            CreatePath(CPath + "//03_Gun");
            CreatePath(CPath + "//04_ATC");
            CreatePath(CPath + "//05_Dress");
            CreatePath(CPath + "//06_Riser");
            CreatePath(CPath + "//07_Box");
            CreatePath(CPath + "//08_Water unit");
            CreatePath(CPath + "//09_GlueMachine");
            CreatePath(CPath + "//10_Vin");
            CreatePath(CPath + "//11_WaterUnit");
            CreatePath(CPath + "//12_APC");
        }
        public void CreatePath(string Dpath)
        {
            if (!Directory.Exists(Dpath))//如果不存在就创建 dir 文件夹 
            {
                Directory.CreateDirectory(Dpath);
            }

        }

        /// <summary>
        /// 文件夹初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderInit_Click(object sender, EventArgs e)
        {
            string Path = string.Empty;
            System.Threading.Thread importThread = new System.Threading.Thread(new ThreadStart(InitSimDocument));
            importThread.SetApartmentState(ApartmentState.STA); //重点
            importThread.Start();
        }

        private void Fullint_Click(object sender, EventArgs e)
        {
            ProcessDocument DSActiveDocument = DStype.DSActiveDocument;
            PPRDocument PPRD = (PPRDocument)DSActiveDocument.PPRDocument;
            PPRProducts PPRS = (PPRProducts)PPRD.Resources;//读取资源列表
            if (PPRS.Count>0)
            {
                MessageBox.Show("当前仿真文档已被初始化，无法重新执行初始化!");
                Fullint.Enabled = false;
                return;
            }
            CheckForIllegalCrossThreadCalls = false;
            if (string.IsNullOrEmpty(SavePath.Text))
            {
                MessageBox.Show("请设置工作目录或保存Process后重试,请勿向默认Process中添加任何元素！");
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
        }

        private void InitDelmiaDocument_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            System.Environment.Exit(0);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Text = "InitDelmiaDocument_本技术由瑞祥工业数字化_叶朝成提供|SystemTime:" + DateTime.Now;
            if (!string.IsNullOrEmpty(SavePath.Text))
            {
                string[] dirst = Directory.GetDirectories(SavePath.Text);//读取文件夹中文件夹数量
                if (dirst.Length > 0)
                {
                    FolderInit.Enabled = false;
                }
                else
                {
                    FolderInit.Enabled = true;
                }
            }
        }

        private void InitRobot_Click(object sender, EventArgs e)
        {
            GloalForDelmia GFD = new GloalForDelmia();
            DStype = GFD.InitCatEnv(this);
            if (DStype.Revalue == -1)
            {
                return;
            }
            Selection Uselect = GFD.GetIRobotMotion(this, DStype);
            if (Uselect != null && Uselect.Count > 0)
            {
                try
                {
                    String GetName = string.Empty;
                    Product Usp = (Product)Uselect.Item2(1).Value;
                    GetName = Usp.get_Name();
                    RobGenericController Rgcr = (RobGenericController)Usp.GetTechnologicalObject("RobGenericController");
                    RobControllerFactory CRM = (RobControllerFactory)Usp.GetTechnologicalObject("RobControllerFactory");
                    GetName = CRM.get_Name();
                    for (int i = 1; i <= Convert.ToInt16(RobotCtrlNum.Text); i++)
                    {
                        GenericAccuracyProfile GP;
                        GenericMotionProfile GMP;
                        GenericToolProfile GTP;
                        GenericObjFrameProfile GOP;
                        bool ExistsObject;
                        CRM.CreateGenericAccuracyProfile(out GP);
                        GP.GetName(ref GetName);
                        GetName = CRM.get_Name();
                        GP.SetAccuracyValue(i * 0.1);
                        GP.SetName(i * 10 + "%");
                        GP.SetAccuracyType(AccuracyType.ACCURACY_TYPE_SPEED);
                        GP.SetFlyByMode(false);
                        Rgcr.HasAccuracyProfile((i * 10 + "%"), out ExistsObject);
                        if (!ExistsObject)
                        {
                            Rgcr.AddAccuracyProfile(GP);
                        }

                        CRM.CreateGenericObjFrameProfile(out GOP);
                        GOP.SetObjectFrame(0, 0, 0, 0, 0, 0);
                        GOP.SetName("Object_0" + i);
                        Rgcr.HasObjFrameProfile(("Object_0" + i), out ExistsObject);
                        if (!ExistsObject)
                        {
                            Rgcr.AddObjFrameProfile(GOP);
                        }
                        CRM.CreateGenericMotionProfile(out GMP);
                        GMP.SetSpeedValue(i * 0.1);
                        GMP.SetName(i * 10 + "%");
                        GMP.SetMotionBasis(MotionBasis.MOTION_PERCENT);
                        Rgcr.HasMotionProfile((i * 10 + "%"), out ExistsObject);
                        if (!ExistsObject)
                        {
                            Rgcr.AddMotionProfile(GMP);
                        }

                        // NwName = i < 9 ? ("Tool_0" + i) : ("Tool_" + i);
                        string NwName = "Tool_0" + i;
                        Rgcr.HasToolProfile(NwName, out ExistsObject);
                        if (!ExistsObject)
                        {
                            try
                            {
                                int ToolNum = 0;
                                Rgcr.GetToolProfileCount(out ToolNum);
                                string Ctname = string.Empty;
                                if (ToolNum < 16)
                                {
                                    CRM.CreateGenericToolProfile(out GTP);
                                    Rgcr.AddToolProfile(GTP);
                                    //Object[] ToolLists = new object[ToolNum];
                                    //Rgcr.GetToolProfiles(ToolLists);
                                    //for (int j = 1; j <= ToolNum; j++)
                                    //{
                                    //    Ctname = ((GenericToolProfile)ToolLists[i]).get_Name();
                                    //    ((GenericToolProfile)ToolLists[i]).set_Name(NwName);
                                    //}
                                    //GTP.GetName(Ctname);
                                    //GTP.SetToolMobility(true);
                                    //GTP.set_Name(NwName);
                                }
                            }
                            catch (Exception)
                            {
                                throw;
                            }

                            //Object[] TooList = new object[99];
                            //Rgcr.GetToolProfiles(TooList);
                            //int TotalTool;
                            //Rgcr.GetToolProfileCount(out TotalTool);
                            //GenericToolProfile ToolProfile =(GenericToolProfile)TooList[TotalTool-1];
                            //NwName = ToolProfile.get_Name();
                            //ToolProfile.set_Name(NwName);
                        }

                    }
                    RobotTaskFactory Rtf = (RobotTaskFactory)Usp.GetTechnologicalObject("RobotTaskFactory");
                    object[] RobotTaskLists = new object[99];
                    try
                    {
                        Rtf.GetAllRobotTasks(RobotTaskLists);
                    }
                    catch (Exception)
                    {
                        RobotTaskLists = null;
                    }
                    GetName = Rtf.get_Name();
                    if (GPWeld.Checked)
                    {
                        String RobotTaskName = ((Product)((Product)Usp.Parent).Parent).get_PartNumber() + "_" + RobotID.Text.ToUpper() + "_" + ModelName.Text.ToUpper() + "_GP" + "_" + ELEID.Text;
                        if (!CheckTaskExists(RobotTaskLists, RobotTaskName))
                        {
                            Rtf.CreateRobotTask(RobotTaskName, null);
                            NwSingleTagGroup(((Product)((Product)Usp.Parent).Parent), RobotTaskName);
                        }
                        if (GunStand.Checked)
                        {
                            RobotTaskName = ((Product)((Product)Usp.Parent).Parent).get_PartNumber() + "_" + RobotID.Text.ToUpper() + "_GUN" + "_" + ELEID.Text + "_PickAndPlace";
                            if (!CheckTaskExists(RobotTaskLists, RobotTaskName))
                            {
                                Rtf.CreateRobotTask(RobotTaskName, null);
                                NwSingleTagGroup(((Product)((Product)Usp.Parent).Parent), RobotTaskName);
                            }
                        }
                    }
                    if (RPWeld.Checked)
                    {
                        String RobotTaskName = ((Product)((Product)Usp.Parent).Parent).get_PartNumber() + "_" + RobotID.Text.ToUpper() + "_" + ModelName.Text.ToUpper() + "_RP" + "_" + ELEID.Text;
                        if (!CheckTaskExists(RobotTaskLists, RobotTaskName))
                        {
                            Rtf.CreateRobotTask(RobotTaskName, null);
                            NwSingleTagGroup(((Product)((Product)Usp.Parent).Parent), RobotTaskName);
                        }

                    }
                    if (Glue.Checked)
                    {
                        String RobotTaskName = ((Product)((Product)Usp.Parent).Parent).get_PartNumber() + "_" + RobotID.Text.ToUpper() + "_" + ModelName.Text.ToUpper() + "_Glue" + "_" + ELEID.Text;
                        if (!CheckTaskExists(RobotTaskLists, RobotTaskName))
                        {
                            Rtf.CreateRobotTask(RobotTaskName, null);
                            NwSingleTagGroup(((Product)((Product)Usp.Parent).Parent), RobotTaskName);
                        }

                    }
                    if (PickAndUp.Checked)
                    {
                        String RobotTaskName = ((Product)((Product)Usp.Parent).Parent).get_PartNumber() + "_" + RobotID.Text.ToUpper() + "_" + ModelName.Text.ToUpper() + "_Gripper" + "_" + ELEID.Text;
                        if (!CheckTaskExists(RobotTaskLists, RobotTaskName))
                        {
                            Rtf.CreateRobotTask(RobotTaskName, null);
                            NwSingleTagGroup(((Product)((Product)Usp.Parent).Parent), RobotTaskName);
                        }
                        if (GrpStand.Checked)
                        {
                            RobotTaskName = ((Product)((Product)Usp.Parent).Parent).get_PartNumber() + "_" + RobotID.Text.ToUpper() + "_Grip" + "_" + ELEID.Text + "_Pick&Drop";
                            if (!CheckTaskExists(RobotTaskLists, RobotTaskName))
                            {
                                Rtf.CreateRobotTask(RobotTaskName, null);
                                NwSingleTagGroup(((Product)((Product)Usp.Parent).Parent), RobotTaskName);
                            }
                        }
                    }
                    if (StudWeld.Checked)
                    {
                        String RobotTaskName = ((Product)((Product)Usp.Parent).Parent).get_PartNumber() + "_" + RobotID.Text.ToUpper() + "_" + ModelName.Text.ToUpper() + "_Stud" + "_" + ELEID.Text;
                        if (!CheckTaskExists(RobotTaskLists, RobotTaskName))
                        {
                            Rtf.CreateRobotTask(RobotTaskName, null);
                            NwSingleTagGroup(((Product)((Product)Usp.Parent).Parent), RobotTaskName);
                        }

                    }
                    object[] RTask = new object[50];
                    Rtf.GetAllRobotTasks(RTask);
                    foreach (RobotTask item in RTask)
                    {
                        if (item != null)
                        {
                            item.set_Description("安徽瑞祥工业自动化产品，机器人轨迹,创建于:" + DateTime.Now);
                        }
                    }
                    //DeviceTaskFactory DTF= (DeviceTaskFactory)Usp.GetTechnologicalObject("DeviceTaskFactory");
                    //DeviceTask DT=null;
                    //DTF.CreateDeviceTask("YECCNewTask",ref DT);
                    Usp.Update();
                }
                catch (Exception)
                {
                    //throw;
                    MessageBox.Show("您选择的不是一个运动机构！");
                }
            }
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
        }
        /// <summary>
        /// 检查机器人程序是否重复
        /// </summary>
        /// <param name="RobotTaskList">机器人程序集</param>
        /// <param name="CheckedName">检查是否存在的程序名称</param>
        /// <returns></returns>
        private bool CheckTaskExists(Object[] RobotTaskList, string CheckedName)
        {
            if (RobotTaskList == null)
            {
                return false;
            }
            foreach (RobotTask item in RobotTaskList)
            {
                if (item != null)
                {
                    String taskName = item.get_Name();
                    if (taskName == CheckedName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void ModelName_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ModelName = ModelName.Text;
            Properties.Settings.Default.Save();
        }

        private void RobotID_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RobotID = RobotID.Text; ;
            Properties.Settings.Default.Save();
        }

        private void ELEADD_Click(object sender, EventArgs e)
        {
            int CV = Convert.ToInt16(ELEID.Text);
            CV += 1;
            CV = CV < 1 ? 1 : CV;
            String TV = CV < 10 ? (0 + CV.ToString()) : CV.ToString();
            ELEID.Text = TV;
        }

        private void ELEREMOVE_Click(object sender, EventArgs e)
        {
            int CV = Convert.ToInt16(ELEID.Text);
            CV -= 1;
            CV = CV < 1 ? 1 : CV;
            String TV = CV < 10 ? (0 + CV.ToString()) : CV.ToString();
            ELEID.Text = TV;
        }

        private void ManuleInit_Click(object sender, EventArgs e)
        {
            INITCtrol();
        }
    }
}
