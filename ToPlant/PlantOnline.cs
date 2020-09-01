using System;
namespace ToPlant
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
        public static string WriteFence(Double FenceLength, Double[] CenterPosition, Double FenceAngle, double[] RefPoint)
        {
            string _exit = string.Empty;
            try
            {
                CenterPosition = PlantOnline.TranslateDataToPlant(CenterPosition, RefPoint);
                FenceLength = Math.Round(FenceLength / 1000, 3);
                string str = "DrawFence([" + Math.Abs(FenceLength) + "," + 0 + "," + 2 + "],[" + CenterPosition[0] + "," + CenterPosition[1] + "," + CenterPosition[2] + "]," + FenceAngle.ToString() + ")";
                _exit = str;
            }
            catch (System.Exception)
            {
                throw;
            }
            return _exit;

        }
        /// <summary>
        /// 坐标转Plant可识别的数据格式
        /// </summary>
        /// <param name="StartPoint">始点</param>
        /// <param name="StopPoint">终点</param>
        /// <param name="TrackType">路径类型</param>
        /// <param name="StartAngle">起始角</param>
        /// <param name="CenterPosition">中心点坐标</param>
        /// <param name="StopAngle">终止角</param>
        /// <param name="FwAngle">方向角</param>
        /// <param name="RefPoint">参考点</param>
        /// <returns></returns>
        public static string WriteTrack(string TrackName,Double[] StartPoint, Double[] StopPoint, string TrackType, Double StartAngle, Double[] CenterPosition, Double StopAngle, Double FwAngle,Double ArcRadius, double[] RefPoint)
        {
            string _exit = string.Empty;
            try
            {
                //CenterPosition = PlantOnline.TranslateDataToPlant(CenterPosition, RefPoint);
                //StartPoint = PlantOnline.TranslateDataToPlant(StartPoint, RefPoint);
                //StopPoint = PlantOnline.TranslateDataToPlant(StopPoint, RefPoint);
                //string str = "[" + StartPoint[0] + "," + StartPoint[1] + "," + StartPoint[2] + "],[" + StopPoint[0] + "," + StopPoint[1] + "," + StopPoint[2] + "]," +
                //    TrackType.ToString() + "," +StartAngle.ToString() + "," + "[" + CenterPosition[0] + "," + CenterPosition[1] + "," + CenterPosition[2] + "]," +
                //    StopAngle.ToString() + "," + FwAngle.ToString();
                string str = StartPoint[0] + "," + StartPoint[1] + "," + StartPoint[2] + "," + StopPoint[0] + "," + StopPoint[1] + "," + StopPoint[2] + "," +
    TrackType.ToString() + "," + StartAngle.ToString() + "," + CenterPosition[0] + "," + CenterPosition[1] + "," + CenterPosition[2] + "," +
    StopAngle.ToString() + "," + FwAngle.ToString()+","+ TrackName + "," + ArcRadius;
                _exit = str;
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
                x = (CadData[0] - RefPoint[0]) / 1000;
                y = (CadData[1] - RefPoint[1]) / 1000;
                z = (CadData[2] - RefPoint[2]) / 1000;
                double[] Res = new double[3];
                Res[0] = Math.Round(x, 3);
                Res[1] = Math.Round(y, 3);
                Res[2] = Math.Round(z, 3);
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
