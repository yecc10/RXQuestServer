using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtWorks.QRCode.Codec;
using WxPayAPI;
using WxPayAPI.lib;
using RFTechnology;
using System.Globalization;
using System.Windows.Forms;

namespace RFTechnology.BusinessCode
{
    class PayUserPayDataAndToServer
    {
    }
    class PayUserData
    {
        string NetID;//设备网卡编号
        /// <summary>
        /// 以下为请求参数 系统查询时候会将相关参数直接带回////////////////////////////////////////////////////////////////////////////
        /// </summary>
        string appid; //公众账号ID
        string mch_id; //商户号
        string transaction_id; //微信订单号
        string out_trade_no; //商户订单号
        string nonce_str; //随机字符串
        string sign; //签名
        string sign_type; //签名类型
        /// <summary>
        /// 以下为返回结果
        /// </summary>
        string return_code;//返回状态码 SUCCESS/FAIL 此字段是通信标识，非交易标识，交易是否成功需要查看trade_state来判断
        string return_msg;//返回信息当return_code为FAIL时返回信息为错误原因 ，例如签名失败 参数格式校验错误
        /// <summary>
        /// 以下字段在return_code为SUCCESS的时候有返回
        /// </summary>
        string result_code;//业务结果
        //string err_code;//错误代码
        //string err_code_des;//错误代码描述
        /// <summary>
        /// 以下字段在return_code 、result_code、trade_state都为SUCCESS时有返回 。
        /// </summary>
        string device_info;//设备号
        string openid;//用户标识
        string is_subscribe;//是否关注公众账号
        string trade_type;//交易类型
        string trade_state;//交易状态
        string bank_type;//付款银行
        int total_fee;//标价金额
        //int settlement_total_fee;//应结订单金额	
        string fee_type;//标价币种
        int cash_fee;//现金支付金额
        string cash_fee_type;//现金支付币种
        //int coupon_fee;//代金券金额
        ////int coupon_count;//代金券使用数量
        string coupon_type_n;//代金券类型
        string coupon_id_n;//代金券ID
        //int coupon_fee_n;//单个代金券支付金额
        string attach;//附加数据
        DateTime time_end;//支付完成时间
        string trade_state_desc;//交易状态描述
        int? Writed;
        /// <summary>
        /// 初始化类
        /// </summary>
        public PayUserData()
        {
            NetID = string.Empty;//设备网卡编号
            appid = string.Empty; //公众账号ID
            mch_id = string.Empty; //商户号
            transaction_id = string.Empty; //微信订单号
            out_trade_no = string.Empty; //商户订单号
            nonce_str = string.Empty; //随机字符串
            sign = string.Empty; //签名
            sign_type = string.Empty; //签名类型
            return_code = string.Empty;//返回状态码 SUCCESS/FAIL 此字段是通信标识，非交易标识，交易是否成功需要查看trade_state来判断
            return_msg = string.Empty;//返回信息当return_code为FAIL时返回信息为错误原因 ，例如签名失败 参数格式校验错误
            result_code = string.Empty; //业务结果
            device_info = string.Empty;//设备号
            openid = string.Empty;//用户标识
            is_subscribe = string.Empty;//是否关注公众账号
            trade_type = string.Empty;//交易类型
            trade_state = string.Empty;//交易状态
            bank_type = string.Empty;//付款银行
            total_fee = -99;//标价金额
            //settlement_total_fee = -99;//应结订单金额	
            fee_type = string.Empty;//标价币种
            cash_fee = -99;//现金支付金额
            cash_fee_type = string.Empty;//现金支付币种
            //coupon_fee = -99;//代金券金额
            //coupon_count = -99;//代金券使用数量
            coupon_type_n = string.Empty;//代金券类型
            coupon_id_n = string.Empty;//代金券ID
            //coupon_fee_n = -99;//单个代金券支付金额
            transaction_id = string.Empty;//微信支付订单号
            out_trade_no = string.Empty;//商户订单号
            attach = string.Empty;//附加数据
            time_end = new DateTime();//支付完成时间
            trade_state_desc = string.Empty;//交易状态描述
            Writed = -99;
        }
        /// <summary>
        /// 将用户付款信息转换并发送到数据库
        /// </summary>
        /// <param name="UserPayData"></param>
        public PayUserData(String UserNetID, WxPayData ProductData, WxPayData UserPayData,ref bool Result)
        {
            NetID = UserNetID;//设备网卡编号
            //device_info = UserPayData.GetValue("device_info").ToString();//设备号
            appid = UserPayData.GetValue("appid").ToString();//公众账号ID
            attach = UserPayData.GetValue("attach").ToString();//附加数据
            bank_type = UserPayData.GetValue("bank_type").ToString();//付款银行
            cash_fee = Convert.ToInt32(UserPayData.GetValue("cash_fee"));//现金支付金额
            cash_fee_type = UserPayData.GetValue("cash_fee_type").ToString();//现金支付币种
            fee_type = UserPayData.GetValue("fee_type").ToString();//标价币种
            is_subscribe = UserPayData.GetValue("is_subscribe").ToString();//是否关注公众账号
            mch_id = UserPayData.GetValue("mch_id").ToString(); //商户号
            nonce_str = UserPayData.GetValue("nonce_str").ToString(); //随机字符串
            openid = UserPayData.GetValue("openid").ToString();//用户标识
            out_trade_no = UserPayData.GetValue("out_trade_no").ToString(); //商户订单号
            result_code = UserPayData.GetValue("result_code").ToString();
            return_code = UserPayData.GetValue("return_code").ToString();//返回状态码 SUCCESS/FAIL 此字段是通信标识，非交易标识，交易是否成功需要查看trade_state来判断
            return_msg = UserPayData.GetValue("return_msg").ToString();//返回信息当return_code为FAIL时返回信息为错误原因 ，例如签名失败 参数格式校验错误
            sign = UserPayData.GetValue("sign").ToString(); //签名  20210812135640
            ///转换支付完成时间
            bool TranslateTimeRes = DateTime.TryParseExact(UserPayData.GetValue("time_end").ToString(), "yyyyMMddhhmmss", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out time_end);
            if (!TranslateTimeRes)
            {
                time_end = DateTime.Now;
            }
            total_fee = Convert.ToInt32(UserPayData.GetValue("total_fee"));//标价金额
            trade_state = UserPayData.GetValue("trade_state").ToString();//交易状态
            trade_state_desc = UserPayData.GetValue("trade_state_desc").ToString();//交易状态描述
            trade_type = UserPayData.GetValue("trade_type").ToString();//交易类型
            transaction_id = UserPayData.GetValue("transaction_id").ToString();//微信支付订单号
            Writed = -99;
            DataClassesDataContext data = new DataClassesDataContext();
            try
            {
                //写入数据库
                attach = ProductData.GetValue("body").ToString();
                data.AddUserWxPayInformation(UserNetID, appid, attach, bank_type, cash_fee, cash_fee_type, fee_type
                    , is_subscribe, mch_id, nonce_str, openid, out_trade_no, result_code, return_code, return_msg, sign
                    , time_end, total_fee, trade_state, trade_state_desc, trade_type, transaction_id, ref Writed);
            }
            catch (Exception e)
            {
                //throw e;
                Result = false;
            }
            switch (attach)
            {
                case "锐锋科技自动化产品3个月授权注册":
                    data.UpataUserPayInformation(UserNetID, 93);
                    break;
                case "锐锋科技自动化产品6个月授权注册":
                    data.UpataUserPayInformation(UserNetID, 186);
                    break;
                case "锐锋科技自动化产品12+3【赠送】个月授权注册":
                    data.UpataUserPayInformation(UserNetID, 465);
                    break;
                case "锐锋科技自动化产品24+6【赠送】个月授权注册":
                    data.UpataUserPayInformation(UserNetID, 930);
                    break;
                case "锐锋科技自动化产品36+12【赠送】个月授权注册":
                    data.UpataUserPayInformation(UserNetID, 1440);
                    break;
                default:
                    break;
            }
            Result = true;
        }
    }
}
