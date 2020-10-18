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
using WindowsAPI_Interface;
using System.Web;
using DNBFastener;

namespace YeDassaultSystemDev
{
    class CATIA_Class
    {
        #region GetObj
        static void GetObj(int i, String progID)
        {
            Object obj = null;

            Console.WriteLine("\n" + i + ") Object obj = GetActiveObject(\"" + progID + "\")");
            try
            { obj = Marshal.GetActiveObject(progID); }
            catch (Exception e)
            {
                Write2Console("\n   Failure: obj did not get initialized\n" +
                              "   Exception = " + e.ToString().Substring(0, 43), 0);
            }

            if (obj != null)
            { Write2Console("\n   Success: obj = " + obj.ToString(), 1); }
        }
        static void Write2Console(String s, int color)
        {
            Console.ForegroundColor = color == 1 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        #endregion


        #region 初始化CATIA环境并获取信息到全局变量 
        /// <summary>
        /// 初始化CATIA环境并获取信息到全局变量 
        /// </summary>
        /// <param name="CatApplication">CATIA程序框架</param>
        /// <param name="CatDocument">CATIA 活动文档</param>
        /// <param name="PartID">CATIA 零件目标</param>
        /// <param name="form">当前活动窗口</param>
        /// <returns></returns>
        public bool InitCatEnv(ref INFITF.Application CatApplication, ref ProductDocument CatDocument, ref Part PartID, Form form)
        {
            Process[] AllProcess = Process.GetProcessesByName("CNEXT"); //Only When Get CATIA Process
            form.TopMost = false;
            // Process[] AllProcess = Process.GetProcessesByName("Delmia");
            //if (AllProcess.Length > 1)
            //{
            //    try
            //    {
            //        WAPI wAPI = new WAPI();
            //        AllProcess[0].WaitForInputIdle();
            //        string MainWintitle = AllProcess[0].MainWindowTitle;
            //        int MainPID = AllProcess[0].Id;
            //        IntPtr intPtr = AllProcess[0].MainWindowHandle;
            //        IntPtr intPtr2 = WAPI.FindWindow(null, MainWintitle);
            //        // CatApplication = (INFITF.Application)AllProcess[0].CreateObjRef(INFITF.Application);
            //        var application = Marshal.GetObjectForNativeVariant(intPtr);
            //        CatApplication = (INFITF.Application)application;
            //        string CapName1 = CatApplication.get_Caption();
            //        CatApplication.set_Caption("正在运行瑞祥快速建模工具！瑞祥快捷设计中心 BY_安徽瑞祥工业【工厂仿真组】叶朝成");
            //        AllProcess[1].WaitForInputIdle();
            //        IntPtr ProgHandle = AllProcess[1].Handle;
            //        //CatApplication = (INFITF.Application)Marshal.GetObjectForNativeVariant(ProgId);
            //        string CapName2 = CatApplication.get_Caption();
            //        //MessageBox.Show("当前打开超过1个CATIA,可能操控的CATIA非您需要的对象，请核实！");
            //        //GetObj(1, "Catia.Application");
            //        //GetObj(2, "Delmia.Application");
            //        // IntPtr Ptr = AllProcess[2].MainWindowHandle;
            //        // string Pname = AllProcess[2].MainWindowTitle;
            //        //  int progid=  AllProcess[2].;
            //        // object Pobj = Marshal.GetActiveObject("Delmia.Application");
            //        //// object Tobj = Marshal.GetObjectForIUnknown(ptr2);
            //        // object Pobj0 = Marshal.GetActiveObject(progid.ToString());
            //        // DSApplication = (INFITF.Application)Pobj;
            //        // String tn = DSApplication.get_Caption();
            //    }
            //    catch (Exception)
            //    {
            //        throw;
            //    }
            //}
            try
            {
                CatApplication = (INFITF.Application)Marshal.GetActiveObject("Catia.Application");
            }
            catch (Exception)
            {
                form.WindowState = FormWindowState.Normal;
                form.StartPosition = FormStartPosition.CenterScreen;
                MessageBox.Show("未检测到打开的CATIA!,请重新运行CATIA!");
                return false;
                //throw;
            }
            try
            {
                string path = CatApplication.SystemService.Environ("CATTemp");
                CatApplication.set_Caption("正在运行瑞祥快速建模工具！瑞祥快捷设计中心 BY_安徽瑞祥工业【工厂仿真组】叶朝成");
                string GunPath = CatApplication.FileSelectionBox("请选择焊枪", "*.cgr;*.wrl;*.CATPart", CatFileSelectionMode.CatFileSelectionModeSave);
            }
            catch (Exception)
            {
                throw;
            }
            // 获取当前活动ProductDocument
            try
            {
                CatDocument = (ProductDocument)CatApplication.ActiveDocument;
            }
            catch (Exception)
            {
                CatDocument = (ProductDocument)CatApplication.Documents.Add("Product");
                try
                {
                    CatDocument.Product.set_PartNumber("RxProduct");
                }
                catch (Exception)
                {
                    MessageBox.Show("未检测到活动Product,正在为您创建，请手动辅助完成！");
                    return false;
                }
                //MessageBox.Show("未检测到活动Product,已自动为您创建对象！");
            }
            try
            {
                CatDocument.Product.ApplyWorkMode(CatWorkModeType.DESIGN_MODE);
            }
            catch (Exception)
            {
                Console.WriteLine("Change Design Model Faild!");
            }
            Selection selection = CatDocument.Selection;
            selection.Clear();
            CreatWorkPart(CatApplication, CatDocument, ref PartID); //Get New Part For Work
            return true;
        }
        /// <summary>
        /// 创建一个工作用的Part 文件
        /// </summary>
        /// <param name="CatApplication">CATIA程序框架</param>
        /// <param name="CatDocument">CATIA 活动文档</param>
        /// <param name="PartID">待创建的CATIA 零件目标</param>
        public void CreatWorkPart(INFITF.Application CatApplication, ProductDocument CatDocument, ref Part PartID)
        {
            // 添加一个新零件
            string Name = "RXFastDesignTool";
            try
            {
                PartID = ((PartDocument)CatApplication.Documents.Item(Name + ".CATPart")).Part;
            }
            catch (Exception)
            {
                try
                {
                    CatDocument.Product.Products.AddNewComponent("Part", Name);
                    PartID = ((PartDocument)CatApplication.Documents.Item(Name + ".CATPart")).Part;
                }
                catch (Exception)
                {
                    return;
                    // throw;
                }
            }
            HybridBodies HBS = PartID.HybridBodies;
            if (HBS.Count < 1)
            {
                HybridBody HB = HBS.Add();
                HB.set_Name("Geometrical Set.1");
            }
            OriginElements Tpart = PartID.OriginElements;
            AnyObject dxy = Tpart.PlaneXY;
            AnyObject dyz = Tpart.PlaneYZ;
            AnyObject dzx = Tpart.PlaneZX;
            Selection SelectT = CatDocument.Selection;
            VisPropertySet VP = SelectT.VisProperties;
            SelectT.Add(dxy);
            SelectT.Add(dyz);
            SelectT.Add(dzx);
            VP = (VisPropertySet)VP.Parent;
            VP.SetShow(CatVisPropertyShow.catVisPropertyNoShowAttr);
            SelectT.Clear();
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region 获得用户选择集
        /// <summary>
        /// 获得用户选择集
        /// </summary>
        /// <returns></returns>
        public void GetSelect(ProductDocument CatDocument, ref Selection SelectArc, Form form)
        {
            if (CatDocument == null)
            {
                MessageBox.Show("仿真环境未初始化！请先用工具栏初始化命令初始化运行环境!");
                return;
            }
            form.WindowState = FormWindowState.Minimized;
            SelectArc = CatDocument.Selection;
            SelectArc.Clear();
            var Result = SelectArc.SelectElement3(InputObjectType(4), "请选择曲面", true, CATMultiSelectionMode.CATMultiSelTriggWhenSelPerf, false);
            if (Result == "Cancel")
            {
                return;
            }
            if (SelectArc.Count < 1)
            {
                MessageBox.Show("请先选择对象后再点此命令！");
                return;
            }
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterScreen;

            return;

        }
        [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)]
        private object[] InputObjectType(int ReadType)
        {
            switch (ReadType)
            {
                case 1: //GetPoint
                    {
                        return new object[] { "Point", "Symmetry", "Translate" };
                    }
                case 2: //GetAnyObject
                    {
                        return new object[] { "AnyObject" };
                    }
                case 3: //SketchBasedShape 
                    {
                        return new object[] { "Sweep", "prisms", "holes", "revolutions" };
                    }
                case 4: //BooleanShape  
                    {
                        return new object[] { "Fastener", "FastenerGroup", "HybridShape", "Shape" };
                    }
                case 5: //BooleanShape  
                    {
                        return new object[] { "HybridShape", "Shape", "Body" };
                    }
                default:
                    return new object[] { "AnyObject" };
            }
        }
        #endregion
    }
}
