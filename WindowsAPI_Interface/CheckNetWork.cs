using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace WindowsAPI_Interface
{
    public class CheckNetWork
    {
        //判断本机电脑是否能连接外网主要思路：
        //1.通过InternetGetConnectedState API函数判断当前电脑是否已连接到网络上；
        //2.通过Dns.GetHostAddresses("www.baidu.com")函数判断当前电脑网络是否可以连接到外网（第一步可以不要，但是电脑没有连接任何网络时，InternetGetConnectedState函数执行很快，要是直接用第2步，则会有时延的问题。）；
        
        //函数InternetGetConnectedState 判断本机电脑联网状态
        //函数原形：BOOL InternetGetConnectedState(LPDWORD lpdwFlags, DWORD dwReserved);
        //参数lpdwFlags返回当前网络状态,参数dwReserved依然是保留参数，设置为0即可。 
        //INTERNET_CONNECTION_MODEM 通过调治解调器连接网络
        //INTERNET_CONNECTION_LAN 通过局域网连接网络
        //这个函数的功能是很强的。它可以：   
        //1.   判断网络连接是通过网卡还是通过调治解调器   
        //2.   是否通过代理上网   
        //3.   判断连接是On Line还是Off   Line   
        //4.   判断是否安装“拨号网络服务”   
        //5.   判断调治解调器是否正在使用
        //返回值若为false，则表示当前电脑没有连接到任何网络上。
        
       [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(ref int dwFlag, int dwReserved);
        private const int INTERNET_CONNECTION_MODEM = 1;
        private const int INTERNET_CONNECTION_LAN = 2;
        /// <summary>
        /// 判断本机是否联网
        /// </summary>
        /// <returns></returns>
        public  bool IsConnectNetwork()
        {
            try
            {
                int dwFlag = 0;
                //false表示没有连接到任何网络,true表示已连接到网络上
                if (!InternetGetConnectedState(ref dwFlag, 0))
                {
                    //if (!InternetGetConnectedState(ref dwFlag, 0))
                    //     Console.WriteLine("未连网!");
                    //else if ((dwFlag & INTERNET_CONNECTION_MODEM) != 0)
                    //    Console.WriteLine("采用调治解调器上网。");
                    //else if ((dwFlag & INTERNET_CONNECTION_LAN) != 0)
                    //    Console.WriteLine("采用网卡上网。");  
                    return false;
                }
                //判断当前网络是否可用
                IPAddress[] addresslist = Dns.GetHostAddresses("www.baidu.com");
                if (addresslist[0].ToString().Length <= 6)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
