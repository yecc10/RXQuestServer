using DNBIgpTagPath;
using INFITF;
using ProductStructureTypeLib;
using SPATypeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YeDassaultSystemDev
{
    public partial class RobotTaskControl : Form
    {
        #region GlobalValue
        DataType.SimulationDir SimulationDir = new DataType.SimulationDir();
        DataType.Dsystem DStype = new DataType.Dsystem();
        Product MechanismProduct = null;
        List<Tag> tagList = new List<Tag>(); // Init A container to Save Target Tag List
        List<Tag> viatagList = new List<Tag>(); // Init A container to Save Target Tag List
        List<Tag> processtagList = new List<Tag>(); // Init A container to Save Target Tag List
        List<RobotTask> robotTasks = new List<RobotTask>(); // Init A container to Save Target Tag List
        /// <summary>
        /// 自动化布局主要区域类型
        /// </summary>
        enum LayoutType { MB, SBL, SBR, FR, RR, UB, ST }
        #endregion
        public RobotTaskControl()
        {
            InitializeComponent();
            taskNameTotalNum.SelectedIndex = 0; // Init Total Num is 2
        }

        private void RobotTaskControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            System.Environment.Exit(0);
        }

        private void reSelectRobotTask_Click(object sender, EventArgs e)
        {
            tagList.Clear();
            viatagList.Clear();
            processtagList.Clear();
            ProcessTaskAddress.Items.Clear();
            Pbar.Value = 0;
            Pbar.Step = 10;
            GloalForDelmia GFD = new GloalForDelmia();
            DStype = GFD.InitCatEnv(this);
            if (DStype.Revalue == -1)
            {
                return;
            }
            this.TopMost = false;
            this.WindowState = FormWindowState.Minimized;
            Selection Uselect = GFD.GetIRobotMotion(this, DStype, 12, "请选择即将操作的Taglist对象");
            RobotTask robotTask = null;
            if (Uselect != null && Uselect.Count > 0)
            {
                try
                {
                    String GetName = string.Empty;
                    robotTask = (RobotTask)Uselect.Item2(1).Value;
                    GetName = robotTask.get_Name();
                    selectedrobotTaskName.Text = GetName;
                    //GFD.ClearRobotHomeList(this, DStype, Usp, "Test", Pbar);
                    GFD.ReadTaskTagList(this, robotTask, TaskListA, TaskListB, Pbar, ref tagList, ref viatagList, ref processtagList);
                }
                catch
                {
                    MessageBox.Show("操作目标过程中发生未知错误，编号：0029874，在入口的帮助选项卡中反馈该问题!");
                }
            }
            //this.TopMost = true;
            //this.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = false;
        }

        private void onlyForProcess_Click(object sender, EventArgs e)
        {
            TaskListB.Items.Clear();
            if (processtagList != null)
            {
                foreach (Tag tag in processtagList)
                {
                    string TagName = tag.get_Name();
                    TaskListB.Items.Add(TagName);
                }
            }
        }

        private void onlyForVia_Click(object sender, EventArgs e)
        {
            TaskListB.Items.Clear();
            if (viatagList != null)
            {
                foreach (Tag tag in viatagList)
                {
                    string TagName = tag.get_Name();
                    TaskListB.Items.Add(TagName);
                }
            }
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            TaskListB.Items.Clear();
        }

        private void allTaget_Click(object sender, EventArgs e)
        {
            TaskListB.Items.Clear();
            if (tagList != null)
            {
                foreach (Tag tag in tagList)
                {
                    string TagName = tag.get_Name();
                    TaskListB.Items.Add(TagName);
                }
            }
        }

        private void WorkToBefore_Click(object sender, EventArgs e)
        {
            if (TaskListB.Items.Count < 1)
            {
                MessageBox.Show("目标TagList 为空，无法执行该操作");
                return;
            }
            List<Tag> tags = new List<Tag>();
            Pbar.Value = 0;
            Pbar.Maximum = TaskListB.Items.Count;
            Pbar.Step = 1;
            int stepNum = Convert.ToInt32(taskNameNumStep.Text);
            int CurrentID = Convert.ToInt32(taskNameStartNum.Text);
            foreach (string TagName in TaskListB.Items)
            {
                try
                {
                    Tag tag = null;
                    var Return = tagList.Find(
                        delegate (Tag tag1)
                        {
                            tag = tag1;
                            return tag1.get_Name() == TagName; //需要修改为检查ID 名称可重复
                        }); // Check Repeact 
                    if (Return != null) //
                    {
                        string prestr = string.Empty, endstr = string.Empty;
                        if (!string.IsNullOrEmpty(taskNameFrontStr.Text))
                        {
                            prestr = taskNameFrontStr.Text + "_";
                        }
                        if (!string.IsNullOrEmpty(taskNameRearStr.Text))
                        {
                            endstr = "_" + taskNameRearStr.Text;
                        }
                        string TagNewName = prestr + taskNameTagName.Text + (CurrentID) + endstr;
                        CurrentID += stepNum;
                        tag.SetName(TagNewName);
                        tags.Add(tag);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                Pbar.PerformStep();
            }
            TaskListB.Items.Clear();// 重新刷新 记录表B
            if (tags != null)
            {
                foreach (Tag tag in tags)
                {
                    string TagName = tag.get_Name();
                    TaskListB.Items.Add(TagName);
                }
            }
            TaskListA.Items.Clear();// 重新刷新 记录表Ba
            if (tagList != null)
            {
                foreach (Tag tag in tagList)
                {
                    string TagName = tag.get_Name();
                    TaskListA.Items.Add(TagName);
                }
            }
            Pbar.Value = Pbar.Maximum;
        }

        private void ProcessTaskAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (robotTasks.Count < 1)
            {
                return;
            }
            String GetName = string.Empty;
            int SelectIndex = ProcessTaskAddress.SelectedIndex;
            RobotTask srobotTask = robotTasks[SelectIndex];
            GetName = srobotTask.get_Name();
            //selectedrobotTaskName.Text = GetName;
            //GFD.ClearRobotHomeList(this, DStype, Usp, "Test", Pbar);
            GloalForDelmia GFD = new GloalForDelmia();
            DStype = GFD.InitCatEnv(this);
            GFD.ReadTaskTagList(this, srobotTask, TaskListA, TaskListB, Pbar, ref tagList, ref viatagList, ref processtagList);
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
        }

        private void reSelectRobot_Click(object sender, EventArgs e)
        {
            robotTasks.Clear();
            tagList.Clear();
            viatagList.Clear();
            processtagList.Clear();
            Pbar.Value = 0;
            Pbar.Step = 10;
            GloalForDelmia GFD = new GloalForDelmia();
            DStype = GFD.InitCatEnv(this);
            if (DStype.Revalue == -1)
            {
                return;
            }
            Selection Uselect = GFD.GetIRobotMotion(this, DStype, 16, "请选择即将操作Taglist的机器人对象");
            Product Robot = null;
            if (Uselect != null && Uselect.Count > 0)
            {
                try
                {
                    String GetName = string.Empty;
                    Robot = (Product)Uselect.Item2(1).Value;
                    GetName = Robot.get_Name();
                    selectedrobotTaskName.Text = GetName;
                    //GFD.ClearRobotHomeList(this, DStype, Usp, "Test", Pbar);
                    GFD.ReadRobotTaskTagList(this, Robot, ProcessTaskAddress, Pbar, ref robotTasks);
                }
                catch
                {
                    MessageBox.Show("操作目标过程中发生未知错误，编号：0029874，在入口的帮助选项卡中反馈该问题!");
                }
            }
            //this.TopMost = true;
            //this.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = false;

        }

        private void tGP_CheckedChanged(object sender, EventArgs e)
        {
            taskNameTagName.Text = "GP";
        }

        private void tRP_CheckedChanged(object sender, EventArgs e)
        {
            taskNameTagName.Text = "RP";
        }

        private void tLHP_CheckedChanged(object sender, EventArgs e)
        {
            taskNameTagName.Text = "LHP";
        }

        private void OutTargetListAix_Click(object sender, EventArgs e)
        {
            GloalForDelmia GFD = new GloalForDelmia();
            DStype = GFD.InitCatEnv(this);
            if (DStype.Revalue == -1)
            {
                return;
            }
            Selection Uselect = GFD.GetIRobotMotion(this, DStype, 9, "请选择正确的产品数模作为坐标基准");
            Product BaseProduct = null;
            if (Uselect == null && Uselect.Count < 1)
            {
                return;
            }
            BaseProduct = (Product)Uselect.Item2(1).Value;
            SPAWorkbench TheSPAWorkbench = (SPAWorkbench)DStype.CDSActiveDocument.GetWorkbench("SPAWorkbench"); // Default Get Coordxyz From Word
            try
            {
                Reference basereference = Uselect.Item2(1).Reference;
                Measurable measurable = TheSPAWorkbench.GetMeasurable(basereference);
                object[] PointCoord = new object[3];//{-99, -99, -99, -99, -99, -99, -99, -99, -99 };
                Uselect.Item2(1).GetCoordinates(PointCoord);
                measurable.GetCenter(PointCoord);
            }
            catch (Exception e1)
            {

                MessageBox.Show("发生未知错误:" + e1.Message);
            }
        }

        private void goBackToFather_Click(object sender, EventArgs e)
        {
            InitDelmiaDocument initDelmiaDocument = new InitDelmiaDocument();
            this.Hide();
            initDelmiaDocument.Show();
        }
    }
}
