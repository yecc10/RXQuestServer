using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WordToAix
{
    public partial class WordToAix : Form
    {
        Core core = new Core();
        Bitmap bitmap = null;
        public WordToAix()
        {
            InitializeComponent();
            timer.Enabled = true;
        }
        private void DoTranslate_Click(object sender, EventArgs e)
        {
            TextPicture.SizeMode = PictureBoxSizeMode.Zoom;
            if (!string.IsNullOrEmpty(TargetText.Text))
            {
                Size size = new Size(Convert.ToInt32(Xpix.Text), Convert.ToInt32(Ypix.Text));
                bitmap =core.GetCharBMP(TargetText.Text, size);
                TextPicture.Image = bitmap;
            }
        }
        private void SaveAix_Click(object sender, EventArgs e)
        {
            if (bitmap!=null)
            {
                Size size = new Size(Convert.ToInt32(Xpix.Text), Convert.ToInt32(Ypix.Text));
                core.SaveImageDateToXls(bitmap, size);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Text = "瑞祥快捷设计中心 BY_安徽瑞祥工业【工厂仿真组】叶朝成_当前时间: " + DateTime.Now.ToString();
        }
    }
}
