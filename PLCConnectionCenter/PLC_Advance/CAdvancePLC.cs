﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.UaFx.Client;
using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Client;
namespace RXQuestServer.PLC_Advance
{
    public partial class CAdvancePLC : Form
    {
        Subscription m_subscription = null;
        public CAdvancePLC()
        {
            InitializeComponent();
        }
    }
}
