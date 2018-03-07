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
    public partial class frmCategoryEdit : Form
    {
        ErrorProvider ep = new ErrorProvider();
        DAL.Category cg = new DAL.Category();
        public frmCategoryEdit(int _id)
        {
            InitializeComponent();
            cg.Id = _id;
            if (cg.SelectById())
            {
                cg.Name = cg.Name;
                cg.Description = cg.Description;
                cg.CategoryId = cg.CategoryId;
            }
            else
            {
                MessageBox.Show(cg.Error);
                Close();
            }
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
                ep.SetError(txtName, "Requred");
            }

            if (txtDescription.Text == "")
            {
                er++;
                ep.SetError(txtDescription, "Required");
            }
            if (cmbCategory.SelectedValue == null || cmbCategory.SelectedValue.ToString() == "")
                {
                    er++;
                   ep.SetError(cmbCategory, "Required");
                }

                if (er > 0)
                return;
            //br.Id = 1;        

            cg.Name = txtName.Text;
            cg.Description = txtDescription.Text;
            cg.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);

            if (cg.Update())
            {
                MessageBox.Show("Updated");
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(cg.Error);
            }
        }

        private void frmCategoryEdit_Load(object sender, EventArgs e)
        {
            loadCategory();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        private void loadCategory()
        {
            DAL.Category category = new DAL.Category();
            cmbCategory.DataSource = category.Select().Tables[0];
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "id";
            cmbCategory.SelectedValue = -1;
        }

        private void frmCategoryEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
