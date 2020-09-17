using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAPI_Interface
{
    //注册操作集
    public class RegOprate
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
                admindir = software.OpenSubKey("RXYFYECHAOCHENG", true);
            }
            subkeyName = admindir.GetSubKeyNames();
            foreach (string KeyName in subkeyName)
            {
                RegistryKey registryKey = admindir.OpenSubKey(name, true);
                if (KeyName.Trim().ToUpper() == name.Trim().ToUpper() && registryKey != null)
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
        static public bool DeleteRegedit(string name)
        {
            bool _exit = false;
            string[] subkeyName;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
            RegistryKey YeMainKey = software.OpenSubKey("RXYFYECHAOCHENG", true);
            if (YeMainKey == null)
            {
                software.CreateSubKey("RXYFYECHAOCHENG");
                YeMainKey = software.OpenSubKey("RXYFYECHAOCHENG", true);
            }
            subkeyName = YeMainKey.GetSubKeyNames();
            foreach (string KeyName in subkeyName)
            {
                RegistryKey registryKey = YeMainKey.OpenSubKey(name, true);
                if (KeyName.Trim().ToUpper() == name.Trim().ToUpper() && registryKey != null)
                {
                    YeMainKey.DeleteSubKey(name);
                    _exit = true;
                    hkml.Close();
                    software.Close();
                    registryKey.Close();
                    return _exit;
                }
            }
            hkml.Close();
            software.Close();
            YeMainKey.Close();
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
            RegistryKey YeMainKey = software.OpenSubKey("RXYFYECHAOCHENG", true);
            if (YeMainKey == null)
            {
                software.CreateSubKey("RXYFYECHAOCHENG");
                YeMainKey = software.OpenSubKey("RXYFYECHAOCHENG", true);
            }
            RegistryKey admindir = YeMainKey.OpenSubKey(name, true);
            if (admindir == null)
            {
                YeMainKey.CreateSubKey(name);
                admindir = YeMainKey.OpenSubKey(name, true);
            }
            admindir.SetValue(name, value);
            hklm.Close();
            software.Close();
            admindir.Close();
        }
        static public String GetRegValue(string str)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
            RegistryKey YeMainKey = software.OpenSubKey("RXYFYECHAOCHENG", true);
            if (YeMainKey == null)
            {
                software.CreateSubKey("RXYFYECHAOCHENG");
                YeMainKey = software.OpenSubKey("RXYFYECHAOCHENG", true);
            }
            RegistryKey admindir = YeMainKey.OpenSubKey(str, true);
            object str1 = admindir.GetValue(str);
            hklm.Close();
            software.Close();
            admindir.Close();
            return Convert.ToString(str1);
        }

    }
}
