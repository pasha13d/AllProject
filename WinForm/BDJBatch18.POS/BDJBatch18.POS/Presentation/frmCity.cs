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
    public partial class frmCity : BDJBatch18.POS.Presentation.Templates.frmDisplay
    {
        public frmCity()
        {
            InitializeComponent();
        }

        private void frmCity_Load(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmCityNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            City city = new City();
            dgvCity.DataSource = city.Select().Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCity.SelectedRows.Count <= 0)
                return;

            DialogResult dr = MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;

            DAL.City ct = new DAL.City();
            ct.Id = Convert.ToInt32(dgvCity.SelectedRows[0].Cells["colId"].Value);
            if(ct.Delete())
            {
                MessageBox.Show("Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(ct.Error); 
            } 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCity.SelectedRows.Count <= 0)
                return;
            frmCityEdit brEdit = new frmCityEdit(Convert.ToInt32(dgvCity.SelectedRows[0].Cells["colId"].Value));
            brEdit.ShowDialog();
        }
    }
}
