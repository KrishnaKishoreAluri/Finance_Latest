using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceV1
{
    public partial class frmFNPartNew : Form
    {
        string custID = string.Empty;
        string mode = string.Empty;
        public frmFNPartNew(string pId)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(pId))
            {
                mode = "create";
            }
            else
                mode = "edit";
            custID = pId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFirstName.Text.Trim()) || string.IsNullOrEmpty(txtLastName.Text.Trim()) || string.IsNullOrEmpty(txtFatherName.Text.Trim()) || string.IsNullOrEmpty(txtResAddress.Text.Trim()) || string.IsNullOrEmpty(txtMobileNumber.Text.Trim()))
                {
                    MessageBox.Show("Enter Mandatory Fields");
                }
                else
                {
                    query = string.Empty;
                    var custType = "0";
                    if (cboCustType.SelectedItem != null)
                        custType = cboCustType.SelectedItem.ToString();
                    var gender = "U";
                    if (radioMale.Checked)
                        gender = "M";
                    else if (radioFemale.Checked)
                        gender = "F";
                    if (mode == "create")
                    {
                        query = "INSERT INTO PersonalInfo(CustCode,CustFName,CustLName,FName,Address,Phone,Mobile,CustCategory,CustType,IDNumber,Address2,Mobile2,SpouseName,Occupation,Phone2,Age,Gender) VALUES('" + lblCustId.Text + "','" + txtFirstName.Text + "'," +
                            "'" + txtLastName.Text + "','" + txtFatherName.Text + "','" + txtResAddress.Text + "','" + txtResNumber.Text + "','" + txtMobileNumber.Text + "','P','" + custType + "','"
                            + txtIdNumber.Text + "','" + txtOffAddress.Text + "','" + txtMobileNumber2.Text + "','" + txtSpouseName.Text + "','" + txtOccupation.Text + "'," + txtOffNumber.Text + "'," + txtAge.Text + ",'" + gender + "' ) ";
                    }
                    else
                    {
                        query = "Update PersonalInfo SET CustFName ='" + txtFirstName.Text + "',CustLName='" + txtLastName.Text
                            + "',FName='" + txtFatherName.Text + "',Address='" + txtResAddress.Text + "',Phone='" + txtResNumber.Text +
                            "',Mobile='" + txtMobileNumber.Text + "',CustType='" + custType +
                            "',IDNumber='" + txtIdNumber.Text + "',Address2='" + txtOffAddress.Text + "',Mobile2='" + txtMobileNumber2.Text + "',SpouseName='" + txtSpouseName.Text + "',Occupation='" + txtOccupation.Text + "',Phone2='" + txtOffNumber.Text +
                            "',Age=" + txtAge.Text + ",Gender='" + gender + "' WHERE CustCode='" + lblCustId.Text.ToString() + "'";

                    }
                    config.Execute_Query(query);
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SQLConfig config = new SQLConfig();
        usableFunction func = new usableFunction();
        string query;
        private void pictureCam_Click(object sender, EventArgs e)
        {
            FrmFNCamPic frm = new FrmFNCamPic(lblCustId.Text.ToString());
            frm.FormClosed += new FormClosedEventHandler(ob_FormClosed);
            frm.ShowDialog();
        }
        void ob_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(string.Format(Path.GetDirectoryName(Application.ExecutablePath) + @"\CamCapture\{0}.png", custID)))
                CustomerPic.ImageLocation = string.Format(Path.GetDirectoryName(Application.ExecutablePath) + @"\CamCapture\{0}.png", custID);
        }
        private void pictureGallery1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + @"\CamCapture\";
            openFileDialog1.Title = "Save Files";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.DefaultExt = "png";
            openFileDialog1.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(string.Format(Path.GetDirectoryName(Application.ExecutablePath) + @"\CamCapture\{0}.png", custID)))
                    File.Delete(string.Format(Path.GetDirectoryName(Application.ExecutablePath) + @"\CamCapture\{0}.png", custID));

                System.IO.File.Copy(openFileDialog1.FileName, string.Format(Path.GetDirectoryName(Application.ExecutablePath) + @"\CamCapture\{0}.png", custID));
                CustomerPic.ImageLocation = string.Format(Path.GetDirectoryName(Application.ExecutablePath) + @"\CamCapture\{0}.png", custID);
            }
        }

        private void frmFNPartNew_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(custID))
            {
                query = string.Empty;
                query = "SELECT Replace(CustCode,'P','') FROM PersonalInfo WHERE CustCategory ='P'";
                int maxrow = config.maxrow(query);

                if (maxrow > 0)
                {
                    lblCustId.Text = "P" + (maxrow + 1).ToString();
                }
                else
                {
                    MessageBox.Show("No Data", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                query = string.Empty;
                query = "SELECT * FROM PersonalInfo WHERE CustCode ='" + custID + "'";
                DataTable dt = config.GetTable(query);
                if (dt.Rows.Count > 0)
                {
                    lblCustId.Text = custID;
                    txtFirstName.Text = dt.Rows[0]["CustFName"].ToString();
                    txtLastName.Text = dt.Rows[0]["CustLName"].ToString();
                    txtFatherName.Text = dt.Rows[0]["FName"].ToString();
                    txtResAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtResNumber.Text = dt.Rows[0]["Phone"].ToString();
                    txtMobileNumber.Text = dt.Rows[0]["Mobile"].ToString();
                    txtIdNumber.Text = dt.Rows[0]["IDNumber"].ToString();
                    txtOffAddress.Text = dt.Rows[0]["Address2"].ToString();
                    txtSpouseName.Text = dt.Rows[0]["SpouseName"].ToString();
                    txtMobileNumber2.Text = dt.Rows[0]["Mobile2"].ToString();
                    txtOccupation.Text = dt.Rows[0]["Occupation"].ToString();
                    txtOffNumber.Text = dt.Rows[0]["Phone2"].ToString();
                    cboCustType.SelectedValue = dt.Rows[0]["CustType"].ToString();
                    txtAge.Text = dt.Rows[0]["Age"].ToString();
                    if (dt.Rows[0]["Gender"].ToString() == "M")
                        radioMale.Checked = true;
                    if (dt.Rows[0]["Gender"].ToString() == "F")
                        radioFemale.Checked = true;
                }
                if (File.Exists(string.Format(Path.GetDirectoryName(Application.ExecutablePath) + @"\CamCapture\{0}.png", custID)))
                    CustomerPic.ImageLocation = string.Format(Path.GetDirectoryName(Application.ExecutablePath) + @"\CamCapture\{0}.png", custID);
                pictureCam.ImageLocation = Path.GetDirectoryName(Application.ExecutablePath) + @"\bg\webcam-icon.png";
            }
        }
    }
}
