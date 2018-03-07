using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation
{
    public partial class frmProductPrice : BDJBatch18.POS.Presentation.Templates.frmDisplay
    {
        public frmProductPrice()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProductPriceNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.ProductPrice pp = new DAL.ProductPrice();
            pp.Search = txtSearch.Text;
            dgvProductPrice.DataSource = pp.Select().Tables[0];
        }
    }
}
