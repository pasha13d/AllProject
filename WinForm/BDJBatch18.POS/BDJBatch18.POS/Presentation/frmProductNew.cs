using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation
{
    public partial class frmProductNew : BDJBatch18.POS.Presentation.Templates.frmNewEdit
    {
       // ErrorProvider ep = new ErrorProvider();
        DAL.Product p = new DAL.Product();
        public frmProductNew()
        {
            InitializeComponent();
        }

        private void frmProductNew_Load(object sender, EventArgs e)
        {
            DAL.Brand b = new DAL.Brand();
            cmbBrand.DataSource = b.Select().Tables[0];
            cmbBrand.DisplayMember = "name";
            cmbBrand.ValueMember = "id";
            cmbBrand.SelectedValue = -1;

            DAL.Category c = new DAL.Category();
            cmbCategory.DataSource = c.Select().Tables[0];
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "id";
            cmbCategory.SelectedValue = -1;

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
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

            if (txtCode.Text == "")
            {
                er++;
                ep.SetError(txtCode, "Required");
            }
            if (txtDescription.Text == "")
            {
                er++;
                ep.SetError(txtDescription, "Required");
            }
            if (cmbBrand.SelectedValue == null || cmbBrand.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbBrand, "Required");
            }
            if (cmbCategory.SelectedValue == null || cmbCategory.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbCategory, "Required");
            }


            if (er > 0)
                return;
            
            p.Name = txtName.Text;
            p.Code = txtCode.Text;
            p.Description = txtDescription.Text;
            p.BrandId = Convert.ToInt32(cmbBrand.SelectedValue);
            p.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            p.CreateDate = Convert.ToDateTime(DateTime.Now);

            if (p.insert())
            {
                MessageBox.Show(@"Brand Saved");
                txtName.Text = "";
                txtCode.Text = "";
                txtDescription.Text = "";
                cmbBrand.SelectedValue = -1;
                cmbCategory.SelectedValue = -1;
                
                txtName.Focus();
            }

            else
            {
                MessageBox.Show(p.Error);
            }
        }

        private void frmProductNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
