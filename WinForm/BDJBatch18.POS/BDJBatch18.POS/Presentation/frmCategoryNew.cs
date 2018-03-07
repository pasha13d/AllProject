using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace BDJBatch18.POS.Presentation
{
    public partial class frmCategoryNew : BDJBatch18.POS.Presentation.Templates.frmNewEdit
    {
        public frmCategoryNew()
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
                ep.SetError(txtName, "Name Required");
            }
            if (txtDescription.Text == "")
            {
                er++;
                ep.SetError(txtDescription, "Description Required");
            }

            if (er > 0)
                return;

            Category category = new Category();
            category.Name = txtName.Text;
            category.Description = txtDescription.Text;
            category.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);

            if (category.Insert())
            {
                MessageBox.Show("Category Saved");
                txtName.Text = "";
                txtDescription.Text = "";
                cmbCategory.SelectedValue = -1;
                txtName.Focus();
                loadCategory();
            }

            else
                MessageBox.Show(category.Error);
        }

        private void frmCategoryNew_Load(object sender, EventArgs e)
        {
            loadCategory();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void loadCategory()
        {
            Category category = new Category();
            cmbCategory.DataSource = category.Select().Tables[0];
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "id";
            cmbCategory.SelectedValue = -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCategoryNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
