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
using YeccAutoCenter;
using CATSchematicTypeLib;


namespace YeDassaultSystemDev
{
    public partial class _2DModel : Form
    {
        INFITF.Application CatApplication; //CATIA
        ProductDocument CatDocument;
        Part PartID;
        AnyObject[] GetRepeatRef = new AnyObject[9999];
        CATIA_Class CATIA_Class = new CATIA_Class();
        int RepeatNum = 0;
        public _2DModel()
        {
            InitializeComponent();
        }

        private void ReConnectCATIA_Click(object sender, EventArgs e)
        {
            CATIA_Class.InitCatEnv(ref CatApplication, ref CatDocument, ref PartID, this,true, myMessage);
        }
    }
}
