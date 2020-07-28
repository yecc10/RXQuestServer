using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OcrCenter
{
    public partial class ScreenImage : Form
    {
        Rectangle RC = new Rectangle(0, 0, 0, 0);
        Point _StartPoint = new Point(0, 0);
        Point _EndPoint = new Point(0, 0);
        Form BeforeForm = null;
        public ScreenImage()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            pictureBox.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }
        public void SetCallerForm(Form PreForm)
        {
            BeforeForm = PreForm;
        }
        public void SetPictureBox(Image Picture)
        {
            pictureBox.Image = Picture;
            Cursor.Position = new Point(Screen.PrimaryScreen.Bounds.Width/2, Screen.PrimaryScreen.Bounds.Height/2);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _StartPoint.X = Cursor.Position.X;
            _StartPoint.Y = Cursor.Position.Y;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.Hide();
            _EndPoint.X = Cursor.Position.X;
            _EndPoint.Y = Cursor.Position.Y;
            //创建图象，保存将来截取的图象
            Bitmap image = new Bitmap(Math.Abs(_StartPoint.X - _EndPoint.X), Math.Abs(_StartPoint.Y - _EndPoint.Y));
            Graphics imgGraphics = Graphics.FromImage(image);
            //设置截屏区域
            imgGraphics.CopyFromScreen(_StartPoint.X, _StartPoint.Y,0, 0,new Size(Math.Abs(_StartPoint.X- _EndPoint.X), Math.Abs(_StartPoint.Y - _EndPoint.Y)));
            //保存;
            GetScreen GS = new GetScreen();
            string Path=GS.SaveImage(image,true);
            OCR _ocr = (OCR)BeforeForm;
            _ocr.Show();
            _ocr.MaximizeBox = true;
            _ocr.TopMost = true;
            _ocr.TranslateOCRByScreenImage(Path);
        }
    }
}
