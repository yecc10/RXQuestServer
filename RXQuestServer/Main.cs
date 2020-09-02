using Microsoft.Win32;
using NPOI.SS.Formula.Functions;
using RXQuestServer.Delmia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.Identity;
using System.Management;

namespace RXQuestServer
{
    public partial class Main : Form
    {
        bool HasAccessToRun = false;
        public Main()
        {
            InitializeComponent();
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitDelmiaDocument_Click(object sender, EventArgs e)
        {
            if (! HasAccessToRun)
            {
                CheckUserAccess();
            }
            if (HasAccessToRun)
            {
                InitDelmiaDocument IDM = new InitDelmiaDocument();
                this.Hide();
                IDM.Show();
            }

        }

        private void WeldSportTool_Click(object sender, EventArgs e)
        {
            if (!HasAccessToRun)
            {
                CheckUserAccess();
            }
            if (HasAccessToRun)
            {
                AutoDeskLine_ToPlant.CatiaQuickTool CQT = new AutoDeskLine_ToPlant.CatiaQuickTool();
                this.Hide();
                CQT.Show();
            }

        }

        private void GotoOCR_Click(object sender, EventArgs e)
        {
            if (!HasAccessToRun)
            {
                CheckUserAccess();
            }
            if (HasAccessToRun)
            {
                OcrCenter.OCR Socr = new OcrCenter.OCR();
                this.Hide();
                Socr.Show();
            }

        }

        private void InPutWorkTime_Click(object sender, EventArgs e)
        {
            if (!HasAccessToRun)
            {
                CheckUserAccess();
            }
            if (HasAccessToRun)
            {
                WorkOffice.WorkTimeUpdata workTimeUpdata = new WorkOffice.WorkTimeUpdata();
                this.Hide();
                workTimeUpdata.Show();
            }

        }

        private void PlantDTrack_Click(object sender, EventArgs e)
        {
            if (!HasAccessToRun)
            {
                CheckUserAccess();
            }
            if (HasAccessToRun)
            {
                ToPlant.AutoDesKToPlant autoDesKToPlant = new ToPlant.AutoDesKToPlant();
                this.Hide();
                autoDesKToPlant.Show();
            }

        }

        private void PlantDFence_Click(object sender, EventArgs e)
        {
            if (!HasAccessToRun)
            {
                CheckUserAccess();
            }
            if (HasAccessToRun)
            {
                ToPlant.DrawFence autoDesKToPlant = new ToPlant.DrawFence();
                this.Hide();
                autoDesKToPlant.Show();
            }

        }

        private void WorkData_Click(object sender, EventArgs e)
        {
            if (!HasAccessToRun)
            {
                CheckUserAccess();
            }
            if (HasAccessToRun)
            {
                RX_DataUpdata.ULogin uLogin = new RX_DataUpdata.ULogin();
                this.Hide();
                uLogin.Show();
            }

        }

        private void CreateTrackOnLine_Click(object sender, EventArgs e)
        {
            if (!HasAccessToRun)
            {
                CheckUserAccess();
            }
            if (HasAccessToRun)
            {
                ToPlant.DrawTrack autoDesKToPlant = new ToPlant.DrawTrack();
                this.Hide();
                autoDesKToPlant.Show();
            }
        }

        private void CheckUserAccess()
        {
            DateTime dateTime = DateTime.Now;
            var Psh = new PasswordHasher();
            //检查注册信息,如果未注册设定30天试用
            PasswordHasher passwordHasher = new PasswordHasher();
            GetComputerData getComputerData = new GetComputerData();
            string protectid = getComputerData.GetHashProtectComputerID();
            string hashp= passwordHasher.HashPassword(protectid);
            if (RegOprate.IsRegeditExit("RegKey"))
            {
                string RegWord = RegOprate.GetRegValue("Regkey");
                var Str = Psh.VerifyHashedPassword(hashp, RegWord);  // 使用PASSWORDHASH 数值进行对比
                if (Convert.ToBoolean(Str))
                {
                    HasAccessToRun = true;
                    return;
                }
            }
            //检查是否处于试用期 并小于30天
            if (RegOprate.IsRegeditExit("SetUpTime"))
            {
                DateTime RegWord =Convert.ToDateTime(RegOprate.GetRegValue("SetUpTime"));
                if (dateTime> RegWord)
                {
                    MessageBox.Show("当前试用30天已过期，请申请正式版本！");
                }
                else
                {
                    HasAccessToRun = true;
                    return;
                }
            }
            else
            {
                RegOprate.WriteRegdit("SetUpTime", dateTime.ToString());
                HasAccessToRun = true;
                return;
            }
            //非注册用户并超期试用，强制退出
            this.Hide();
            RegKeyInput regKeyInput = new RegKeyInput();
            regKeyInput.Show();
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
