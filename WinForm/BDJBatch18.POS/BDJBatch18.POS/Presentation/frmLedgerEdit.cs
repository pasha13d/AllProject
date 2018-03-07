using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation
{
    public partial class frmLedgerEdit : Form
    {
        ErrorProvider ep = new ErrorProvider();
        DAL.Ledger ld = new DAL.Ledger();
        public frmLedgerEdit(int _id)
        {
            InitializeComponent();
            ld.Id = _id;
            if (ld.selectById())
            {
                ld.Name = ld.Name;
                ld.Contact = ld.Contact;
                ld.Email = ld.Email;
                ld.Password = ld.Password;
                ld.Gender = ld.Gender;
                ld.Address = ld.Address;
                ld.CityId = ld.CityId;
                ld.DateOfBirth = ld.DateOfBirth;
                ld.CreateDate = ld.CreateDate;
                ld.Type = ld.Type;
                ld.Image = ld.Image;
            }
            else
            {
                MessageBox.Show(ld.Error);
                Close();
            }
        }

        private void lblClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.Image = null;
        }

        private void lblBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "JPG|*.jpg|GIF|*.gif|PNG|*.png";

            ofd.ShowDialog();

            if (ofd.FileName == null || ofd.FileName == "")
                return;

            pbImage.Image = Image.FromFile(ofd.FileName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            ep.Clear();

            if (txtName.Text == "")
            {
                er++;
                ep.SetError(txtName, "Requred");
            }

            if (txtContact.Text == "")
            {
                er++;
                ep.SetError(txtContact, "Required");
            }
            if (txtEmail.Text == "")
            {
                er++;
                ep.SetError(txtEmail, "Required");
            }
            if (txtPassword.Text == "")
            {
                er++;
                ep.SetError(txtPassword, "Required");
            }           
            if (txtAddress.Text == "")
            {
                er++;
                ep.SetError(txtAddress, "Required");
            }
            if (cmbCity.SelectedValue == null || cmbCity.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbCity, "Required");
            }
            if (dtpDateOfBirth.Value.ToString() == "")
            {
                er++;
                ep.SetError(dtpDateOfBirth, "Required");
            }
            if (pbImage.Image == null)
            {
                er++;
                ep.SetError(pbImage, "Required");
            }

            if (er > 0)
                return;

            ld.Name = txtName.Text;
            ld.Contact = txtContact.Text;
            ld.Email = txtEmail.Text;
            ld.Password = txtPassword.Text;
            ld.Gender = Convert.ToInt32(cmbGender.SelectedValue);
            ld.Address = txtAddress.Text;
            ld.CityId = Convert.ToInt32(cmbCity.SelectedValue);
            ld.DateOfBirth = Convert.ToDateTime(dtpDateOfBirth.Text);
            ld.CreateDate = Convert.ToDateTime(DateTime.Now);
            ld.Type = Convert.ToString(cmbType.SelectedValue);
            try
            {
                ld.Image = BDJBatch18.POS.FimeImage.ImageToByte(pbImage.Image);
            }
            catch { }

            if (ld.update())
            {
                MessageBox.Show("Updated");
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(ld.Error);
            }
        }

        private void frmLedgerEdit_Load(object sender, EventArgs e)
        {
            DAL.City ct = new DAL.City();
            cmbCity.DataSource = ct.Select().Tables[0];
            cmbCity.DisplayMember = "name";
            cmbCity.ValueMember = "id";
            cmbCity.SelectedValue = -1;

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void frmLedgerEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
