#region 程序头文件集 // Create by Yechaocheng with 20201212
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
#endregion
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
        public string GetProductPath(Product Tproduct, DataType.Dsystem DStype)
        {
            Documents CatDocuments = DStype.DSDocument;
            String Path = string.Empty;
            String SPath = string.Empty;
            String Name = Tproduct.get_PartNumber();
            //String NwProductName = Name + "_Fixture";
            try
            {
                ProductDocument DSPD = (ProductDocument)CatDocuments.Item(Name + ".CATProduct");
                string cPath = DSPD.Path;
                return cPath;
            }
            catch (Exception)
            {
                //
            }
            return null;
        }
        public ProductDocument GetProductPath(Product Tproduct, DataType.Dsystem DStype, bool Value = false)
        {
            Documents CatDocuments = DStype.DSDocument;
            String Path = string.Empty;
            String SPath = string.Empty;
            String Name = Tproduct.get_PartNumber();
            //String NwProductName = Name + "_Fixture";
            try
            {
                ProductDocument DSPD = (ProductDocument)CatDocuments.Item(Name + ".CATProduct");
                return DSPD;
            }
            catch (Exception)
            {
                //
            }
            return null;
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
            ProductDocument partDocument = GetProductPath(product, DSystem, false);
            Selection selection = partDocument.Selection;
            selection.Clear();
            try
            {
                BasicDevice basicDevice = (BasicDevice)product.GetTechnologicalObject("BasicDevice");
                System.Array homePositions = null;
                //for (int i = 0; i < 100; i++) // add New Robot Home Position
                //{
                //    object[] HomePos = { 0, 0, 0, 0, 0, 0 };
                //    basicDevice.SetHomePosition("RobotHome_" + i, HomePos);
                //}
                basicDevice.GetHomePositions(out homePositions);
                int HomePosNum = homePositions.Length;
                if (HomePosNum > 1) //当对象运动机构数量>1时 清除全部机构对象
                {
                    foreach (HomePosition homePosition in homePositions)
                    {
                        selection.Add(homePosition);
                        //Array AtoolTip = null;
                        //homePosition.GetAssociatedToolTip(out AtoolTip);
                        //selection.Add(homePosition);

                    }
                    selection.Delete();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ";请在帮助-》问题反馈与建议中反馈该问题，谢谢!");
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
        /// <summary>
        /// 对机器人程序进行操作
        /// </summary>
        /// <param name="FM"></param>
        /// <param name="robotTask"></param>
        /// <param name="listBoxMain"></param>
        /// <param name="listBoxTarget"></param>
        /// <param name="Pbar"></param>
        public void ReadTaskTagList(Form FM, RobotTask robotTask, ListBox listBoxMain, ListBox listBoxTarget, ProgressBar Pbar, ref List<Tag> tagList, ref List<Tag> viatagList, ref List<Tag> processtagList)
        {
            listBoxMain.Items.Clear();
            listBoxTarget.Items.Clear();
            tagList.Clear();
            viatagList.Clear();
            processtagList.Clear();
            if (robotTask.ChildrenActivities.Count < 1)
            {
                Pbar.Maximum = 100;
                Pbar.Value = 100;
                Pbar.Step = 1;
                return;
            }
            Pbar.Value = 0;
            //List<Tag> tagList = new List<Tag>(); // Init A container to Save Target Tag List
            //List<Tag> viatagList = new List<Tag>(); // Init A container to Save Target Tag List
            //List<Tag> processtagList = new List<Tag>(); // Init A container to Save Target Tag List
            Pbar.Maximum = robotTask.ChildrenActivities.Count;
            try
            {
                foreach (Operation soperation in robotTask.ChildrenActivities)
                {
                    foreach (Activity activity in soperation.ChildrenActivities)
                    {
                        string activityName = activity.Type;
                        if (activityName == "DNBRobotMotionActivity")
                        {
                            RobotMotion robotMotion = (RobotMotion)activity;
                            short TagetType = -1;
                            robotMotion.GetTargetType(ref TagetType); //Type of the Target (Cartesian = 0, Joint = 1, Tag = 2, Home = 3). 
                            if (TagetType != 2)
                            {
                                continue;
                            }
                            try
                            {
                                Tag tag = null;
                                robotMotion.GetTagTarget(ref tag);
                                var Return = tagList.Find(
                                    delegate (Tag tag1)
                                    {
                                        return tag1.get_Name() == tag.get_Name(); //需要修改为检查ID 名称可重复
                                    }); // Check Repeact 
                                if (Return == null) //当列表中不存在时 把新对象加载进入
                                {
                                    //确定当前Opration类型 The Via Mode (1 if the target is a via point and 0 if the Target is Untyped (process)). 
                                    short ViaMode = -1;
                                    soperation.GetViaMode(ref ViaMode);
                                    switch (ViaMode)
                                    {
                                        case 0:
                                            processtagList.Add(tag);
                                            break;
                                        case 1:
                                            viatagList.Add(tag);
                                            break;
                                        default:
                                            break;
                                    }
                                    tagList.Add(tag);
                                    string TagName = tag.get_Name();
                                    listBoxMain.Items.Add(TagName);
                                }
                            }
                            catch (Exception)
                            {
                                continue;
                                //throw;
                            }

                        }
                    }
                    Pbar.PerformStep();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("在处理Oprations时发生错误，请联系或在帮助选项中反馈该问题!" + e.Message);
            }
            Pbar.Value = Pbar.Maximum;
        }
        public void ReadRobotTaskTagList(Form FM, Product robot, ListBox listRobotBox, ProgressBar Pbar, ref List<RobotTask> RobotTaskList)
        {
            FM.TopMost = false;
            FM.WindowState = FormWindowState.Minimized;
            listRobotBox.Items.Clear();
            RobotTaskFactory TobjDeviceTaskFactory = (RobotTaskFactory)robot.GetTechnologicalObject("RobotTaskFactory");
            object[] SrcRobotAllTask = new object[999];
            TobjDeviceTaskFactory.GetAllRobotTasks(SrcRobotAllTask);
            if (SrcRobotAllTask[0] ==null)
            {
                Pbar.Maximum = 100;
                Pbar.Value = 100;
                Pbar.Step = 1;
                return;
            }
            foreach (RobotTask robotTask in SrcRobotAllTask)
            {
                if (robotTask == null)
                {
                    return;
                }
                string robotTaskName = robotTask.get_Name();
                listRobotBox.Items.Add(robotTaskName);
                RobotTaskList.Add(robotTask);
            }
                Pbar.Value = 0;

            Pbar.Value = Pbar.Maximum;
        }
        public void CopyTaskToNewRobot(Form FM, DataType.Dsystem DSystem, RobotTask robotTask, RobotTask TargetrobotTask, Product SrcRobot, Product TargetRobot)
        {
            //string TarName = SrcRobot.get_PartNumber();
            //ProductDocument SrcRobotDoc = (ProductDocument)DSystem.DSDocument.Item(TarName + ".CATProduct");
            //TarName = TargetRobot.get_PartNumber();
            //ProductDocument TargetRobotDoc = (ProductDocument)DSystem.DSDocument.Item(TargetRobot.get_PartNumber() + ".CATProduct");
            Selection selection = DSystem.CDSActiveDocument.Selection;
            selection.Clear();
            //foreach (Operation soperation in robotTask.ChildrenActivities)
            //{
            //    selection.Add(soperation);
            //}
            selection.Add(robotTask);
            try
            {
                selection.Copy();
                selection.Clear();
                //selection = TargetRobotDoc.Selection;
                selection.Add(TargetrobotTask);
                selection.Paste();
            }
            catch (Exception e)
            {
                MessageBox.Show("应发了未知错误，请核实是否完全克隆后再删除原机器人! " + e.Message);
            }
        }
    }
}
