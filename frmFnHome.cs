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
    public partial class frmFnHome : Form
    {
        public frmFnHome()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFnPersonalInfo frmPr = new frmFnPersonalInfo();
            frmPr.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFnLoans frmLoan = new frmFnLoans();
            frmLoan.Show();
        }

        private void frmFnHome_Load(object sender, EventArgs e)
        {

        }

        private void personalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFnPersonalInfo frm = new frmFnPersonalInfo();
            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Controls.Add(frm);
        }

        private void revenuExpencesStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
