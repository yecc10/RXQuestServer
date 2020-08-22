using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YeccAutoCenter;

namespace WorkOffice
{
    public partial class WorkTimeUpdata : Form
    {
        System.Data.DataTable datatable = new System.Data.DataTable();
        System.Data.DataColumn dataColum;
        DataRow DataRow;
        DataView dataview;
        public WorkTimeUpdata()
        {
            InitializeComponent();
        }

        private void ReadData_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            ReadData.BackColor = SystemColors.ActiveCaption;
            System.Threading.Thread importThread = new System.Threading.Thread(new ThreadStart(xlsPath));
            importThread.SetApartmentState(ApartmentState.STA); //重点
            importThread.Start();
        }
        public void xlsPath()
        {
            CheckForIllegalCrossThreadCalls = false;
            string Path = string.Empty;
            OpenFileDialog XlsFile = new OpenFileDialog();
            XlsFile.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            XlsFile.Filter = "EXCEL files (*.xls,*.xlsx,*.csv)|*.xls;*.xlsx;*.csv";
            XlsFile.FilterIndex = 2;
            XlsFile.RestoreDirectory = true;
            XlsFile.Multiselect = false;
            if (XlsFile.ShowDialog() == DialogResult.OK)
            {
                //RxDataOprator.ExcelOprator.ReadXlsData(XlsFile.FileName, DataGrid);

                if (ByExcel.Checked)
                {
                    RxDataOprator.ExcelOprator.ReadXlsData(XlsFile.FileName, datatable, RxDataOprator.ExcelOprator.ReadXlsType.ReadRxWorkTime,pbar);
                }
                else
                {
                    RxDataOprator.ExcelOprator.ReadXlsData(XlsFile.FileName, datatable);
                }
                ReadData.BackColor = Color.Green;
                SetDataGrid();
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            this.TopMost = true;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void SetDataGrid()
        {
            //DataGrid.DataSource = null;
            //DataGrid.DataSource = datatable;
            //DataGrid.AllowUserToAddRows = true;
            //DataGrid.Enabled = true;
            //DataGrid.ScrollBars = ScrollBars.Vertical;
            this.Invoke(new InvokeHandler(delegate ()
            {
                DataGrid.DataSource = null;
                DataGrid.DataSource = datatable;
            }));
            DataGrid.Update();
        }
        private delegate void InvokeHandler();

        private void WorkTimeUpdata_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            System.Environment.Exit(0);
        }
        //子线程中
    }
}
