using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAPI_Interface;

namespace RFTechnology
{
    class NetCheck
    {
        string KeyCode = string.Empty;
        DateTime? CreateTime = null, RegPayFinishedTime = null, LastLogTime = null, validServerEndTime = null;
        int? RegPayDays = -1;
        bool GetedDataFromSql = false;
        string SFLocalPass = "yeccdesignforruixiang2020";
        string NetBoardID = string.Empty;
        //上述为该功能模块的全局变量///////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);
        private bool IsConnected()
        {
            int I = 0;
            bool state = InternetGetConnectedState(out I, 0);
            return state;
        }
        /// <summary>
        /// 从数据库同步用户数据
        /// </summary>
        private void CheckCorderFromDataBase()
        {
            GetComputerData getComputerData = new GetComputerData();
            string BIOSID = getComputerData.GetBIOSID();//获取Bios ID
            string BoardID = getComputerData.GetBoardID();//获取主板ID
            string CPUID = getComputerData.GetCPUID();//获取CPU ID
            string DiskID = getComputerData.GetDiskID();//获取硬盘ID
            NetBoardID = getComputerData.GetNetBoardID(); //获取网卡ID
            string ComputerName = Environment.MachineName;
            DataClassesDataContext dataClassesData = new DataClassesDataContext();
            int Result = dataClassesData.CheckComputerWithRegInformation(NetBoardID);
            if (Result < 0)
            {
                //首次登录
                CreateTime = DateTime.Now;
                string LocalCode = NetBoardID + CreateTime;
                PasswordHasher passwordHasher = new PasswordHasher();
                string HasValue = passwordHasher.HashPassword(LocalCode);
                var tr = passwordHasher.VerifyHashedPassword(HasValue, LocalCode);
                dataClassesData.CreateNewReginformation(ComputerName, NetBoardID, BIOSID, CPUID, DiskID, BoardID, HasValue, CreateTime);
            }
            dataClassesData.UpdataUserLogTime(NetBoardID);
            //服务器中已存在记录
            dataClassesData.GetDbAllDataWithCurrentPC(NetBoardID, ref KeyCode, ref CreateTime, ref RegPayFinishedTime, ref LastLogTime, ref RegPayDays, ref validServerEndTime);
            try
            {
                Properties.Settings.Default.ComputerName = ComputerName;
                Properties.Settings.Default.NetID = NetBoardID;
                Properties.Settings.Default.KeyCode = KeyCode.Trim();
                Properties.Settings.Default.CreateTime = Convert.ToDateTime(CreateTime);
                Properties.Settings.Default.RegPayFinishedTime = Convert.ToDateTime(RegPayFinishedTime);
                Properties.Settings.Default.LastLogTime = Convert.ToDateTime(LastLogTime);
                Properties.Settings.Default.RegPayDays = Convert.ToInt32(RegPayDays);
                Properties.Settings.Default.validServerEndTime = Convert.ToDateTime(validServerEndTime);
            }
            catch (Exception)
            {
                MessageBox.Show("数据更新失败！");
            }
        }
        /// <summary>
        /// 检查网络连接
        /// </summary>
        /// <param name="HasAccessToRun"></param>
        /// <returns></returns>
        public int CheckAccessFromNet(ref bool HasAccessToRun)
        {
            //1 正常执行完成 0 网络未连接 -1网线未连接  -2用户权限过期
            if (IsConnected())
            {
                Ping ping = new Ping();
                PingReply reply = null;
                try
                {
                    reply = ping.Send("www.baidu.com");//百度IP
                }
                catch (Exception)
                {
                    CheckUserAccess(ref HasAccessToRun, KeyCode, Convert.ToDateTime(CreateTime), Convert.ToDateTime(RegPayFinishedTime), Convert.ToInt32(RegPayDays));
                    return -1;
                }
                if (reply.Status == IPStatus.Success)
                {
                    GetedDataFromSql = true;
                    CheckCorderFromDataBase();
                    CheckUserAccess(ref HasAccessToRun, KeyCode, Convert.ToDateTime(CreateTime), Convert.ToDateTime(RegPayFinishedTime), Convert.ToInt32(RegPayDays), true);
                    return 1;
                }
                else
                {
                    CheckUserAccess(ref HasAccessToRun, KeyCode, Convert.ToDateTime(CreateTime), Convert.ToDateTime(RegPayFinishedTime), Convert.ToInt32(RegPayDays));
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }
        private string TranslatePasswards(string Pass)
        {
            int len = Pass.Trim().Length;
            if (Pass.Trim() != string.Empty && Pass.Trim().Length == 68)
            {
                return Pass.Trim();
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 权限检查
        /// </summary>
        /// <param name="HasAccessToRun">是否具有运行权限</param>
        /// <param name="KeyCode">校核秘钥</param>
        /// <param name="CreateTime">创建日期</param>
        /// <param name="RegPayFinishedTime">最终付款日期</param>
        /// <param name="RegPayDays">购买天数</param>
        /// <param name="GetedDataFromSql">是否从数据库读取</param>
        /// <returns></returns>
        public bool CheckUserAccess(ref bool HasAccessToRun, string KeyCode, DateTime CreateTime, DateTime RegPayFinishedTime, int RegPayDays, bool GetedDataFromSql = false)
        {
            DateTime dateTime = DateTime.Now;
            var Psh = new PasswordHasher();
            //检查注册信息,如果未注册设定30天试用
            PasswordHasher passwordHasher = new PasswordHasher();
            String protectid = String.Empty;
            if (RegOprate.IsRegeditExit("ProtectComputerID"))
            {
                protectid = RegOprate.GetRegValue("ProtectComputerID");
            }
            if (String.IsNullOrEmpty(protectid))
            {
                GetComputerData getComputerData = new GetComputerData();
                protectid = getComputerData.GetHashProtectComputerID(); //重新获取ID
                RegOprate.WriteRegdit("ProtectComputerID", protectid);
            }
            protectid = protectid + SFLocalPass;
            if (RegOprate.IsRegeditExit("RegKey"))
            {
                string RegWord = RegOprate.GetRegValue("Regkey");
                var Str = Psh.VerifyHashedPassword(RegWord, protectid);  // 使用PASSWORDHASH 数值进行对比
                if (Convert.ToBoolean(Str))
                {
                    HasAccessToRun = true;
                    //Yecc_Help.Enabled = false;
                    Properties.Settings.Default.VisionType = "正式授权版";
                    return HasAccessToRun;
                }
            }
            //检查是否处于试用期 并小于30天
            if (RegOprate.IsRegeditExit("SetUpTime"))
            {
                if (GetedDataFromSql)
                {
                    RegOprate.WriteRegdit("SetUpTime", Convert.ToString(CreateTime));//将服务器中的创建时间刷入到当前软件注册表中
                    RegOprate.WriteRegdit("RegPayFinishedTime", Convert.ToString(RegPayFinishedTime));//将服务器中的创建时间刷入到当前软件注册表中
                    RegOprate.WriteRegdit("RegPayDays", Convert.ToString(RegPayDays));//将服务器中的创建时间刷入到当前软件注册表中
                    RegOprate.WriteRegdit("KeyCode", Convert.ToString(KeyCode));//将服务器中的创建时间刷入到当前软件注册表中
                    RegOprate.WriteRegdit("validServerEndTime", Convert.ToString(validServerEndTime));//将服务器中的创建时间刷入到当前软件注册表中
                }
                DateTime RegWord = Convert.ToDateTime(RegOprate.GetRegValue("validServerEndTime"));
                RegPayDays = Convert.ToInt32(RegOprate.GetRegValue("RegPayDays"));
                KeyCode = RegOprate.GetRegValue("KeyCode");
                if (RegPayDays < 1)
                {
                    DateTime NormalWorkTime = RegWord;
                    if (dateTime > NormalWorkTime)
                    {
                        Properties.Settings.Default.VisionType = "30天试用版";
                        MessageBox.Show("当前试用30天已过期，请申请正式版本！");
                    }
                    else
                    {
                        //临时授权未过期 授权通过使用
                        TimeSpan WorkDays = NormalWorkTime - dateTime;
                        Properties.Settings.Default.VisionType = "30天试用版,剩余[小时]: " + WorkDays.TotalHours.ToString("0");
                        HasAccessToRun = true;
                        //Yecc_Help.Enabled = true;
                        return HasAccessToRun;
                    }
                }
                else
                {
                    //检查KeyCode确定用户是否非法修改了注册表
                    bool isNormalSet = false;
                    if (!string.IsNullOrEmpty(KeyCode))
                    {
                        String LocalPass = NetBoardID + Convert.ToString(CreateTime);
                        KeyCode = TranslatePasswards(KeyCode);
                        var Str = Psh.VerifyHashedPassword(KeyCode, LocalPass);
                        isNormalSet = true;
                    }
                    if (!isNormalSet)
                    {
                        Properties.Settings.Default.VisionType = "正式授权版";
                        MessageBox.Show("您已非法修改内部参数，软件不在可用!请联系供应商:yecc10@live.cn 远程支援!");
                        HasAccessToRun = false;
                        Process.GetCurrentProcess().Kill();
                        return HasAccessToRun;
                    }
                    DateTime NormalWorkTime = RegWord; //RegWord 为软件到期时间
                    if (dateTime > NormalWorkTime)
                    {
                        Properties.Settings.Default.VisionType = "正式授权版";
                        MessageBox.Show("当前授权许可已过期，请重新申请正式版本！");
                        HasAccessToRun = false;
                        return HasAccessToRun;
                    }
                    else
                    {
                        //临时授权未过期 授权通过使用
                        Properties.Settings.Default.VisionType = "正式授权版";
                        TimeSpan WorkDays = NormalWorkTime - dateTime;
                        HasAccessToRun = true;
                        return HasAccessToRun;
                        //Yecc_Help.Enabled = true;
                    }
                }

            }
            else
            {
                //首次安装使用
                string message = Properties.Resources.SoftAccess;
                string caption = "首次使用授权说明:";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    DateTime dateTime1 = dateTime;
                    RegOprate.WriteRegdit("SetUpTime", dateTime1.ToString());
                    HasAccessToRun = true;
                    Properties.Settings.Default.VisionType = "30天试用版";
                    return HasAccessToRun;
                }
                else
                {
                    Process.GetCurrentProcess().Kill();
                    return HasAccessToRun;
                }
            }
            //非注册用户并试用时间已过期，强制退出
            //this.Hide();
            Process[] AllProcess = Process.GetProcessesByName("RFTechnology");
            if (AllProcess.Length == 1)
            {
                Process process = AllProcess[0];
                string TitleName = process.MainWindowTitle;
                if (TitleName == "RegKeyInput")
                {
                    MessageBox.Show("注册窗口您已打开，无需重复打开!");
                    return HasAccessToRun;
                }
            }
            RegKeyInput regKeyInput = new RegKeyInput();
            regKeyInput.Show();
            return HasAccessToRun;
        }
    }
}
