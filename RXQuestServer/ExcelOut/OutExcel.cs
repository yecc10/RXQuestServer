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
namespace RXQuestServer.ExcelOut
{
    /// <summary>
    /// Excel操作
    /// </summary>
    static public class ExcelOprator
    {
        #region Data Out To Excel
        /// <summary>
        /// 将dataGridView导出到EXCEL
        /// </summary>
        /// <param name="dataGridView">需要导出的dataGridView数据</param>
        /// <returns></returns>
        static public bool SaveToExcel(DataGridView dataGridView, string SportName)
        {
            if (dataGridView.Rows.Count > 1)
            {
                HSSFWorkbook wkb = new HSSFWorkbook();
                ISheet sheet = wkb.CreateSheet("瑞祥工业物流组");
                sheet.DefaultColumnWidth = 15;
                IRow HeadRow = sheet.CreateRow(0);
                HeadRow.Height = 400;
                ICellStyle CST = wkb.CreateCellStyle();
                CST.VerticalAlignment = VerticalAlignment.Center;
                CST.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                for (int i = 0; i < dataGridView.Rows[1].Cells.Count; i++) //初始化表头
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
        #endregion
        #region DataInput
        static public bool ReadExcel(DataGridView dataGridView, string SportName)
        {
            return true;
        }
        #endregion
    }
}