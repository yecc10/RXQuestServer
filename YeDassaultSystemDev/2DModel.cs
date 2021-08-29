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
        List<string> ViaIndentification = new List<string> { "定位块", "连接块", "脚座", "压紧块", "压臂", "销座", "Base" };
        /// <summary>
        /// 3D零件有效类别
        /// </summary>
        enum ViaIndentificationEnum
        {
            定位块
                , 连接块
                , 脚座
                , 压紧块
                , 压臂
                , 销座
                , Base
        }
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
        DrawingDocument drawingDocument = null;

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////

        int RepeatNum = 0;
        public _2DModel()
        {
            InitializeComponent();
            CATIA_Class.InitCatEnv(ref CatApplication, ref CatDocument, ref PartID, this, true, myMessage);
        }
        private void Read3DPose_Click(object sender, EventArgs e)
        {
            PartlistBox.Items.Clear(); //清空当前列表
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

        private void Create2DDrawing_Click(object sender, EventArgs e)
        {
            // 直接使用模板 不再重新创建
            //try
            //{
            //    drawingDocument = (DrawingDocument)CatApplication.Documents.Add("Drawing");//创建2D草绘
            //    string FilePath = CatDocument.Path;
            //    if (string.IsNullOrEmpty(FilePath))
            //    {
            //        FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //    }
            //    CatApplication.DisplayFileAlerts = false;
            //    drawingDocument.SaveAs(FilePath + "\\" + UnitName.Text + ".CATDrawing");
            //    CatApplication.DisplayFileAlerts = true;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("创建草绘 草图失败！请重启软件重试！");
            //    return;
            //}
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
            DrawingSheets drawingSheets = drawingDocument.Sheets;
            foreach (Product item in vUnitPartProductList)
            {
                //根据零件属性名称 创建2D图框 草图

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
                bool Find = false;
                foreach (Parameter item in parameters)
                {
                    string ParamName = item.get_Name();
                    string[] StrName = ParamName.Split(new char[1] { '\\' });
                    ParamName = StrName[2];
                    //string ParamName = item.ValueAsString(); 获取属性值
                    if (ParamName == Identificationclass)
                    {
                        string ParamValue = item.ValueAsString(); //获取属性值
                        if (ViaIndentification.IndexOf(ParamValue) > 0) //检查零件的值是否属于合法范围
                        {
                            Find = true;
                            continue;
                        }
                    }
                }
                if (!Find)
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
                //StrParam strParam = parameters.CreateString("类型", "定位块");
            }
            if (UnFindAttrPartList.Items.Count < 1)
            {
                MessageBox.Show("当前零件全部正常！");
            }
        }
        private void UnFindAttrPartList_Click(object sender, EventArgs e)
        {
            if (UnFindAttrPartList.SelectedIndex < 0)
            {
                return;
            }
            int DeletePartIndex = UnFindAttrPartList.SelectedIndex;
            String DeletePartName = UnFindAttrPartList.SelectedItem.ToString();
            try
            {
                Product PreDeletePart = (Product)ErrPartList[DeletePartIndex];
                if (PreDeletePart.get_PartNumber() == DeletePartName)//核实用户对象和软件队列中对象是一致的
                {
                    try
                    {
                        Parameters parameters = PreDeletePart.ReferenceProduct.UserRefProperties;
                        parameters.CreateString(Identificationclass, "连接块");
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

        private void UnitPartProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PartAttr
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
                        StrParam strParam = (StrParam)parameters.GetItem(Identificationclass);
                        PartAttr.Text = strParam.ValueAsString();
                    }
                    catch (Exception)
                    {
                        PartAttr.Text = "读取选择的对象属性失败，未检测到对象存在有效属性请在左侧对其进行定义！！！";
                        return;
                    }
                }
            }
            catch (Exception)
            {
                PartAttr.Text = "对象属性获取失败！！！";
            }
        }
    }
}
