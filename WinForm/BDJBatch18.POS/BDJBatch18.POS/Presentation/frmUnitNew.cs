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
    public partial class frmUnitNew : BDJBatch18.POS.Presentation.Templates.frmNewEdit
    {
        public frmUnitNew()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            ep.Clear();

            if (txtName.Text == "")
            {
                er++;
                ep.SetError(txtName,"Name Required");
            }

            if (txtDescription.Text == "")
            {
                er++;
                ep.SetError(txtDescription, "Description Required");
            }

            if (txtPrimaryQty.Text == "")
            {
                er++;
                ep.SetError(txtPrimaryQty, "Description Required");
            }

            if (er > 0)
                return;

            Unit unit = new Unit();
            unit.Name = txtName.Text;
            unit.Description = txtDescription.Text;
            unit.PrimaryQty = Convert.ToInt32(txtPrimaryQty.Text);

            if (unit.insert())
            {
                MessageBox.Show(@"Unit saved");
                txtName.Text = "";
                txtDescription.Text = "";
                txtPrimaryQty.Text = "";
                txtName.Focus();
            }

            else
                MessageBox.Show(unit.Error);
        }

        private void frmUnitNew_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void frmUnitNew_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
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
