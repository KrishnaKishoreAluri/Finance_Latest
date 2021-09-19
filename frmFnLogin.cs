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
    public partial class frmFnLogin : Form
    {
        
        //public frmFnLogin(Form1 frm)
        //{
        //    InitializeComponent();
        //    this.frm = frm;
        //}
        public frmFnLogin()
        {
            InitializeComponent();
            //shwfrm(this);
        }
        private void shwfrm(Form frm)
        {
            frm.ShowDialog();
        }
        SQLConfig config = new SQLConfig();
        usableFunction func = new usableFunction();
        string query;
        int maxrow;

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM Users WHERE UserName ='" + UsernameTextBox.Text + "' AND Password = '" + PasswordTextBox.Text + "'";
            maxrow = config.maxrow(query);

            if(maxrow > 0)
            {
                //MessageBox.Show("User successfully logged in");
                this.Hide();
                frmFnHome frmHome = new frmFnHome();
                frmHome.Show();
                //frm.enable_menu();
                
                
            }
            else
            {
                MessageBox.Show("Account does not exist!","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
