using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Interop;
using System.Reflection;
using System.Security.Permissions;
using System.Diagnostics;
using Autodesk.AutoCAD.Interop.Common;
using eMPlantLib;
using System.Data.SQLite;
using System.Security.Principal;
using System.IO.MemoryMappedFiles;
using System.IO;

namespace AutoDeskLine_ToPlant
{
    class PlantOnline
    {
        /// <summary>
        /// 在Plant中绘制围栏
        /// </summary>
        /// <param name="FenceDimerns">围栏尺寸</param>
        /// <param name="CenterPosition">围栏中心点</param>
        /// <param name="FenceAngle">围栏角度</param>
        /// <returns></returns>
        public static  string WriteFence(Double FenceLength, Double[] CenterPosition, Double FenceAngle, double[] RefPoint)
        {
            string _exit = string.Empty;
            try
            {
                CenterPosition = PlantOnline.TranslateDataToPlant(CenterPosition, RefPoint);
                FenceLength = Math.Round(FenceLength/1000, 3);
                string str = "DrawFence([" +Math.Abs(FenceLength) + "," + 0 + "," + 2 + "],[" + CenterPosition[0] + "," + CenterPosition[1] + "," + CenterPosition[2] + "]," + FenceAngle.ToString() + ")";
                _exit=str;
            }
            catch (System.Exception)
            {
                throw;
            }
            return _exit;

        }

        /// <summary>
        /// 数组转换
        /// </summary>
        /// <param name="CadData">Cad 坐标值</param>
        /// <returns></returns>
        public static Double[] TranslateDataToPlant(Double[] CadData, Double[] RefPoint)
        {
            double[] _exit = new double[3] { -1, -1, -1 };
            if (CadData != null && CadData.Length == 3)
            {
                double x, y, z;
                x = CadData[0];
                y = CadData[1];
                z = CadData[2];
                x = (CadData[0] - RefPoint[0]) / 1000 ;
                y = (CadData[1] - RefPoint[1]) / 1000;
                z = (CadData[2] - RefPoint[2]) / 1000;
                double[] Res = new double[3];
                Res[0] =Math.Round(x, 3);
                Res[1] =Math.Round(y, 3);
                Res[2] =Math.Round(z, 3);
                return Res;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 数值转换
        /// </summary>
        /// <param name="CadData">Cad 坐标值</param>
        /// <returns></returns>
        public static Double TranslateDataToPlant(Double CadData)
        {
            return -1;
        }
        /// <summary>
        /// 将CAD 角度值转换成Plant角度值
        /// </summary>
        /// <param name="Angle">CAD 角度值</param>
        /// <returns></returns>
        public static Double TranslateAngleToPlant(Double Angle)
        {
            double Tangle = (180 / Math.PI) * Angle;
            Angle = Math.Round(Tangle, 1);
            return Angle;
        }
    }
}
