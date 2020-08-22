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
        public Yeknowledge()
        {
            InitializeComponent();
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
    }
}
