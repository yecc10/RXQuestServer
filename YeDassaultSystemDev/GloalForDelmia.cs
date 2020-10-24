using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Windows.Forms;
using PROCESSITF;
using PPR;
using NPOI.POIFS.Crypt.Dsig;
using NPOI.XWPF.UserModel;
using KinTypeLib;

namespace YeDassaultSystemDev
{
    class GloalForDelmia
    {
        /// <summary>
        /// 初始化软件环境及全局变量
        /// </summary>
        /// <param name="FM">当前From</param>
        /// <param name="SoftTarget">Catia/Delmia</param>
        /// <returns></returns>
        public DataType.Dsystem InitCatEnv(Form FM)
        {
            DataType.Dsystem Dsvalue = new DataType.Dsystem();
            INFITF.Application DSApplication;
            Documents DSDocument;
            INFITF.Document CDSActiveDocument;
            ProcessDocument DSActiveDocument;
            Process[] AllProcess = Process.GetProcessesByName("DELMIA");
            if (AllProcess.Length > 1)
            {
                try
                {
                    // MessageBox.Show("当前打开超过1个Delmia,可能操控的Delmia非您需要的对象，请核实！");
                    // IntPtr Ptr = AllProcess[2].MainWindowHandle;
                    // string Pname = AllProcess[2].MainWindowTitle;
                    //  int progid=  AllProcess[2].;
                    // object Pobj = Marshal.GetActiveObject("Delmia.Application");
                    //// object Tobj = Marshal.GetObjectForIUnknown(ptr2);
                    // object Pobj0 = Marshal.GetActiveObject(progid.ToString());
                    // DSApplication = (INFITF.Application)Pobj;
                    // String tn = DSApplication.get_Caption();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            try
            {
                DSApplication = (INFITF.Application)Marshal.GetActiveObject("Delmia.Application");
            }
            catch (Exception)
            {
                FM.WindowState = FormWindowState.Normal;
                FM.StartPosition = FormStartPosition.CenterScreen;
                MessageBox.Show("未检测到打开的Delmia!,请重新运行Delmia!");
                Dsvalue.Revalue = -1;
                return Dsvalue;
                //throw;
            }
            try
            {
                DSApplication.set_Caption("正在运行瑞祥快速建模工具！");
            }
            catch (Exception)
            {

              //  throw;
            }
            // 获取当前活动ProductDocument
            try
            {
                DSDocument = (Documents)DSApplication.Documents;
                CDSActiveDocument = DSApplication.ActiveDocument;
                try
                {
                    DSActiveDocument = (ProcessDocument)CDSActiveDocument;
                }
                catch (Exception)
                {
                    DSActiveDocument = null;
                    //throw;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("未检测到活动Product,正在为您创建，请手动辅助完成！");
                Dsvalue.Revalue = -1;
                return Dsvalue;
                //MessageBox.Show("未检测到活动Product,已自动为您创建对象！");
            }
            // 添加一个新零件
            Dsvalue.DSApplication = DSApplication;
            Dsvalue.DSDocument = DSDocument;
            Dsvalue.DSActiveDocument = DSActiveDocument;
            Dsvalue.CDSActiveDocument = CDSActiveDocument;
            Dsvalue.Revalue = 0;
            return Dsvalue;
        }
        /// <summary>
        /// Delmia 在仿真示教模式下使用
        /// </summary>
        /// <param name="FM"></param>
        /// <param name="DSystem"></param>
        /// <returns></returns>
        public Selection GetInitTargetProduct(Form FM, DataType.Dsystem DSystem,int dType=9, string Msg = "请选择初始化对象")
        {
            FM.WindowState = FormWindowState.Minimized;
            ProcessDocument PPRP = DSystem.DSActiveDocument;
            Selection USelect = null;
            if (PPRP == null)
            {
                return null;
            }
            USelect = PPRP.Selection;
            USelect.Clear();
            var Result = USelect.SelectElement2(DataType.InputObjectType(dType), Msg, true);
            if (Result == "Cancel")
            {
                return null;
            }
            if (USelect.Count < 1)
            {
                MessageBox.Show("请先选择对象后再点此命令！");
                return null;
            }
            return USelect;
        }
        /// <summary>
        /// Delmia 在非仿真示教模式下使用
        /// </summary>
        /// <param name="FM">当前窗口</param>
        /// <param name="DelmiaDocument">DelmiaDocument</param>
        /// <returns></returns>
        public Selection GetInitTargetProduct(Form FM, INFITF.Document DelmiaDocument, string Msg = "请选择初始化对象", bool MultSelect = false)
        {
            FM.WindowState = FormWindowState.Minimized;
            INFITF.Document PPRP = DelmiaDocument;
            Selection USelect = null;
            if (PPRP == null)
            {
                return null;
            }
            USelect = PPRP.Selection;
            USelect.Clear();
            string Result;
            if (MultSelect)
            {
                Result = USelect.SelectElement3(DataType.InputObjectType(9), Msg, true, CATMultiSelectionMode.CATMultiSelTriggWhenUserValidatesSelection, false);
            }
            else
            {
                Result = USelect.SelectElement2(DataType.InputObjectType(9), Msg, true);
            }
            if (Result == "Cancel")
            {
                return null;
            }
            if (USelect.Count < 1)
            {
                MessageBox.Show("请先选择对象后再点此命令！");
                return null;
            }
            return USelect;
        }
        public Selection GetIRobotMotion(Form FM, DataType.Dsystem DSystem)
        {
            FM.WindowState = FormWindowState.Minimized;
            INFITF.Application CatApplication = DSystem.DSApplication;
            ProcessDocument PPRP = DSystem.DSActiveDocument;
            Selection USelect = PPRP.Selection;
            USelect.Clear();
            var Result = USelect.SelectElement2(DataType.InputObjectType(9), "请选择一个机器人", true);
            if (Result == "Cancel")
            {
                return null;
            }
            if (USelect.Count < 1)
            {
                MessageBox.Show("请先选择对象后再点此命令！");
                return null;
            }
            return USelect;
        }
        public void SetRobotFixMechanism(Form FM, INFITF.Document document, Mechanism mechanism)
        {
            Selection Uselect = GetInitTargetProduct(FM, document, "请选择固定的对象!");
            if (Uselect == null)
            {
                return;
            }
            mechanism.FixedPart = (Product)Uselect.Item(1).Value;

            Uselect = GetInitTargetProduct(FM, document, "请选择固联的对象!",true);
            if (Uselect == null)
            {
                return;
            }
            try
            {
                Reference reference = Uselect.Item(1).Reference;
                Reference reference1 = Uselect.Item(2).Reference;
                AnyObject[] RefenceObject = new AnyObject[] { reference, reference1 };
                Joint joint = mechanism.AddJoint("CATKinRigidJoint", RefenceObject);
                mechanism.Update();
            }
            catch (Exception)
            {
                throw;
            }   
        }
    }
}
