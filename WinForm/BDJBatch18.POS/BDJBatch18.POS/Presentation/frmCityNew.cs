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
    public partial class frmCityNew : BDJBatch18.POS.Presentation.Templates.frmNewEdit
    {
       
        public frmCityNew()
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
            
            if (er > 0)
                return;

            City city = new City();
            city.Name = txtName.Text;

            if (city.Insert())
            {
                MessageBox.Show("City Saved");
                txtName.Text = "";
                txtName.Focus();
            }
            else
                MessageBox.Show(city.Error);
        }

        private void frmCityNew_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void frmCityNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
