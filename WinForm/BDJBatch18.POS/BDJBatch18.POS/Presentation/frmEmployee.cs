using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation
{
    public partial class frmEmployee : BDJBatch18.POS.Presentation.Templates.frmDisplay
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmEmployeeNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count <= 0)
                return;
            frmEmplyeeEdit emEdit = new frmEmplyeeEdit(Convert.ToInt32(dgvEmployee.SelectedRows[0].Cells["colId"].Value));
            emEdit.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Employee em = new DAL.Employee();
            em.Search = txtSearch.Text;
            try
            {
                em.Type = Convert.ToString(cmbEmployeeType.SelectedValue);
            }
            catch { }
            dgvEmployee.DataSource = em.select().Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count <= 0)
                return;

            DialogResult dr = MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;

            DAL.Employee em = new DAL.Employee();
            em.Id = Convert.ToInt32(dgvEmployee.SelectedRows[0].Cells["colId"].Value);
            if(em.delete())
            {
                MessageBox.Show("Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(em.Error); 
            } 
        }
    }
}
