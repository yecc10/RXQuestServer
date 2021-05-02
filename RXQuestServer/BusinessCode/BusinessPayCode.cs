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
            string url2 = nativePay.GetPayUrl("产品注册3个月",8100, "锐锋科技自动化产品3个月授权注册"); //生成扫码支付模式二url
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

        private void purchase3_CheckedChanged(object sender, EventArgs e)
        {
            NativePay nativePay = new NativePay();
            string url2 = nativePay.GetPayUrl("产品注册3个月", 8100, "锐锋科技自动化产品3个月授权注册"); //生成扫码支付模式二url
            //将url生成二维码图片
            WxPayCode.Image = QrCode(url2);
        }

        private void purchase6_CheckedChanged(object sender, EventArgs e)
        {
            NativePay nativePay = new NativePay();
            string url2 = nativePay.GetPayUrl("产品注册6个月", 15300, "锐锋科技自动化产品6个月授权注册"); //生成扫码支付模式二url
            //将url生成二维码图片
            WxPayCode.Image = QrCode(url2);
        }

        private void purchase12_CheckedChanged(object sender, EventArgs e)
        {
            NativePay nativePay = new NativePay();
            string url2 = nativePay.GetPayUrl("产品注册1年许可", 28800, "锐锋科技自动化产品12+3【赠送】个月授权注册"); //生成扫码支付模式二url
            //将url生成二维码图片
            WxPayCode.Image = QrCode(url2);
        }

        private void purchase24_CheckedChanged(object sender, EventArgs e)
        {
            NativePay nativePay = new NativePay();
            string url2 = nativePay.GetPayUrl("产品注册2年许可", 54000, "锐锋科技自动化产品24+6【赠送】个月授权注册"); //生成扫码支付模式二url
            //将url生成二维码图片
            WxPayCode.Image = QrCode(url2);
        }

        private void purchase36_CheckedChanged(object sender, EventArgs e)
        {
            NativePay nativePay = new NativePay();
            string url2 = nativePay.GetPayUrl("产品注册3年许可", 75600, "锐锋科技自动化产品36+12【赠送】个月授权注册"); //生成扫码支付模式二url
            //将url生成二维码图片
            WxPayCode.Image = QrCode(url2);
        }
    }
}
