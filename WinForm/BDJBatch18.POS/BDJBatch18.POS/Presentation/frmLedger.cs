using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation
{
    public partial class frmLedger : BDJBatch18.POS.Presentation.Templates.frmDisplay
    {
        public frmLedger()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmLedgerNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Ledger ld = new DAL.Ledger();
            ld.Search = txtSearch.Text;
            ld.Contact = Convert.ToString(txtContact.Text);
            ld.Email = Convert.ToString(txtEmail.Text);

            //dateSearch
            ld.isDateSearch = ucDateSearch1.isEnabled;
            ld.DateFrom = ucDateSearch1.DateFrom;
            ld.DateTo = ucDateSearch1.DateTo;
                      
            dgvLedger.DataSource = ld.select().Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          if (dgvLedger.SelectedRows.Count <= 0)
                return;

            DialogResult dr = MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;

            DAL.Ledger ld = new DAL.Ledger();
            ld.Id = Convert.ToInt32(dgvLedger.SelectedRows[0].Cells["colId"].Value);
            if(ld.delete())
            {
                MessageBox.Show("Data has been Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(ld.Error); 
            } 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLedger.SelectedRows.Count <= 0)
                return;
            frmLedgerEdit ledgerEdit = new frmLedgerEdit(Convert.ToInt32(dgvLedger.SelectedRows[0].Cells["colId"].Value));
            ledgerEdit.ShowDialog();
        }
    }
}
