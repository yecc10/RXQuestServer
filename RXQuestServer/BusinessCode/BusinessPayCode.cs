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
using RFTechnology;

namespace RFTechnology.BusinessCode
{
    public partial class BusinessPayCode : Form
    {
        WxPayData notifyData = new WxPayData();
        public BusinessPayCode()
        {
            InitializeComponent();
            TextBox.Text = Properties.Resources.PayNote.ToString();//初始化支付页面说明
            NativePay nativePay = new NativePay();
            string url2 = nativePay.GetPayUrl("产品注册3个月", 1, "锐锋科技自动化产品3个月授权注册",ref notifyData); //生成扫码支付模式二url
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
            string url2 = nativePay.GetPayUrl("产品注册3个月", 300, "锐锋科技自动化产品3个月授权注册", ref notifyData); //生成扫码支付模式二url
            //将url生成二维码图片
            WxPayCode.Image = QrCode(url2);
        }

        private void purchase6_CheckedChanged(object sender, EventArgs e)
        {
            NativePay nativePay = new NativePay();
            string url2 = nativePay.GetPayUrl("产品注册6个月", 600, "锐锋科技自动化产品6个月授权注册", ref notifyData); //生成扫码支付模式二url
            //将url生成二维码图片
            WxPayCode.Image = QrCode(url2);
        }

        private void purchase12_CheckedChanged(object sender, EventArgs e)
        {
            NativePay nativePay = new NativePay();
            string url2 = nativePay.GetPayUrl("产品注册1年许可", 1200, "锐锋科技自动化产品12+3【赠送】个月授权注册", ref notifyData); //生成扫码支付模式二url
            //将url生成二维码图片
            WxPayCode.Image = QrCode(url2);
        }

        private void purchase24_CheckedChanged(object sender, EventArgs e)
        {
            NativePay nativePay = new NativePay();
            string url2 = nativePay.GetPayUrl("产品注册2年许可", 2400, "锐锋科技自动化产品24+6【赠送】个月授权注册", ref notifyData); //生成扫码支付模式二url
            //将url生成二维码图片
            WxPayCode.Image = QrCode(url2);
        }

        private void purchase36_CheckedChanged(object sender, EventArgs e)
        {
            NativePay nativePay = new NativePay();
            string url2 = nativePay.GetPayUrl("产品注册3年许可", 3600, "锐锋科技自动化产品36+12【赠送】个月授权注册", ref notifyData); //生成扫码支付模式二url
            //将url生成二维码图片
            WxPayCode.Image = QrCode(url2);
        }

        private void PayFinishedGetResult_Click(object sender, EventArgs e)
        {
            WxPayData Data = new WxPayData();
            Data.SetValue("body",notifyData.GetValue("body"));
            Data.SetValue("out_trade_no", notifyData.GetValue("out_trade_no"));
            Data.SetValue("total_fee", notifyData.GetValue("total_fee"));
            Data.SetValue("auth_code", notifyData.GetValue("auth_code"));
            WxPayData result = WxPayApi.OrderQuery(notifyData, 10); //提交被扫支付，接收返回结果
                                                                  //如果提交被扫支付接口调用失败，则抛异常
            //刷卡支付直接成功
            if (result.GetValue("return_code").ToString() == "SUCCESS" &&
                result.GetValue("result_code").ToString() == "SUCCESS"&&
                result.GetValue("trade_state").ToString() == "SUCCESS")
            {
                try
                {
                    //将数据写入数据库
                    GetComputerData computerData = new GetComputerData();
                    string NetID = computerData.GetNetBoardID();
                   
                    int? WriteResult =-99;
                    data.AddUserWxPayInformation(NetID,result.GetValue("device_info").ToString(),result.GetValue("openid").ToString(), result.GetValue("is_subscribe").ToString(), result.GetValue("trade_type").ToString()
                        , result.GetValue("trade_state").ToString(), result.GetValue("bank_type").ToString(), Convert.ToInt32(result.GetValue("total_fee")), Convert.ToInt32(result.GetValue("settlement_total_fee")),result.GetValue("fee_type").ToString()
                        , Convert.ToInt32(result.GetValue("cash_fee")), result.GetValue("cash_fee_type").ToString(), Convert.ToInt32(result.GetValue("coupon_fee")), Convert.ToInt32(result.GetValue("coupon_count")), result.GetValue("coupon_type_$n").ToString()
                        , result.GetValue("coupon_id_$n").ToString(), Convert.ToInt32(result.GetValue("coupon_fee_$n")),result.GetValue("transaction_id").ToString(), result.GetValue("out_trade_no").ToString(), result.GetValue("attach").ToString()
                        , result.GetValue("time_end").ToString(), result.GetValue("trade_state_desc").ToString(), ref WriteResult);
                    if (WriteResult==1)
                    {

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("您已完成付款，但是数据库写入失败，请将订单信息 截图发送到邮箱yecc10@live.cn 我们将尽快为您处理，如果您着急使用可以直接电话联系15655358685！---为表示歉意 我们会为您额外赠送1个月的使用权限！");
                }
                //Log.Debug("MicroPay", "Micropay business success, result : " + result.ToXml());
               // return result.ToPrintStr();
            }
        }
    }
}
