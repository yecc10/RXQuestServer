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

namespace RFTechnology
{
    public partial class RegKeyInput : Form
    {
        public RegKeyInput()
        {
            InitializeComponent();
            GetComputerData getComputerData = new GetComputerData();
            AppliCode.Text = getComputerData.GetComputerID();
        }

        private void RegRxSoft_Click(object sender, EventArgs e)
        {
            if (RegKey.Text.Trim() != string.Empty && RegKey.Text.Trim().Length==68)
            {
                GetComputerData getComputerData = new GetComputerData();
               var res= getComputerData.CheckUsrKey(RegKey.Text.Trim());
                if (!res)
                {
                    RegKey.Text = string.Empty;
                    MessageBox.Show("注册码错误，请输入正确的注册码!");
                }
                else
                {
                    MessageBox.Show("注册码输入成功，请重启软件进行使用!");
                    Process.GetCurrentProcess().Kill();
                    System.Environment.Exit(0);
                }
            }
            else
            {
                RegKey.Text ="输入的为无效注册码!";
            }
        }

        private void RegKeyInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            System.Environment.Exit(0);
        }
    }
}
