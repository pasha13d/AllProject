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
    public partial class frmEmplyeeEdit : Form
    {
        ErrorProvider ep = new ErrorProvider();
        DAL.Employee em = new DAL.Employee();
        public frmEmplyeeEdit(int _id)
        {
            InitializeComponent();
            em.Id = _id;
            if (em.selectById())
            {
                em.Name = em.Name;
                em.Contact = em.Contact;
                em.Email = em.Email;
                em.Password = em.Password;
                em.Type = em.Type;
            }
            else
            {
                MessageBox.Show(em.Error);
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

            if (txtContact.Text == "")
            {
                er++;
                ep.SetError(txtContact, "Required");
            }

            if(txtEmail.Text == "")
            {
                er++;
                ep.SetError(txtEmail, "Required");
            }

            if(txtPassword.Text == "")
            {
                er++;
                ep.SetError(txtPassword, "Required");
            }

            if (cmbEmployeeType.Text == "")
            {
                er++;
                ep.SetError(cmbEmployeeType, "Required");
            }

            if (er > 0)
                return;
            //br.Id = 1;        

            em.Name = txtName.Text;
            em.Contact = txtContact.Text;
            em.Email = txtEmail.Text;
            em.Password = txtPassword.Text;
            em.Type = Convert.ToString(cmbEmployeeType.SelectedValue);

            if (em.update())
            {
                MessageBox.Show("Updated");
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(em.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEmplyeeEdit_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void frmEmplyeeEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
