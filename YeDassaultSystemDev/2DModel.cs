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
            Product UnitPart = null;//单元对象
            Products UnitPartProducts = null;//零件集合
            try
            {
                UnitPart = (Product)SelectArc.Item(1).Value;
                UnitName.Text = UnitPart.get_PartNumber();
                UnitPartProducts = UnitPart.Products;
            }
            catch (Exception)
            {
                myMessage.Text = "所选择的对象非单元集合请重新选择！";
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.TopMost = true;
                return;
            }
            foreach (var item in UnitPart.Products)
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
                MessageBox.Show("！");
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
            foreach (Product CUnitProduct in vUnitPartProductList)
            {
                //根据零件属性名称 创建2D图框 草图 
                string CUnitProductName = CUnitProduct.get_PartNumber();
                Parameters parameters = CUnitProduct.ReferenceProduct.UserRefProperties;
                StrParam strParam = (StrParam)parameters.GetItem(Identificationclass);
                string CunitType = strParam.ValueAsString();
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
                            double PartWeight = WeightFromProduct(CUnitProduct);
                            PartWeight = Math.Round(PartWeight, 3);
                            string Wtext = PartWeight + "kg";
                            drawingText.set_Text(Wtext);
                            //更新当前页数
                            drawingText = (DrawingText)drawingTexts.GetItem("TitleBlock_Text_SHEET_Num");
                            DRAWING_Num = drawingText.get_Text();
                            NewText = "第" + CurrentPage + "张" + "\r\n" + "Page No.";
                            drawingText.set_Text(NewText);
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
                string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string RefDocFilePath = FilePath + "\\" + UnitName.Text + ".CATDrawing";
                if (!CatApplication.FileSystem.FileExists(RefDocFilePath))
                {
                    CatApplication.DisplayFileAlerts = false;
                    drawingDocument.SaveAs(RefDocFilePath);
                    CatApplication.DisplayFileAlerts = true;
                }
                else
                {
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
            } while (UnFindAttrPartList.SelectedItems.Count > 1);
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
            try
            {
                Product PreDeletePart = (Product)vUnitPartProductList[DeletePartIndex];
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
                MessageBox.Show(DeletePartName + " 未成功获取到缩略图！");
                return;
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

                MessageBox.Show("未检索到任何已经打开的草图！请检查！任务已退出！");
                return;
            }
            int TotalPages = vUnitPartProductList.Count;
            int CurrentPage = 1;
            progressBar.Step = 1000 / TotalPages;
            DrawingSheets drawingSheets = drawingDocument.Sheets;
            ProductDocument productDocument = (ProductDocument)CatApplication.Documents.Item(UnitName.Text + ".CATProduct");//直接获取对象--即将被投影的零件
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
                try
                {
                    string dename = CUnitProduct.get_Name();
                    drawingViewGenerativeLinks.AddLink(TargetPart);//将当前视图 关联零件
                    drawingViewGenerativeBehavior.DefineFrontView(0.000000, -1.000000, 0.000000, -1.000000, 0.000000, 0.000000);
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
                }
                catch (Exception)
                {

                    throw;
                }
                try
                {
                    DrawingView drawingtopView = drawingViews.Add("AutomaticNaming");
                    drawingtopView.x = 325;
                    drawingtopView.y = 148;
                    drawingtopView.Scale = 1.000000;
                    DrawingViewGenerativeLinks drawingTopViewGenerativeLinks = drawingtopView.GenerativeLinks;//获取对象链接操作接口
                    DrawingViewGenerativeBehavior drawingTopViewGenerativeBehavior = drawingtopView.GenerativeBehavior;//获取对象视角操作接口
                    drawingTopViewGenerativeLinks.AddLink(TargetPart);//将当前视图 关联零件
                    drawingTopViewGenerativeBehavior.DefineProjectionView(drawingViewGenerativeBehavior, CatProjViewType.catLeftView);//设置顶视图投影视角
                    drawingTopViewGenerativeBehavior.Update();//刷新视图 使零件正常显示
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
            UnFindAttrPartList.SelectedItems.Clear();
            CheckPartList();
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
                                    MessageBox.Show("从内存中读取读取材料错误！请重启软件后尝试！");
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
            //string Name = product.get_PartNumber();
            //WeightFromProduct(product);
        }
    }
}
