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
using System.Reflection;
using DNBRobot;
using DNBDevice;
using DNBIgpTagPath;

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
            #region Vision Selection Model
            //if (AllProcess.Length > 1)
            //{
            //    try
            //    {
            //        // MessageBox.Show("当前打开超过1个Delmia,可能操控的Delmia非您需要的对象，请核实！");
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
            #endregion
            try
            {
                DSApplication = (INFITF.Application)Marshal.GetActiveObject("Delmia.Application");
            }
            catch (Exception)
            {
                FM.WindowState = FormWindowState.Normal;
                FM.StartPosition = FormStartPosition.CenterScreen;
                MessageBox.Show("未检测到打开的Delmia!,请重新运行Delmia!_" + AllProcess.Length);
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
        public Selection GetInitTargetProduct(Form FM, DataType.Dsystem DSystem, int dType = 9, string Msg = "请选择初始化对象")
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
        public Selection GetIRobotMotion(Form FM, DataType.Dsystem DSystem, int SelectType = 9, string Mess = "请选择一个机器人")
        {
            FM.WindowState = FormWindowState.Minimized;
            INFITF.Application CatApplication = DSystem.DSApplication;
            Selection USelect = null;
            try
            {
                ProcessDocument PPRP = DSystem.DSActiveDocument;
                if (PPRP == null)
                {
                    USelect = DSystem.CDSActiveDocument.Selection;
                }
                else
                {
                    USelect = PPRP.Selection;
                }
            }
            catch (Exception)
            {


            }
            USelect.Clear();
            var Result = USelect.SelectElement2(DataType.InputObjectType(SelectType), Mess, true);
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
        public void CreateRobotMoto(Form FM, DataType.Dsystem DSystem, Product product, String RobotName, ProgressBar progressBar, bool CreateCable = false)
        {
            Workbench TheKinWorkbench = DSystem.CDSActiveDocument.GetWorkbench("KinematicsWorkbench");
            Mechanisms cTheMechanisms = null;
            try
            {
                cTheMechanisms = (Mechanisms)product.GetTechnologicalObject("Mechanisms");
                if (cTheMechanisms.Count > 1) //当对象运动机构数量>1时 清除全部机构对象
                {
                    foreach (Mechanism item in cTheMechanisms)
                    {
                        cTheMechanisms.Remove(item); //Clear All Mechanisms 
                    }
                }
            }
            catch (Exception)
            {
                //选定的对象不存在任何运动机构
            }
            //BasicDevice basicDevice = (BasicDevice)product.GetTechnologicalObject("BasicDevice");
            //Mechanisms TheMechanismsList = TheKinWorkbench.Mechanisms;
            RobGenericController Rgcr = (RobGenericController)product.GetTechnologicalObject("RobGenericController");
            RobControllerFactory CRM = (RobControllerFactory)product.GetTechnologicalObject("RobControllerFactory");
            GenericMotionProfile genericMotion = null;
            int ProfileCount = 0;
            Rgcr.GetMotionProfileCount(out ProfileCount);
            if (ProfileCount > 0)
            {
                string ProfileName = "DNBRobController";
                Rgcr.GetMotionProfile(ProfileName, out genericMotion);
            }
            InitController(Rgcr, CRM, 10, progressBar);
            Mechanism mechanism = cTheMechanisms.Add();
            //mechanism.FixedPart=
            ///RefDocument//mk:@MSITStore:F:\02%20我的知识库\05%20学习&总结资料\01%20CAA开发资料\V5Automation.chm::/online/CAAScdDmuUseCases/CAAKiiMechanismCreationSource.htm                 
            //string GetName = CRM.get_Name();
        }
        /// <summary>
        /// 清空机器人Home预制坐标信息_Yecc
        /// </summary>
        /// <param name="FM"></param>
        /// <param name="DSystem"></param>
        /// <param name="product"></param>
        /// <param name="RobotName"></param>
        /// <param name="progressBar"></param>
        /// <param name="CreateCable"></param>
        public void ClearRobotHomeList(Form FM, DataType.Dsystem DSystem, Product product, String RobotName, ProgressBar progressBar, bool CreateCable = false)
        {
            //Workbench TheKinWorkbench = DSystem.CDSActiveDocument.GetWorkbench("KinematicsWorkbench");
            Mechanisms cTheMechanisms = null;
            Selection selection = DSystem.CDSActiveDocument.Selection;
            selection.Clear();
            try
            {
                BasicDevice basicDevice = (BasicDevice)product.GetTechnologicalObject("BasicDevice");
                System.Array homePositions=null; 
                for (int i = 0; i < 100; i++)
                {
                    object[] HomePos = {0,0,0,0,0,0 };
                    basicDevice.SetHomePosition("RobotHome_" + i, HomePos);
                }
                basicDevice.GetHomePositions(out homePositions);
                int HomePosNum = homePositions.Length;
                if (HomePosNum > 1) //当对象运动机构数量>1时 清除全部机构对象
                {
                    foreach (HomePosition homePosition in homePositions)
                    {
                        //Array AtoolTip = null;
                        //homePosition.GetAssociatedToolTip(out AtoolTip);
                        //selection.Add(item);

                    }
                    selection.Delete();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+";请在帮助-》问题反馈与建议中反馈该问题，谢谢!");
                //选定的对象不存在任何运动机构
            }
            //Mechanisms TheMechanismsList = TheKinWorkbench.Mechanisms;
            RobGenericController Rgcr = (RobGenericController)product.GetTechnologicalObject("RobGenericController");
            RobControllerFactory CRM = (RobControllerFactory)product.GetTechnologicalObject("RobControllerFactory");
            GenericMotionProfile genericMotion = null;
            int ProfileCount = 0;
            Rgcr.GetMotionProfileCount(out ProfileCount);
            if (ProfileCount > 0)
            {
                string ProfileName = "DNBRobController";
                Rgcr.GetMotionProfile(ProfileName, out genericMotion);
            }
            InitController(Rgcr, CRM, 10, progressBar);
            Mechanism mechanism = cTheMechanisms.Add();
            //mechanism.FixedPart=
            ///RefDocument//mk:@MSITStore:F:\02%20我的知识库\05%20学习&总结资料\01%20CAA开发资料\V5Automation.chm::/online/CAAScdDmuUseCases/CAAKiiMechanismCreationSource.htm                 
            //string GetName = CRM.get_Name();
        }
        private void InitController(RobGenericController Rgcr, RobControllerFactory CRM, int RobotCtrlNum, ProgressBar Pbar)
        {
            #region 机器人基本TCP Motion初始化
            // Rgcr.moti
            String GetName = string.Empty;
            GetName = CRM.get_Name();
            for (int i = 1; i <= RobotCtrlNum; i++)
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
                Pbar.PerformStep();
                /////////////////////////////////////////////////////////////////////
                CRM.CreateGenericObjFrameProfile(out GOP);
                GOP.SetObjectFrame(0, 0, 0, 0, 0, 0);
                GOP.SetName("Object_0" + i);
                Rgcr.HasObjFrameProfile(("Object_0" + i), out ExistsObject);
                if (!ExistsObject)
                {
                    Rgcr.AddObjFrameProfile(GOP);
                }
                Pbar.PerformStep();
                /////////////////////////////////////////////////////////////////////
                CRM.CreateGenericMotionProfile(out GMP);
                GMP.SetSpeedValue(i * 0.1);
                GMP.SetName(i * 10 + "%");
                GMP.SetMotionBasis(MotionBasis.MOTION_PERCENT);
                Rgcr.HasMotionProfile((i * 10 + "%"), out ExistsObject);
                if (!ExistsObject)
                {
                    Rgcr.AddMotionProfile(GMP);
                }
                Pbar.PerformStep();
                /////////////////////////////////////////////////////////////////////
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
                Pbar.PerformStep();
            }
            #endregion
            #region 机器人默认值设置
            //Init Current Motion Profile \accuracy \ Tool Profile \Object
            bool ExistsObj;
            Rgcr.HasAccuracyProfile((100 + "%"), out ExistsObj);
            if (ExistsObj)
            {
                Rgcr.SetCurrentAccuracyProfile((100 + "%"));
            }
            Rgcr.HasObjFrameProfile("Object_01", out ExistsObj);
            if (ExistsObj)
            {
                Rgcr.SetCurrentObjFrameProfile("Object_01");
            }
            Rgcr.HasMotionProfile((100 + "%"), out ExistsObj);
            if (ExistsObj)
            {
                Rgcr.SetCurrentMotionProfile((100 + "%"));
            }
            Rgcr.HasToolProfile("Tool_01", out ExistsObj);
            if (ExistsObj)
            {
                Rgcr.SetCurrentToolProfile("Tool_01");
            }
            #endregion
            #region 机器日Taglist目录及RobotTask批量设置
            //RobotTaskFactory Rtf = (RobotTaskFactory)Usp.GetTechnologicalObject("RobotTaskFactory");
            object[] RobotTaskLists = new object[99];
            //try
            //{
            //    Rtf.GetAllRobotTasks(RobotTaskLists);
            //}
            //catch (Exception)
            //{
            //    RobotTaskLists = null;
            //}
            //GetName = Rtf.get_Name();
            Pbar.PerformStep();
            #endregion
            object[] RTask = new object[50];
            // Rtf.GetAllRobotTasks(RTask);
            foreach (RobotTask item in RTask)
            {
                if (item != null)
                {
                    item.set_Description("安徽瑞祥工业自动化产品，机器人轨迹,创建于:" + DateTime.Now);
                }
            }
        }
        public void SetRobotFixMechanism(Form FM, INFITF.Document document, Mechanism mechanism)
        {
            Selection Uselect = GetInitTargetProduct(FM, document, "请选择固定的对象!");
            if (Uselect == null)
            {
                return;
            }
            mechanism.FixedPart = (Product)Uselect.Item(1).Value;

            Uselect = GetInitTargetProduct(FM, document, "请选择固联的对象!", true);
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
