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
            try
            {
                DSApplication = (INFITF.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Delmia.Application");
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
            Selection USelect= PPRP.Selection;
            USelect.Clear();
            var Result = USelect.SelectElement2(InputObjectType(9), "请选择初始化对象", true);
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
        /// 设置CATIA 拾取对象类型
        /// 0：GetAnyObject；1：GetPoint；2:Face；3:Edge；4:Pad；5:sketch；6:Shape；7:Bodies；8:Part；9：Product
        /// </summary>
        /// <returns>:</returns>
        [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)]
        public object[] InputObjectType(int ReadType)
        {
            switch (ReadType)
            {
                case 0: //GetAnyObject
                    {
                        return new object[] { "AnyObject" };
                    }
                case 1: //GetPoint
                    {
                        return new object[] { "Point", "Symmetry", "Translate" };
                    }
                case 2: //Face
                    {
                        return new object[] { "Face" };
                    }
                case 3: //Edge
                    {
                        return new object[] { "Edge" };
                    }
                case 4: //Pad
                    {
                        return new object[] { "Pad" };
                    }
                case 5: //sketch
                    {
                        return new object[] { "sketch" };
                    }
                case 6: //Shape
                    {
                        return new object[] { "Shape" };
                    }
                case 7: //Bodies
                    {
                        return new object[] { "Bodies" };
                    }
                case 8: //Part
                    {
                        return new object[] { "Product" };
                    }
                case 9: //Product
                    {
                        return new object[] { "Product" };
                    }
                default:
                    return new object[] { "AnyObject" };
            }
        }
    }
}
