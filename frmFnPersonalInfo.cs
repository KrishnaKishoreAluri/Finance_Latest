using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceV1
{
    public partial class frmFnPersonalInfo : Form
    {
        public frmFnPersonalInfo()
        {
            InitializeComponent();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            this.tabPage1.Controls.Clear();
            int selIndex = ((System.Windows.Forms.TabControl)sender).SelectedIndex;
            switch (selIndex)
            {
                case 0:
                    frmFNPartHome frm = new frmFNPartHome();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    frm.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.tabPage1.Controls.Add(frm);
                    break;
                case 1:
                    frmFNCustHome frm1 = new frmFNCustHome();
                    frm1.TopLevel = false;
                    frm1.Visible = true;
                    frm1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    frm1.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.tabPage2.Controls.Add(frm1);
                    break;
                case 2:
                    frmFNEmpHome frm2 = new frmFNEmpHome();
                    frm2.TopLevel = false;
                    frm2.Visible = true;
                    frm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    frm2.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.tabPage3.Controls.Add(frm2);
                    break;
                case 3:
                    frmFNVendHome frm3 = new frmFNVendHome();
                    frm3.TopLevel = false;
                    frm3.Visible = true;
                    frm3.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    frm3.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.tabPage4.Controls.Add(frm3);
                    break;
            }
               
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
             
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            
        }

        private void frm_Load(object sender, EventArgs e)
        {

        }
    }
}
