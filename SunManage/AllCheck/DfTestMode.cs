using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SunManage;

namespace SunManage.AllCheck
{
    public partial class DfTestMode : Form
    {
        public DfTestMode()
        {
            InitializeComponent();
        }

        private void m_lable_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_btnMicrofil_Click(object sender, EventArgs e)
        {
            Main.ms_objMain.DFlowTest();
        }

        private void m_btnUltrafil_Click(object sender, EventArgs e)
        {
            Main.ms_objMain.DFlowExTest();
        }
    }
}
