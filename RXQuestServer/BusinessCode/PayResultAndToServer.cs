using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtWorks.QRCode.Codec;
using WxPayAPI;
using WxPayAPI.lib;
using RFTechnology;

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
        string err_code;//错误代码
        string err_code_des;//错误代码描述
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
        int settlement_total_fee;//应结订单金额	
        string fee_type;//标价币种
        int cash_fee;//现金支付金额
        string cash_fee_type;//现金支付币种
        int coupon_fee;//代金券金额
        int coupon_count;//代金券使用数量
        string coupon_type_n;//代金券类型
        string coupon_id_n;//代金券ID
        int coupon_fee_n;//单个代金券支付金额
        string attach;//附加数据
        string time_end;//支付完成时间
        string trade_state_desc;//交易状态描述
        int Writed;
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
            device_info = string.Empty;//设备号
            openid = string.Empty;//用户标识
            is_subscribe = string.Empty;//是否关注公众账号
            trade_type = string.Empty;//交易类型
            trade_state = string.Empty;//交易状态
            bank_type = string.Empty;//付款银行
            total_fee = -99;//标价金额
            settlement_total_fee = -99;//应结订单金额	
            fee_type = string.Empty;//标价币种
            cash_fee = -99;//现金支付金额
            cash_fee_type = string.Empty;//现金支付币种
            coupon_fee = -99;//代金券金额
            coupon_count = -99;//代金券使用数量
            coupon_type_n = string.Empty;//代金券类型
            coupon_id_n = string.Empty;//代金券ID
            coupon_fee_n = -99;//单个代金券支付金额
            transaction_id = string.Empty;//微信支付订单号
            out_trade_no = string.Empty;//商户订单号
            attach = string.Empty;//附加数据
            time_end = string.Empty;//支付完成时间
            trade_state_desc = string.Empty;//交易状态描述
            Writed = -99;
        }
        /// <summary>
        /// 将用户付款信息转换并发送到数据库
        /// </summary>
        /// <param name="UserPayData"></param>
        public PayUserData(String UserNetID, WxPayData UserPayData)
        {
            NetID = UserNetID;//设备网卡编号
            //device_info = UserPayData.GetValue("device_info").ToString();//设备号
            appid = UserPayData.GetValue("appid").ToString();//公众账号ID
            mch_id = UserPayData.GetValue("mch_id").ToString(); //商户号
            transaction_id = UserPayData.GetValue("transaction_id").ToString(); //微信订单号
            out_trade_no = UserPayData.GetValue("out_trade_no").ToString(); //商户订单号
            nonce_str = UserPayData.GetValue("nonce_str").ToString(); //随机字符串
            sign = UserPayData.GetValue("sign").ToString(); //签名
            sign_type = UserPayData.GetValue("sign_type").ToString(); //签名类型
            openid = UserPayData.GetValue("openid").ToString();//用户标识
            is_subscribe = UserPayData.GetValue("is_subscribe").ToString();//是否关注公众账号
            trade_type = UserPayData.GetValue("trade_type").ToString();//交易类型
            trade_state = UserPayData.GetValue("trade_state").ToString();//交易状态
            bank_type = UserPayData.GetValue("bank_type").ToString();//付款银行
            total_fee = Convert.ToInt32(UserPayData.GetValue("total_fee"));//标价金额
            settlement_total_fee = Convert.ToInt32(UserPayData.GetValue("settlement_total_fee"));//应结订单金额	
            fee_type = UserPayData.GetValue("fee_type").ToString();//标价币种
            cash_fee = Convert.ToInt32(UserPayData.GetValue("cash_fee"));//现金支付金额
            cash_fee_type = UserPayData.GetValue("cash_fee_type").ToString();//现金支付币种
            //coupon_fee = Convert.ToInt32(UserPayData.GetValue("coupon_fee"));//代金券金额
            //coupon_count = Convert.ToInt32(UserPayData.GetValue("coupon_count"));//代金券使用数量
            //coupon_type_n = UserPayData.GetValue("coupon_type_$n").ToString();//代金券类型
            //coupon_id_n = UserPayData.GetValue("coupon_id_$n").ToString();//代金券ID
            //coup+on_fee_n = Convert.ToInt32(UserPayData.GetValue("coupon_fee_$n"));//单个代金券支付金额
            transaction_id = UserPayData.GetValue("transaction_id").ToString();//微信支付订单号
            out_trade_no = UserPayData.GetValue("out_trade_no").ToString();//商户订单号
            attach = UserPayData.GetValue("attach").ToString();//附加数据
            time_end = UserPayData.GetValue("time_end").ToString();//支付完成时间
            trade_state_desc = UserPayData.GetValue("trade_state_desc").ToString();//交易状态描述
            Writed = -99;
            DataClassesDataContext data = new DataClassesDataContext();
            data.AddUserWxPayInformation(NetID,);
        }
    }
}
