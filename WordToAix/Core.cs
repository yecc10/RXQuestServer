using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YeccAutoCenter;

namespace WordToAix
{
    class Core
    {
        public Bitmap GetCharBMP(string str,Size size)
        {
            StringFormat sf = new StringFormat(); // 设置格式
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Near;
            Bitmap bmp = new Bitmap(size.Width, size.Height); // 新建位图变量
            Graphics g = Graphics.FromImage(bmp);
            g.DrawString(str, new Font("宋体", (size.Width) * 3 / 4 / str.Length), Brushes.Black, new Rectangle(0, 0, size.Width, size.Height), sf); // 向图像变量输出字符
            return bmp;
        }
        public void CreateCharSetFile(string filePath, Size size)
        {
            StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Default);
            sw.WriteLine("char char_set_pixel [] = {"); // 开始写入字符点阵
            string charSet = string.Empty;
            foreach (char ch in charSet)
            {
                Bitmap bmp = GetCharBMP(ch.ToString(), size); // 获取待分析的字符位图
                for (int i = 0; i < bmp.Height; i++)
                {
                    byte temp = 0;
                    for (int j = 0; j < bmp.Width; j++)
                    {
                        if (bmp.GetPixel(j, i) == Color.FromArgb(0, 0, 0))// 以下几行根据点阵格式计算它的十六进制并写入
                            //temp += (byte)Math.Pow(2, (size / 4 - 1) - j % (size / 4));
                        if (j % 8 == 7)
                        {
                            if (temp.ToString("x").Length == 2)
                                sw.Write("0x" + temp.ToString("x"));
                            else sw.Write("0x0" + temp.ToString("x"));
                            if (!(j == bmp.Width - 1 && i == bmp.Height - 1 && ch == charSet[charSet.Length - 1]))
                                sw.Write(",");
                            temp = 0;
                        }
                    }
                    if (i % 4 == 3)
                        sw.WriteLine();
                }
                sw.WriteLine();
            }
            sw.WriteLine("};");
            sw.Close();
        }
        public void SaveImageDateToXls(Bitmap bmp,Size size)
        {
            DataTable dataTable = new DataTable();
            System.Data.DataColumn dataColum;
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "X坐标";
            dataTable.Columns.Add(dataColum);
            dataColum = new System.Data.DataColumn();
            dataColum.ColumnName = "Y坐标";
            dataTable.Columns.Add(dataColum);
            DataGridView dataGrid = new DataGridView();
            dataGrid.Columns.Add("X坐标", "X坐标");
            dataGrid.Columns.Add("Y坐标", "Y坐标");
            // 获取待分析的字符位图
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    if (bmp.GetPixel(j, i) == Color.FromArgb(0, 0, 0))// 以下几行根据点阵格式计算它的十六进制并写入
                    {
                        dataGrid.Rows.Add(i,j);
                        DataRow dataRow = dataTable.NewRow();
                        dataRow["X坐标"] = i;
                        dataRow["Y坐标"] = j;
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
            RxDataOprator.ExcelOprator.SaveExcelForLvSport(dataGrid, "文字仓储");
            //Console.WriteLine(dataTable.Rows.Count);
        }
    }
}
