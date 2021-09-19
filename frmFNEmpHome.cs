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
    public partial class frmFNEmpHome : Form
    {
        public frmFNEmpHome()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmFNEmpNew frm = new frmFNEmpNew();
            frm.ShowDialog();
        }
    }
}
