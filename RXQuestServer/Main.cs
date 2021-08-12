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
using WxPayAPI;
using WxPayAPI.lib;
using RFTechnology.BusinessCode;

namespace RFTechnology
{
    public partial class Main : Form
    {
        bool HasAccessToRun = false;
        bool CheckedAccess = false;
        int RegPayDays = Convert.ToInt32(RegOprate.GetRegValue("RegPayDays"));
        DateTime RegTime = Convert.ToDateTime(RegOprate.GetRegValue("SetUpTime"));
        public Main()
        {
            InitializeComponent();
            NetCheck netCheck = new NetCheck();
            int Result = netCheck.CheckAccessFromNet(ref HasAccessToRun);//同步检查数据库中的用户记录
            if (Result!=1)
            {
                MessageBox.Show("请连接网络获取最新软件信息及使用体验");
            }
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
            NetCheck netCheck = new NetCheck();
           return netCheck.CheckUserAccess(ref HasAccessToRun,string.Empty, DateTime.Now, DateTime.Now, -1, false);
        }
        private void Yecc_Help_Click(object sender, EventArgs e)
        {
            this.Hide();
            //RegKeyInput regKeyInput = new RegKeyInput();
            //regKeyInput.Show();
            BusinessCode.BusinessPayCode businessPayCode = new BusinessCode.BusinessPayCode();
            businessPayCode.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            if (RegPayDays<1)
            {
                TimeSpan WorkDays = RegTime.AddDays(30) - dateTime;
                if (WorkDays.TotalMinutes > 0)
                {
                    this.Text = "YECC_" + Application.ProductVersion.ToString() + Properties.Settings.Default.VisionType + ",剩余[秒]: " + WorkDays.TotalSeconds.ToString("0");//+ "——当前时间:" + DateTime.Now.ToString()
                }
                else
                {
                    MessageBox.Show("当前试用30天已过期，请申请正式版本！");
                    Process.GetCurrentProcess().Kill();
                }
            }
            else
            {
                TimeSpan WorkDays = RegTime.AddDays(RegPayDays) - dateTime;
                if (WorkDays.TotalDays >15)
                {
                    this.Text = "YECC_" + Application.ProductVersion.ToString() + Properties.Settings.Default.VisionType;// +",剩余[秒]: " + WorkDays.TotalSeconds.ToString("0");//+ "——当前时间:" + DateTime.Now.ToString()
                }
                else if (WorkDays.TotalDays > 0)
                {
                    this.Text = "YECC_" + Application.ProductVersion.ToString() + Properties.Settings.Default.VisionType+",剩余[秒]: " + WorkDays.TotalSeconds.ToString("0");//+ "——当前时间:" + DateTime.Now.ToString()
                }
                else
                {
                    MessageBox.Show("当前授权许可已过期，请重新申请正式版本！");
                    Process.GetCurrentProcess().Kill();
                }
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

        private void 访问官方网站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.ahrfkj.cn/");
        }

        private void 关于本软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }
    }
}
