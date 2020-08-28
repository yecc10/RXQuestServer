using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
namespace AutoDeskLine_ToPlant
{
    public partial class AutoDesKToPlant : Form
    {
        [DllImportAttribute("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess
     (
         int dwDesiredAccess,
         bool bInheritHandle,
         int dwProcessId
     );
        /// <summary>
        /// 已打开的CAD图纸
        /// </summary>
        AcadApplication tAcadApplication = null;
        System.Data.DataTable datatable = new System.Data.DataTable();
        System.Data.DataColumn dataColum;
        DataRow DataRow;
        DataView dataview;
        /// <summary>
        /// 全局变量 保存上一个读取的Cad对象
        /// </summary>
        object AcadObj;
        int index = 0;
        /// <summary>
        /// 参考点
        /// </summary>
        double[] RefPoint = new double[3];
        /// <summary>
        /// 当前点十分为线头/尾点"A/B"
        /// </summary>
        string CBEP = string.Empty;
        public AutoDesKToPlant()
        {
            InitializeComponent();
            timer.Enabled = true;
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "序号";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "X坐标";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "Y坐标";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "Z坐标";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "Radius";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "TrackType";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "StartAngle";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "CenterX";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "CenterY";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "CenterZ";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "EndAngle";
            datatable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "FwAngle";
            datatable.Columns.Add(dataColum);
        } //Init Global Data
        private void SetRefPoint_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            try
            {
                tAcadApplication = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application");
                if (tAcadApplication.Name == "AutoCAD")
                {
                    tAcadApplication.Visible = true;
                    AcadDocument caddocument = tAcadApplication.ActiveDocument;
                    caddocument.Activate();
                    try
                    {
                        caddocument.Utility.Prompt("请选择一个基准点:");
                        var re = caddocument.WindowState;
                        var point = caddocument.Utility.GetPoint();
                        this.WindowState = FormWindowState.Maximized;
                        RefPoint = point;
                        SX_AIX.Text = Convert.ToString(Math.Round(point[0], Convert.ToInt16(KeepValue.Text)));
                        SY_AIX.Text = Convert.ToString(Math.Round(point[1], Convert.ToInt16(KeepValue.Text)));
                       
                    }
                    catch (System.Exception)
                    {
                        this.WindowState = FormWindowState.Maximized;
                        //MessageBox.Show("UCS创建失败！e02" + e);
                    }
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                    //MessageBox.Show("请先打开AutoCad!+e00");
                }
            }
            catch (System.Exception)
            {
                this.WindowState = FormWindowState.Maximized;
                // MessageBox.Show("请先打开AutoCad!");
            }
        }
        private void ManulInputPoint_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            try
            {
                tAcadApplication = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application");
                if (tAcadApplication.Name == "AutoCAD")
                {
                    tAcadApplication.Visible = true;
                    AcadDocument caddocument = tAcadApplication.ActiveDocument;
                    caddocument.Activate();
                    try
                    {
                        do
                        {
                            double[] point = new double[3] { 0, 0, 0 };
                            try
                            {
                                try
                                {
                                    point = caddocument.Utility.GetPoint(point, "请选择一个点:");
                                }
                                catch (COMException E)
                                {
                                    if (((dynamic)E).HResult == -2147352567 || ((dynamic)E).HResult == -2145320928)
                                    {
                                        //Console.Write(((dynamic)e).Button);
                                        this.WindowState = FormWindowState.Maximized;
                                        break;
                                    }
                                    Console.Write(((dynamic)e).Button);
                                    continue;
                                }
                                ReShow(null, null, point);
                                switch (CBEP)
                                {
                                    case "A":
                                        {
                                            CBEP = "B";
                                            break;
                                        }
                                    case "B":
                                        {
                                            CBEP = "A";
                                            break;
                                        }
                                    default:
                                        CBEP = "A";
                                        break;
                                }
                                if (ContinuRoad.Checked)
                                {
                                    CBEP = "0";
                                }
                                WriteObjectToDataGrid(point);
                            }
                            catch (System.Exception)
                            {
                                //this.WindowState = FormWindowState.Maximized;
                                //caddocument.Utility.Prompt("读取发生故障请重新，点击命令进行拾取！");
                                //return;
                                continue;
                            }
                        }
                        while (index != 99999);
                        this.WindowState = FormWindowState.Maximized;
                    }
                    catch (System.Exception)
                    {
                        this.WindowState = FormWindowState.Maximized;
                        //MessageBox.Show("UCS创建失败！e02" + e);
                    }
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                    //MessageBox.Show("请先打开AutoCad!+e00");
                }
            }
            catch (System.Exception)
            {
                this.WindowState = FormWindowState.Maximized;
                //MessageBox.Show("请先打开AutoCad!");
            }
        }
        private void ClearData_Click(object sender, EventArgs e)
        {
            datatable.Clear();
            dataview = new DataView(datatable);
            DataGrid.DataSource = dataview;
            DataGrid.Update();
            index = 0;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            this.FindForm().Text = "物流输送系统路径转化程序 BY_安徽瑞祥工业【工厂仿真组】叶朝成_当前时间: " + DateTime.Now.ToString();
        }
        private void DeleteData_Click(object sender, EventArgs e)
        {
            dynamic NlineTaype = ((dynamic)AcadObj).EntityName;
            string NlineT = Convert.ToString(NlineTaype);
            if (NlineT == "AcDbCircle")
            {
                ((dynamic)AcadObj).delete();
            }
            else
            {
                ((dynamic)AcadObj).color = ACAD_COLOR.acByLayer;
            }
            datatable.Rows.Remove(datatable.Rows[datatable.Rows.Count - 1]);
            dataview = new DataView(datatable);
            DataGrid.DataSource = dataview;
            DataGrid.Update();
            index -= 1;
        }
        private void ManulInputLine_Click(object sender, EventArgs e)
        {
            Reset:
            AcadDocument caddocument=null;
            try
            {
                this.WindowState = FormWindowState.Minimized;
                tAcadApplication = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application");
                caddocument = tAcadApplication.ActiveDocument;
            }
            catch (COMException)
            {
                //throw;
            }
            object obj, pickedObj = null;
            try
            {
                int JS = 0;
               do
                {
                    JS += 1;
                    try
                    {
                        caddocument.Utility.GetEntity(out obj, out pickedObj, "请选择一个直线或圆弧,取消点击空白区域、右击、ESC命令即可:");
                    }
                    catch (COMException E)
                    {
                        if (((dynamic)E).HResult == -2147352567)
                        {
                            //Console.Write(((dynamic)e).Button);
                            this.WindowState = FormWindowState.Maximized;
                            break;
                        }
                        continue;
                    }
                    var db = caddocument.Database;
                    dynamic NlineTaype = ((dynamic)obj).EntityName;
                    string NlineT = Convert.ToString(NlineTaype);
                    AcadObj = obj;
                    switch (NlineT)
                    {
                        case "AcDbLine":
                            {
                                ((dynamic)obj).color = caddocument.ActiveLayer.color;
                                RxTypeList.AcadLine RT = new RxTypeList.AcadLine();
                                RT.StartPoint = ((dynamic)obj).StartPoint;
                                RT.EndPoint = ((dynamic)obj).EndPoint;
                                RT.FwAngle= ((dynamic)obj).Angle;
                                double Tangle= (180 / Math.PI) * RT.FwAngle;
                                RT.FwAngle = Math.Round(Tangle, 1);
                                OprateFormData(RT);
                                break;
                            }
                        case "AcDbArc":
                            {
                                ((dynamic)obj).color = caddocument.ActiveLayer.color;
                                RxTypeList.AcDbArc Arc = new RxTypeList.AcDbArc();
                                Arc.StartPoint = ((dynamic)obj).StartPoint;
                                Arc.EndPoint = ((dynamic)obj).EndPoint;
                                Arc.Center = ((dynamic)obj).Center;
                                Arc.Radius = ((dynamic)obj).Radius;
                                Arc.StartAngle = ((dynamic)obj).StartAngle;
                                Arc.StartAngle = (180/ Math.PI) * Arc.StartAngle;
                                Arc.EndAngle = ((dynamic)obj).EndAngle;
                                Arc.EndAngle = (180 / Math.PI) * Arc.EndAngle;
                                Arc.Normal = ((dynamic)obj).Normal;
                                OprateFormData(Arc);
                                break;
                            }
                        default:
                            MessageBox.Show("您选择的不是一条直线无法获取起始点和结束点！");
                            this.WindowState = FormWindowState.Maximized;
                            break;
                    }
                } while (JS < 99999);
            }
            catch (COMException E)
            {
                if (((dynamic)E).HResult == -2147352567)
                {
                    //Console.Write(((dynamic)e).Button);
                    this.WindowState = FormWindowState.Maximized;
                    return;
                }
                else
                {
                    goto Reset;
                }
            }
        }
        private void OutExcel_Click(object sender, EventArgs e)
        {
            RxDataOprator.ExcelOprator.SaveExcelForLvSport(this.DataGrid, "Cad路径坐标值");
        }
        /// <summary>
        /// 通过从CAD返回的点坐标进行Form中的添加及更新操作
        /// </summary>
        /// <param name="point">获取的点</param>
        /// <param name="BEP">起始点为A 结束点为B</param>
        private void OprateFormData(RxTypeList.AcDbArc arc)
        {
            if (SX_AIX.Text == string.Empty || SY_AIX.Text == string.Empty)
            {
                MessageBox.Show("未初始化参考坐标！请先初始化参考坐标系！");
                return;
            }
            int keepValuePoint = Convert.ToInt16(KeepValue.Text);
            double[] StartPoint = CadOprator.TackAix(arc.StartPoint, RefPoint, ApplyPlantAix.Checked);
            double[] EndPoint = CadOprator.TackAix(arc.EndPoint, RefPoint, ApplyPlantAix.Checked);
            double[] TCenter = CadOprator.TackAix(arc.Center, RefPoint, ApplyPlantAix.Checked);
            double Radius=Math.Round(arc.Radius / 1000 * 20, keepValuePoint);
            double StartAngle = Math.Round(arc.StartAngle, keepValuePoint);
            double EndAngle = Math.Round(arc.EndAngle, keepValuePoint);
            String Ttrack = string.Empty;
            if (SingeRoadSelected.Checked)
            {
                Ttrack = "SingerTrack";
            }
            else
            {
                Ttrack = "DoubleTrack";
            }
            if (WriteObjectToDataGrid(StartPoint,TCenter,Radius,StartAngle,EndAngle, "A", Ttrack))
            {
                if (WriteObjectToDataGrid(EndPoint, 0, "B", Ttrack))
                {
                    ///////////////////////////////////////////////////////
                }
            }
            try
            {
                WriteObjectID(arc.StartPoint, arc.EndPoint, (index + "-A"));
            }
            catch (System.Exception)
            {
               //throw;
            }
            index += 1;
        }
        /// <summary>
        /// 通过从CAD返回的点坐标进行Form中的添加及更新操作
        /// </summary>
        /// <param name="point">获取的点</param>
        /// <param name="BEP">起始点为A 结束点为B</param>
        /// <param name="Line"></param>
        private void OprateFormData(RxTypeList.AcadLine Line)
        {
            if (SX_AIX.Text == string.Empty || SY_AIX.Text == string.Empty)
            {
                MessageBox.Show("未初始化参考坐标！请先初始化参考坐标系！");
                return;
            }
            double[] StartPoint = CadOprator.TackAix(Line.StartPoint, RefPoint, ApplyPlantAix.Checked);
            double[] EndPoint = CadOprator.TackAix(Line.EndPoint, RefPoint, ApplyPlantAix.Checked);
            String Ttrack = string.Empty;
            if (SingeRoadSelected.Checked)
            {
                Ttrack = "SingerTrack";
            }
            else
            {
                Ttrack = "DoubleTrack";
            }
            if (WriteObjectToDataGrid(StartPoint, Line.FwAngle, "A", Ttrack))
            {
                if (WriteObjectToDataGrid(EndPoint,0, "B", Ttrack))
                {
                   ///////////////////////////////////////////////////////
                }
            }
            try
            {
                WriteObjectID(Line.StartPoint, Line.EndPoint,(index + "-A"));
            }
            catch (System.Exception)
            {
                //throw;
            }
            index += 1;
        }
        /// <summary>
        /// 直线数据写入DataGridView
        /// </summary>
        /// <param name="PointData">点坐标</param>
        /// <param name="FwAngle">直线方向</param>
        /// <param name="BEP">起点A/末点B</param>
        /// <param name="Ttrack">直线类型</param>
        /// <returns>写入成功/失败</returns>
        private bool WriteObjectToDataGrid(double[] PointData,double FwAngle, String BEP, String Ttrack)
        {
            try
            {
                int keepValuePoint = Convert.ToInt16(KeepValue.Text);
                DataRow = datatable.NewRow();
                DataRow["序号"] = index + "-" + BEP;
                DataRow["X坐标"] = Math.Round(PointData[0], keepValuePoint);
                DataRow["Y坐标"] = Math.Round(PointData[1], keepValuePoint);
                DataRow["Z坐标"] = Math.Round(PointData[2], keepValuePoint);
                DataRow["Radius"] = 0;
                DataRow["CenterX"] = 0;
                DataRow["CenterY"] = 0;
                DataRow["CenterZ"] = 0;
                DataRow["StartAngle"] = 0;
                DataRow["EndAngle"] = 0;
                DataRow["FwAngle"] = FwAngle;
                DataRow["TrackType"] = Ttrack;
                datatable.Rows.Add(DataRow);
                dataview = new DataView(datatable);
                DataGrid.DataSource = dataview;
                DataGrid.Update();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 圆弧数据写入DataGridView
        /// </summary>
        /// <param name="PointData">点坐标</param>
        /// <param name="CenterData">弧中心</param>
        /// <param name="Radius">弧半径</param>
        /// <param name="StartAngle">起始角</param>
        /// <param name="EndAngle">结束角</param>
        /// <param name="BEP">起点A/末点B</param>
        /// <param name="Ttrack">直线类型</param>
        /// <returns>写入成功/失败</returns>
        private bool WriteObjectToDataGrid(double[] PointData, double[] CenterData, double Radius, double StartAngle, double EndAngle, String BEP, String Ttrack)
        {
            try
            {
                int keepValuePoint = Convert.ToInt16(KeepValue.Text);
                DataRow = datatable.NewRow();
                DataRow["序号"] = index + "-" + BEP;
                DataRow["X坐标"] = Math.Round(PointData[0], keepValuePoint);
                DataRow["Y坐标"] = Math.Round(PointData[1], keepValuePoint);
                DataRow["Z坐标"] = Math.Round(PointData[2], keepValuePoint);
                DataRow["Radius"] = Math.Round(Radius, keepValuePoint);
                DataRow["CenterX"] = Math.Round(CenterData[0], keepValuePoint);
                DataRow["CenterY"] = Math.Round(CenterData[1], keepValuePoint);
                DataRow["CenterZ"] = Math.Round(CenterData[2], keepValuePoint);
                DataRow["StartAngle"] = Math.Round(StartAngle, keepValuePoint);
                DataRow["EndAngle"] = Math.Round(EndAngle, keepValuePoint);
                DataRow["FwAngle"] = 0;
                DataRow["TrackType"] = Ttrack;
                datatable.Rows.Add(DataRow);
                dataview = new DataView(datatable);
                DataGrid.DataSource = dataview;
                DataGrid.Update();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        private bool WriteObjectToDataGrid(double[] PointData)
        {
            try
            {
                try
                {
                    WriteObjectID(PointData, PointData, (index + "-A"));
                }
                catch (System.Exception)
                {
                    //throw;
                }
                PointData = CadOprator.AixOprate(PointData, RefPoint, ApplyPlantAix.Checked);
                String Ttrack = string.Empty;
                if (SingeRoadSelected.Checked)
                {
                    Ttrack = "SingerTrack";
                }
                else
                {
                    Ttrack = "DoubleTrack";
                }
                int keepValuePoint = Convert.ToInt16(KeepValue.Text);
                DataRow = datatable.NewRow();
                DataRow["序号"] = index + "-" + "0";
                DataRow["X坐标"] = Math.Round(PointData[0], keepValuePoint);
                DataRow["Y坐标"] = Math.Round(PointData[1], keepValuePoint);
                DataRow["Z坐标"] = Math.Round(PointData[2], keepValuePoint);
                DataRow["Radius"] = 0;
                DataRow["CenterX"] =0;
                DataRow["CenterY"] = 0;
                DataRow["CenterZ"] = 0;
                DataRow["StartAngle"] = 0;
                DataRow["EndAngle"] =0;
                DataRow["FwAngle"] = 0;
                DataRow["TrackType"] = Ttrack;
                datatable.Rows.Add(DataRow);
                dataview = new DataView(datatable);
                DataGrid.DataSource = dataview;
                DataGrid.Update();
                index += 1;
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 高亮显示已标记部分
        /// </summary>
        /// <param name="StartPoint">起始点</param>
        /// <param name="EndPoint">结束点</param>
        /// <param name="Center">中心点</param>
        private void ReShow(double[] StartPoint, double[] EndPoint, double[] Center)
        {
            var caddocument = tAcadApplication.ActiveDocument;
            if (Center == null)
            {
                AcadLine line = caddocument.ModelSpace.AddLine(StartPoint, EndPoint);
                line.color = ACAD_COLOR.acByLayer;
                AcadObj = line;
            }
            else
            {
                AcadCircle line = caddocument.ModelSpace.AddCircle(Center, 60);
                line.color = ACAD_COLOR.acByLayer;
                AcadObj = line;
            }
        }
        /// <summary>
        /// 创建读取对象的ID编号
        /// </summary>
        /// <param name="Position">文字防止位置</param>
        /// <param name="Content">文字内容</param>
        /// <param name="Height">文字高度</param>
        private void WriteObjectID(double[] StartPosition, double[] endPosition, string Content)
        {
            double[] Position = new double[3] {0,0,0};
            double Height = 100;
            Position[0] = StartPosition[0] + (endPosition[0] - StartPosition[0]) / 2;
            Position[1] = StartPosition[1] + (endPosition[1] - StartPosition[1]) / 2;
            Position[2] = StartPosition[2] + (endPosition[2] - StartPosition[2]) / 2;
                var caddocument = tAcadApplication.ActiveDocument;
                AcadText line = caddocument.ModelSpace.AddText(Content, Position, Height);
                line.color = ACAD_COLOR.acByLayer;
                AcadObj = line;
        }
        private void AutoRead_Click(object sender, EventArgs e)
        {
            // Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            //Database db = HostApplicationServices.WorkingDatabase;
            tAcadApplication = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application");
            AcadDocument doc = tAcadApplication.ActiveDocument;
            double[] d2 = new double[3] { 0, 0, 0 };
            var d = doc.Utility.GetPoint(d2, "Select a point:");
        }
        private void AutoDesKToPlant_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            System.Environment.Exit(0);
        }
    }
}
