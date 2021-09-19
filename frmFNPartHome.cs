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
    public partial class frmFNPartHome : Form
    {
        public frmFNPartHome()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmFNPartNew frm = new frmFNPartNew(string.Empty);
            frm.ShowDialog();
        }
        SQLConfig config = new SQLConfig();
        usableFunction func = new usableFunction();
        string query;
        private void frmFNPartHome_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.AutoGenerateColumns = false;
                //Set Columns Count.
                dataGridView1.ColumnCount = 8;
                dataGridView1.Width = 800;
                //Add Columns.
                dataGridView1.Columns[0].Name = "SerialNo";
                dataGridView1.Columns[0].HeaderText = "S.No";
                dataGridView1.Columns[0].DataPropertyName = "SerialNo";
                dataGridView1.Columns[0].Width = 20;

                dataGridView1.Columns[1].Name = "CustId";
                dataGridView1.Columns[1].HeaderText = "Id";
                dataGridView1.Columns[1].DataPropertyName = "CustId";
                dataGridView1.Columns[1].Width = 20;

                dataGridView1.Columns[2].HeaderText = "Name";
                dataGridView1.Columns[2].Name = "CustName";
                dataGridView1.Columns[2].DataPropertyName = "CustName";
                dataGridView1.Columns[2].Width = 100;

                dataGridView1.Columns[3].Name = "Address";
                dataGridView1.Columns[3].HeaderText = "Address";
                dataGridView1.Columns[3].DataPropertyName = "Address";
                dataGridView1.Columns[3].Width = 250;

                dataGridView1.Columns[4].Name = "Phone";
                dataGridView1.Columns[4].HeaderText = "Phone";
                dataGridView1.Columns[4].DataPropertyName = "Phone";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].Name = "Mobile";
                dataGridView1.Columns[5].HeaderText = "Mobile";
                dataGridView1.Columns[5].DataPropertyName = "Mobile";
                dataGridView1.Columns[5].Width = 100;

                dataGridView1.Columns[6].Name = "Shares";
                dataGridView1.Columns[6].HeaderText = "Shares";
                dataGridView1.Columns[6].DataPropertyName = "Shares";
                dataGridView1.Columns[6].Width = 100;

                dataGridView1.Columns[7].Name = "Limit";
                dataGridView1.Columns[7].HeaderText = "Limit";
                dataGridView1.Columns[7].DataPropertyName = "Limit";
                dataGridView1.Columns[7].Width = 100;

                query = "SELECT '1' AS [SerialNo],CustCode as CustId, (CustFName + ' ' +CustLName) AS CustName,Address,Phone,Mobile,'' AS Shares,'' AS Limit FROM PersonalInfo WHERE CustCategory ='P' Order by CustCode";
                config.Load_DTG(query, dataGridView1);
                LoadSerial();

            }
            catch (Exception ex)
            {

            }
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            var cid = string.Empty;
            if (((DataGridView)sender).SelectedRows != null && ((DataGridView)sender).SelectedRows.Count > 0)
            {
                cid = ((DataGridView)sender).SelectedRows[0].Cells[1].Value.ToString();
                frmFNPartNew frm = new frmFNPartNew(cid);
                frm.FormClosed += new FormClosedEventHandler(ob_FormClosed);
                frm.ShowDialog();

            }
        }
        void ob_FormClosed(object sender, FormClosedEventArgs e)
        {
            query = "SELECT '1' AS [SerialNo],CustCode as CustId, (CustFName + ' ' +CustLName) AS CustName,Address,Phone,Mobile FROM PersonalInfo WHERE CustCategory ='P' Order by CustCode";
            config.Load_DTG(query, dataGridView1);
            LoadSerial();
        }
        private void txt_SearchName_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT '1' AS [SerialNo],CustCode as CustId, (CustFName + ' ' +CustLName) AS CustName,Address,Phone,Mobile FROM PersonalInfo WHERE CustFName like '" + txtSearch.Text + "%' OR CustCode like '" + txtSearch.Text + "%' OR CustLName like '" + txtSearch.Text + "%'";
            config.Load_DTG(query, dataGridView1);
            LoadSerial();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var cid = string.Empty;
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                cid = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                frmFNPartNew frm = new frmFNPartNew(cid);
                frm.FormClosed += new FormClosedEventHandler(ob_FormClosed);
                frm.ShowDialog();
            }
        }
    }
}

