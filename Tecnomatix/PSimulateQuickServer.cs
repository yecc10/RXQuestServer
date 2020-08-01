using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecnomatix;
using Tecnomatix.Engineering;
using Tecnomatix.Engineering.Utilities;
using Tecnomatix.Engineering.Ui;
using Tecnomatix.Engineering.ModelObjects;
using Tecnomatix.Engineering.DataTypes;

namespace Tecnomatix
{
    public partial class PSimulateQuickServer : Form
    {
        public PSimulateQuickServer()
        {
            InitializeComponent();
        }

        private void cUiContinuousButton1_Click(object sender, EventArgs e)
        {
            TxVector txVector=null;
            txVector.X = 20;
            txVector.Y = 20;
            txVector.Z = 20;
            MessageBox.Show("Hello word");
            TxMfgCreationDataFactory.CreateWeldPointCreationData("ABC", txVector);
        }
    }
}
