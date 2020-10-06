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
using YeccAutoCenter;
using CATSchematicTypeLib;

namespace YeDassaultSystemDev
{
    public partial class CatiaQuickTool : Form
    {
        INFITF.Application CatApplication;
        ProductDocument CatDocument;
        System.Data.DataTable datatable = new System.Data.DataTable();
        System.Data.DataColumn dataColum;
        DataRow DataRow;
        DataView dataview;
        Part PartID;
        AnyObject[] GetRepeatRef = new AnyObject[99];
        CATIA_Class CATIA_Class = new CATIA_Class();
        int RepeatNum = 0;
        /// <summary>
        /// Value=1->Read Point;Value=2->AnyPoint
        /// </summary>
        int ReadType = 0;
        public CatiaQuickTool()
        {
            InitializeComponent();
            timer.Enabled = true;
            InitDataTable();
            CATIA_Class.InitCatEnv(ref CatApplication, ref CatDocument, ref PartID, this);
        }
        private void TryRead_Click(object sender, EventArgs e)
        {
            //RXQuestServer.Main CM = new RXQuestServer.Main();
            //this.Hide();
            //CM.Show();
        }
        private void CatiaQuickTool_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        private void OutToEXcel_Click(object sender, EventArgs e)
        {
            RxDataOprator.ExcelOprator.SaveExcelForLvSport(this.DataGrid, "Cad路径坐标值");
        }
        private void BollToPoint_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            ReadType = 2;
            Selection SelectArc = null;
            CATIA_Class.GetSelect(CatDocument, ref SelectArc, this);
            if (SelectArc == null || SelectArc.Count2 == 0)
            {
                return;
            }
            int ERR = 0;
            object[] PointCoord = new object[] { -99, -99, -99 };
            for (int i = 1; i <= SelectArc.Count2; i++)
            {
                HybridShapeFactory PartHyb = (HybridShapeFactory)PartID.HybridShapeFactory;
                SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatDocument.GetWorkbench("SPAWorkbench");
                Reference referenceObject = SelectArc.Item(i).Reference;
                Measurable TheMeasurable = TheSPAWorkbench.GetMeasurable(referenceObject);
                TheMeasurable.GetPoint(PointCoord); //读取选择的曲面坐标
                var TName = referenceObject.get_Name(); //读取选择的曲面名称
                HybridShapePointCoord NewPoint = PartHyb.AddNewPointCoord(Convert.ToDouble(PointCoord[0]), Convert.ToDouble(PointCoord[1]), Convert.ToDouble(PointCoord[2]));
                if (KeepName.Checked)
                {
                    NewPoint.set_Name(TName);
                }
                else
                {
                    NewPoint.set_Name("Rx_" + i);
                }
                HybridBodies Hybs = PartID.HybridBodies;
                HybridBody Hyb = null;
                try
                {
                    Hyb = Hybs.Item("几何图形集.1");
                }
                catch (Exception)
                {
                    Hyb = Hybs.Item("Geometrical Set.1");
                }
                Hyb.AppendHybridShape(NewPoint);
                PartID.InWorkObject = NewPoint;
                try
                {
                    PartID.Update();
                }
                catch (Exception)
                {
                    ERR += 1;
                }
            }
            if (ERR > 0)
            {
                MessageBox.Show("共计:" + ERR + "个点创建新参考点失败！");
            }
        }
        /// <summary>
        /// 记录重复对象并将坐标保存到主视图DataGrid中
        /// </summary>
        /// <param name="Name">元素名称</param>
        /// <param name="PointData">点坐标</param>
        /// <param name="RefObj">操作对象</param>
        /// <param name="IgRepeat">是否过滤重复数据</param>
        /// <returns></returns>
        private bool WriteObjectToDataGrid(string Name, object[] PointData, Reference RefObj, bool IgRepeat)
        {
            try
            {
                double[] xyz = new double[3];
                int keepValuePoint = Convert.ToInt16(2);
                if (!datatable.IsInitialized)
                {
                    datatable.Reset();
                }
                DataRow = datatable.NewRow();
                datatable.Rows.Add(DataRow);
                xyz[0] = Math.Round(Convert.ToDouble(PointData[0]), keepValuePoint);
                xyz[1] = Math.Round(Convert.ToDouble(PointData[1]), keepValuePoint);
                xyz[2] = Math.Round(Convert.ToDouble(PointData[2]), keepValuePoint);
                if (RxDataOprator.DoRepeatCheck(xyz, datatable))//True 为重复值
                {
                    GetRepeatRef.SetValue(RefObj, RepeatNum);//记录重复对象
                    RepeatNum += 1;
                    if (IgRepeat)
                    {
                        return true;
                    }
                }
                DataRow["序号"] = datatable.Rows.Count;
                DataRow["名称"] = Name;//Convert.ToDouble(PointCoord[0]), Convert.ToDouble(PointData[1]), Convert.ToDouble(PointData[2])
                DataRow["X坐标"] = xyz[0];
                DataRow["Y坐标"] = xyz[1];
                DataRow["Z坐标"] = xyz[2];
                DataRow["RX"] = Math.Round(Convert.ToDouble(PointData[3]), keepValuePoint);
                DataRow["RY"] = Math.Round(Convert.ToDouble(PointData[4]), keepValuePoint);
                DataRow["RZ"] = Math.Round(Convert.ToDouble(PointData[5]), keepValuePoint);
                datatable.Rows.Add(DataRow);
                //dataview = new DataView(datatable);
                return true;
            }
            catch (System.Exception)
            {
                //throw;
                return false;
            }
        }
        private void ReadCoord_Click(object sender, EventArgs e)
        {
            if (datatable.Columns.Count < 1)
            {
                InitDataTable();
            }
            this.WindowState = FormWindowState.Minimized;
            RepeatNum = 0;
            Array.Clear(GetRepeatRef, 0, GetRepeatRef.Length);
            ReadType = 2;
            Selection SelectArc = null;
            CATIA_Class.GetSelect(CatDocument, ref SelectArc, this);
            if (SelectArc == null || SelectArc.Count2 == 0)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.TopMost = true;
                return;
            }
            int ERR = 0;
            for (int i = 1; i < SelectArc.Count2 + 1; i++)
            {
                object[] PointCoord = new object[] { -99, -99, -99, -99, -99, -99 };
                HybridShapeFactory PartHyb = (HybridShapeFactory)PartID.HybridShapeFactory;
                SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatDocument.GetWorkbench("SPAWorkbench");
                Reference referenceObject;
                String ObjType = SelectArc.Item(i).Type;
                Boolean LeafProductProcessed;
                string TName = string.Empty; 
                switch (ObjType)
                {
                    case "HybridShape":
                        {
                            referenceObject = SelectArc.Item(i).Reference;//!=null? SelectArc.Item(i).Reference: Temp;
                            TName = referenceObject.get_Name(); //读取选择的曲面名称
                            break;
                        }
                    case "Shape":
                        {
                            string Name = string.Empty;
                            Shape shape = (Shape)SelectArc.Item(i).Value;
                            Product product = (Product)SelectArc.Item(i).LeafProduct;
                            TName = product.get_PartNumber(); //读取选择的曲面名称
                            String RefStr = product.GetMasterShapeRepresentationPathName(); //获取零件路径地址
                            string[] RefStrArry = RefStr.Split('\\');
                            if (RefStrArry.Length>1)
                            {
                                RefStr = RefStrArry.Last();
                            }
                            Part RefPart = ((PartDocument)CatApplication.Documents.Item(RefStr)).Part;//通过总文档将当前零件转换成PartDocumet
                            try
                            {
                                referenceObject = RefPart.CreateReferenceFromObject(shape);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("请确认当前是否打开了多个窗口，软件识别的零件和您选择的零件不在一个集合!");
                                return;
                            }
                            break;
                        }
                    default:
                        {
                            AnyObject Feature = (AnyObject)SelectArc.Item(i).Value;
                            try
                            {
                                String Name = string.Empty;
                                Shape GE = (Shape)SelectArc.Item(i).Value;
                                //Name = GE.get_Name();
                                //Pad Spad = (Pad)GE.GetItem("Face1");
                                //Name = Spad.get_Name();
                                referenceObject = PartID.CreateReferenceFromObject(Feature);
                                PartHyb.AddNewPointCenter(referenceObject);
                            }
                            catch (Exception)
                            {
                                ERR += 1;
                                var LeafProduct = SelectArc.Item(i).LeafProduct;
                                LeafProductProcessed = true;
                                if (LeafProduct.get_Name() == "InvalidLeafProduct")
                                {
                                    LeafProductProcessed = false;
                                }
                                if (LeafProductProcessed)
                                {
                                    String ShapeName = Feature.get_Name();
                                    VisPropertySet VPS = SelectArc.VisProperties;
                                    VPS.SetVisibleColor(255, 0, 0, 0);
                                    continue;
                                }
                                else
                                {
                                    String ShapeName = Feature.get_Name();
                                    VisPropertySet VPS = SelectArc.VisProperties;
                                    VPS.SetVisibleColor(255, 0, 0, 0);
                                    continue;
                                }
                            }
                        }
                        break;
                }
                Measurable TheMeasurable = TheSPAWorkbench.GetMeasurable(referenceObject);
                try
                {
                    TheMeasurable.GetPoint(PointCoord); //读取选择的曲面坐标
                }
                catch (Exception)
                {
                    try
                    {
                        TheMeasurable.GetCOG(PointCoord);
                    }
                    catch (Exception)
                    {
                        ERR += 1;
                    }
                }
                if (!KeepName.Checked)
                {
                    TName = "Rx_" + (datatable.Rows.Count + 1);
                }
                WriteObjectToDataGrid(TName, PointCoord, referenceObject, IgRepeat.Checked); //记录数据到DataGridView
            }
            SetDataGrid();
            if (ERR > 0)
            {
                MessageBox.Show("共计:" + ERR + "个点创建新参考点失败！");
            }
            if (RepeatCheck.Checked)
            {
                CheckRepeat(SelectArc);
            }
            DataGrid.AllowUserToAddRows = false;
        }
        private void CheckRepeat(Selection SelectArc)
        {
            if (RepeatNum > 0)
            {
                VisPropertySet VPS = SelectArc.VisProperties;
                SelectArc.Clear();
                foreach (var item in GetRepeatRef)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    SelectArc.Add(item);
                }
                VPS.SetRealColor(255, 0, 128, 0);
                MessageBox.Show("当前选择的对象集中存在: " + RepeatNum + "个重复数据!并已为你进行颜色标记!");
                RepeatNum = 0;
                Array.Clear(GetRepeatRef, 0, GetRepeatRef.Length);
            }
        }
        private void ClearAllData_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
            if (DataGrid.DataSource != null)
            {
                datatable.Clear();
            }
            else
            {
                DataGrid.Rows.Clear();
            }
            DataGrid.ScrollBars = ScrollBars.Vertical;
            DataGrid.AllowUserToAddRows = true;
            DataGrid.Update();
            this.TopMost = true;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            this.FindForm().Text = "瑞祥快捷设计中心 BY_安徽瑞祥工业【工厂仿真组】叶朝成_当前时间: " + DateTime.Now.ToString();
        }
        private void PointToCoord_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            RepeatNum = 0;
            Array.Clear(GetRepeatRef, 0, GetRepeatRef.Length);
            ReadType = 1;
            Selection SelectArc = null;
            CATIA_Class.GetSelect(CatDocument, ref SelectArc, this);
            if (SelectArc == null || SelectArc.Count2 == 0)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.TopMost = true;
                return;
            }
            int ERR = 0;
            object[] PointCoord = new object[] { -99, -99, -99, -99, -99, -99 };
            for (int i = 1; i <= SelectArc.Count2; i++)
            {
                HybridShapeFactory PartHyb = (HybridShapeFactory)PartID.HybridShapeFactory;
                SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatDocument.GetWorkbench("SPAWorkbench");
                Reference referenceObject = SelectArc.Item(i).Reference;
                Measurable TheMeasurable = TheSPAWorkbench.GetMeasurable(referenceObject);
                TheMeasurable.GetPoint(PointCoord); //读取选择的曲面坐标
                var TName = referenceObject.get_Name(); //读取选择的曲面名称
                if (!KeepName.Checked)
                {
                    TName = "Rx_" + (datatable.Rows.Count + 1);
                }
                WriteObjectToDataGrid(TName, PointCoord, referenceObject, IgRepeat.Checked);
            }
            SetDataGrid();
            if (ERR > 0)
            {
                MessageBox.Show("共计:" + ERR + "个点创建新参考点失败！");
            }
            if (RepeatCheck.Checked)
            {
                CheckRepeat(SelectArc);
            }
        }
        [STAThread]
        private void Aix_To_Ball_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            ReadAixPoint.BackColor = SystemColors.ActiveCaption;
            System.Threading.Thread importThread = new System.Threading.Thread(new ThreadStart(xlsPath));
            importThread.SetApartmentState(ApartmentState.STA); //重点
            importThread.Start();
        }
        public void xlsPath()
        {
            CheckForIllegalCrossThreadCalls = false;
            string Path = string.Empty;
            OpenFileDialog XlsFile = new OpenFileDialog();
            XlsFile.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            XlsFile.Filter = "EXCEL files (*.xls,*.xlsx,*.csv)|*.xls;*.xlsx;*.csv";
            XlsFile.FilterIndex = 2;
            XlsFile.RestoreDirectory = true;
            XlsFile.Multiselect = false;
            if (XlsFile.ShowDialog() == DialogResult.OK)
            {
                //RxDataOprator.ExcelOprator.ReadXlsData(XlsFile.FileName, DataGrid);
                if (ByExcel.Checked)
                {
                    RxDataOprator.ExcelOprator.ReadXlsData(XlsFile.FileName, datatable, RxDataOprator.ExcelOprator.ReadXlsType.ReadWeldPoint, null);
                }
                else
                {
                    RxDataOprator.ExcelOprator.ReadXlsData(XlsFile.FileName, datatable);
                }
                ReadAixPoint.BackColor = Color.Green;
                SetDataGrid();
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            this.TopMost = true;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void SetDataGrid()
        {
            //DataGrid.DataSource = null;
            //DataGrid.DataSource = datatable;
            //DataGrid.AllowUserToAddRows = true;
            //DataGrid.Enabled = true;
            //DataGrid.ScrollBars = ScrollBars.Vertical;
            this.Invoke(new InvokeHandler(delegate ()
            {
                DataGrid.DataSource = null;
                DataGrid.DataSource = datatable;
            }));
            DataGrid.Update();
        }
        private delegate void InvokeHandler();
        //子线程中
        private void Creat3dBall_Click(object sender, EventArgs e)//Creat3dPoint_Click
        {
            DataGrid.AllowUserToAddRows = false;
            if (PartID == null)
            {
                MessageBox.Show("仿真环境未初始化！请先用工具栏初始化命令初始化运行环境!");
                return;
            }
            Creat3dBall.BackColor = SystemColors.ActiveCaption;
            ReadType = 2;
            int ERR = 0;
            if (DataGrid.RowCount < 1)
            {
                MessageBox.Show("数据为空，无法建立3D模型！");
                return;
            }
            HybridBodies Hybs = PartID.HybridBodies;
            HybridBody Hyb = null;
            //try
            //{
            //    Hyb = Hybs.Item("几何图形集.1");
            //}
            //catch (Exception)
            //{
            //    Hyb = Hybs.Item("Geometrical Set.1");
            //}
            Hyb = Hybs.Add();
            for (int i = 0; i < DataGrid.RowCount; i++)
            {
                HybridShapeFactory PartHyb = (HybridShapeFactory)PartID.HybridShapeFactory;
                //SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatDocument.GetWorkbench("SPAWorkbench");
                //Reference referenceObject = SelectArc.Item(i).Reference;
                //Measurable TheMeasurable = TheSPAWorkbench.GetMeasurable(referenceObject);
                //TheMeasurable.GetPoint(PointCoord); //读取选择的曲面坐标
                string TName;
                try
                {
                    TName = DataGrid.Rows[i].Cells[1].Value.ToString(); //读取选择的曲面名称
                }
                catch (Exception)
                {
                    continue;
                }
                HybridShapePointCoord NewPoint = PartHyb.AddNewPointCoord(Convert.ToDouble(DataGrid.Rows[i].Cells[2].Value.ToString()), Convert.ToDouble(DataGrid.Rows[i].Cells[3].Value.ToString()), Convert.ToDouble(DataGrid.Rows[i].Cells[4].Value.ToString()));
                Reference ShapeRef = PartID.CreateReferenceFromObject(NewPoint);
                HybridShapeSphere NewShape = PartHyb.AddNewSphere(ShapeRef, null, Convert.ToDouble(BallRadio.Text), -45.000000, 45.000000, 0.000000, 180.000000);
                NewShape.Limitation = 1;
                if (KeepName.Checked)
                {
                    NewPoint.set_Name(TName);
                    NewShape.set_Name(TName);
                }
                else
                {
                    NewPoint.set_Name("Rx_" + (i + 1));
                    NewShape.set_Name("Rx_" + (i + 1));
                }
                // Hyb.AppendHybridShape(NewPoint);
                Hyb.AppendHybridShape(NewShape);
                //  PartID.InWorkObject = NewPoint;
                PartID.InWorkObject = NewShape;
                try
                {
                    PartID.Update();
                }
                catch (Exception)
                {
                    ERR += 1;
                }
                Selection SetColor = CatDocument.Selection;
                VisPropertySet VSet = SetColor.VisProperties;
                SetColor.Add(NewShape);
                VSet.SetRealColor(128, 255, 0, 0);
            }
            if (ERR > 0)
            {
                MessageBox.Show("共计:" + ERR + "个点创建新参考点失败！");
            }
            Creat3dBall.BackColor = Color.Green;
            ShowCenter();
        }
        private void Creat3dPoint_Click(object sender, EventArgs e)//Creat3dBall_Click
        {
            DataGrid.AllowUserToAddRows = false;
            Creat3dPoint.BackColor = SystemColors.ActiveCaption;
            ReadType = 2;
            if (PartID == null)
            {
                MessageBox.Show("仿真环境未初始化！请先用工具栏初始化命令初始化运行环境!");
                return;
            }
            int ERR = 0;
            if (DataGrid.RowCount < 1)
            {
                MessageBox.Show("数据为空，无法建立3D模型！");
                return;
            }
            HybridBodies Hybs = PartID.HybridBodies;
            //HybridBody Hyb = Hybs.Item(1);
            HybridBody Hyb = Hybs.Add();
            for (int i = 0; i < DataGrid.RowCount; i++)
            {
                HybridShapeFactory PartHyb = (HybridShapeFactory)PartID.HybridShapeFactory;
                //SPAWorkbench TheSPAWorkbench = (SPAWorkbench)CatDocument.GetWorkbench("SPAWorkbench");
                //Reference referenceObject = SelectArc.Item(i).Reference;
                //Measurable TheMeasurable = TheSPAWorkbench.GetMeasurable(referenceObject);
                //TheMeasurable.GetPoint(PointCoord); //读取选择的曲面坐标
                string TName;
                try
                {
                    TName = DataGrid.Rows[i].Cells[1].Value.ToString(); //读取选择的曲面名称
                }
                catch (Exception)
                {
                    continue;
                }
                HybridShapePointCoord NewPoint = PartHyb.AddNewPointCoord(Convert.ToDouble(DataGrid.Rows[i].Cells[2].Value.ToString()), Convert.ToDouble(DataGrid.Rows[i].Cells[3].Value.ToString()), Convert.ToDouble(DataGrid.Rows[i].Cells[4].Value.ToString()));
                if (KeepName.Checked)
                {
                    NewPoint.set_Name(TName);
                }
                else
                {
                    NewPoint.set_Name("Rx_" + (i + 1));
                }
                Hyb.AppendHybridShape(NewPoint);
                PartID.InWorkObject = NewPoint;
                try
                {
                    PartID.Update();
                }
                catch (Exception)
                {
                    ERR += 1;
                }
            }
            if (ERR > 0)
            {
                MessageBox.Show("共计:" + ERR + "个点创建新参考点失败！");
            }
            Creat3dPoint.BackColor = Color.Green;
            ShowCenter();
        }
        private bool ShowCenter()
        {
            SpecsAndGeomWindow SAGW = (SpecsAndGeomWindow)CatApplication.ActiveWindow;
            Viewer3D NewView = (Viewer3D)SAGW.ActiveViewer;
            NewView.Reframe();
            Viewpoint3D viewpoint3D1 = NewView.Viewpoint3D;
            this.TopMost = false;
            return false;
        }
        private void InsGun_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.WindowState = FormWindowState.Minimized;
            if (DataGrid.RowCount < 1)
            {
                MessageBox.Show("未检测到任何数据请先导入EXCEL数据再执行该操作!");
                return;
            }
            if (CatDocument == null)
            {
                CATIA_Class.InitCatEnv(ref CatApplication, ref CatDocument, ref PartID, this);
            }
            Product Cproduct;
            try
            {
                Cproduct = CatDocument.Product;
            }
            catch (Exception)
            {
                CATIA_Class.InitCatEnv(ref CatApplication, ref CatDocument, ref PartID, this);
                Cproduct = CatDocument.Product;
            }
            Products Cps = Cproduct.Products;
            string GunPath = string.Empty;
            this.TopMost = true;
            object[] oPositionMatrix = new object[12];
            object[] oPositionSafeMatrix = new object[12] { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 };
            double oRx, oRy, oRz;
            for (int i = 0; i < DataGrid.RowCount; i++)
            {
                string TName;
                try
                {
                    TName = DataGrid.Rows[i].Cells[1].Value.ToString(); //读取选择的曲面名称
                    String GunName = DataGrid.Rows[i].Cells[1].Value.ToString();
                    if (TName == "ChangeGun")
                    {
                    A: GunPath = Cps.Application.FileSelectionBox("请选择焊枪", "*.cgr;*.wrl;*.CATPart", 0);
                        if (string.IsNullOrEmpty(GunPath))
                        {
                            var Result = MessageBox.Show("未选择任何焊枪，是否重新选择？（Y/N/C）", "请做出选择", MessageBoxButtons.YesNoCancel);
                            switch (Result)
                            {
                                case DialogResult.None:
                                    break;
                                case DialogResult.OK:
                                    break;
                                case DialogResult.Cancel:
                                    this.TopMost = true;
                                    this.WindowState = FormWindowState.Normal;
                                    this.StartPosition = FormStartPosition.CenterScreen;
                                    return; //终止焊枪导入
                                case DialogResult.Abort:
                                    break;
                                case DialogResult.Retry:
                                    break;
                                case DialogResult.Ignore:
                                    break;
                                case DialogResult.Yes:
                                    goto A; //回到插入焊枪阶段
                                case DialogResult.No:
                                    this.TopMost = true;
                                    this.WindowState = FormWindowState.Normal;
                                    this.StartPosition = FormStartPosition.CenterScreen;
                                    return; //终止焊枪导入
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            Cproduct = AddProduct(CatDocument.Product.Products, GunName);
                            Cps = Cproduct.Products;
                        }
                        continue;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(GunPath)) //常规模式下读取焊枪 一次即可
                        {
                            Cproduct = AddProduct(CatDocument.Product.Products, GunName);
                            Cps = Cproduct.Products;
                            GunPath = Cps.Application.FileSelectionBox("请选择焊枪", "*.cgr;*.wrl;*.CATPart", 0);
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
                double oPi = 3.1415926536;
                if (ARCChange.Checked) //弧度值
                {
                    oRx = Convert.ToDouble(DataGrid.Rows[i].Cells[7].Value.ToString()); //DELMIA Tag点导出集合该坐标为Z
                    oRy = Convert.ToDouble(DataGrid.Rows[i].Cells[6].Value.ToString());//DELMIA Tag点导出集合该坐标为Y
                    oRz = Convert.ToDouble(DataGrid.Rows[i].Cells[5].Value.ToString());//DELMIA Tag点导出集合该坐标为X
                }
                else
                {
                    oRx = Convert.ToDouble(DataGrid.Rows[i].Cells[5].Value.ToString()) * oPi / 180; //转换弧度进行运算
                    oRy = Convert.ToDouble(DataGrid.Rows[i].Cells[6].Value.ToString()) * oPi / 180;//转换弧度进行运算
                    oRz = Convert.ToDouble(DataGrid.Rows[i].Cells[7].Value.ToString()) * oPi / 180;//转换弧度进行运算
                }
                oPositionMatrix[0] = Math.Round(Math.Cos(oRy) * Math.Cos(oRz), 5);
                oPositionMatrix[1] = Math.Round(Math.Cos(oRy) * Math.Sin(oRz), 5);
                oPositionMatrix[2] = Math.Round(-Math.Sin(oRy), 5);
                oPositionMatrix[3] = Math.Round((Math.Sin(oRx) * Math.Sin(oRy) * Math.Cos(oRz)) - (Math.Cos(oRx) * Math.Sin(oRz)), 5);
                oPositionMatrix[4] = Math.Round((Math.Sin(oRx) * Math.Sin(oRy) * Math.Sin(oRz)) + (Math.Cos(oRx) * Math.Cos(oRz)), 5);
                oPositionMatrix[5] = Math.Round((Math.Sin(oRx) * Math.Cos(oRy)), 5);
                oPositionMatrix[6] = Math.Round((Math.Cos(oRx) * Math.Sin(oRy) * Math.Cos(oRz)) + (Math.Sin(oRx) * Math.Sin(oRz)), 5);
                oPositionMatrix[7] = Math.Round((Math.Cos(oRx) * Math.Sin(oRy) * Math.Sin(oRz)) - (Math.Sin(oRx) * Math.Cos(oRz)), 5);
                oPositionMatrix[8] = Math.Round(Math.Cos(oRx) * Math.Cos(oRy), 5);
                oPositionMatrix[9] = Convert.ToDouble(DataGrid.Rows[i].Cells[2].Value.ToString());
                oPositionMatrix[10] = Convert.ToDouble(DataGrid.Rows[i].Cells[3].Value.ToString());
                oPositionMatrix[11] = Convert.ToDouble(DataGrid.Rows[i].Cells[4].Value.ToString());
                //oPositionMatrix =new object[12]{ 1,0,0,0,0.707,0.707,0,-0.707,0.707,10,20,30};//测试
                object[] arrayOfVariantOfBSTR1 = new object[1] { GunPath };
                Cps.AddComponentsFromFiles(arrayOfVariantOfBSTR1, "All");
                Cps.Item(Cps.Count).Position.SetComponents(oPositionMatrix);// 相对世界坐标设定位置
                string NewName = DataGrid.Rows[i].Cells[1].Value.ToString();
                Cps.Item(Cps.Count).set_PartNumber(NewName);
            }
            ShowCenter();
        }
        private Product AddProduct(Products TargetProduct, string Name)
        {
            try
            {
                Product Tdocument = TargetProduct.AddNewProduct(Name);
                //(ProductDocument)TargetProduct.Application.Documents.Add("Product");
                //Tdocument.Product.set_PartNumber(Name);
                return Tdocument;
            }
            catch (Exception)
            {
                return null; ;
            }
        }
        private void InitDataTable()
        {
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "序号";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "名称";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "X坐标";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "Y坐标";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "Z坐标";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "RX";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "RY";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "RZ";
            datatable.Columns.Add(dataColum);
        }

        private void InitCatia_Click(object sender, EventArgs e)
        {
            CATIA_Class.InitCatEnv(ref CatApplication, ref CatDocument, ref PartID, this);
        }

        private void ExtraPadToSurface_Click(object sender, EventArgs e)
        {

        }
    }
}
