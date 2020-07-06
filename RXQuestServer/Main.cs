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

namespace RXQuestServer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitDelmiaDocument_Click(object sender, EventArgs e)
        {
            InitDelmiaDocument IDM = new InitDelmiaDocument();
            this.Hide();
            IDM.Show();
        }

        private void WeldSportTool_Click(object sender, EventArgs e)
        {
            AutoDeskLine_ToPlant.CatiaQuickTool CQT = new AutoDeskLine_ToPlant.CatiaQuickTool();
            this.Hide();
            CQT.Show();
        }
    }
}
