using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CATIA_APP_ITF;
using SURFACEMACHINING;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Diagnostics;
using INFITF;
using MECMOD;
using PARTITF;
using ProductStructureTypeLib;
using SPATypeLib;
using NavigatorTypeLib;
using KnowledgewareTypeLib;
using HybridShapeTypeLib;
using System.IO;
using DNBPert;
using CATMat;
using FittingTypeLib;
using DNBASY;


namespace RXQuestServer.Delmia
{
    public partial class InitDelmiaDocument : Form
    {
        DataType.Dsystem DStype = new DataType.Dsystem();
        public InitDelmiaDocument()
        {
            InitializeComponent();
        }

        private void SelectInit_Click(object sender, EventArgs e)
        {
            GloalForDelmia GFD = new GloalForDelmia();
            DStype=GFD.InitCatEnv(this);
            if (DStype.Revalue==-1)
            {
                return;
            }
          Selection Uselect=GFD.GetInitTargetProduct(this, DStype);
            try
            {
                Product Usp = (Product)Uselect.Item2(1).Value;
                String Name = Usp.get_PartNumber();
                Usp.Products.AddNewProduct(Name+ "_Fixture");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
