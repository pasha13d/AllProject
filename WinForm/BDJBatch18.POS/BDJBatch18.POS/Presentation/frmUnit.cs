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
    public partial class frmUnit : BDJBatch18.POS.Presentation.Templates.frmDisplay
    {
        public frmUnit()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmUnitNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Unit un = new DAL.Unit();
            un.Search = txtSearch.Text;
            dgvUnit.DataSource = un.select().Tables[0];
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUnit.SelectedRows.Count <= 0)
                return;
            frmUnitEdit uEdit = new frmUnitEdit(Convert.ToInt32(dgvUnit.SelectedRows[0].Cells["colId"].Value));
            uEdit.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUnit.SelectedRows.Count <= 0)
                return;

            DialogResult dr = MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;

            DAL.Unit unit = new DAL.Unit();
            unit.Id = Convert.ToInt32(dgvUnit.SelectedRows[0].Cells["colId"].Value);
            if(unit.delete())
            {
                MessageBox.Show("Data has been Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(unit.Error); 
            } 
        }
    }
}
