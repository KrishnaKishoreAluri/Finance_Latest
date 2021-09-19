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
    public partial class frmFNVendHome : Form
    {
        public frmFNVendHome()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmFNVendNew frm = new frmFNVendNew();
            frm.ShowDialog();
        }

        private void frmFNVendHome_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    dataGridView1.AutoGenerateColumns = false;
            //    //Set Columns Count.
            //    dataGridView1.ColumnCount = 6;
            //    dataGridView1.Width = 600;
            //    //Add Columns.
            //    dataGridView1.Columns[0].Name = "SerialNo";
            //    dataGridView1.Columns[0].HeaderText = "S.No";
            //    dataGridView1.Columns[0].DataPropertyName = "SerialNo";
            //    dataGridView1.Columns[0].Width = 20;

            //    dataGridView1.Columns[1].Name = "CustId";
            //    dataGridView1.Columns[1].HeaderText = "Id";
            //    dataGridView1.Columns[1].DataPropertyName = "CustId";
            //    dataGridView1.Columns[1].Width = 20;

            //    dataGridView1.Columns[2].HeaderText = "Name";
            //    dataGridView1.Columns[2].Name = "CustName";
            //    dataGridView1.Columns[2].DataPropertyName = "CustName";
            //    dataGridView1.Columns[2].Width = 100;

            //    dataGridView1.Columns[3].Name = "Address";
            //    dataGridView1.Columns[3].HeaderText = "Address";
            //    dataGridView1.Columns[3].DataPropertyName = "Address";
            //    dataGridView1.Columns[3].Width = 250;

            //    dataGridView1.Columns[4].Name = "Phone";
            //    dataGridView1.Columns[4].HeaderText = "Phone";
            //    dataGridView1.Columns[4].DataPropertyName = "Phone";
            //    dataGridView1.Columns[4].Width = 100;

            //    dataGridView1.Columns[5].Name = "Mobile";
            //    dataGridView1.Columns[5].HeaderText = "Mobile";
            //    dataGridView1.Columns[5].DataPropertyName = "Mobile";
            //    dataGridView1.Columns[5].Width = 100;

            //    query = "SELECT (select count(1) from PersonalInfo where A.CustCategory ='C') AS [SerialNo],A.CustCode as CustId, (A.CustFName + ' ' +A.CustLName) AS CustName,A.Address,A.Phone,A.Mobile FROM PersonalInfo A WHERE A.CustCategory ='C' Order by A.CustCode";
            //    config.Load_DTG(query, dataGridView1);
            //}
            //catch (Exception ex)
            //{

            //}
        }
    }
}
