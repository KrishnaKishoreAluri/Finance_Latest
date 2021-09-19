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
    public partial class frmFNCustHome : Form
    {
        public frmFNCustHome()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmFNCustNew frmCust = new frmFNCustNew(string.Empty);
            frmCust.ShowDialog();
        }
        SQLConfig config = new SQLConfig();
        usableFunction func = new usableFunction();
        string query;
        private void frmFNCustHome_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.AutoGenerateColumns = false;
                //Set Columns Count.
                dataGridView1.ColumnCount = 6;
                dataGridView1.Width = 800;
                
                //Add Columns.
                dataGridView1.Columns[0].Name = "SerialNo";
                dataGridView1.Columns[0].HeaderText = "S.No";
                dataGridView1.Columns[0].DataPropertyName = "SerialNo";
                dataGridView1.Columns[0].Width = 50;

                dataGridView1.Columns[1].Name = "CustId";
                dataGridView1.Columns[1].HeaderText = "Id";
                dataGridView1.Columns[1].DataPropertyName = "CustId";
                dataGridView1.Columns[1].Width = 50;

                dataGridView1.Columns[2].HeaderText = "Name";
                dataGridView1.Columns[2].Name = "CustName";
                dataGridView1.Columns[2].DataPropertyName = "CustName";
                dataGridView1.Columns[2].Width = 300;

                dataGridView1.Columns[3].Name = "Address";
                dataGridView1.Columns[3].HeaderText = "Address";
                dataGridView1.Columns[3].DataPropertyName = "Address";
                dataGridView1.Columns[3].Width = 300;

                dataGridView1.Columns[4].Name = "Phone";
                dataGridView1.Columns[4].HeaderText = "Phone";
                dataGridView1.Columns[4].DataPropertyName = "Phone";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].Name = "Mobile";
                dataGridView1.Columns[5].HeaderText = "Mobile";
                dataGridView1.Columns[5].DataPropertyName = "Mobile";
                dataGridView1.Columns[5].Width = 100;

                query = "SELECT '1' AS [SerialNo],A.CustCode as CustId, (A.CustFName + ' ' +A.CustLName) AS CustName,A.Address,A.Phone,A.Mobile FROM PersonalInfo A WHERE A.CustCategory ='C' Order by A.CustCode";
                config.Load_DTG(query, dataGridView1);
                LoadSerial();
            }
            catch (Exception ex) {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var cid = string.Empty;
            //if (((DataGridView)sender).SelectedRows != null && ((DataGridView)sender).SelectedRows.Count > 0)
            //{
            //    cid = ((DataGridView)sender).SelectedRows[0].Cells[1].Value.ToString();
            //    frmFNCustNew frm = new frmFNCustNew(cid);
            //    frm.FormClosed += new FormClosedEventHandler(ob_FormClosed);
            //    frm.ShowDialog();
            //}
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }
        void ob_FormClosed(object sender, FormClosedEventArgs e)
        {
            query = "SELECT '1' AS [SerialNo],A.CustCode as CustId, (A.CustFName + ' ' +A.CustLName) AS CustName,A.Address,A.Phone,A.Mobile FROM PersonalInfo A WHERE A.CustCategory ='C' Order by A.CustCode";
            config.Load_DTG(query, dataGridView1);
        }
        private void txt_SearchName_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT '1' AS [SerialNo],A.CustCode as CustId, (A.CustFName + ' ' +A.CustLName) AS CustName,A.Address,A.Phone,A.Mobile FROM PersonalInfo A WHERE A.CustFName like '" + txtSearch.Text + "%' OR A.CustCode like '" + txtSearch.Text + "%' OR A.CustLName like '" + txtSearch.Text + "%'";
            config.Load_DTG(query, dataGridView1); ;
        }

        private void panelbuttons_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["SerialNo"].Value = i; i++;
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            LoadSerial();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var cid = string.Empty;
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                cid = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                frmFNCustNew frm = new frmFNCustNew(cid);
                frm.FormClosed += new FormClosedEventHandler(ob_FormClosed);
                frm.ShowDialog();
            }
        }
    }
}
