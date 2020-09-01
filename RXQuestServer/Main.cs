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

        private void PlantDTrack_Click(object sender, EventArgs e)
        {
            ToPlant.AutoDesKToPlant autoDesKToPlant = new ToPlant.AutoDesKToPlant();
            this.Hide();
            autoDesKToPlant.Show();
        }

        private void PlantDFence_Click(object sender, EventArgs e)
        {
            ToPlant.DrawFence autoDesKToPlant = new ToPlant.DrawFence();
            this.Hide();
            autoDesKToPlant.Show();
        }

        private void WorkData_Click(object sender, EventArgs e)
        {
            RX_DataUpdata.ULogin uLogin = new RX_DataUpdata.ULogin();
            this.Hide();
            uLogin.Show();
        }

        private void CreateTrackOnLine_Click(object sender, EventArgs e)
        {
            ToPlant.DrawTrack autoDesKToPlant = new ToPlant.DrawTrack();
            this.Hide();
            autoDesKToPlant.Show();
        }
    }
}
