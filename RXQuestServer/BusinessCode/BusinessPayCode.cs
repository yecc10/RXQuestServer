using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using WxPayAPI;
using WxPayAPI.lib;

namespace RFTechnology.BusinessCode
{
    public partial class BusinessPayCode : Form
    {
        public BusinessPayCode()
        {
            InitializeComponent();
            TextBox.Text = Properties.Resources.Note_text.ToString();//初始化支付页面说明
            NativePay nativePay = new NativePay();
            string url2 = nativePay.GetPayUrl("Test"); //生成扫码支付模式二url
            //将url生成二维码图片
            WxPayCode.ImageLocation = "MakeQRCode.aspx?data=" + HttpUtility.UrlEncode(url2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegKeyInput regKeyInput = new RegKeyInput();
            regKeyInput.Show();
        }
    }
}
