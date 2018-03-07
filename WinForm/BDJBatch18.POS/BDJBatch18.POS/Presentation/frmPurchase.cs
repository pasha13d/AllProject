using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BDJBatch18.POS.Presentation
{
    public partial class frmPurchase : BDJBatch18.POS.Presentation.Templates.frmDisplay
    {



        public frmPurchase()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {


        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmPurchaseNew().ShowDialog();
            btnSearch.PerformClick();
        }
    }
}

