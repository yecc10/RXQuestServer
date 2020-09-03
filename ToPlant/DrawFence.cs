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
using System.Net.Sockets;
using System.Threading;
using System.Net;
namespace ToPlant
{
    public partial class DrawFence : Form
    {
        [STAThreadAttribute]
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
        Thread ThreadClient = null;
        Socket SocketClient = null;
        public DrawFence()  //Init Global data
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            SocketLogs.Text = string.Empty;
            ServerIP.Text = "127.0.0.1";
            ServerPort.Text = "30000";
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
        }
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
                        this.WindowState = FormWindowState.Normal;
                        this.StartPosition = FormStartPosition.CenterScreen;
                        //MessageBox.Show("UCS创建失败！e02" + e);
                    }
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                    this.StartPosition = FormStartPosition.CenterScreen;
                    //MessageBox.Show("请先打开AutoCad!+e00");
                }
            }
            catch (System.Exception)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
                // MessageBox.Show("请先打开AutoCad!");
            }
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
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
            this.WindowState = FormWindowState.Minimized;
            if (OnlineModel.Checked != true | SX_AIX.Text == string.Empty | SX_AIX.Text == "")
            {
                MessageBox.Show("当前未切换到在线设计模式或未设置参考点坐标！，无法继续后续操作！请选择在线模式!");
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
                return;
            }
            Reset:
            AcadDocument caddocument = null;
            tAcadApplication.Visible = true;
            try
            {
                this.WindowState = FormWindowState.Minimized;
                tAcadApplication = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application");
                caddocument = tAcadApplication.ActiveDocument;
                caddocument.Utility.Prompt("命令已初始化......!");
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
                                //((dynamic)obj).color = caddocument.ActiveLayer.color;
                                RxTypeList.AcadLine RT = new RxTypeList.AcadLine();
                                RT.StartPoint = ((dynamic)obj).StartPoint;
                                RT.EndPoint = ((dynamic)obj).EndPoint;
                                RT.FwAngle = ((dynamic)obj).Angle;
                                RT.Length = ((dynamic)obj).length;
                                double[] LineCenter = new double[3] { 0, 0, 0 };
                                LineCenter[0] = RT.StartPoint[0] + (RT.EndPoint[0] - RT.StartPoint[0]) / 2;
                                LineCenter[1] = RT.StartPoint[1] + (RT.EndPoint[1] - RT.StartPoint[1]) / 2;
                                LineCenter[2] = RT.StartPoint[2] + (RT.EndPoint[2] - RT.StartPoint[2]) / 2;
                                RT.CenterPoint = LineCenter;
                                double Tangle = (180 / Math.PI) * RT.FwAngle;
                                RT.FwAngle = Math.Round(Tangle, 1);
                                OprateFormData(RT);
                                string str = PlantOnline.WriteFence(RT.Length, RT.CenterPoint, RT.FwAngle, RefPoint);
                                if (str != string.Empty)
                                {
                                    SendDataToSocket(str);
                                }
                                break;
                            }
                        case "AcDbArc":
                            {
                                //((dynamic)obj).color = caddocument.ActiveLayer.color;
                                RxTypeList.AcDbArc Arc = new RxTypeList.AcDbArc();
                                Arc.StartPoint = ((dynamic)obj).StartPoint;
                                Arc.EndPoint = ((dynamic)obj).EndPoint;
                                Arc.Center = ((dynamic)obj).Center;
                                Arc.Radius = ((dynamic)obj).Radius;
                                Arc.StartAngle = ((dynamic)obj).StartAngle;
                                Arc.StartAngle = (180 / Math.PI) * Arc.StartAngle;
                                Arc.EndAngle = ((dynamic)obj).EndAngle;
                                Arc.EndAngle = (180 / Math.PI) * Arc.EndAngle;
                                Arc.Normal = ((dynamic)obj).Normal;
                                OprateFormData(Arc);
                                break;
                            }
                        case "AcDbPolyline":
                            {
                                //((dynamic)obj).color = caddocument.ActiveLayer.color;
                                RxTypeList.AcDbPolyline Pl = new RxTypeList.AcDbPolyline();
                                Pl.Points = ((dynamic)obj).Coordinates;
                                int NumberLine, NumberPoints;
                                NumberPoints = Pl.Points.Count();//Total Polyline Point Number
                                NumberLine = NumberPoints / 2 - 1;//Total Polyline Number
                                int Cline = 0;
                                for (int i = 0; i < NumberPoints; i++)
                                {
                                    RxTypeList.AcadLine Aline = new RxTypeList.AcadLine();
                                    try
                                    {
                                        Aline.StartPoint = new double[3] { Math.Round(Pl.Points[i], 0), Math.Round(Pl.Points[i + 1], 0), 0 };
                                        Aline.EndPoint = new double[3] { Math.Round(Pl.Points[i + 2], 0), Math.Round(Pl.Points[i + 3], 0), 0 };
                                        if (Aline.StartPoint == Aline.EndPoint) //始点==末点 执行下个循环
                                        {
                                            i += 1;
                                            continue;
                                        }
                                    }
                                    catch (System.Exception)
                                    {
                                        i += 1;
                                        continue;
                                    }
                                    Aline.CenterPoint = new double[3];
                                    Aline.CenterPoint[0] = Aline.StartPoint[0] + (Aline.EndPoint[0] - Aline.StartPoint[0]) / 2;
                                    Aline.CenterPoint[1] = Aline.StartPoint[1] + (Aline.EndPoint[1] - Aline.StartPoint[1]) / 2;
                                    Aline.CenterPoint[2] = Aline.StartPoint[2] + (Aline.EndPoint[2] - Aline.StartPoint[2]) / 2;
                                    //Aline.FwAngle = Math.Atan(Math.Abs(Aline.EndPoint[1] - Aline.StartPoint[1]) / Math.Abs(Aline.EndPoint[0] - Aline.StartPoint[0]));
                                    Aline.FwAngle = Math.Atan((Aline.EndPoint[1] - Aline.StartPoint[1]) / (Aline.EndPoint[0] - Aline.StartPoint[0]));
                                    double ASin = Aline.FwAngle;
                                    Aline.FwAngle = Math.Round(180 * Aline.FwAngle / Math.PI, 2);
                                    if (Aline.EndPoint[1] - Aline.StartPoint[1] == 0)
                                    {
                                        Aline.Length = Math.Abs(Aline.EndPoint[0] - Aline.StartPoint[0]);
                                    }
                                    else if (Aline.EndPoint[0] - Aline.StartPoint[0] == 0)
                                    {
                                        Aline.Length = Math.Abs(Aline.EndPoint[1] - Aline.StartPoint[1]);
                                    }
                                    else
                                    {
                                        double dy = Math.Abs(Aline.EndPoint[1] - Aline.StartPoint[1]);
                                        Aline.Length = Math.Round(dy / Math.Sin(ASin), 4);
                                    }
                                    if (Math.Round(Aline.Length, 0) == 0)
                                    {
                                        i += 1;
                                        continue;
                                    }
                                    Cline += 1;
                                    string str = PlantOnline.WriteFence(Aline.Length, Aline.CenterPoint, Aline.FwAngle, RefPoint);
                                    if (str != string.Empty)
                                    {
                                        SendDataToSocket(str);
                                    }
                                    //if (Cline== NumberLine)
                                    //{
                                    //    continue;
                                    //}
                                    i += 1;
                                }
                                break;
                            }
                        default:
                            MessageBox.Show("您选择的不是一条直线无法获取起始点和结束点！");
                            this.WindowState = FormWindowState.Normal;
                            this.StartPosition = FormStartPosition.CenterScreen;
                            break;
                    }
                    try
                    {
                        ((dynamic)obj).color = caddocument.ActiveLayer.color;
                    }
                    catch (System.Exception)
                    {
                        continue;
                    }
                } while (JS < 99999);
            }
            catch (COMException E)
            {
                if (((dynamic)E).HResult == -2147352567)
                {
                    //Console.Write(((dynamic)e).Button);
                    this.WindowState = FormWindowState.Normal;
                    this.StartPosition = FormStartPosition.CenterScreen;
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
            double Radius = Math.Round(arc.Radius / 1000 * 20, keepValuePoint);
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
            if (WriteObjectToDataGrid(StartPoint, TCenter, Radius, StartAngle, EndAngle, "A", Ttrack))
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
                if (WriteObjectToDataGrid(EndPoint, 0, "B", Ttrack))
                {
                    ///////////////////////////////////////////////////////
                }
            }
            try
            {
                WriteObjectID(Line.StartPoint, Line.EndPoint, (index + "-A"));
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
        private bool WriteObjectToDataGrid(double[] PointData, double FwAngle, String BEP, String Ttrack)
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
                DataRow["CenterX"] = 0;
                DataRow["CenterY"] = 0;
                DataRow["CenterZ"] = 0;
                DataRow["StartAngle"] = 0;
                DataRow["EndAngle"] = 0;
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
            double[] Position = new double[3] { 0, 0, 0 };
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
        private void OnlineModel_CheckedChanged(object sender, EventArgs e)
        {
            if (UserClass.IsRegeditExit())
            {
                if (OnlineModel.Checked)
                {
                    SocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress address = IPAddress.Parse(ServerIP.Text);
                    IPEndPoint Point = new IPEndPoint(address, Convert.ToInt32(ServerPort.Text));
                    try
                    {
                        SocketClient.Connect(Point);
                        OnlineModel.Checked = true;
                        SocketLogs.AppendText("服务器：" + ServerIP.Text + ":" + ServerPort.Text + "连接成功！" + DateTime.Now.ToString() + "\r\n\n");
                    }
                    catch (System.Exception)
                    {
                        Debug.WriteLine("连接失败！");
                        SocketLogs.AppendText("服务器：" + ServerIP.Text + ":" + ServerPort.Text + "连接失败！！！" + DateTime.Now.ToString() + "\r\n\n");
                        OnlineModel.Checked = false;
                        //throw;
                    }
                    String Str = string.Empty;
                    ThreadClient = new Thread(SocketRecive);
                    ThreadClient.IsBackground = true;
                    ThreadClient.Start();
                }
                else
                {
                    SocketClient.Close();
                    SocketLogs.AppendText("您已断开和PlantSimulation链接，无法执行后续操作！" + DateTime.Now.ToString() + "\r\n\n");
                }
            }
            else
            {
                SocketLogs.AppendText("未检测到您安装了PlantSimulation 15.1 无法执行后续操作！" + DateTime.Now.ToString() + "\r\n\n");
            }
        }
        /// <summary>
        /// 获取Socket 返回值
        /// </summary>
        public void SocketRecive()
        {
            while (true)
            {
                if (!OnlineModel.Checked)
                {
                    return;
                }
                try
                {
                    byte[] ArryRecvmsg = new byte[1024 * 1024];
                    int length = SocketClient.Receive(ArryRecvmsg);
                    string Strmsg = Encoding.UTF8.GetString(ArryRecvmsg, 0, length);
                    if (length > 0)
                    {
                        this.SocketLogs.AppendText("\r\n" + "服务器01：" + DateTime.Now.ToString() + "\r\n" + Strmsg + "\r\n\n");
                        Debug.WriteLine("\r\n" + "服务器01：" + DateTime.Now.ToString() + "\r\n" + Strmsg + "\r\n\n");
                    }
                    else
                    {
                        this.SocketLogs.AppendText("\r\n" + "服务器01：服务器连接已中断,请重新连接......" + DateTime.Now.ToString() + "\r\n" + Strmsg + "\r\n\n");
                        Debug.WriteLine("\r\n" + "服务器01：服务器连接已中断,请重新连接......" + DateTime.Now.ToString() + "\r\n" + Strmsg + "\r\n\n");
                        OnlineModel.Checked = false;
                        SocketClient.Close();
                        return;
                    }
                }
                catch (System.Exception)
                {
                    this.SocketLogs.AppendText("\r\n" + "服务器连接已中断,请重新连接......" + DateTime.Now.ToString() + "\r\n\n");
                    Debug.WriteLine("\r\n" + "服务器连接已中断,请重新连接...... " + DateTime.Now.ToString() + "\r\n\n");
                    OnlineModel.Checked = false;
                    SocketClient.Close();
                    return;
                }
            }
        }
        public void SendDataToSocket(string SendData)
        {
            try
            {
                byte[] ArrClientMessage = Encoding.UTF8.GetBytes(SendData);
                SocketClient.Send(ArrClientMessage);
                Debug.WriteLine("\r\n" + "数据： " + SendData + "已向服务器发送完成，" + DateTime.Now.ToString() + "\r\n" + "\r\n\n");
                SocketLogs.AppendText("\r\n" + "数据： " + SendData + "已向服务器发送完成，" + DateTime.Now.ToString() + "\r\n" + "\r\n\n");
            }
            catch (System.Exception)
            {
                SocketLogs.AppendText("服务器连接已中断,发送失败！,请重新连接...... " + DateTime.Now.ToString() + "\r\n\n");
                Debug.WriteLine("服务器连接已中断,发送失败！,请重新连接...... " + DateTime.Now.ToString() + "\r\n\n");
                SocketClient.Close();
                OnlineModel.Checked = false;
            }
        }
        private void TestSocket_Click(object sender, EventArgs e)
        {
            if (!OnlineModel.Checked)
            {
                SocketLogs.AppendText("服务器连接尚未启动，请先启动在线模式！ " + DateTime.Now.ToString() + "\r\n\n");
            }
            SendDataToSocket("TryConnect");
        }
        private void ClearLogs_Click(object sender, EventArgs e)
        {
            SocketLogs.Text = string.Empty;
        }
        private void DeleteLastFence_Click(object sender, EventArgs e)
        {
            SendDataToSocket("DeleteLastFence");
        }
        private void ExploreJT_Click(object sender, EventArgs e)
        {
            SendDataToSocket("SaveJt");
        }
        private void ClearModel_Click(object sender, EventArgs e)
        {
            SendDataToSocket("DeleteAllFence");
        }
        private void DrawFence_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (SocketClient!=null)
                {
                    SocketClient.Close();
                }
                //System.Environment.Exit(0);
                if (ThreadClient!=null)
                {
                    ThreadClient.DisableComObjectEagerCleanup();
                }
                Process.GetCurrentProcess().Kill();
            }
            catch (System.Exception)
            {
                Process.GetCurrentProcess().Kill();
                Debug.WriteLine("Close Faild!");
            }
        }
        private void timer_Tick_1(object sender, EventArgs e)
        {
            this.FindForm().Text = "瑞祥快捷设计中心 BY_安徽瑞祥工业【工厂仿真组】叶朝成_当前时间: " + DateTime.Now.ToString();
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void MannuSetFW_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AutoSetFW_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void LishanRoad_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ContinuRoad_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void DoubleRoadSelected_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SingeRoadSelected_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Sscale_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ServerPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void ServerIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void KeepValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void ApplyPlantAix_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChangeXY_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AutoRead_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void SX_AIX_TextChanged(object sender, EventArgs e)
        {

        }

        private void SY_AIX_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SocketLogs_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
