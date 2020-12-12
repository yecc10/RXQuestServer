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
        public RobotTaskControl()
        {
            InitializeComponent();
        }

        private void RobotTaskControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            System.Environment.Exit(0);
        }
    }
}
