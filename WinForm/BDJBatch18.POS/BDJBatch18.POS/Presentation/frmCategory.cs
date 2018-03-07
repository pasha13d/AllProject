using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation
{
    public partial class frmCategory : BDJBatch18.POS.Presentation.Templates.frmDisplay
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmCategoryNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Category category = new DAL.Category();
            dgvCategory.DataSource = category.Select().Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count <= 0)
                return;

            DialogResult dr = MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;

            DAL.Category c = new DAL.Category();
            c.Id = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells["colId"].Value);
            if(c.Delete())
            {
                MessageBox.Show("Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(c.Error); 
            } 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count <= 0)
                return;
            frmCategoryEdit cgEdit = new Presentation.frmCategoryEdit(Convert.ToInt32(dgvCategory.SelectedRows[0].Cells["colId"].Value));
            cgEdit.ShowDialog();
        }    
    }
}
