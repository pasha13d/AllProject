using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation
{
    public partial class frmEmployeeNew : BDJBatch18.POS.Presentation.Templates.frmNewEdit
    {
        
        public frmEmployeeNew()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            ep.Clear();

            if (txtName.Text == "")
            {
                er++;
                ep.SetError(txtName, "Required");
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
            if (cmbEmployeeType.Text == "")
            {
                er++;
                ep.SetError(cmbEmployeeType, "Required");
            }

            if (er > 0)
                return;
            DAL.Employee employee = new DAL.Employee();
            employee.Name = txtName.Text;
            employee.Contact = txtContact.Text;
            employee.Email = txtEmail.Text;
            employee.Password = txtPassword.Text;
            employee.Type = Convert.ToString(cmbEmployeeType.SelectedValue);

            if (employee.insert())
            {
                MessageBox.Show(@"Brand Saved");
                txtName.Text = "";
                txtContact.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                cmbEmployeeType.SelectedValue = -1;
                txtName.Focus();
            }

            else
            {
                MessageBox.Show(employee.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEmployeeNew_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void frmEmployeeNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
