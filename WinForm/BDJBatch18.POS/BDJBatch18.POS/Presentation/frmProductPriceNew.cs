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
    public partial class frmProductPriceNew : BDJBatch18.POS.Presentation.Templates.frmNewEdit
    {
        public frmProductPriceNew()
        {
            InitializeComponent();
        }

        private void frmProductPriceNew_Load(object sender, EventArgs e)
        {
            //DAL.Category ct = new DAL.Category();
            //cmbUnit.DataSource = ct.Select().Tables[0];
            //cmbUnit.DisplayMember = "name";
            //cmbUnit.ValueMember = "id";
            //cmbUnit.SelectedValue = -1;

            Unit unit = new Unit();
            cmbUnit.DataSource = unit.select().Tables[0];
            cmbUnit.DisplayMember = "name";
            cmbUnit.ValueMember = "id";
            cmbUnit.SelectedValue = -1;

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void frmProductPriceNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
