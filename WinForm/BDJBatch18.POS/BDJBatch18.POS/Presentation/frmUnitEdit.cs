using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation
{
    public partial class frmUnitEdit : Form
    {
        ErrorProvider ep = new ErrorProvider();
        DAL.Unit u = new DAL.Unit();
        public frmUnitEdit(int _id)
        {
            InitializeComponent();
            u.Id = _id;
            if (u.selectById())
            {
                u.Name = u.Name;
                u.Description = u.Description;
                u.PrimaryQty = u.PrimaryQty;
            }
            else
            {
                MessageBox.Show(u.Error);
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            ep.Clear();

            if (txtName.Text == "")
            {
                er++;
                ep.SetError(txtName, "Requred");
            }

            if (txtDescription.Text == "")
            {
                er++;
                ep.SetError(txtDescription, "Required");
            }
            if (txtPrimaryQty.Text == "")
            {
                er++;
                ep.SetError(txtPrimaryQty, "Required");
            }

            if (er > 0)
                return;                 

            u.Name = txtName.Text;
            u.Description = txtDescription.Text;
            u.PrimaryQty = Convert.ToInt32(txtPrimaryQty.Text);

            if (u.update())
            {
                MessageBox.Show("Updated");
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(u.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
