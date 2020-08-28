using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.Geometry;
using System.Data;
using System.Reflection;
namespace ToPlant
{
    /// <summary>
    /// 读取单条直线
    /// </summary>
    public class CadOprator
    {
        static public void ReadSingeLine()
        {
            Document Doc = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
            Editor Editor = Doc.Editor;
            PromptSelectionResult Rest = Editor.GetSelection();
            if (Rest.Status == PromptStatus.OK) return;
            Autodesk.AutoCAD.ApplicationServices.Core.Application.ShowAlertDialog("第一个选中集中实体的数量:" + Rest.Value.Count.ToString());

        }
        /// <summary>
        /// 路径坐标运算
        /// </summary>
        /// <param name="NewAIX">新点世界坐标值Double[3]</param>
        /// <param name="RefPoint">参考点坐标</param>
        /// <param name="ApplyPlantAix">是否应用Plant坐标规则</param>
        /// <returns></returns>
        static public double[] AixOprate(double[] NewAIX, double[] RefPoint,bool ApplyPlantAix)
        {
            if (NewAIX != null && NewAIX.Length == 3)
            {
                double x, y, z;
                x = NewAIX[0];
                y = NewAIX[1];
                z = NewAIX[2];
                if (ApplyPlantAix)
                {
                    x = (NewAIX[0] - RefPoint[0]) / 1000 * 20;
                    y = (NewAIX[1] - RefPoint[1]) / 1000 * 20;
                    z = (NewAIX[2] - RefPoint[2]) / 1000 * 20;
                }
                else
                {
                    x = (NewAIX[0] - RefPoint[0]);
                    y = (NewAIX[1] - RefPoint[1]);
                    z = (NewAIX[2] - RefPoint[2]);
                }
                double[] Res = new double[3];
                Res[0] = x;
                Res[1] = y;
                Res[2] = z;
                return Res;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 路径坐标运算
        /// </summary>
        /// <param name="NewAIX">新读取的坐标值</param>
        /// <param name="RefPoint">参考坐标值</param>
        /// <param name="ApplyPlantAix">是否运用Plant坐标规则</param>
        /// <returns></returns>
        static public double[] TackAix(double[] NewAIX, double[] RefPoint, bool ApplyPlantAix)
        {
            if (NewAIX != null && NewAIX.Length == 3)
            {
                double x, y, z;
                x = NewAIX[0];
                y = NewAIX[1];
                z = NewAIX[2];
                if (ApplyPlantAix)
                {
                    x = (NewAIX[0] - RefPoint[0]) / 1000*20;
                    y = (NewAIX[1] - RefPoint[1]) / 1000*20;
                    z = (NewAIX[2] - RefPoint[2]) / 1000*20;
                }
                else
                {
                    x = (NewAIX[0] - RefPoint[0]);
                    y = (NewAIX[1] - RefPoint[1]);
                    z = (NewAIX[2] - RefPoint[2]);
                }
                double[] Res = new double[3];
                Res[0] = x;
                Res[1] = y;
                Res[2] = z;
                return Res;
            }
            else
            {
                return null;
            }

        }

    }
}
