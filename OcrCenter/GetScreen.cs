using Baidu.Aip.Ocr;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OcrCenter
{
    class GetScreen
    {
        //截取全屏图象
        public void GetWholeScreen()
        {
            //创建图象，保存将来截取的图象
            Bitmap image = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics imgGraphics = Graphics.FromImage(image);
            //设置截屏区域
            imgGraphics.CopyFromScreen(0, 0, 0, 0, new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
            //保存

            SaveImage(image);
        }

        //保存图象文件
        public void SaveImage(Image image)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                string extension = Path.GetExtension(fileName);
                if (extension == ".jpg")
                {
                    image.Save(fileName, ImageFormat.Jpeg);
                }
                else
                {
                    image.Save(fileName, ImageFormat.Bmp);
                }
            }
        }
    }
    class SaveAsNewDoc
    {
        /// <summary>
        /// 设置字体格式
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="table"></param>
        /// <param name="setText"></param>
        /// <returns></returns>
        public XWPFParagraph SetCellText(XWPFDocument doc, XWPFTable table, string setText)
        {
            //table中的文字格式设置
            var para = new CT_P();
            var pCell = new XWPFParagraph(para, table.Body);
            pCell.Alignment = ParagraphAlignment.CENTER; //字体居中
            pCell.VerticalAlignment = TextAlignment.CENTER; //字体居中
            var r1c1 = pCell.CreateRun();
            r1c1.SetText(setText);
            r1c1.FontSize = 12;
            r1c1.SetFontFamily("华文楷体", FontCharRange.None); //设置雅黑字体
            return pCell;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //创建document对象
            var doc = new XWPFDocument();
            //创建段落对象1
            var p1 = doc.CreateParagraph();
            p1.Alignment = ParagraphAlignment.CENTER; //字体居中
                                                      //创建run对象
                                                      //本节提到的所有样式都是基于XWPFRun的，
                                                      //你可以把XWPFRun理解成一小段文字的描述对象，
                                                      //这也是Word文档的特征，即文本描述性文档。
                                                      //来自Tony Qu http://tonyqus.sinaapp.com/archives/609
            var runTitle = p1.CreateRun();
            runTitle.IsBold = true;
            runTitle.SetText("军检验收单");
            runTitle.FontSize = 16;
            runTitle.SetFontFamily("宋体", FontCharRange.None); //设置雅黑字体
                                                              //创建段落对象2
            var p2 = doc.CreateParagraph();
            var run1 = p2.CreateRun();
            run1.SetText(" 军检项目号：");
            run1.FontSize = 12;
            run1.SetFontFamily("华文楷体", FontCharRange.None); //设置雅黑字体
            #region 头部(6 rows)
            //基本row12，列5;头部6行，4列
            var tableTop = doc.CreateTable(6, 5);
            tableTop.Width = 1000 * 5;
            tableTop.SetColumnWidth(0, 1300); /* 设置列宽 */
            tableTop.SetColumnWidth(1, 500); /* 设置列宽 */
            tableTop.SetColumnWidth(2, 1000); /* 设置列宽 */
            tableTop.SetColumnWidth(3, 500); /* 设置列宽 */
            tableTop.SetColumnWidth(4, 1700); /* 设置列宽 */
            tableTop.GetRow(0).MergeCells(1, 4); /* 合并行 */
            tableTop.GetRow(0).GetCell(0).SetParagraph(SetCellText(doc, tableTop, "产品名称"));
            tableTop.GetRow(0).GetCell(1).SetParagraph(SetCellText(doc, tableTop, " "));
            tableTop.GetRow(1).MergeCells(1, 4);
            tableTop.GetRow(1).GetCell(0).SetParagraph(SetCellText(doc, tableTop, "项目名称"));
            tableTop.GetRow(1).GetCell(1).SetParagraph(SetCellText(doc, tableTop, " "));
            tableTop.GetRow(2).MergeCells(1, 4);
            tableTop.GetRow(2)
            .GetCell(0)
            .SetParagraph(SetCellText(doc, tableTop, "施工依据", ParagraphAlignment.CENTER, 45));
            tableTop.GetRow(2)
            .GetCell(1)
            .SetParagraph(SetCellText(doc, tableTop, " ", ParagraphAlignment.CENTER, 45));
            tableTop.GetRow(3).GetCell(0).SetParagraph(SetCellText(doc, tableTop, "检验方式"));
            tableTop.GetRow(3).GetCell(1).SetParagraph(SetCellText(doc, tableTop, "独立检验"));
            tableTop.GetRow(3).GetCell(2).SetParagraph(SetCellText(doc, tableTop, " "));
            tableTop.GetRow(3).GetCell(3).SetParagraph(SetCellText(doc, tableTop, "联合检验"));
            tableTop.GetRow(3).GetCell(4).SetParagraph(SetCellText(doc, tableTop, " "));
            tableTop.GetRow(4).MergeCells(3, 4);
            tableTop.GetRow(4).GetCell(0).SetParagraph(SetCellText(doc, tableTop, "设备名称及编号"));
            tableTop.GetRow(4).GetCell(1).SetParagraph(SetCellText(doc, tableTop, " "));
            tableTop.GetRow(4).GetCell(2).SetParagraph(SetCellText(doc, tableTop, "设备制造厂"));
            tableTop.GetRow(4).GetCell(3).SetParagraph(SetCellText(doc, tableTop, " "));
            //tableTop.GetRow(4).GetCell(3).SetBorderBottom(XWPFtableTop.XWPFBorderType.NONE,0,0,"");
            tableTop.GetRow(5).MergeCells(0, 4);
            var para = new CT_P();
            var pCell = new XWPFParagraph(para, tableTop.Body);
            pCell.Alignment = ParagraphAlignment.LEFT; //字体居中
            var r1c1 = pCell.CreateRun();
            r1c1.SetText("检验要素共9项");
            r1c1.FontSize = 12;
            r1c1.SetFontFamily("华文楷体", FontCharRange.None); //设置雅黑字体
            tableTop.GetRow(5).GetCell(0).SetParagraph(pCell);
            //table.GetRow(6).GetCell(0).SetParagraph(SetCellText(doc, table, "序号"));
            //table.GetRow(6).GetCell(1).SetParagraph(SetCellText(doc, table, "检验要素"));
            //table.GetRow(6).GetCell(2).SetParagraph(SetCellText(doc, table, "指标要求"));
            //table.GetRow(6).GetCell(3).SetParagraph(SetCellText(doc, table, "实测值"));
            //table.GetRow(6).GetCell(4).SetParagraph(SetCellText(doc, table, "测量工具编号及有效期"));
            #endregion
            #region 检验要素列表部分(数据库读取循环显示)
            /* 打印1页:小于8行数据,创建9行；
            * 打印2页:大于8小于26行数据，创建27行。增加18
            * 打印3页:大于26小于44行数据，创建45行。增加18
            */
            var tableContent = doc.CreateTable(45, 5);
            tableContent.Width = 1000 * 5;
            tableContent.SetColumnWidth(0, 300); /* 设置列宽 */
            tableContent.SetColumnWidth(1, 1000); /* 设置列宽 */
            tableContent.SetColumnWidth(2, 1000); /* 设置列宽 */
            tableContent.SetColumnWidth(3, 1000); /* 设置列宽 */
            tableContent.SetColumnWidth(4, 1700); /* 设置列宽 */
            tableContent.GetRow(0).GetCell(0).SetParagraph(SetCellText(doc, tableContent, "序号"));
            tableContent.GetRow(0).GetCell(1).SetParagraph(SetCellText(doc, tableContent, "检验要素"));
            tableContent.GetRow(0).GetCell(2).SetParagraph(SetCellText(doc, tableContent, "指标要求"));
            tableContent.GetRow(0).GetCell(3).SetParagraph(SetCellText(doc, tableContent, "实测值"));
            tableContent.GetRow(0).GetCell(4).SetParagraph(SetCellText(doc, tableContent, "测量工具编号及有效期"));
            for (var i = 1; i < 45; i++)
            {
                tableContent.GetRow(i)
                .GetCell(0)
                .SetParagraph(SetCellText(doc, tableContent, i.ToString(), ParagraphAlignment.CENTER, 50));
                tableContent.GetRow(i)
                .GetCell(1)
                .SetParagraph(SetCellText(doc, tableContent, "检验要素", ParagraphAlignment.CENTER, 50));
                tableContent.GetRow(i)
                .GetCell(2)
                .SetParagraph(SetCellText(doc, tableContent, "指标要求", ParagraphAlignment.CENTER, 50));
                tableContent.GetRow(i)
                .GetCell(3)
                .SetParagraph(SetCellText(doc, tableContent, "实测值", ParagraphAlignment.CENTER, 50));
                tableContent.GetRow(i)
                .GetCell(4)
                .SetParagraph(SetCellText(doc, tableContent, "测量工具编号及有效期", ParagraphAlignment.CENTER, 50));
            }
            #endregion
            #region 底部内容
            var tableBottom = doc.CreateTable(5, 4);
            tableBottom.Width = 1000 * 5;
            tableBottom.SetColumnWidth(0, 1000); /* 设置列宽 */
            tableBottom.SetColumnWidth(1, 1500); /* 设置列宽 */
            tableBottom.SetColumnWidth(2, 1000); /* 设置列宽 */
            tableBottom.SetColumnWidth(3, 1500); /* 设置列宽 */
            tableBottom.GetRow(0).MergeCells(0, 3); /* 合并行 */
            tableBottom.GetRow(0)
            .GetCell(0)
            .SetParagraph(SetCellText(doc, tableBottom, "附件：", ParagraphAlignment.LEFT, 80));
            tableBottom.GetRow(0).Height = 30;
            tableBottom.GetRow(1).MergeCells(0, 3); /* 合并行 */
            tableBottom.GetRow(1)
            .GetCell(0)
            .SetParagraph(SetCellText(doc, tableBottom, "检验结论：", ParagraphAlignment.LEFT, 80));
            tableBottom.GetRow(1).Height = 30;
            tableBottom.GetRow(2).GetCell(0).SetParagraph(SetCellText(doc, tableBottom, "施工部门"));
            tableBottom.GetRow(2).GetCell(1).SetParagraph(SetCellText(doc, tableBottom, " "));
            tableBottom.GetRow(2).GetCell(2).SetParagraph(SetCellText(doc, tableBottom, "报验日期"));
            tableBottom.GetRow(2).GetCell(3).SetParagraph(SetCellText(doc, tableBottom, " "));
            tableBottom.GetRow(3).GetCell(0).SetParagraph(SetCellText(doc, tableBottom, "军检次数"));
            tableBottom.GetRow(3).GetCell(1).SetParagraph(SetCellText(doc, tableBottom, " "));
            tableBottom.GetRow(3).GetCell(2).SetParagraph(SetCellText(doc, tableBottom, "军检日期"));
            tableBottom.GetRow(3).GetCell(3).SetParagraph(SetCellText(doc, tableBottom, " "));
            tableBottom.GetRow(4).GetCell(0).SetParagraph(SetCellText(doc, tableBottom, "检验员"));
            tableBottom.GetRow(4).GetCell(1).SetParagraph(SetCellText(doc, tableBottom, " "));
            tableBottom.GetRow(4).GetCell(2).SetParagraph(SetCellText(doc, tableBottom, "军代表"));
            tableBottom.GetRow(4).GetCell(3).SetParagraph(SetCellText(doc, tableBottom, " "));
            #endregion
            //保存文件到磁盘WinForm
            //string docPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "DocxWord");
            //if (!Directory.Exists(docPath)) { Directory.CreateDirectory(docPath); }
            //string fileName = string.Format("{0}.doc", HttpUtility.UrlEncode("jjysd" + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff"), System.Text.Encoding.UTF8));
            //FileStream out1 = new FileStream(Path.Combine(docPath, fileName), FileMode.Create);
            //doc.Write(out1);
            //out1.Close();
            #region 保存导出WebForm
            //Response.Redirect(ResolveUrl(string.Format(@"~\DocxWord\{0}", fileName)));
            var ms = new MemoryStream();
            doc.Write(ms);
            //Response.AddHeader("Content-Disposition",
            // string.Format("attachment; filename={0}.doc",
            // HttpUtility.UrlEncode("文件名" + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff"),
            // Encoding.UTF8)));
            //Response.BinaryWrite(ms.ToArray());
            //Response.End();
            ms.Close();
            ms.Dispose();
            //using (MemoryStream ms = new MemoryStream())
            //{
            // doc.Write(ms);
            // Response.ClearContent();
            // Response.Buffer = true;
            // Response.ContentType = "application/octet-stream";
            // Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.doc", HttpUtility.UrlEncode("军检验收单" + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff"), System.Text.Encoding.UTF8)));
            // Response.BinaryWrite(ms.ToArray());
            // //Response.End();
            // Response.Flush();
            // doc = null;
            // ms.Close();
            // ms.Dispose();
            //}
            #endregion
        }
        /// <summary>
        /// 设置单元格格式
        /// </summary>
        /// <param name="doc">doc对象</param>
        /// <param name="table">表格对象</param>
        /// <param name="setText">要填充的文字</param>
        /// <param name="align">文字对齐方式</param>
        /// <param name="textPos">rows行的高度</param>
        /// <returns></returns>
        public XWPFParagraph SetCellText(XWPFDocument doc, XWPFTable table, string setText, ParagraphAlignment align,
        int textPos)
        {
            var para = new CT_P();
            var pCell = new XWPFParagraph(para, table.Body);
            //pCell.Alignment = ParagraphAlignment.LEFT;//字体
            pCell.Alignment = align;
            var r1c1 = pCell.CreateRun();
            r1c1.SetText(setText);
            r1c1.FontSize = 12;
            r1c1.SetFontFamily("华文楷体", FontCharRange.None); //设置雅黑字体
            //r1c1.SetTextPosition(textPos); //设置高度
            return pCell;
        }

    }
}
