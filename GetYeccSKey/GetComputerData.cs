﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Management;
using System.Security.Policy;
using Microsoft.Win32;
using System.Windows.Forms;

namespace GetYeccSKey
{
    class GetUserKeyData
    {
        private string GetCPUID()
        {
            ManagementClass managClass = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = managClass.GetInstances();
            string CPUID = null;
            foreach (ManagementObject item in moc)
            {
                CPUID = item.Properties["processorid"].Value.ToString();
                break;
            }
            return CPUID;
        }
        private string GetBoardID()
        {
            ManagementClass managClass = new ManagementClass("Win32_BaseBoard");
            ManagementObjectCollection moc = managClass.GetInstances();
            string BoardID = null;
            foreach (ManagementObject item in moc)
            {
                BoardID = item.Properties["SerialNumber"].Value.ToString();
                break;
            }
            return BoardID;
        }
        private string GetBIOSID()
        {
            ManagementClass managClass = new ManagementClass("Win32_BIOS");
            ManagementObjectCollection moc = managClass.GetInstances();
            string BIOSID = null;
            foreach (ManagementObject item in moc)
            {
                BIOSID = item.Properties["SerialNumber"].Value.ToString();
                break;
            }
            return BIOSID;
        }
        private string GetDiskID()
        {
            ManagementClass managClass = new ManagementClass("win32_logicaldisk");
            ManagementObjectCollection moc = managClass.GetInstances();
            string DiskID = null;
            foreach (ManagementObject item in moc)
            {
                DiskID = item.Properties["VolumeSerialNumber"].Value.ToString();
                break;
            }
            return DiskID;
        }
        private string GetComputerID()
        {
            string ComputerId = GetBoardID() + GetBoardID() + GetCPUID()+ GetDiskID();
            return ComputerId;
        }
        public string GetHashProtectComputerID()
        {
            string ComputerId = GetComputerID()+ "yeccdesignforruixiang2020";
           // int HashComputerId=ComputerId.GetHashCode();
            return ComputerId;
        }
        public string GetHashProtectComputerID(String UserCode)
        {
            string NewUserCode = UserCode + "yeccdesignforruixiang2020";
            // int HashComputerId=ComputerId.GetHashCode();
            PasswordHasher passwordHasher = new PasswordHasher();
            string ComputerId = passwordHasher.HashPassword(NewUserCode);
            var Str = passwordHasher.VerifyHashedPassword(ComputerId, NewUserCode);  // 使用PASSWORDHASH 数值进行对比
            if (!Convert.ToBoolean(Str))
            {
                ComputerId = null;
            }
            return ComputerId;
        }
        public bool CheckUsrKey(string UserKey)
        {
            DateTime dateTime = DateTime.Now;
            var Psh = new PasswordHasher();
            //检查注册信息,如果未注册设定30天试用
            PasswordHasher passwordHasher = new PasswordHasher();
            string protectid =GetHashProtectComputerID();
            var Str = Psh.VerifyHashedPassword(UserKey, protectid);  // 使用PASSWORDHASH 数值进行对比
            if (Convert.ToBoolean(Str))
            {
                RegOprate.WriteRegdit("Regkey", UserKey);
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetUsrRegKey(string UserKey)
        {
            string Res= GetHashProtectComputerID(UserKey);
            return Res;
        }
        #region 注册操作集
        class RegOprate
        {
            /// <summary>
            /// 注册表存在检查
            /// </summary>
            /// <param name="name">待确认的注册表名称</param>
            /// <returns></returns>
            static public bool IsRegeditExit(string name)
            {
                bool _exit = false;
                string[] subkeyName;
                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
                RegistryKey admindir = software.OpenSubKey("RXYFYECHAOCHENG", true);
                if (admindir == null)
                {
                    software.CreateSubKey("RXYFYECHAOCHENG");
                }
                admindir = software.OpenSubKey("RXYFYECHAOCHENG", true);
                subkeyName = admindir.GetValueNames();
                foreach (var KeyName in subkeyName)
                {
                    if (KeyName == name)
                    {
                        _exit = true;
                        hkml.Close();
                        software.Close();
                        admindir.Close();
                        return _exit;
                    }
                }
                hkml.Close();
                software.Close();
                admindir.Close();
                return _exit;
            }
            /// <summary>
            /// 写入注册表
            /// </summary>
            /// <param name="name">名称</param>
            /// <param name="value">值</param>
            static public void WriteRegdit(string name, string value)
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                RegistryKey admindir = software.OpenSubKey("RXYFYECHAOCHENG", true);
                admindir.SetValue(name, value);
                hklm.Close();
                software.Close();
                admindir.Close();
            }
            static public String GetRegValue(string str)
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                RegistryKey admindir = software.OpenSubKey("RXYFYECHAOCHENG", true);
                object str1 = admindir.GetValue(str);
                hklm.Close();
                software.Close();
                admindir.Close();
                return Convert.ToString(str1);
            }

        }
        #endregion
    }
}
