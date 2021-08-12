using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFTechnology
{
    public partial class UserDataInformationFromServer : Form
    {
        public UserDataInformationFromServer()
        {
            InitializeComponent();
            RintData();
        }

        private void MserchFromServer_Click(object sender, EventArgs e)
        {
            RintData();
        }
        public void RintData()
        {
            CName.Text = Properties.Settings.Default.ComputerName;
            CID.Text = Properties.Settings.Default.KeyCode;
            CreateTime.Text = Properties.Settings.Default.CreateTime.ToString();
            EndPayTime.Text = Properties.Settings.Default.RegPayFinishedTime.ToString();
            LastUseDate.Text = Properties.Settings.Default.LastLogTime.ToString();
            GetedDays.Text = Properties.Settings.Default.RegPayDays.ToString();
            ValidDate.Text = Properties.Settings.Default.validServerEndTime.ToString();
        }
    }
}
