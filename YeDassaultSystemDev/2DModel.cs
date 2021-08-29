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
    public partial class _2DModel : Form
    {
        INFITF.Application CatApplication; //CATIA
        ProductDocument CatDocument;
        Part PartID;
        AnyObject[] GetRepeatRef = new AnyObject[9999];
        CATIA_Class CATIA_Class = new CATIA_Class();
        /// <summary>
        /// 实例化的容器存放单元中零件对象集合
        /// </summary>
        List<Product> UnitPartList = new List<Product>();//实例化容器存放单元中零件对象
        /// <summary>
        /// 实例化的容器存放单元中需要创建2D的零件对象集合
        /// </summary>
        List<Product> vUnitPartProductList = new List<Product>();// 实例化的容器存放单元中需要创建2D的零件对象集合
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////


        int RepeatNum = 0;
        public _2DModel()
        {
            InitializeComponent();
            CATIA_Class.InitCatEnv(ref CatApplication, ref CatDocument, ref PartID, this, true, myMessage);
        }

        private void ReConnectCATIA_Click(object sender, EventArgs e)
        {
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
        }
    }
}
