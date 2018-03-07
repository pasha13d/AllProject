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
    public partial class frmProductEdit : Form
    {
        ErrorProvider ep = new ErrorProvider();
        DAL.Product pr = new DAL.Product();
        public frmProductEdit(int _id)
        {
            InitializeComponent();
            pr.Id = _id;
            if (pr.selectById())
            {
                pr.Name = pr.Name;
                pr.Code = pr.Code;
                pr.Description = pr.Description;
                pr.BrandId = pr.BrandId;
                pr.CategoryId = pr.CategoryId;
            }
            else
            {
                MessageBox.Show(pr.Error);
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
            //br.Id = 1;        

            pr.Name = txtName.Text;
            pr.Code = txtCode.Text;
            pr.Description = txtDescription.Text;
            pr.BrandId = Convert.ToInt32(cmbBrand.SelectedValue);
            pr.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            pr.CreateDate = Convert.ToDateTime(DateTime.Now);

            if (pr.update())
            {
                MessageBox.Show("Updated");
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(pr.Error);
            }
        }

        private void frmProductEdit_Load(object sender, EventArgs e)
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

        private void frmProductEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
