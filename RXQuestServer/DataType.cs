using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStructureTypeLib;
using MECMOD;
using INFITF;
using PROCESSITF;
using PPR;
using System.Runtime.InteropServices;

namespace RXQuestServer
{
    class DataType
    {
        /// <summary>
        /// 达索关键值传送器
        /// </summary>
        public class Dsystem
        {
            /// <summary>
            /// 活动Application
            /// </summary>
            public virtual INFITF.Application DSApplication { get; set; }
            public virtual ProcessDocument DSPPRProduct { get; set; }
            public virtual  PPRDocument DsPPRDocument { get; set; }
            public virtual Resources DSResources { get; set; }
            /// <summary>
            /// 活动Document
            /// </summary>
            public virtual Documents DSDocument { get; set; }
            public virtual ProcessDocument DSActiveDocument { get; set; }
            /// <summary>
            /// 自定义的零件
            /// </summary>
            public virtual Part PartID{ get; set; }
            /// <summary>
            /// 用户选择集
            /// </summary>
            public virtual Selection  USelection { get; set; }
            /// <summary>
            /// -1 ERR;0 Normal
            /// </summary>
            public virtual int Revalue { get; set; }
        }
        /// <summary>
        /// 设置CATIA 拾取对象类型
        /// 0：GetAnyObject；1：GetPoint；2:Face；3:Edge；4:Pad；5:sketch；6:Shape；7:Bodies；8:Part；9：Product
        /// </summary>
        /// <returns>:</returns>
        [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)]
       static public object[] InputObjectType(int ReadType)
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
                        return new object[] { "Part" };
                    }
                case 9: //Product
                    {
                        return new object[] { "Product" };
                    }
                case 10: //RobotMotion
                    {
                        return new object[] { "RobotMotion" };
                    }
                case 11: //Robot 
                    {
                        return new object[] { "Robot" };
                    }
                case 12: //RobotTask
                    {
                        return new object[] { "RobotTask" };
                    }
                case 13: //Resource
                    {
                        return new object[] { "Operation" };
                    }
                default:
                    return new object[] { "AnyObject" };
            }
        }
        public class SimulationDir
        {
            public string MBPath { get; set; }
            public string SBRPath { get; set; }
            public string SBLPath { get; set; }
            public string FRPath { get; set; }
            public string RRPath { get; set; }
            public string UBPath { get; set; }
            public string STPath { get; set; }
            public string SMPath { get; set; }
            public string LayoutPath { get; set; }
        }
    }
}
