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
namespace RXQuestServer
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
            DataType.Dsystem  Dsvalue= new DataType.Dsystem();
            INFITF.Application DSApplication;
            Documents DSDocument;
            ProcessDocument DSActiveDocument;
            Process[] AllProcess = Process.GetProcessesByName("DELMIA");
            if (AllProcess.Length>1)
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
            DSApplication.set_Caption("正在运行瑞祥快速建模工具！");
            // 获取当前活动ProductDocument
            try
            {
                DSDocument = (Documents)DSApplication.Documents;
                DSActiveDocument = (ProcessDocument)DSApplication.ActiveDocument;
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
            Dsvalue.Revalue = 0;
            return Dsvalue;
        }
        public Selection GetInitTargetProduct(Form FM, DataType.Dsystem DSystem)
        {
            FM.WindowState = FormWindowState.Minimized;
            INFITF.Application CatApplication=DSystem.DSApplication;
            ProcessDocument PPRP = DSystem.DSActiveDocument;
            if (PPRP==null)
            {
                return null;
            }
            Selection USelect= PPRP.Selection;
            USelect.Clear();
            var Result = USelect.SelectElement2(DataType.InputObjectType(9), "请选择初始化对象", true);
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
    }
}
