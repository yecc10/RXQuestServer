using Microsoft.Win32;
using NPOI.SS.Formula.Functions;
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
using System.Diagnostics;
using WindowsAPI_Interface;

namespace RFTechnology
{
    public partial class Main : Form
    {
        bool HasAccessToRun = false;
        bool CheckedAccess = false;
        DateTime RegTime = Convert.ToDateTime(RegOprate.GetRegValue("SetUpTime"));
        public Main()
        {
            InitializeComponent();
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            timer.Enabled = true;
            this.Text = "YECC_" + Application.ProductVersion.ToString() + Properties.Settings.Default.VisionType.ToString();
            CheckUserAccess();
        }

        private void InitDelmiaDocument_Click(object sender, EventArgs e)
        {
            if (!HasAccessToRun)
            {
                CheckUserAccess();
            }
            if (HasAccessToRun)
            {
                //YeDassaultSystemDev.InitDelmiaDocument initDelmia = new YeDassaultSystemDev.InitDelmiaDocument();
                this.Hide();
                YeDassaultSystemDev.InitDelmiaDocument initDelmia = new YeDassaultSystemDev.InitDelmiaDocument();
                initDelmia.Show();
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
                //YeDassaultSystemDev.CatiaQuickTool CQT = new YeDassaultSystemDev.CatiaQuickTool();
                YeDassaultSystemDev.CatiaQuickTool CQT = new YeDassaultSystemDev.CatiaQuickTool();
                this.TopMost = false;
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
                this.TopMost = false;
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

        private bool CheckUserAccess()
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
            protectid = protectid + "yeccdesignforruixiang2020";
            if (RegOprate.IsRegeditExit("RegKey"))
            {
                string RegWord = RegOprate.GetRegValue("Regkey");
                var Str = Psh.VerifyHashedPassword(RegWord, protectid);  // 使用PASSWORDHASH 数值进行对比
                if (Convert.ToBoolean(Str))
                {
                    HasAccessToRun = true;
                    Yecc_Help.Enabled = false;
                    Properties.Settings.Default.VisionType = "正式授权版";
                    return true;
                }
            }
            //检查是否处于试用期 并小于30天
            if (RegOprate.IsRegeditExit("SetUpTime"))
            {
                DateTime RegWord = Convert.ToDateTime(RegOprate.GetRegValue("SetUpTime"));
                DateTime NormalWorkTime = RegWord.AddDays(30);
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
                    Yecc_Help.Enabled = true;
                    return true;
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
                    return true;
                }
                else
                {
                    Process.GetCurrentProcess().Kill();
                    return true;
                }
            }
            //非注册用户并试用时间已过期，强制退出
            this.Hide();
            Process[] AllProcess = Process.GetProcessesByName("RFTechnology");
            if (AllProcess.Length==1)
            {
                Process process = AllProcess[0];
                string TitleName = process.MainWindowTitle;
                if (TitleName=="RegKeyInput")
                {
                    MessageBox.Show("注册窗口您已打开，无需重复打开!");
                    return false;
                }
            }
            RegKeyInput regKeyInput = new RegKeyInput();
            regKeyInput.Show();
            return false;
        }
        private void Yecc_Help_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegKeyInput regKeyInput = new RegKeyInput();
            regKeyInput.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            TimeSpan WorkDays = RegTime.AddDays(30) - dateTime;
            if (WorkDays.TotalMinutes > 0)
            {
                this.Text = "YECC_" + Application.ProductVersion.ToString() + "30天试用版,剩余[秒]: " + WorkDays.TotalSeconds.ToString("0");//+ "——当前时间:" + DateTime.Now.ToString()
            }
            else
            {
                this.Text = "YECC_" + Application.ProductVersion.ToString() + Properties.Settings.Default.VisionType.ToString();
            }
        }

        private void WordToAixForPlant_Click(object sender, EventArgs e)
        {
            this.Hide();
            WordToAix.WordToAix wordToAix = new WordToAix.WordToAix();
            wordToAix.Show();

        }

        private void ReadHelp_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void OpenApplicationdoc_Click(object sender, EventArgs e)
        {
            string Path = Environment.CurrentDirectory;
            try
            {
                Process.Start(Path);
            }
            catch (Exception)
            {
                MessageBox.Show(Environment.CurrentDirectory + "路径打卡失败，请手动打开!");
            }
        }

        private void 反馈问题建议ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://blog.csdn.net/qingyangwuji/article/details/109142676");
        }
    }
}
