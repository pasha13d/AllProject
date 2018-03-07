using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation
{
    public partial class frmProduct : BDJBatch18.POS.Presentation.Templates.frmDisplay
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProductNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Product product = new DAL.Product();
            product.Search = txtSearch.Text;
            try
            {
                product.BrandId = Convert.ToInt32(cmbBrand.SelectedValue);
                product.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            }
            catch { }

            //DateSearch
            product.isDateSearch = ucDateSearch1.isEnabled;
            product.DateFrom = ucDateSearch1.DateFrom;
            product.DateTo = ucDateSearch1.DateTo;
                  
            dgvProduct.DataSource = product.select().Tables[0];
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count <= 0)
                return;
            frmProductEdit prEdit = new frmProductEdit(Convert.ToInt32(dgvProduct.SelectedRows[0].Cells["colId"].Value));
            prEdit.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count <= 0)
                return;

            DialogResult dr = MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;

            DAL.Product pr = new DAL.Product();
            pr.Id = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells["colId"].Value);
            if(pr.delete())
            {
                MessageBox.Show("Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(pr.Error); 
            } 
        }

        private void frmProduct_Load(object sender, EventArgs e)
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
        }
    }
}
