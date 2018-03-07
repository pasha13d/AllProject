using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation
{
    public partial class frmProductImageNew : BDJBatch18.POS.Presentation.Templates.frmNewEdit
    {
        public frmProductImageNew()
        {
            InitializeComponent();
        }

        private void llClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.Image = null;
        }

        private void llBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "JPG|*.jpg|GIF|*.gif|PNG|*.png";

            ofd.ShowDialog();

            if (ofd.FileName == null || ofd.FileName == "")
                return;

            pbImage.Image = Image.FromFile(ofd.FileName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            ep.Clear();

            if(cmbProduct.SelectedValue == null || cmbProduct.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbProduct, "Requred");
            }

            if(txtTitle.Text == "")
            {
                er++;
                ep.SetError(txtTitle, "Required");
            }

            if(pbImage.Image == null)
            {
                er++;
                ep.SetError(pbImage, "Required");
            }

            if (er > 0)
                return;

            DAL.ProductImage pi = new DAL.ProductImage();

            pi.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
            pi.Title = txtTitle.Text;
            pi.Image = BDJBatch18.POS.FimeImage.ImageToByte(pbImage.Image);

            if(pi.insert())
            {
                MessageBox.Show("Image Saved");
                cmbProduct.SelectedValue = -1;
                txtTitle.Text = "";
                pbImage.Image = null;
                cmbProduct.Focus();
            }
            else
            {
                MessageBox.Show(pi.Error);
            }

        }

        private void frmProductImageNew_Load(object sender, EventArgs e)
        {
            DAL.Product p = new DAL.Product();
            cmbProduct.DataSource = p.select().Tables[0];
            cmbProduct.DisplayMember = "name";
            cmbProduct.ValueMember = "id";
            cmbProduct.SelectedValue = -1;

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void frmProductImageNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
