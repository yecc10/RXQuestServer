using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.OpenXml4Net;
using NPOI.Util;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Data;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Label = System.Windows.Forms.Label;
using System.Runtime.InteropServices;

namespace YeccAutoCenter
{
    static public class RxDataOprator
    {
        /// <summary>
        /// Excel操作
        /// </summary>
        static public class ExcelOprator
        {
            /// <summary>
            /// 将dataGridView导出到EXCEL
            /// </summary>
            /// <param name="dataGridView">需要导出的dataGridView数据</param>
            /// <returns></returns>
            static public bool SaveExcelForLvSport(DataGridView dataGridView, string SportName)
            {
                dataGridView.AllowUserToAddRows = false;
                if (dataGridView.Rows.Count > 0)
                {
                    HSSFWorkbook wkb = new HSSFWorkbook();
                    ISheet sheet = wkb.CreateSheet("瑞祥工业物流组");
                    sheet.DefaultColumnWidth = 15;
                    IRow HeadRow = sheet.CreateRow(0);
                    HeadRow.Height = 400;
                    ICellStyle CST = wkb.CreateCellStyle();
                    CST.VerticalAlignment = VerticalAlignment.Center;
                    CST.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                    for (int i = 0; i < dataGridView.Rows[0].Cells.Count; i++) //初始化表头
                    {
                        ICell HeadCell = HeadRow.CreateCell(i);
                        HeadCell.SetCellValue(dataGridView.Columns[i].HeaderText);
                        HeadCell.CellStyle = CST;
                    }
                    for (int i = 0; i < dataGridView.Rows.Count; i++) //依次遍历全部行
                    {
                        IRow DataRow = sheet.CreateRow(i + 1);
                        DataRow.RowStyle = CST;
                        DataRow.Height = 400;
                        for (int j = 0; j < dataGridView.Rows[i].Cells.Count; j++) //读取每行中所有列
                        {
                            ICell DataCell = DataRow.CreateCell(j);
                            DataCell.SetCellValue(dataGridView.Rows[i].Cells[j].Value.ToString());
                            DataCell.CellStyle = CST;
                        }
                    }
                    string datatime = DateTime.Now.ToString("yyyymmddHHmmssffff");
                    string strDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    string path = strDesktopPath + "\\瑞祥工业工厂仿真组" + datatime + ".xls";
                    FileStream file = new FileStream(path, FileMode.OpenOrCreate);
                    wkb.Write(file);
                    file.Flush();
                    file.Close();
                    wkb = null;
                    MessageBox.Show("文件已保持到本地桌面！");
                    return true;
                }
                else
                {
                    MessageBox.Show("数据表中不存在任何数据，没有必要导出！");
                    return false;
                }
            }
            static public bool ReadXlsData(string xlsPath, DataGridView DG)
            {
                //DataGridView DG = new DataGridView();
                int RowNum = 0;
                try
                {
                    IWorkbook xlsBook = WorkbookFactory.Create(xlsPath);
                    ISheet sheet = (xlsBook.GetSheetAt(0).LastRowNum > xlsBook.GetSheetAt(1).LastRowNum) ? xlsBook.GetSheetAt(0) : xlsBook.GetSheetAt(1);
                    RxTypeList.CatPointType CP = new RxTypeList.CatPointType();
                    bool ChangeGun = false;
                    int GunNum = 0;
                    int RowID = 1;
                    for (int i = 0; i <= sheet.LastRowNum; i++)
                    {
                        if (sheet.LastRowNum < 2)
                        {
                            MessageBox.Show("您选择的坐标XLS为空或首个Sheet表为空，请保证首个Sheet表为即将导入的坐标集！", "导入错误报告", MessageBoxButtons.OK);
                            return false;
                        }
                        IRow Row = sheet.GetRow(i);
                        RowNum = Row.LastCellNum;
                        if (i == 0) //初始化表头
                        {
                            if (RowNum == 3 || RowNum == 4 || RowNum == 7 || RowNum == 8 || RowNum == 21)
                            {
                                DG.DataSource = null;
                                DG.AllowUserToAddRows = true;
                                if (DG.ColumnCount > 0)
                                {
                                    DG.Columns.Remove("序号");
                                    DG.Columns.Remove("名称");
                                    DG.Columns.Remove("X坐标");
                                    DG.Columns.Remove("Y坐标");
                                    DG.Columns.Remove("Z坐标");
                                    DG.Columns.Remove("RX");
                                    DG.Columns.Remove("RY");
                                    DG.Columns.Remove("RZ");
                                }
                                DG.Columns.Add("序号", "序号");
                                DG.Columns.Add("名称", "名称");
                                DG.Columns.Add("X坐标", "X坐标");
                                DG.Columns.Add("Y坐标", "Y坐标");
                                DG.Columns.Add("Z坐标", "Z坐标");
                                DG.Columns.Add("RX", "RX");
                                DG.Columns.Add("RY", "RY");
                                DG.Columns.Add("RZ", "RZ");
                            }
                            else
                            {
                                MessageBox.Show("所提供的EXCEL 文件格式不符合默认标准请提供4列(名称、X、Y、Z)、7列(带角度)、8列(多序号)的Xls表!");
                                return false;
                            }
                        }
                        else
                        {
                            string CheckValue = Row.GetCell(0).StringCellValue;
                            if (string.IsNullOrEmpty(CheckValue))
                            {
                                continue;
                            }
                            try
                            {
                                switch (RowNum)
                                {
                                    case 3:
                                        {
                                            DG.Rows.Add(i, "RX_" + i, Row.GetCell(0), Row.GetCell(1), Row.GetCell(2), 0, 0, 0);
                                            break;
                                        }
                                    case 4:
                                        {
                                            DG.Rows.Add(i, Row.GetCell(0), Row.GetCell(1), Row.GetCell(2), Row.GetCell(3), 0, 0, 0);
                                            break;
                                        }
                                    case 7:
                                        {
                                            if (string.IsNullOrEmpty(Row.GetCell(0).StringCellValue) || string.IsNullOrEmpty(Row.GetCell(1).ToString()))
                                            {
                                                ChangeGun = true;
                                                continue;
                                            }
                                            if (ChangeGun)
                                            {
                                                ChangeGun = false;
                                                DG.Rows.Add(0, "ChangeGun", 0, 0, 0, 0, 0);
                                                GunNum++;
                                            }
                                            DG.Rows.Add(i, Row.GetCell(0), Row.GetCell(1), Row.GetCell(2), Row.GetCell(3), Row.GetCell(4), Row.GetCell(5), Row.GetCell(6));
                                            RowID++;
                                            break;
                                        }
                                    case 8:
                                        {
                                            if (string.IsNullOrEmpty(Row.GetCell(0).StringCellValue) || string.IsNullOrEmpty(Row.GetCell(2).ToString()))
                                            {
                                                ChangeGun = true;
                                                continue;
                                            }
                                            if (ChangeGun)
                                            {
                                                ChangeGun = false;
                                                DG.Rows.Add(0, "ChangeGun", 0, 0, 0, 0, 0);
                                                GunNum++;
                                            }
                                            DG.Rows.Add(i, Row.GetCell(1), Row.GetCell(2), Row.GetCell(3), Row.GetCell(4), Row.GetCell(5), Row.GetCell(6), Row.GetCell(7));
                                            RowID++;
                                            break;
                                        }
                                    case 21:
                                        {
                                            if (string.IsNullOrEmpty(Row.GetCell(0).StringCellValue) || string.IsNullOrEmpty(Row.GetCell(3).ToString()))
                                            {
                                                ChangeGun = true;
                                                continue;
                                            }
                                            if (ChangeGun)
                                            {
                                                ChangeGun = false;
                                                DG.Rows.Add(0, "ChangeGun", 0, 0, 0, 0, 0);
                                                GunNum++;
                                            }
                                            DG.Rows.Add(RowID, Row.GetCell(0), Row.GetCell(3), Row.GetCell(4), Row.GetCell(5), Row.GetCell(6), Row.GetCell(7), Row.GetCell(8));
                                            RowID++;
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                    MessageBox.Show("打开失败!请确认是否已解密？");
                }
                return false;
            }
            static private void CopyStream(Stream input, Stream output)
            {
                try
                {
                    int bufferSize = 4096;
                    byte[] buffer = new byte[bufferSize];

                    while (true)
                    {
                        int read = input.Read(buffer, 0, buffer.Length);
                        if (read <= 0)
                        {
                            return;
                        }
                        output.Write(buffer, 0, read);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            static public bool ReadXlsData(string xlsPath, System.Data.DataTable DG)
            {
                //DataGridView DG = new DataGridView();
                IWorkbook xlsBook = null;
                int RowNum = 0;
                try
                {
                     xlsBook = WorkbookFactory.Create(xlsPath);
                }
                catch (Exception e)
                {
                    ////FileUpload1是 一个FileUpload控件
                    //FileInfo fileInfo = new FileInfo(xlsPath);
                    //Stream stream = File.OpenRead(xlsPath);
                    //InputStream inputStream = new FileInputStream(stream);
                    //MemoryStream m = new MemoryStream();
                    ////将文件的流拷贝一份，以内存流的格式保存
                    //CopyStream(inputStream, m);
                    //if (fileInfo.Extension.ToLower().Equals(".xls"))
                    //{
                    //    xlsBook = new HSSFWorkbook(inputStream);
                    //}
                    //else
                    //{
                    //    xlsBook = WorkbookFactory.Create(inputStream);
                    //}
                    MessageBox.Show("打开失败!错误:"+e.Message.ToString());
                    return false;
                }
                try
                {
                    ISheet sheet = (xlsBook.GetSheetAt(0).LastRowNum > xlsBook.GetSheetAt(1).LastRowNum) ? xlsBook.GetSheetAt(0) : xlsBook.GetSheetAt(1);
                    RxTypeList.CatPointType CP = new RxTypeList.CatPointType();
                    bool ChangeGun = false;
                    int GunNum = 0;
                    int RowID = 1;
                    for (int i = 0; i <= sheet.LastRowNum; i++)
                    {
                        if (sheet.LastRowNum < 2)
                        {
                            MessageBox.Show("您选择的坐标XLS为空或首个Sheet表为空，请保证首个Sheet表为即将导入的坐标集！", "导入错误报告", MessageBoxButtons.OK);
                            return false;
                        }
                        IRow Row = sheet.GetRow(i);
                        RowNum = Row.LastCellNum;
                        if (i == 0) //初始化表头
                        {
                            if (RowNum == 3 || RowNum == 4 || RowNum == 7 || RowNum == 8 || RowNum == 21)
                            {
                                System.Data.DataColumn dataColum;
                                if (DG.Columns.Count < 1)
                                {
                                    dataColum = new System.Data.DataColumn();
                                    dataColum.ColumnName = "序号";
                                    DG.Columns.Add(dataColum);
                                    dataColum = new System.Data.DataColumn();
                                    dataColum.ColumnName = "名称";
                                    DG.Columns.Add(dataColum);
                                    dataColum = new System.Data.DataColumn();
                                    dataColum.ColumnName = "X坐标";
                                    DG.Columns.Add(dataColum);
                                    dataColum = new System.Data.DataColumn();
                                    dataColum.ColumnName = "Y坐标";
                                    DG.Columns.Add(dataColum);
                                    dataColum = new System.Data.DataColumn();
                                    dataColum.ColumnName = "Z坐标";
                                    DG.Columns.Add(dataColum);
                                    dataColum = new System.Data.DataColumn();
                                    dataColum.ColumnName = "RX";
                                    DG.Columns.Add(dataColum);
                                    dataColum = new System.Data.DataColumn();
                                    dataColum.ColumnName = "RY";
                                    DG.Columns.Add(dataColum);
                                    dataColum = new System.Data.DataColumn();
                                    dataColum.ColumnName = "RZ";
                                    DG.Columns.Add(dataColum);
                                }
                            }
                            else
                            {
                                MessageBox.Show("所提供的EXCEL 文件格式不符合默认标准请提供4列(名称、X、Y、Z)、7列(带角度)、8列(多序号)的Xls表!");
                                return false;
                            }
                        }
                        else
                        {
                            string CheckValue = Row.GetCell(0).StringCellValue;
                            if (string.IsNullOrEmpty(CheckValue))
                            {
                                continue;
                            }
                            try
                            {
                                switch (RowNum)
                                {
                                    case 3:
                                        {
                                            DG.Rows.Add(i, "RX_" + i, Row.GetCell(0), Row.GetCell(1), Row.GetCell(2), 0, 0, 0);
                                            break;
                                        }
                                    case 4:
                                        {
                                            DG.Rows.Add(i, Row.GetCell(0), Row.GetCell(1), Row.GetCell(2), Row.GetCell(3), 0, 0, 0);
                                            break;
                                        }
                                    case 7:
                                        {
                                            if (string.IsNullOrEmpty(Row.GetCell(0).StringCellValue) || string.IsNullOrEmpty(Row.GetCell(1).ToString()))
                                            {
                                                ChangeGun = true;
                                                continue;
                                            }
                                            if (ChangeGun)
                                            {
                                                ChangeGun = false;
                                                DG.Rows.Add(0, "ChangeGun", 0, 0, 0, 0, 0);
                                                GunNum++;
                                            }
                                            DG.Rows.Add(i, Row.GetCell(0), Row.GetCell(1), Row.GetCell(2), Row.GetCell(3), Row.GetCell(4), Row.GetCell(5), Row.GetCell(6));
                                            RowID++;
                                            break;
                                        }
                                    case 8:
                                        {
                                            if (string.IsNullOrEmpty(Row.GetCell(0).StringCellValue) || string.IsNullOrEmpty(Row.GetCell(2).ToString()))
                                            {
                                                ChangeGun = true;
                                                continue;
                                            }
                                            if (ChangeGun)
                                            {
                                                ChangeGun = false;
                                                DG.Rows.Add(0, "ChangeGun", 0, 0, 0, 0, 0);
                                                GunNum++;
                                            }
                                            DG.Rows.Add(i, Row.GetCell(1), Row.GetCell(2), Row.GetCell(3), Row.GetCell(4), Row.GetCell(5), Row.GetCell(6), Row.GetCell(7));
                                            RowID++;
                                            break;
                                        }
                                    case 21:
                                        {
                                            if (string.IsNullOrEmpty(Row.GetCell(0).StringCellValue) || string.IsNullOrEmpty(Row.GetCell(3).ToString()))
                                            {
                                                ChangeGun = true;
                                                continue;
                                            }
                                            if (ChangeGun)
                                            {
                                                ChangeGun = false;
                                                DG.Rows.Add(0, "ChangeGun", 0, 0, 0, 0, 0);
                                                GunNum++;
                                            }
                                            DG.Rows.Add(RowID, Row.GetCell(0), Row.GetCell(3), Row.GetCell(4), Row.GetCell(5), Row.GetCell(6), Row.GetCell(7), Row.GetCell(8));
                                            RowID++;
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                    MessageBox.Show("打开失败!请确认是否已解密？");
                }
                return false;
            }
            public enum ReadXlsType { ReadWeldPoint, ReadRxWorkTime }
            static public bool ReadXlsData(string xlsPath, System.Data.DataTable DG, ReadXlsType readXlsType, ProgressBar progressBar)
            {
                //DataGridView DG = new DataGridView();
                int ColumnsNum = 0;
                try
                {
                    Excel.Application xlApp = new Excel.Application();
                    xlApp.DisplayAlerts = false;
                    xlApp.Visible = false;
                    xlApp.ScreenUpdating = false;
                    //打开Excel
                    Excel.Workbook xlsWorkBook = xlApp.Workbooks.Open(xlsPath, System.Type.Missing, System.Type.Missing, System.Type.Missing,
                    System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing,
                    System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing);
                    //处理数据过程，更多操作方法自行百度
                    Excel.Worksheet sheet;
                    if (xlsWorkBook.Sheets.Count > 1)
                    {
                        Excel.Worksheet sheetA = xlsWorkBook.Worksheets[1];//工作薄从1开始，不是0
                        Excel.Worksheet sheetB = xlsWorkBook.Worksheets[2];//工作薄从1开始，不是0
                        sheet = (sheetA.Cells.Count > sheetB.Cells.Count) ? sheetA : sheetB;
                    }
                    else
                    {
                        sheet = xlsWorkBook.Worksheets[1];
                    }
                    int SheetCount = sheet.UsedRange.Rows.Count;
                    if (SheetCount < 2)
                    {
                        MessageBox.Show("您选择的坐标XLS为空或首个Sheet表为空，请保证首个Sheet表为即将导入的坐标集！", "导入错误报告", MessageBoxButtons.OK);
                        return false;
                    }
                    if (progressBar != null)
                    {
                        progressBar.Minimum = 0;
                        progressBar.Value = 2;
                        progressBar.Maximum = SheetCount;
                        progressBar.Step = 1;
                        
                    }
                    switch (readXlsType)
                    {
                        case ReadXlsType.ReadWeldPoint:
                            #region Read And Oprate WeldPoint Part
                            RxTypeList.CatPointType CP = new RxTypeList.CatPointType();
                            bool ChangeGun = false;
                            int GunNum = 0;
                            int RowID = 1;
                            for (int i = 1; i <= SheetCount; i++)
                            {
                                ColumnsNum = sheet.UsedRange.Columns.Count;
                                if (i == 1) //初始化表头
                                {
                                    if (ColumnsNum == 3 || ColumnsNum == 4 || ColumnsNum == 7 || ColumnsNum == 8 || ColumnsNum == 21)
                                    {
                                        System.Data.DataColumn dataColum;
                                        if (DG.Columns.Count < 1)
                                        {
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "序号";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "名称";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "X坐标";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "Y坐标";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "Z坐标";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "RX";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "RY";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "RZ";
                                            DG.Columns.Add(dataColum);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("所提供的EXCEL 文件格式不符合默认标准请提供4列(名称、X、Y、Z)、7列(带角度)、8列(多序号)的Xls表!");
                                        return false;
                                    }
                                }
                                else
                                {
                                    string CheckValue = sheet.UsedRange.Cells[i, 1].Value;
                                    if (string.IsNullOrEmpty(CheckValue))
                                    {
                                        continue;
                                    }
                                    try
                                    {
                                        switch (ColumnsNum)
                                        {
                                            case 3:
                                                {
                                                    DG.Rows.Add(i, "RX_" + (i - 1), sheet.Cells[i, 1].Value, sheet.Cells[i, 2].Value, sheet.Cells[i, 3].Value, 0, 0, 0);
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    DG.Rows.Add((i - 1), sheet.Cells[i, 1].Value, sheet.Cells[i, 2].Value, sheet.Cells[i, 3].Value, sheet.Cells[i, 4].Value, 0, 0, 0);
                                                    break;
                                                }
                                            case 7:
                                                {
                                                    if (string.IsNullOrEmpty(sheet.Cells[i, 1].Value) || string.IsNullOrEmpty(sheet.Cells[i, 2].Value))
                                                    {
                                                        ChangeGun = true;
                                                        continue;
                                                    }
                                                    if (ChangeGun)
                                                    {
                                                        ChangeGun = false;
                                                        DG.Rows.Add(0, "ChangeGun", 0, 0, 0, 0, 0);
                                                        GunNum++;
                                                    }
                                                    DG.Rows.Add((i - 1), sheet.Cells[i, 1].Value, sheet.Cells[i, 2].Value, sheet.Cells[i, 3].Value, sheet.Cells[i, 4].Value, sheet.Cells[i, 5].Value, sheet.Cells[i, 6].Value, sheet.Cells[i, 7].Value);
                                                    RowID++;
                                                    break;
                                                }
                                            case 8:
                                                {
                                                    if (string.IsNullOrEmpty(sheet.Cells[i, 1].Value) || string.IsNullOrEmpty(sheet.Cells[i, 2].Value))
                                                    {
                                                        ChangeGun = true;
                                                        continue;
                                                    }
                                                    if (ChangeGun)
                                                    {
                                                        ChangeGun = false;
                                                        DG.Rows.Add(0, "ChangeGun", 0, 0, 0, 0, 0);
                                                        GunNum++;
                                                    }
                                                    DG.Rows.Add((i - 1), sheet.Cells[i, 2].Value, sheet.Cells[i, 3].Value, sheet.Cells[i, 4].Value, sheet.Cells[i, 5].Value, sheet.Cells[i, 6].Value, sheet.Cells[i, 7].Value, sheet.Cells[i, 8].Value);
                                                    RowID++;
                                                    break;
                                                }
                                            case 21:
                                                {
                                                    if (string.IsNullOrEmpty(sheet.Cells[i, 1].Value) || string.IsNullOrEmpty(sheet.Cells[i, 4].Value))
                                                    {
                                                        ChangeGun = true;
                                                        continue;
                                                    }
                                                    if (ChangeGun)
                                                    {
                                                        ChangeGun = false;
                                                        DG.Rows.Add(0, "ChangeGun", 0, 0, 0, 0, 0);
                                                        GunNum++;
                                                    }
                                                    DG.Rows.Add(RowID, sheet.Cells[i, 1].Value, sheet.Cells[i, 4].Value, sheet.Cells[i, 5].Value, sheet.Cells[i, 6].Value, sheet.Cells[i, 7].Value, sheet.Cells[i, 8].Value, sheet.Cells[i, 9].Value);
                                                    RowID++;
                                                    break;
                                                }
                                            default:
                                                break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                }
                            }
                            ClosePro(xlApp, xlsWorkBook);
                            return true;
                        #endregion
                        case ReadXlsType.ReadRxWorkTime:
                            #region Read Xls Data And Updata To DataGard For Rx WorkTime
                            for (int i = 2; i <= SheetCount; i++)
                            {
                                progressBar.PerformStep();
                                ColumnsNum = sheet.UsedRange.Columns.Count;
                                if (i == 2) //初始化表头
                                {
                                    if (ColumnsNum == 3 || ColumnsNum == 4 || ColumnsNum == 7 || ColumnsNum == 8 || ColumnsNum == 21)
                                    {
                                        System.Data.DataColumn dataColum;
                                        if (DG.Columns.Count < 1)
                                        {
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "序号";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "人员编号";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "姓名";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "部门";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "上班考勤时间";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "下班考勤时间";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "考勤状态";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "考勤区域";
                                            DG.Columns.Add(dataColum);
                                            dataColum = new System.Data.DataColumn();
                                            dataColum.ColumnName = "设备序列号";
                                            DG.Columns.Add(dataColum);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("所提供的EXCEL 文件格式不符合默认标准请提供4列(名称、X、Y、Z)、7列(带角度)、8列(多序号)的Xls表!");
                                        return false;
                                    }
                                }
                                else
                                {
                                    string CheckValue = sheet.UsedRange.Cells[i, 1].Value;
                                    if (string.IsNullOrEmpty(CheckValue))
                                    {
                                        continue;
                                    }
                                    try
                                    {
                                        if (string.IsNullOrEmpty(sheet.Cells[i, 1].Value) || string.IsNullOrEmpty(sheet.Cells[i, 2].Value))
                                        {
                                            ChangeGun = true;
                                            continue;
                                        }
                                        Task.Run(DG.Rows.Add((i - 2), sheet.Cells[i, 1].Value, sheet.Cells[i, 2].Value, sheet.Cells[i, 3].Value, sheet.Cells[i, 4].Value, 0, sheet.Cells[i, 5].Value, sheet.Cells[i, 6].Value, sheet.Cells[i, 7].Value));
                                        //DG.Rows.Add((i - 2), sheet.Cells[i, 1].Value, sheet.Cells[i, 2].Value, sheet.Cells[i, 3].Value, sheet.Cells[i, 4].Value,0, sheet.Cells[i, 5].Value, sheet.Cells[i, 6].Value, sheet.Cells[i, 7].Value);
                                        //break;
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                }
                            }
                            ClosePro(xlApp, xlsWorkBook);
                            #endregion
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("打开失败!使用该软件必须装载有Office 2013或以上版本，如果已安装请确认是否已解密？");
                }
                return false;
            }
            /// <summary>
            /// 读取EXCEL焊点坐标数据
            /// </summary>
            static public string oPenXls()
            {
                //HSSFWorkbook wkb = new HSSFWorkbook();
                Stream myStream = null;
                OpenFileDialog XlsFile = new OpenFileDialog();
                XlsFile.InitialDirectory = "C:\\Users\\Administrator\\Desktop\\";
                XlsFile.Filter = "EXCEL files (*.xls,*.xlsx)|*.xls;*.xlsx";
                XlsFile.FilterIndex = 2;
                XlsFile.RestoreDirectory = true;
                if (XlsFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((myStream = XlsFile.OpenFile()) != null)
                        {
                            return XlsFile.FileName;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// 对数据进行执行重复检查，标记重复数据并在执行完成后报警！
        /// </summary>
        /// <param name="DGR">待检测对象行</param>
        /// <param name="DG">参考数据集</param>
        /// <returns></returns>
        static public bool DoRepeatCheck(double[] DGR, System.Data.DataTable DG)
        {
            bool Result = false;
            int Num = 0;
            if (DG.Rows.Count < 1)
            {
                // MessageBox.Show("当前未导入任何数据，请导入数据后重试!");
                return false;
            }
            foreach (DataRow Row in DG.Rows)
            {
                if (string.IsNullOrEmpty(Row[0].ToString())) //确定当前行非空
                {
                    continue;
                }
                if ((Convert.ToDouble(Row[2]) == DGR[0] && Convert.ToDouble(Row[3]) == DGR[1] && Convert.ToDouble(Row[4]) == DGR[2]))//对比XYZ值 如果一致则判断重复
                {
                    Num += 1;
                }
            }
            Result = Num > 0; //扣除本身数量
            return Result;
        }
        static void ClosePro(Excel.Application xlApp, Excel.Workbook xlsWorkBook)
        {
            if (xlsWorkBook != null)
                xlsWorkBook.Close(true, Type.Missing, Type.Missing);
            xlApp.Quit();
            // 安全回收进程
            System.GC.GetGeneration(xlApp);
            // IntPtr t = new IntPtr(xlApp.Hwnd);   //获取句柄
            //int k = 0;
            //GetWindowThreadProcessId(t, out k);   //获取进程唯一标志
            //System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
            // p.Kill();     //关闭进程
        }
    }
}
