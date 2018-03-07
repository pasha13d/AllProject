using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation
{
    public partial class frmProductImage : BDJBatch18.POS.Presentation.Templates.frmDisplay
    {
        public frmProductImage()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.ProductImage pi = new DAL.ProductImage();
            pi.Search = txtSearch.Text;
            try
            {
                pi.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);               
            }
            catch { }
            dgvProductImage.DataSource = pi.select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProductImageNew().ShowDialog();
            //btnSearch.PerformClick();
        }

        private void frmProductImage_Load(object sender, EventArgs e)
        {
            DAL.Product p = new DAL.Product();
            cmbProduct.DataSource = p.select().Tables[0];
            cmbProduct.DisplayMember = "name";
            cmbProduct.ValueMember = "id";
            cmbProduct.SelectedValue = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProductImage.SelectedRows.Count <= 0)
                return;

            DialogResult dr = MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;

            DAL.ProductImage pi = new DAL.ProductImage();
            pi.Id = Convert.ToInt32(dgvProductImage.SelectedRows[0].Cells["colId"].Value);
            if(pi.delete())
            {
                MessageBox.Show("Data has been Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(pi.Error); 
            } 
        }
    }
}
