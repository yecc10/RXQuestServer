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
using DRAFTINGITF;
using Microsoft.WindowsAPICodePack.Shell;

namespace YeDassaultSystemDev
{
    public partial class _2DModel : Form
    {
        INFITF.Application CatApplication; //CATIA
        ProductDocument CatDocument;
        Part PartID;
        AnyObject[] GetRepeatRef = new AnyObject[9999];
        CATIA_Class CATIA_Class = new CATIA_Class();
        string Identificationclass = "2DIdentificationclass";
        MaterialDocument oMaterial_document = null;
        List<string> ViaIndentification = new List<string> { };
        string PartTypeString = "定位块";
        /// <summary>
        /// 实例化的容器存放单元中零件对象集合
        /// </summary>
        List<Product> UnitPartList = new List<Product>();//实例化容器存放单元中零件对象
        /// <summary>
        /// 实例化的容器存放单元中需要创建2D的零件对象集合
        /// </summary>
        List<Product> vUnitPartProductList = new List<Product>();// 实例化的容器存放单元中需要创建2D的零件对象集合
        /// <summary>
        /// 经过检查缺失类别属性的对象
        /// </summary>
        List<Product> ErrPartList = new List<Product>();// 实例化的容器存放单元中需要创建2D的零件对象集合
        /// <summary>
        /// 材料集合
        /// </summary>
        List<Material> MaterialList = new List<Material> { };
        DrawingDocument drawingDocument = null;
        Product UnitProduct = null; //单元对象

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////
        public _2DModel()
        {
            InitializeComponent();
            //显示控制  100%  显示尺寸  1276, 756
            //float SX = GetSysDPIAndScale.PrimaryScreen.ScaleX;
            //if (SX<=1)
            //{
            //    this.Width = 1276;
            //    this.Height = 756;
            //}
            //else
            //{   //1912, 1132
            //    this.Height = 1132;
            //    this.Width = 1912 ;
            //}

            CATIA_Class.InitCatEnv(ref CatApplication, ref CatDocument, ref PartID, this, true, myMessage);
            if (!GetUserDrawingMode() && CatApplication != null)
            {
                OpenDrawingModelFile();
                GetUserDrawingMode();
            }
        }
        private void Read3DPose_Click(object sender, EventArgs e)
        {
            PartlistBox.Items.Clear(); //清空当前列表
            UnitPartProductList.Items.Clear();
            UnFindAttrPartList.Items.Clear();
            ErrPartList.Clear();
            UnitPartList.Clear();
            vUnitPartProductList.Clear();

            Selection SelectArc = null;
            CATIA_Class.GetSelect(CatDocument, ref SelectArc, 6, this);
            if (SelectArc == null || SelectArc.Count2 == 0)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.TopMost = true;
                return;
            }
            Products UnitPartProducts = null;//零件集合
            try
            {
                UnitProduct = (Product)SelectArc.Item(1).Value;
                UnitName.Text = UnitProduct.get_PartNumber();
                UnitPartProducts = UnitProduct.Products;
            }
            catch (Exception)
            {
                myMessage.Text = "所选择的对象非单元集合请重新选择！";
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.TopMost = true;
                return;
            }
            foreach (var item in UnitPartProducts)
            {
                try
                {
                    Product UnitSingePart = (Product)item;
                    string ItemName = UnitSingePart.get_PartNumber();//获取零件名称
                    PartlistBox.Items.Add(ItemName);
                    UnitPartList.Add(UnitSingePart);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void _2DModel_Load(object sender, EventArgs e)
        {

        }

        private void AddAll_Click(object sender, EventArgs e)
        {
            if (UnitPartList.Count < 1)
            {
                MessageBox.Show("您尚未选择任何零件 请选选择需要厂家2D的对象集合！");
            }
            vUnitPartProductList = UnitPartList;
            try
            {
                foreach (Product item in vUnitPartProductList)
                {
                    UnitPartProductList.Items.Add(item.get_PartNumber());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void RemoveOne_Click(object sender, EventArgs e)
        {
            if (UnitPartProductList.SelectedIndex < 0)
            {
                MessageBox.Show("您尚未选择任何对象！");
                return;
            }
            int DeletePartIndex = UnitPartProductList.SelectedIndex;
            String DeletePartName = UnitPartProductList.SelectedItem.ToString();
            try
            {
                Product PreDeletePart = (Product)vUnitPartProductList[DeletePartIndex];
                if (PreDeletePart.get_PartNumber() == DeletePartName)//核实用户对象和软件队列中对象是一致的
                {
                    vUnitPartProductList.Remove(PreDeletePart); //删除用户指定对象
                    UnitPartProductList.Items.Remove(UnitPartProductList.SelectedItem);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("删除失败！");
                return;
            }
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            UnitPartProductList.Items.Clear();//清空显示队列  
            vUnitPartProductList.Clear();//清空寄存器队列
        }

        private void AddOne_Click(object sender, EventArgs e)
        {
            if (PartlistBox.SelectedIndex < 0)
            {
                MessageBox.Show("您尚未选择任何对象！");
                return;
            }
            foreach (object item in PartlistBox.SelectedItems)
            {
                try
                {
                    int DeletePartIndex = PartlistBox.Items.IndexOf(item);//获取对象在原始集合中的索引位置
                    String DeletePartName = item.ToString();//获取指定对象的名称
                    UnitPartProductList.Items.Add(item);
                    vUnitPartProductList.Add(UnitPartList[DeletePartIndex]);
                }
                catch (Exception)
                {
                    MessageBox.Show("添加失败，请重新选择！");
                    return;
                }
            }
            CheckPartList();//检测添加的对象是否合法
        }
        private void OpenDrawingModelFile()
        {
            //直接使用模板 不再重新创建
            Window Catwindow = CatApplication.ActiveWindow;
            try
            {
                string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string RefDocFilePath = FilePath + "\\" + "Model.CATDrawing";
                DrawingDocument RefdrawingDocument = (DrawingDocument)CatApplication.Documents.Open(RefDocFilePath);//创建2D草绘
                drawingDocument = RefdrawingDocument; // Updata 20210729 禁用重新创建草图
            }
            catch (Exception)
            {
                MessageBox.Show("创建草绘 草图失败！请重启软件重试！");
                return;
            }
            Catwindow.Activate();
        }
        private void Create2DDrawing_Click(object sender, EventArgs e)
        {
            if (UnFindAttrPartList.Items.Count > 0)
            {
                MessageBox.Show("存在尚未解决的问题！");
                return;
            }
            if (UnitPartProductList.Items.Count < 1)
            {
                MessageBox.Show("任务队列中不存在任何数据！");
                return;
            }
            progressBar.Value = 0;
            try
            {
                //读取已经打开的草图
                drawingDocument = (DrawingDocument)CatApplication.Documents.Item("Model.CATDrawing");
                //debug
                //Documents Documents = CatApplication.Documents;
                //foreach (Document item in Documents)
                //{
                //    string DocName = item.get_Name();
                //}
            }
            catch (Exception)
            {
                //未成功检索到 已打开的模板图  开始自行打开新的模板图
                try
                {

                    string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string RefDocFilePath = FilePath + "\\" + "Model.CATDrawing";
                    DrawingDocument RefdrawingDocument = (DrawingDocument)CatApplication.Documents.Open(RefDocFilePath);//创建2D草绘
                    drawingDocument = RefdrawingDocument; // Updata 20210729 禁用重新创建草图
                }
                catch (Exception)
                {
                    MessageBox.Show("打开参考 草图失败！请重启软件重试！");
                    return;
                }
            }
            DrawingSheets drawingSheets = drawingDocument.Sheets;
            int TotalPages = vUnitPartProductList.Count;
            int CurrentPage = 1;
            progressBar.Step = 1000 / TotalPages;
            foreach (string CUnitPartName in UnitPartProductList.Items)
            {
                Product CUnitProduct = vUnitPartProductList.Find(x => x.get_PartNumber() == CUnitPartName);
                //根据零件属性名称 创建2D图框 草图 
                string CUnitProductName = CUnitProduct.get_PartNumber();
                Parameters parameters = CUnitProduct.ReferenceProduct.UserRefProperties;
                StrParam strParam = (StrParam)parameters.GetItem(Identificationclass);
                string CunitType = strParam.ValueAsString();
                if (CunitType == "单元X" && CurrentPage == 1)
                {
                    //当对象属于单元类别时候前面放置2个空白序号 用户存放总阻力及BASE图
                    CurrentPage = 3;
                    TotalPages += 2;
                }
                if (ViaIndentification.IndexOf(CunitType) < 0)
                {
                    MessageBox.Show("零件属性不合法，已停止后续任务执行！");
                    return;
                }
                #region 激活拆图窗口
                try
                {
                    Windows CATWindows = CatApplication.Windows;
                    Window DrawingWindow = CATWindows.Item("Model.CATDrawing");
                    DrawingWindow.Activate();
                }
                catch (Exception)
                {

                }
                #endregion
                DrawingSheet drawingSheet = null;
                try
                {
                    Selection selection = drawingDocument.Selection;
                    selection.Clear();
                    drawingSheet = drawingSheets.Item(CunitType);
                    if (drawingSheet == null)
                    {
                        MessageBox.Show(CunitType + "  对象未在草图模板中找到！请检查该对象！");
                        return;
                    }
                    selection.Add(drawingSheet);
                    selection.Copy();
                    selection.Clear();
                    DrawingRoot drawingRoot = (DrawingRoot)drawingDocument.GetItem("CATIADrawingDrawing0");
                    selection.Add(drawingRoot);
                    selection.Paste();
                    selection.Clear();
                    drawingSheet = drawingSheets.Item(drawingSheets.Count);
                    try
                    {
                        drawingSheet.set_Name(CUnitProductName);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            drawingSheet.set_PaperName(CUnitProductName);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("零件：" + CUnitProductName + "操作失败！请重新操作！");
                    return;
                }
                try
                {
                    DrawingViews DetailparametersViews = drawingSheet.Views;
                    DrawingView DetailparametersView = DetailparametersViews.ActiveView;
                    #region DEBUG
                    //int uindex = DetailparametersViews.Count;
                    //string ViewName = DetailparametersView.get_Name();
                    //GeometricElements DetailGeometricElements = DetailparametersView.GeometricElements;//获取主视图中所有几何元素
                    //uindex = DetailGeometricElements.Count;
                    //foreach (GeometricElement item in DetailGeometricElements)
                    //{
                    //    String MVNAME = item.get_Name();
                    //}
                    //DrawingComponents drawingComponents = DetailparametersView.Components; //获取组件
                    //uindex = drawingComponents.Count;
                    //if (uindex > 1)
                    //{
                    //    foreach (DrawingComponent drawingComponent in drawingComponents)
                    //    {
                    //        String MVNAME = drawingComponent.get_Name();
                    //    }
                    //}
                    //DrawingDimensions drawingDimensions = DetailparametersView.Dimensions;//获取尺寸标注信息
                    //uindex = drawingDimensions.Count;
                    #endregion
                    DrawingViewGenerativeLinks drawingViewGenerativeLinks = DetailparametersView.GenerativeLinks;//获取2D链接
                    DrawingTexts drawingTexts = DetailparametersView.Texts;//获取图框中全部文字信息
                    int uindex = drawingTexts.Count;
                    if (uindex > 0)
                    {
                        try
                        {
                            DrawingText drawingText = (DrawingText)drawingTexts.GetItem("TitleBlock_Text_LeftProductName");
                            string Tvalue = drawingText.get_Text();
                            drawingText.set_Text(CUnitProductName);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("零件：" + CUnitProductName + "修改工作视图中属性失败，操作失败！请重新操作！");
                            return;
                        }
                    }
                    if (CunitType == "单元X")
                    {
                        DrawingTables drawingTables = DetailparametersView.Tables;
                        uindex = drawingTables.Count;
                        if (uindex > 0)
                        {
                            List<Product> TotalProduct = new List<Product> { };//申明一个容器 存放当前单元全部对象 方便后续检索
                            try
                            {
                                //更新自制件
                                #region 更新自制件
                                DrawingTable drawingTable = (DrawingTable)drawingTables.GetItem("CreatedbyselfBOM");//获取自制件表
                                int Rows = drawingTable.NumberOfRows;
                                if (Rows > 1)
                                {
                                    do
                                    {
                                        drawingTable.RemoveRow(1);//删除所有多余表
                                    } while (drawingTable.NumberOfRows > 1);
                                }
                                try
                                {
                                    int ID = 1;
                                    List<Product> TotalSTDList = new List<Product> { };//统计全部自制 零件 便于后续统计数量
                                    List<Product> WritedSTDList = new List<Product> { };//统计已写入Bom的自制 零件清单 放置重复写入
                                    foreach (Product item in CUnitProduct.Products)
                                    {
                                        TotalSTDList.Add(item);
                                    }
                                    foreach (Product item in CUnitProduct.Products)
                                    {
                                        TotalProduct.Add(item);
                                        string PartName = item.get_PartNumber();
                                        if (PartName == "STD" || PartName == "PUR" || PartName == "OPEN")
                                        {
                                            continue;
                                        }
                                        String[] StrNameList = PartName.Split(new char[] { '-', '.' });
                                        if (StrNameList.Contains("GB70") || StrNameList.Contains("STD") || StrNameList.Contains("PUR") || StrNameList.Contains("OPEN"))
                                        {
                                            continue;
                                        }
                                        if (WritedSTDList.Count > 0 && WritedSTDList.Count(x => x.get_PartNumber() == PartName) > 0)
                                        {
                                            //当前对象已写过
                                            continue;
                                        }
                                        int TargetNumber = TotalSTDList.Count(x => x.get_PartNumber() == PartName);
                                        String PartID = "1" + (ID > 9 ? Convert.ToString(ID) : "0" + Convert.ToString(ID));
                                        drawingTable.AddRow(1);
                                        int CRow = 1;// drawingTable.NumberOfRows;
                                        drawingTable.SetCellAlignment(CRow, 1, CatTablePosition.CatTableMiddleCenter);
                                        drawingTable.SetCellAlignment(CRow, 2, CatTablePosition.CatTableMiddleCenter);
                                        drawingTable.SetCellAlignment(CRow, 3, CatTablePosition.CatTableMiddleCenter);
                                        drawingTable.SetCellAlignment(CRow, 4, CatTablePosition.CatTableMiddleCenter);
                                        drawingTable.SetCellAlignment(CRow, 5, CatTablePosition.CatTableMiddleCenter);
                                        drawingTable.SetCellAlignment(CRow, 6, CatTablePosition.CatTableMiddleCenter);
                                        drawingTable.SetCellString(CRow, 1, PartID);
                                        drawingTable.SetCellString(CRow, 2, PartName);
                                        drawingTable.SetCellString(CRow, 4, TargetNumber.ToString() + "/" + TargetNumber.ToString());//当统计的数量大于1时填写对应数量
                                        drawingTable.SetCellString(CRow, 5, "Q235");
                                        drawingTable.SetCellString(CRow, 6, "自制件");
                                        WritedSTDList.Add(item);
                                        ID += 1;
                                    }
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("零件：" + CUnitProductName + "工作视图中尝试写入自制件Bom信息失败，操作失败！请稍后手动重新操作！");
                                    // throw;
                                }
                                #endregion
                                //更新企标件及采购件
                                #region 更新企标件及采购件
                                drawingTable = (DrawingTable)drawingTables.GetItem("PURBOM");//获取自制件表
                                Rows = drawingTable.NumberOfRows;
                                if (Rows > 1)
                                {
                                    do
                                    {
                                        drawingTable.RemoveRow(1);//删除所有多余表
                                    } while (drawingTable.NumberOfRows > 1);//至少留一行
                                }
                                try
                                {
                                    int ID = 1;
                                    if (TotalProduct.Count > 0)
                                    {
                                        #region 写入企标件数据
                                        Product stdproduct = TotalProduct.Find(x => x.get_PartNumber().Split(new char[] { '-', '.' }).Contains("STD"));//从集合中查询到含STD标记的字符对象
                                        if (stdproduct != null)
                                        {
                                            List<Product> TotalSTDList = new List<Product> { };//统计全部STD 零件 便于后续统计数量
                                            List<Product> WritedSTDList = new List<Product> { };//统计已写入Bom的STD 零件清单 放置重复写入
                                            foreach (Product item in stdproduct.Products)
                                            {
                                                TotalSTDList.Add(item);
                                            }
                                            foreach (Product item in stdproduct.Products)
                                            {
                                                string PartName = item.get_PartNumber();
                                                if (WritedSTDList.Count > 0 && WritedSTDList.Count(x => x.get_PartNumber() == PartName) > 0)
                                                {
                                                    //当前对象已写过
                                                    continue;
                                                }
                                                int TargetNumber = TotalSTDList.Count(x => x.get_PartNumber() == PartName);
                                                String PartID = "7" + (ID > 9 ? Convert.ToString(ID) : "0" + Convert.ToString(ID));
                                                drawingTable.AddRow(1);
                                                int CRow = 1;// drawingTable.NumberOfRows;
                                                drawingTable.SetCellAlignment(CRow, 1, CatTablePosition.CatTableMiddleCenter);
                                                drawingTable.SetCellAlignment(CRow, 2, CatTablePosition.CatTableMiddleCenter);
                                                drawingTable.SetCellAlignment(CRow, 3, CatTablePosition.CatTableMiddleCenter);
                                                drawingTable.SetCellAlignment(CRow, 4, CatTablePosition.CatTableMiddleCenter);
                                                drawingTable.SetCellAlignment(CRow, 5, CatTablePosition.CatTableMiddleCenter);
                                                drawingTable.SetCellAlignment(CRow, 6, CatTablePosition.CatTableMiddleCenter);
                                                drawingTable.SetCellString(CRow, 1, PartID);
                                                drawingTable.SetCellString(CRow, 2, PartName);
                                                drawingTable.SetCellString(CRow, 4, Convert.ToString(TargetNumber * 2));//此处填写总数量L/R 所以乘2
                                                                                                                        //drawingTable.SetCellString(CRow, 5, "");
                                                drawingTable.SetCellString(CRow, 6, "企标件");
                                                WritedSTDList.Add(item);
                                                ID += 1;
                                            }
                                        }

                                        #endregion
                                        #region 写入市购品数据
                                        stdproduct = TotalProduct.Find(x => x.get_PartNumber().Split(new char[] { '-', '.' }).Contains("PUR"));//从集合中查询到含STD标记的字符对象
                                        if (stdproduct != null)
                                        {
                                            List<Product> TotalPURList = new List<Product> { };//统计全部STD 零件 便于后续统计数量
                                            List<Product> WritedPURList = new List<Product> { };//统计已写入Bom的STD 零件清单 放置重复写入
                                            foreach (Product item in stdproduct.Products)
                                            {
                                                TotalPURList.Add(item);
                                            }
                                            foreach (Product item in stdproduct.Products)
                                            {
                                                string PartName = item.get_PartNumber();
                                                if (WritedPURList.Count > 0 && WritedPURList.Count(x => x.get_PartNumber() == PartName) > 0)
                                                {
                                                    //当前对象已写过
                                                    continue;
                                                }
                                                int TargetNumber = TotalPURList.Count(x => x.get_PartNumber() == PartName);
                                                String PartID = "7" + (ID > 9 ? Convert.ToString(ID) : "0" + Convert.ToString(ID));
                                                drawingTable.AddRow(1);
                                                int CRow = 1;// drawingTable.NumberOfRows;
                                                drawingTable.SetCellAlignment(CRow, 1, CatTablePosition.CatTableMiddleCenter);
                                                drawingTable.SetCellAlignment(CRow, 2, CatTablePosition.CatTableMiddleCenter);
                                                drawingTable.SetCellAlignment(CRow, 3, CatTablePosition.CatTableMiddleCenter);
                                                drawingTable.SetCellAlignment(CRow, 4, CatTablePosition.CatTableMiddleCenter);
                                                drawingTable.SetCellAlignment(CRow, 5, CatTablePosition.CatTableMiddleCenter);
                                                drawingTable.SetCellAlignment(CRow, 6, CatTablePosition.CatTableMiddleCenter);
                                                drawingTable.SetCellString(CRow, 1, PartID);
                                                drawingTable.SetCellString(CRow, 2, PartName);
                                                drawingTable.SetCellString(CRow, 4, Convert.ToString(TargetNumber * 2));//此处填写总数量L/R 所以乘2
                                                                                                                        //drawingTable.SetCellString(CRow, 5, "");
                                                drawingTable.SetCellString(CRow, 6, "外购件");
                                                WritedPURList.Add(item);
                                                ID += 1;
                                            }
                                        }
                                        #endregion

                                    }
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("零件：" + CUnitProductName + "工作视图中尝试写入采购件及企标件Bom信息失败，操作失败！请稍后手动重新操作！");
                                    // throw;
                                }
                                #endregion
                                #region 更新标准件
                                drawingTable = (DrawingTable)drawingTables.GetItem("STDBOM");//获取自制件表
                                Rows = drawingTable.NumberOfRows;
                                if (Rows > 1)
                                {
                                    do
                                    {
                                        drawingTable.RemoveRow(1);//删除所有多余表
                                    } while (drawingTable.NumberOfRows > 1);//至少留一行
                                }
                                try
                                {
                                    int ID = 1;
                                    if (TotalProduct.Count > 0)
                                    {
                                        #region 写入企标件数据
                                        Product stdproduct = TotalProduct.Find(x => x.get_PartNumber().Split(new char[] { '-', '.' }).Contains("GB70"));//从集合中查询到含STD标记的字符对象
                                        if (stdproduct == null)
                                        {
                                            continue;
                                        }
                                        List<Product> TotalSTDList = new List<Product> { };//统计全部STD 零件 便于后续统计数量
                                        List<Product> WritedSTDList = new List<Product> { };//统计已写入Bom的STD 零件清单 放置重复写入
                                        foreach (Product item in stdproduct.Products)
                                        {
                                            TotalSTDList.Add(item);
                                        }
                                        foreach (Product item in stdproduct.Products)
                                        {
                                            string PartName = item.get_PartNumber();
                                            if (WritedSTDList.Count > 0 && WritedSTDList.Count(x => x.get_PartNumber() == PartName) > 0)
                                            {
                                                //当前对象已写过
                                                continue;
                                            }
                                            int TargetNumber = TotalSTDList.Count(x => x.get_PartNumber() == PartName);
                                            //String PartID = "7" + (ID > 9 ? Convert.ToString(ID) : "0" + Convert.ToString(ID));
                                            drawingTable.AddRow(1);
                                            int CRow = 1;// drawingTable.NumberOfRows;
                                            drawingTable.SetCellAlignment(CRow, 1, CatTablePosition.CatTableMiddleCenter);
                                            drawingTable.SetCellAlignment(CRow, 2, CatTablePosition.CatTableMiddleCenter);
                                            drawingTable.SetCellAlignment(CRow, 3, CatTablePosition.CatTableMiddleCenter);
                                            drawingTable.SetCellAlignment(CRow, 4, CatTablePosition.CatTableMiddleCenter);
                                            //drawingTable.SetCellString(CRow, 1, PartID);
                                            drawingTable.SetCellString(CRow, 2, PartName);
                                            drawingTable.SetCellString(CRow, 3, Convert.ToString(TargetNumber * 2));//此处填写总数量L/R 所以乘2
                                            drawingTable.SetCellString(CRow, 4, "外购件");
                                            WritedSTDList.Add(item);
                                            ID += 1;
                                        }
                                        #endregion

                                    }
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("零件：" + CUnitProductName + "工作视图中尝试写入自制件 Bom信息失败，操作失败！请稍后手动重新操作！");
                                    // throw;
                                }
                                #endregion

                            }
                            catch (Exception)
                            {
                                MessageBox.Show("零件：" + CUnitProductName + "修改工作视图中Bom失败，操作失败！请稍后手动重新操作！");
                                // throw;
                            }
                        }
                    }
                    //进入图纸背景状态
                    DetailparametersView = DetailparametersViews.Item(2);//获取背景视图
                    //ViewName = DetailparametersView.get_Name();
                    drawingTexts = DetailparametersView.Texts;//获取图框中全部文字信息
                    uindex = drawingTexts.Count;
                    if (uindex > 0)
                    {
                        try
                        {
                            //更新零件背景编号
                            DrawingText drawingText = (DrawingText)drawingTexts.GetItem("TitleBlock_Text_ProductName");
                            //string Tvalue = drawingText.get_Text();
                            drawingText.set_Text(CUnitProductName);
                            //更新总页数
                            drawingText = (DrawingText)drawingTexts.GetItem("TitleBlock_Text_DRAWING_Num");
                            string DRAWING_Num = drawingText.get_Text();
                            string NewText = "共" + TotalPages + "张" + "\r\n" + "ALL No.";
                            drawingText.set_Text(NewText);
                            //更新零件重量 TitleBlock_Text_Weight_1
                            drawingText = (DrawingText)drawingTexts.GetItem("TitleBlock_Text_Weight_1");
                            double PartWeight = 0;
                            try
                            {
                                PartWeight = WeightFromProduct(CUnitProduct);
                                PartWeight = Math.Round(PartWeight, 3);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("提示：零件：" + CUnitProductName + "获取重量信息失败，请稍后自行手动操作！");
                                //不做任何处理
                            }
                            string Wtext = PartWeight + "kg";
                            drawingText.set_Text(Wtext);
                            //更新当前页数
                            drawingText = (DrawingText)drawingTexts.GetItem("TitleBlock_Text_SHEET_Num");
                            DRAWING_Num = drawingText.get_Text();
                            NewText = "第" + CurrentPage + "张" + "\r\n" + "Page No.";
                            drawingText.set_Text(NewText);
                            if (CunitType == "单元X")
                            {
                                try
                                {
                                    //更改单元编号 中文 TitleBlock_Text_PartNumber
                                    string CID = GetNumWithChina(CurrentPage - 2);
                                    drawingText = (DrawingText)drawingTexts.GetItem("TitleBlock_Text_PartNumber");
                                    NewText = "单元" + CID;
                                    drawingText.set_Text(NewText);
                                    //更改单元编号  英文 TitleBlock_Text_PartEnglistName
                                    drawingText = (DrawingText)drawingTexts.GetItem("TitleBlock_Text_PartEnglistName");
                                    int WPage = CurrentPage - 2;
                                    NewText = "UNIT " + (WPage < 10 ? Convert.ToString("0" + WPage) : Convert.ToString(WPage));
                                    drawingText.set_Text(NewText);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("零件：" + CUnitProductName + "修改背景视图中单元属性失败，操作失败！请重新操作！");
                                }
                                //更新组立图Bom信息
                            }
                            CurrentPage += 1;
                            progressBar.PerformStep();
                            progressBar.Update();//刷新进度条
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("零件：" + CUnitProductName + "修改背景视图中属性失败，操作失败！请重新操作！");
                            return;
                        }

                    }
                    //var res = DetailGeometricElements.GetItem("0-NW26-W281L-C49-U05-01");
                    //int Pnum = parameters.Count;
                    //StrParam STRLeftProductText = (StrParam)parameters.Item("TitleBlock_Text_LeftProductName");
                    //STRLeftProductText.set_Value(CUnitProductName);
                }
                catch (Exception)
                {

                    MessageBox.Show("零件：" + CUnitProductName + "内部编号命名失败，操作失败！请重新操作！");
                    return;
                }
            }
            try
            {
                string FilePath = CreatePath(UnitName.Text);
                if (FilePath == null)
                {
                    FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
                string RefDocFilePath = FilePath + "\\" + UnitName.Text + ".CATDrawing";
                if (!CatApplication.FileSystem.FileExists(RefDocFilePath))
                {
                    CatApplication.DisplayFileAlerts = false;
                    drawingDocument.SaveAs(RefDocFilePath);
                    CatApplication.DisplayFileAlerts = true;
                }
                else
                {
                    string datatime = DateTime.Now.ToString("yyyymmddHHmmssffff");
                    RefDocFilePath = FilePath + "\\" + UnitName.Text + "_T" + ".CATDrawing";//若连临时文件都已存在则强制替换临时文件 此处不要加时间进行区别 否则后续无法识别
                    CatApplication.DisplayFileAlerts = false;
                    drawingDocument.SaveAs(RefDocFilePath);
                    CatApplication.DisplayFileAlerts = true;
                    MessageBox.Show("图框生成成功！但是桌面已存在该单元名称的2D图纸，已为您取消强制替换保存，请手动保存！");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("图框生成成功！但是另存图框时发生失败，请手动保存！");
                return;
            }
        }
        private void _2DModel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void Reconnect_Click(object sender, EventArgs e)
        {
            CATIA_Class.InitCatEnv(ref CatApplication, ref CatDocument, ref PartID, this, true, myMessage);
        }
        /// <summary>
        /// 将数字转换成中文符号
        /// </summary>
        /// <param name="number">待转换的数字</param>
        /// <returns></returns>
        private string GetNumWithChina(int number)
        {
            string res = string.Empty;
            string str = number.ToString();
            string schar = str.Substring(0, 1);
            switch (schar)
            {
                case "1":
                    res = "一";
                    break;
                case "2":
                    res = "二";
                    break;
                case "3":
                    res = "三";
                    break;
                case "4":
                    res = "四";
                    break;
                case "5":
                    res = "五";
                    break;
                case "6":
                    res = "六";
                    break;
                case "7":
                    res = "七";
                    break;
                case "8":
                    res = "八";
                    break;
                case "9":
                    res = "九";
                    break;
                default:
                    res = "零";
                    break;
            }
            if (str.Length > 1)
            {
                switch (str.Length)
                {
                    case 2:
                    case 6:
                        res += "十";
                        break;
                    case 3:
                    case 7:
                        res += "百";
                        break;
                    case 4:
                        res += "千";
                        break;
                    case 5:
                        res += "万";
                        break;
                    default:
                        res += "";
                        break;
                }
                if (str.Length > 1 && int.Parse(str.Substring(1, str.Length - 1)) > 0)
                {
                    res += GetNumWithChina(int.Parse(str.Substring(1, str.Length - 1)));
                }
            }
            if (str.Length > 1 && schar == "1")
            {
                res = res.Remove(0, 1);
            }
            return res;
        }
        private void CheckPartDefine_Click(object sender, EventArgs e)
        {
            CheckPartList();
        }
        /// <summary>
        /// 获取指定属性集合中的指定名称的属性对象
        /// </summary>
        /// <param name="mParamName">检查的名称</param>
        /// <param name="parameters">被检查的集合</param>
        /// <returns></returns>
        private Parameter GetParameterFromParameters(String mParamName, Parameters parameters)
        {
            foreach (Parameter item in parameters)
            {
                string ParamName = item.get_Name();
                string[] StrName = ParamName.Split(new char[1] { '\\' });//分割字符串
                ParamName = StrName[2];
                //string ParamName = item.ValueAsString(); 获取属性值
                if (ParamName == mParamName)
                {
                    return item;
                }
            }
            return null;
        }
        /// <summary>
        /// 检查对象属性是否可以在2D图中找到对应模板
        /// </summary>
        /// <param name="parameter">属性对象</param>
        /// <returns></returns>
        private bool IslegalWithParamert(Parameter parameter)
        {
            string ParamValue = parameter.ValueAsString(); //获取属性值
            if (ViaIndentification.IndexOf(ParamValue) > 0) //检查零件的值是否属于合法范围
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 检测即将导出2D的零件集合是否存在问题
        /// </summary>
        private void CheckPartList()
        {
            UnFindAttrPartList.Items.Clear();
            foreach (Product Part in vUnitPartProductList)
            {
                Parameters parameters = null;
                string PartName = Part.get_PartNumber();
                try
                {
                    parameters = Part.ReferenceProduct.UserRefProperties;
                }
                catch (Exception)
                {

                    throw;
                }
                Parameter parameter = GetParameterFromParameters(Identificationclass, parameters);

                if (parameter == null)
                {
                    try
                    {
                        ErrPartList.Add(Part);
                        UnFindAttrPartList.Items.Add(PartName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(PartName + "零件缺失属性，系统在将其添加到故障零件清单中操作失败！");
                        return;
                    }
                }
                else
                {
                    if (!IslegalWithParamert(parameter))//零件属性值不合法时  依旧添加到待处理对象中
                    {
                        ErrPartList.Add(Part);
                        UnFindAttrPartList.Items.Add(PartName);
                    }
                }
                //StrParam strParam = parameters.CreateString("类型", "定位块");
            }
            if (UnFindAttrPartList.Items.Count < 1)
            {
                MessageBox.Show("当前零件全部正常！");
            }
        }
        /// <summary>
        /// 获取指定对象 指定属性的值
        /// </summary>
        /// <param name="ParameName">属性名称</param>
        /// <param name="product">被查询对象</param>
        /// <returns></returns>
        private String GetPartAttrValue(String ParameName, Product product)
        {
            string Result = null;
            Parameters parameters = product.ReferenceProduct.UserRefProperties;
            Parameter parameter = GetParameterFromParameters(Identificationclass, parameters);
            if (parameter != null)
            {
                Result = parameter.ValueAsString();
            }
            else
            {
                Result = "指定对象不存在该属性！";
            }
            return Result;
        }
        /// <summary>
        /// 更新用户选中的零件属性类型
        /// </summary>
        private void UpdataPartAttr()
        {
            if (UnFindAttrPartList.SelectedIndex < 0)
            {
                return;
            }
            do
            {
                object item = UnFindAttrPartList.SelectedItems[0];
                try
                {
                    int DeletePartIndex = UnFindAttrPartList.Items.IndexOf(item);//获取对象在原始集合中的索引位置
                    String DeletePartName = item.ToString();//获取指定对象的名称
                    try
                    {
                        Product PreDeletePart = (Product)ErrPartList.Find(x => x.get_PartNumber() == DeletePartName);//根据名称在集合中自由查询到指定对象
                        if (PreDeletePart.get_PartNumber() == DeletePartName)//核实用户对象和软件队列中对象是一致的
                        {
                            try
                            {
                                Parameters parameters = PreDeletePart.ReferenceProduct.UserRefProperties;
                                Parameter parameter = GetParameterFromParameters(Identificationclass, parameters);
                                if (parameter == null)
                                {
                                    parameters.CreateString(Identificationclass, PartTypeString);
                                }
                                else
                                {
                                    if (!IslegalWithParamert(parameter))
                                    {
                                        StrParam strParam = (StrParam)parameter;
                                        strParam.set_Value(PartTypeString);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("为当前对象创建类别失败！请检查对象是否取消激活！");
                                return;
                            }
                            ErrPartList.Remove(PreDeletePart); //删除用户指定对象
                            UnFindAttrPartList.Items.Remove(UnFindAttrPartList.SelectedItem);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("添加失败，请重新选择！");
                    return;
                }
            } while (UnFindAttrPartList.SelectedItems.Count > 0);
        }
        private void UnFindAttrPartList_Click(object sender, EventArgs e)
        {
            if (UnFindAttrPartList.Items.Count < 1)
            {
                return;
            }
            if (UnFindAttrPartList.SelectedIndex < 0)
            {
                return;
            }
            if (true)
            {

            }
            int DeletePartIndex = UnFindAttrPartList.SelectedIndex;
            String DeletePartName = UnFindAttrPartList.SelectedItem.ToString();
            try
            {
                Product PreDeletePart = (Product)ErrPartList[DeletePartIndex];
                if (PreDeletePart.get_PartNumber() == DeletePartName)//核实用户对象和软件队列中对象是一致的
                {
                    PartDocument productDocument = (PartDocument)CatApplication.Documents.Item(PreDeletePart.get_PartNumber() + ".CATPart");//直接获取对象--即将被投影的零件
                    //string ImagPath = GetFilePicture.ThumbnailHelper.GetInstance().GetJPGThumbnail(productDocument.FullName,129,129);
                    //ScalePicture.ImageLocation = ImagPath;
                    ShellFile shellFile = ShellFile.FromFilePath(productDocument.FullName);
                    Bitmap bitmap = shellFile.Thumbnail.LargeBitmap;
                    ScalePicture.Image = bitmap;
                    TopView.Image = bitmap;
                    LeftView.Image = bitmap;
                    BottomView.Image = bitmap;
                }
            }
            catch (Exception)
            {
                ScalePicture.Image = null;
                TopView.Image = null;
                LeftView.Image = null;
                BottomView.Image = null;
                MessageBox.Show(DeletePartName + " 未成功获取到缩略图！");
                return;
            }
        }

        private void UnitPartProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UnitPartProductList.Items.Count < 1)
            {
                return;
            }
            if (UnitPartProductList.SelectedIndex < 0)
            {
                return;
            }
            if (true)
            {

            }
            int DeletePartIndex = UnitPartProductList.SelectedIndex;
            String DeletePartName = UnitPartProductList.SelectedItem.ToString();
            Product PreDeletePart = null;
            try
            {
                PreDeletePart = (Product)vUnitPartProductList[DeletePartIndex];
                if (PreDeletePart.get_PartNumber() == DeletePartName)//核实用户对象和软件队列中对象是一致的
                {
                    Window MainWindow = CatApplication.ActiveWindow;
                    PartDocument productDocument = (PartDocument)CatApplication.Documents.Item(PreDeletePart.get_PartNumber() + ".CATPart");//直接获取对象--即将被投影的零件
                    //string ImagPath = GetFilePicture.ThumbnailHelper.GetInstance().GetJPGThumbnail(productDocument.FullName,129,129);
                    //ScalePicture.ImageLocation = ImagPath;
                    string ProductPath = productDocument.FullName;
                    ShellFile shellFile = ShellFile.FromFilePath(productDocument.FullName);
                    Bitmap bitmap = shellFile.Thumbnail.LargeBitmap;
                    ScalePicture.Image = bitmap;
                    TopView.Image = bitmap;
                    LeftView.Image = bitmap;
                    BottomView.Image = bitmap;
                    ///////////////////////////////////////////////////////////////////////////
                    PartDocument document = (PartDocument)CatApplication.Documents.Open(ProductPath);
                    Window cwindow = CatApplication.ActiveWindow;
                    Viewer viewer = cwindow.ActiveViewer;
                    Viewer3D viewer3D1 = (Viewer3D)viewer;
                    viewer.FullScreen = false;
                    object[] array = new object[] { 0, 0, 0 };
                    object[] arraySightDirection = new object[] { 0, 0, 0 };
                    Viewpoint3D viewpoint3D = viewer3D1.Viewpoint3D;

                    object[] StdSightDirection = new object[3] {1,0,0};
                    object[] StdUpDirection = new object[3] { 0, 1, 0 };

                    viewer.Reframe();
                    //viewpoint3D.GetOrigin(array);
                    //viewpoint3D.PutOrigin(array);
                    viewpoint3D.PutSightDirection(StdSightDirection);
                    viewpoint3D.PutUpDirection(StdUpDirection);
                    viewpoint3D.ProjectionMode = INFITF.CatProjectionMode.catProjectionCylindric;
                    viewer3D1.Update();
                    viewer3D1.Reframe();
                    viewer3D1.CaptureToFile(CatCaptureFormat.catCaptureFormatJPEG, "C:\\Users\\Administrator\\Desktop\\XProductView.jpeg");
                    //array = new object[3] { 0.0, 12500, 0.0 };
                    //viewpoint3D.PutOrigin(array);
                    //viewer3D1.Update();
                    //viewer3D1.CaptureToFile(CatCaptureFormat.catCaptureFormatJPEG, "C:\\Users\\Administrator\\Desktop\\YProductView.jpeg");
                    //array = new object[3] { 0.0, 0.0,12500.0 };
                    //viewpoint3D.PutOrigin(array);
                    //viewer3D1.Update();
                    //viewer3D1.CaptureToFile(CatCaptureFormat.catCaptureFormatJPEG, "C:\\Users\\Administrator\\Desktop\\ZProductView.jpeg");
                    //viewer.Reframe();
                    ////viewer3D.CaptureToFile(CatCaptureFormat.catCaptureFormatJPEG, "C:\\Users\\Administrator\\Desktop\\ProductView.jpeg");
                    //TopView.ImageLocation = "C:\\Users\\Administrator\\Desktop\\XProductView.jpeg";
                    //LeftView.ImageLocation = "C:\\Users\\Administrator\\Desktop\\YProductView.jpeg";
                    BottomView.ImageLocation = "C:\\Users\\Administrator\\Desktop\\XProductView.jpeg";
                    cwindow.Close();
                    MainWindow.Activate();
                    //Viewers pviewers = productDocument.NewWindow().Viewers;
                    //int Vcont = pviewers.Count;
                    //if (Vcont > 0)
                    //{
                    //    foreach (Viewer item in pviewers)
                    //    {
                    //        item.Activate();
                    //    }
                    //}
                    //pviewer.CaptureToFile(CatCaptureFormat.catCaptureFormatJPEG, "C:\\Users\\Administrator\\Desktop\\PartView.jpeg");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(DeletePartName + " 未成功获取到缩略图！");
                ScalePicture.Image = null;
                TopView.Image = null;
                LeftView.Image = null;
                BottomView.Image = null;
                return;
            }
            try
            {
                PartAttr.Text = GetPartAttrValue(Identificationclass, PreDeletePart);
            }
            catch (Exception)
            {
                MessageBox.Show(DeletePartName + " 未成功获取到指定属性！");
            }
        }

        private void UpdateAttr_Click(object sender, EventArgs e)
        {
            if (UnitPartProductList.SelectedIndex < 0)
            {
                return;
            }
            int DeletePartIndex = UnitPartProductList.SelectedIndex;
            String DeletePartName = UnitPartProductList.SelectedItem.ToString();
            try
            {
                Product PreDeletePart = (Product)vUnitPartProductList[DeletePartIndex];
                if (PreDeletePart.get_PartNumber() == DeletePartName)//核实用户对象和软件队列中对象是一致的
                {
                    try
                    {
                        Parameters parameters = PreDeletePart.ReferenceProduct.UserRefProperties;
                        Parameter parameter = GetParameterFromParameters(Identificationclass, parameters);
                        if (parameter == null)
                        {
                            parameters.CreateString(Identificationclass, PartTypeString);
                        }
                        else
                        {
                            StrParam strParam = (StrParam)parameter;
                            strParam.set_Value(PartTypeString);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("为当前对象更新类别失败！请检查对象是否取消激活！");
                        return;
                    }
                    PartAttr.Text = "对象属性已更新完成！！！";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CreateDraftView_Click(object sender, EventArgs e)
        {
            try
            {
                //读取已经打开的草图
                drawingDocument = (DrawingDocument)CatApplication.Documents.Item("Model.CATDrawing");
            }
            catch (Exception)
            {
                try
                {
                    drawingDocument = (DrawingDocument)CatApplication.Documents.Item(UnitName.Text + ".CATDrawing");
                }
                catch (Exception)
                {
                    try
                    {
                        drawingDocument = (DrawingDocument)CatApplication.Documents.Item(UnitName.Text + "_T" + ".CATDrawing");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("未检索到任何已经打开的草图！请检查！任务已退出！");
                        return;
                    }
                }
            }
            int TotalPages = vUnitPartProductList.Count;
            int CurrentPage = 1;
            progressBar.Value = 0;
            progressBar.Step = 1000 / TotalPages;
            DrawingSheets drawingSheets = drawingDocument.Sheets;
            ProductDocument productDocument = null;
            string vUnitName = UnitName.Text;
            try
            {
                productDocument = (ProductDocument)CatApplication.Documents.Item(vUnitName + ".CATProduct");//直接获取对象--即将被投影的零件
            }
            catch (Exception)
            {
                try
                {
                    Documents CatDocuments = CatApplication.Documents;
                    foreach (Document item in CatDocuments)
                    {
                        string ProductName = item.get_Name();
                        ProductName = ProductName.Split('.')[0];//获取分割段1部分字符
                        ProductName = ProductName.Trim();
                        if (ProductName.Length < vUnitName.Length)
                        {
                            continue;
                        }
                        if (ProductName.Length > vUnitName.Length)
                        {
                            ProductName = ProductName.Remove(vUnitName.Length);//获取指定数量的字符
                        }
                        if (ProductName == vUnitName.Trim())
                        {
                            try
                            {
                                productDocument = (ProductDocument)item;
                                break;
                            }
                            catch (Exception)
                            {

                                //throw;
                            }
                        }

                    }
                    if (productDocument == null)
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(UnitName.Text + "获取单元失败，请检查零件名称和报错名称是否一致！");
                    return;
                }
            }
            foreach (Product CUnitProduct in vUnitPartProductList)
            {
                String ProductName = CUnitProduct.get_PartNumber();
                DrawingSheet drawingSheet = null;
                try
                {
                    drawingSheet = drawingSheets.Item(ProductName);
                    if (drawingSheet == null)
                    {
                        MessageBox.Show(ProductName + "  对象未在草图模板中找到！请检查该对象！");
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(ProductName + "  对象未在草图模板中找到！请检查该对象！");
                    return;
                }
                DrawingViews drawingViews = drawingSheet.Views;
                DrawingView drawingView = drawingViews.Add("AutomaticNaming");
                drawingView.x = 210;
                drawingView.y = 184.5;
                drawingView.Scale = 1.000000;
                DrawingViewGenerativeLinks drawingViewGenerativeLinks = drawingView.GenerativeLinks;//获取对象链接操作接口
                DrawingViewGenerativeBehavior drawingViewGenerativeBehavior = drawingView.GenerativeBehavior;//获取对象视角操作接口
                Products UnitContainer = productDocument.Product.Products;
                Product TargetPart = UnitContainer.Item(CUnitProduct.get_Name());
                drawingView.AlignedWithReferenceView();
                try
                {
                    string dename = CUnitProduct.get_Name();
                    drawingViewGenerativeLinks.AddLink(TargetPart);//将当前视图 关联零件
                    drawingViewGenerativeBehavior.DefineFrontView(-1.000000, 0.000000, 0.000000, 0.000000, 1.000000, 0.000000);
                    drawingViewGenerativeBehavior.Update();//刷新视图 使零件正常显示
                }
                catch (Exception)
                {
                    throw;
                }
                try
                {
                    DrawingView drawingtopView = drawingViews.Add("AutomaticNaming");
                    drawingtopView.x = 210;
                    drawingtopView.y = 33.5;
                    drawingtopView.Scale = 1.000000;
                    DrawingViewGenerativeLinks drawingTopViewGenerativeLinks = drawingtopView.GenerativeLinks;//获取对象链接操作接口
                    DrawingViewGenerativeBehavior drawingTopViewGenerativeBehavior = drawingtopView.GenerativeBehavior;//获取对象视角操作接口
                    drawingTopViewGenerativeLinks.AddLink(TargetPart);//将当前视图 关联零件
                    drawingTopViewGenerativeBehavior.DefineProjectionView(drawingViewGenerativeBehavior, CatProjViewType.catTopView);//设置顶视图投影视角
                    drawingTopViewGenerativeBehavior.Update();//刷新视图 使零件正常显示
                    drawingtopView.AlignedWithReferenceView();
                    drawingtopView.ReferenceView = drawingView;//设置联合关联视图
                }
                catch (Exception)
                {
                    throw;
                }
                try
                {
                    DrawingView drawingtopView = drawingViews.Add("AutomaticNaming");
                    drawingtopView.x = 325;
                    drawingtopView.y = 184.5;
                    drawingtopView.Scale = 1.000000;
                    DrawingViewGenerativeLinks drawingTopViewGenerativeLinks = drawingtopView.GenerativeLinks;//获取对象链接操作接口
                    DrawingViewGenerativeBehavior drawingTopViewGenerativeBehavior = drawingtopView.GenerativeBehavior;//获取对象视角操作接口
                    drawingTopViewGenerativeLinks.AddLink(TargetPart);//将当前视图 关联零件
                    drawingTopViewGenerativeBehavior.DefineProjectionView(drawingViewGenerativeBehavior, CatProjViewType.catLeftView);//设置顶视图投影视角
                    drawingTopViewGenerativeBehavior.Update();//刷新视图 使零件正常显示
                    drawingtopView.AlignedWithReferenceView();
                    drawingtopView.ReferenceView = drawingView;//设置联合关联视图
                }
                catch (Exception)
                {

                    throw;
                }
                CurrentPage += 1;
                progressBar.PerformStep();
                progressBar.Update();//刷新进度条
            }
        }

        private void GetViaPartAtt_Click(object sender, EventArgs e)
        {
            GetUserDrawingMode();
        }
        /// <summary>
        /// 读取用户依旧打开的drawing 文件模板选项
        /// </summary>
        private bool GetUserDrawingMode()
        {
            if (CatApplication == null)
            {
                MessageBox.Show("软件尚未启动！已取消自动检索设置！");
                return false;
            }
            try
            {
                //读取已经打开的草图
                drawingDocument = (DrawingDocument)CatApplication.Documents.Item("Model.CATDrawing");
            }
            catch (Exception)
            {

                return false;
            }
            DrawingSheets drawingSheets = drawingDocument.Sheets;
            ViaIndentification.Clear();//清空有效类型队列准备重新赋值
            PartAttList.Items.Clear();
            for (int i = 0; i < Convert.ToInt32(AttrNumber.Text); i++)
            {
                try
                {
                    string NtypeName = drawingSheets.Item(i).get_Name();
                    PartAttList.Items.Add(NtypeName);
                    ViaIndentification.Add(NtypeName);
                }
                catch (Exception)
                {
                    //throw;
                }
            }
            PartAttList.SelectedIndex = 1;//设置默认值
            return true;
        }

        private void PartAttList_TabIndexChanged(object sender, EventArgs e)
        {
            PartTypeString = PartAttList.SelectedItem.ToString();
        }

        private void SetPartAtt_Click(object sender, EventArgs e)
        {
            UpdataPartAttr();
        }

        private void CheckMetera_Click(object sender, EventArgs e)
        {
            UnFindAttrPartList.Items.Clear();
            ErrPartList.Clear();
            foreach (Product item in vUnitPartProductList)
            {
                string PartName = item.get_PartNumber();
                MaterialManager materialManager = (MaterialManager)item.GetItem("CATMatManagerVBExt");
                Material material = null;
                materialManager.GetMaterialOnProduct(item, out material); //0 Apply the material on the Part ; 1 Apply the material on the Part Body (as a link)
                if (material == null)
                {
                    UnFindAttrPartList.Items.Add(PartName);
                    ErrPartList.Add(item);
                }
            }
            if (UnFindAttrPartList.Items.Count < 1)
            {
                MessageBox.Show("选中的全部零件材料状态已全部正常！");
            }
            /// 
        }

        private void GetmaterialFromDoc_Click(object sender, EventArgs e)
        {
            Documents mDocuments = CatApplication.Documents;
            string MPath = CatApplication.SystemService.Environ("CATStartupPath");
            string sFilePath = MPath + "\\materials\\RF.CATMaterial";
            if (!CatApplication.FileSystem.FileExists(sFilePath))
            {
                MessageBox.Show("未查询到软件默认的材料表");
                return;
            }
            try
            {
                oMaterial_document = (MaterialDocument)CatApplication.Documents.Open(sFilePath);//打开材料表
            }
            catch (Exception)
            {

                MessageBox.Show("默认的材料表打开失败！");
                return;
            }
            MaterialFamilies materialFamilies = oMaterial_document.Families;
            int iNb_families_num = materialFamilies.Count;
            string familiesListName = materialFamilies.Name;
            MaterialFamily materialFamily = materialFamilies.Item(1);
            string FirstFamilyName = materialFamily.get_Name();
            foreach (Material item in materialFamily.Materials)
            {
                MaterialList.Add(item);
                string MaterialName = item.get_Name();
                materialList.Items.Add(MaterialName);
            }
            materialList.SelectedIndex = 1;
            ////oMaterial_document = CatApplication.ActiveDocument;
            //MaterialFamilies MaterialFamilies = (MaterialFamilies)oMaterial_document;
            //int cT = MaterialFamilies.Count;
            //Product product = null;
        }

        private void SetPartmaterial_Click(object sender, EventArgs e)
        {
            int UserSelectedNum = UnFindAttrPartList.SelectedItems.Count;
            if (UserSelectedNum < 1)
            {
                return;
            }
            do
            {
                object item = UnFindAttrPartList.SelectedItems[0];
                try
                {
                    int DeletePartIndex = UnFindAttrPartList.Items.IndexOf(item);//获取对象在原始集合中的索引位置
                    String DeletePartName = item.ToString();//获取指定对象的名称
                    try
                    {
                        Product PreDeletePart = (Product)ErrPartList.Find(x => x.get_PartNumber() == DeletePartName);//根据名称在集合中自由查询到指定对象
                        if (PreDeletePart.get_PartNumber() == DeletePartName)//核实用户对象和软件队列中对象是一致的
                        {
                            try
                            {
                                MaterialManager materialManager = (MaterialManager)PreDeletePart.GetItem("CATMatManagerVBExt");
                                Material material = MaterialList.Find(x => x.get_Name() == materialList.Text);
                                if (material == null)
                                {
                                    MessageBox.Show("从内存中读取读取材料错误！请重新获取材料信息，获请重启软件后尝试！");
                                }
                                materialManager.ApplyMaterialOnProduct(PreDeletePart, material, 0);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("为当前对象创建类别失败！请检查对象是否取消激活！");
                                return;
                            }
                            ErrPartList.Remove(PreDeletePart); //删除用户指定对象
                            UnFindAttrPartList.Items.Remove(UnFindAttrPartList.SelectedItem);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("添加失败，请重新选择！");
                    return;
                }
                UserSelectedNum = UnFindAttrPartList.SelectedItems.Count;
            } while (UserSelectedNum > 0);
            UnFindAttrPartList.SelectedItems.Clear();
            if (UnFindAttrPartList.Items.Count < 1)
            {
                oMaterial_document.Close();//关闭材料表 仅当零件材料赋值完成后关闭
                materialList.Items.Clear();
            }
        }
        /// <summary>
        /// 获取零件的重量信息
        /// </summary>
        /// <param name="product">需要获取重量信息的Product对象</param>
        /// <returns></returns>
        private double WeightFromProduct(Product product)
        {
            Inertia inertia = (Inertia)product.GetTechnologicalObject("Inertia");
            double ProductWeight = inertia.Mass;
            return ProductWeight;
        }

        private void ToBottom_Click(object sender, EventArgs e)
        {
            //Product product = vUnitPartProductList[1];
            //product.CatFileType.catFileTypeHTML, "C:\\Users\\Administrator\\Desktop\\GR.'");
            //AnalysisMaterial analysisMaterial = null;
            //WeightFromProduct(product);
            //DrawingDocument drawingDocument = (DrawingDocument)CatApplication.Documents.Item("0-NW26-W282L-C49-UNIT.CATDrawing");
            //DrawingSheets drawingSheets = drawingDocument.Sheets;
            //DrawingSheet drawingSheet = drawingSheets.Item("0-NW26-W282L-C49-U01-00");
            //DrawingViews drawingViews = drawingSheet.Views;
            //DrawingView drawingView = drawingViews.Item("Isometric view");
            //DrawingViewGenerativeLinks drawingViewGenerativeLinks = drawingView.GenerativeLinks;//获取对象链接操作接口
            //DrawingViewGenerativeBehavior drawingViewGenerativeBehavior = drawingView.GenerativeBehavior;//获取对象视角操作接口
            if (UnitPartProductList.SelectedItems.Count < 1)
            {
                return;
            }
            object Sobj = UnitPartProductList.SelectedItem;
            int Sindex = UnitPartProductList.SelectedIndex;
            if (Sindex > 0)
            {
                UnitPartProductList.Items.Insert(Sindex + 2, Sobj);
                UnitPartProductList.Items.RemoveAt(Sindex);
                UnitPartProductList.SelectedIndex = Sindex + 1;
            }
        }

        private void ExploreIGS_Click(object sender, EventArgs e)
        {
            if (UnitPartProductList.SelectedItems.Count < 1)
            {
                return;
            }
            progressBar.Value = 0;
            progressBar.Step = 1000 / UnitPartProductList.SelectedItems.Count;
            foreach (object item in UnitPartProductList.SelectedItems)
            {
                try
                {
                    int DeletePartIndex = UnitPartProductList.Items.IndexOf(item);//获取对象在原始集合中的索引位置
                    String DeletePartName = item.ToString();//获取指定对象的名称
                    try
                    {
                        Product PreDeletePart = (Product)vUnitPartProductList.Find(x => x.get_PartNumber() == DeletePartName);//根据名称在集合中自由查询到指定对象
                        if (PreDeletePart.get_PartNumber() == DeletePartName)//核实用户对象和软件队列中对象是一致的
                        {
                            try
                            {
                                string Path = CreatePath(UnitName.Text);
                                if (Path == null)
                                {
                                    Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                                }
                                PartDocument partDocument = (PartDocument)CatApplication.Documents.Item(DeletePartName + ".CATPart");
                                string IGSPath = Path + "\\" + DeletePartName + ".igs";
                                partDocument.ExportData(IGSPath, "igs");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("为当前对象创建类别失败！请检查对象是否取消激活！");
                                return;
                            }
                        }
                        progressBar.PerformStep();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("添加失败，请重新选择！");
                    return;
                }
            }
        }

        private void ToTop_Click(object sender, EventArgs e)
        {
            if (UnitPartProductList.SelectedItems.Count < 1)
            {
                return;
            }
            object Sobj = UnitPartProductList.SelectedItem;
            int Sindex = UnitPartProductList.SelectedIndex;
            if (Sindex > 0)
            {
                UnitPartProductList.Items.Insert(Sindex - 1, Sobj);
                UnitPartProductList.Items.RemoveAt(Sindex + 1);
                UnitPartProductList.SelectedIndex = Sindex - 1;
            }

        }
        /// <summary>
        /// 输入文件夹名称 返回对应路径
        /// </summary>
        /// <param name="FileName">需要创建的文件夹名称</param>
        /// <returns>返回对应路径</returns>
        public string CreatePath(string FileName)
        {
            string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string RefDocFilePath = FilePath + "\\" + FileName;
            if (!Directory.Exists(RefDocFilePath))//如果不存在就创建 dir 文件夹 
            {
                try
                {
                    DirectoryInfo directoryinfo = Directory.CreateDirectory(RefDocFilePath);
                    return directoryinfo.FullName;
                }
                catch (Exception)
                {

                    MessageBox.Show("文件夹创建失败！请检查桌面是否做过非法变动或者软件未拿到写入文件夹权限！");
                    return null;
                }
            }
            return RefDocFilePath;
        }
    }
}
