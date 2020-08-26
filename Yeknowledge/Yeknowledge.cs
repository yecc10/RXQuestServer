using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yeknowledge
{
    public partial class Yeknowledge : Form
    {
        int FX, FY, LX, LY, RX, RY;

        private void Yeknowledge_ResizeEnd(object sender, EventArgs e)
        {
            tabControl.Refresh();
            MainTree.Refresh(); ;
            this.Refresh();
            Application.DoEvents();
        }

        public Yeknowledge()
        {
            InitializeComponent();
            FX = this.Size.Width;
            FY = this.Size.Height;
            LX = MainTree.Width;
            LY = MainTree.Height;
            RX = webBrowser.Width;
            RY = webBrowser.Height;
        }

        private void ReadWcp_Click(object sender, EventArgs e)
        {
            YeknowledgeClass yeknowledge = new YeknowledgeClass();
            yeknowledge.UpdataTreeViewByWcp(MainTree, this);
            //CheckForIllegalCrossThreadCalls = false;
            //System.Threading.Thread importThread = new System.Threading.Thread(new ThreadStart(delegate { yeknowledge.UpdataTreeViewByWcp(MainTree, this); }));
            //importThread.SetApartmentState(ApartmentState.STA); //重点
            //importThread.Start();
        }

        private void Yeknowledge_ResizeBegin(object sender, EventArgs e)
        {
            MainTree.Size = new Size(200,this.Size.Height);
            tabControl.Size = new Size(this.Size.Width-200, this.Size.Height);
            tabControl.Refresh();
            MainTree.Refresh();;
            this.Refresh();
            Application.DoEvents();
        }
    }
}
