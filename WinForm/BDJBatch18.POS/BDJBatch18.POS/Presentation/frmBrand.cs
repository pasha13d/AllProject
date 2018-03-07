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
    public partial class frmBrand : BDJBatch18.POS.Presentation.Templates.frmDisplay
    {
        public frmBrand()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Brand br = new DAL.Brand();
            br.Search = txtSearch.Text;
            br.Origin = txtOrigin.Text;         
            dgvBrand.DataSource = br.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmBrandNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBrand.SelectedRows.Count <= 0)
                return;

            DialogResult dr = MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;

            DAL.Brand br = new DAL.Brand();
            br.Id = Convert.ToInt32(dgvBrand.SelectedRows[0].Cells["colId"].Value);
            if (br.Delete())
            {
                MessageBox.Show("Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(br.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBrand.SelectedRows.Count <= 0)
                return;
            frmBrandEdit brEdit = new frmBrandEdit(Convert.ToInt32(dgvBrand.SelectedRows[0].Cells["colId"].Value));
            brEdit.ShowDialog();

        }
    }
}
