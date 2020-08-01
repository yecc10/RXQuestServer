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
            this.TopMost = true;
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

        private void GotoOCR_Click(object sender, EventArgs e)
        {
            OcrCenter.OCR Socr = new OcrCenter.OCR();
            this.Hide();
            Socr.Show();
        }

        private void InPutWorkTime_Click(object sender, EventArgs e)
        {
            WorkOffice.WorkTimeUpdata workTimeUpdata = new WorkOffice.WorkTimeUpdata();
            this.Hide();
            workTimeUpdata.Show();
        }
    }
}
