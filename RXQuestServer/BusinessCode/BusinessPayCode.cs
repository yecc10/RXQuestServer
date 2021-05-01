using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using WxPayAPI;
using WxPayAPI.lib;

namespace RFTechnology.BusinessCode
{
    public partial class BusinessPayCode : Form
    {
        public BusinessPayCode()
        {
            InitializeComponent();
            TextBox.Text = Properties.Resources.PayNote.ToString();//初始化支付页面说明
            NativePay nativePay = new NativePay();
            //string url21 = nativePay.GetPrePayUrl("Test");
            string url2 = nativePay.GetPayUrl("产品注册"); //生成扫码支付模式二url
            //将url生成二维码图片
            WxPayCode.Image = QrCode(url2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegKeyInput regKeyInput = new RegKeyInput();
            regKeyInput.Show();
        }
        public Bitmap QrCode(String TargetStr)
        {
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(TargetStr, QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qRCode = new QRCoder.QRCode(qRCodeData);
            Bitmap bitmap = qRCode.GetGraphic(10, Color.Black, Color.White, null, 15, 6, false);
            return bitmap;
        }

        private void BusinessPayCode_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            System.Environment.Exit(0);
        }
    }
}
