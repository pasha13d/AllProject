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
    public partial class frmBrandEdit : Form
    {
        ErrorProvider ep = new ErrorProvider();
        DAL.Brand br = new DAL.Brand();
        public frmBrandEdit(int _id)
        {
            InitializeComponent();
            br.Id = _id;
            if (br.SelectById())
            {
                br.Name = br.Name;
                br.Origin = br.Origin;
            }
            else
            {
                MessageBox.Show(br.Error);
                Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
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

            if (txtOrigin.Text == "")
            {
                er++;
                ep.SetError(txtOrigin, "Required");
            }

            if (er > 0)
                return;
            //br.Id = 1;        

            br.Name = txtName.Text;
            br.Origin = txtOrigin.Text;

            if (br.Update())
            {
                MessageBox.Show("Updated");
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(br.Error);
            }
        }

        private void frmBrandEdit_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void frmBrandEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
