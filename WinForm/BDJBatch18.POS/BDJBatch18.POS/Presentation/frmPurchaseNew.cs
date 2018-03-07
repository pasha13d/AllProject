using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation
{
    public partial class frmPurchaseNew : BDJBatch18.POS.Presentation.Templates.frmNewEdit
    {
        //ErrorProvider ep = new ErrorProvider();
        public frmPurchaseNew()
        {
            InitializeComponent();
        }

        private void frmPurchaseNew_Load(object sender, EventArgs e)
        {
            //loading ComboBox
            DAL.Ledger ld = new DAL.Ledger();
            DAL.Employee em = new DAL.Employee();
            DAL.Product p = new DAL.Product();
            DAL.Purchase pr = new DAL.Purchase();

            cmbLedger.DataSource = ld.select().Tables[0];
            cmbLedger.DisplayMember = "name";
            cmbLedger.ValueMember = "id";
            cmbLedger.SelectedValue = -1;

            cmbEmployee.DataSource = em.select().Tables[0];
            cmbEmployee.DisplayMember = "name";
            cmbEmployee.ValueMember = "id";
            cmbEmployee.SelectedValue = -1;

            //product
            colProduct.DataSource = p.select().Tables[0];
            colProduct.DisplayMember = "name";
            colProduct.ValueMember = "id";

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void frmPurchaseNew_KeyDown(object sender, KeyEventArgs e)
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

        public void loadTotal()
        {
            double total = 0;
            for(int i = 0; i< dataGridView1.Rows.Count -1; i++)
            {
                try
                {
                    total += Convert.ToDouble(dataGridView1.Rows[i].Cells["colSubTotal"].Value);
                }
                catch { }
            }
            txtTotal.Text = total.ToString();
            txtGrandTotal.Text = (total + total * Convert.ToDouble(txtVat.Text) / 100 - total * Convert.ToDouble(txtDiscount.Text) / 100).ToString();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(e.RowIndex.ToString() + "," + e.ColumnIndex.ToString());

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                DAL.Product p = new DAL.Product();
                p.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["colProduct"].Value);
                p.selectById();
                dataGridView1.Rows[e.RowIndex].Cells["colQty"].Value = 1;
                dataGridView1.Rows[e.RowIndex].Cells["colRate"].Value = p.Price;
                dataGridView1.Rows[e.RowIndex].Cells["colSubTotal"].Value = 1 * p.Price;
            }

            if ((e.ColumnIndex == 1 || e.ColumnIndex ==2) && e.RowIndex >= 0)
            {
                double qty = Convert.ToDouble( dataGridView1.Rows[e.RowIndex].Cells["colQty"].Value);
                double rate = Convert.ToDouble( dataGridView1.Rows[e.RowIndex].Cells["colRate"].Value);
                dataGridView1.Rows[e.RowIndex].Cells["colSubTotal"].Value = qty * rate;
               
            }
            loadTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            if(txtNumber.Text == "")
            {
                er++;
                ep.SetError(txtNumber, "Required");
            }
            if (cmbLedger.SelectedValue == null || cmbLedger.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbLedger, "Required");
            }
            if (cmbEmployee.SelectedValue == null || cmbEmployee.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbEmployee, "Required");
            }
            if (dtpDate.Value.ToString() == "")
            {
                er++;
                ep.SetError(dtpDate, "Required");
            }

            //if(dataGridView1.Rows.Count < 2)
            //{
            //    er++;
            //    ep.SetError(dataGridView1, "Enter some items");
            //}

            if (er > 0)
                return;
            DAL.Purchase prs = new DAL.Purchase();
            prs.Discount = Convert.ToDouble(txtDiscount.Text);
            prs.EmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
            prs.LedgerId = Convert.ToInt32(cmbLedger.SelectedValue);
            prs.Number = txtNumber.Text;
            prs.Total = Convert.ToDouble(txtTotal.Text);
            prs.Vat = Convert.ToDouble(txtVat.Text);

            if(prs.insert())
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    DAL.PurchaseDetails pd = new DAL.PurchaseDetails();
                    pd.PurchaseId = prs.lastId;
                    pd.ProductId = Convert.ToInt32(dataGridView1.Rows[i].Cells["colProduct"].Value);
                    pd.Qty = Convert.ToInt32(dataGridView1.Rows[i].Cells["colQty"].Value);
                    pd.Rate = Convert.ToDouble(dataGridView1.Rows[i].Cells["colRate"].Value);
                    pd.insert();
                }
                MessageBox.Show("Purchased Saved");
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show(prs.Error);
            }

        }
    }
}
