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
    public partial class frmCityEdit : Form
    {
        ErrorProvider ep = new ErrorProvider();
        DAL.City ct = new DAL.City();
        public frmCityEdit(int _id)
        {
            InitializeComponent();
            ct.Id = _id;
            if (ct.SelectById())
            {
                ct.Name = ct.Name;
            }
            else
            {
                MessageBox.Show(ct.Error);
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
            if (er > 0)
                return;                

            ct.Name = txtName.Text;
            if (ct.Update())
            {
                MessageBox.Show("Updated");
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(ct.Error);
            }
        }

        private void frmCityEdit_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void frmCityEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
