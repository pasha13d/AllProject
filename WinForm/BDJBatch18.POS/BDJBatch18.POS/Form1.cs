using BDJBatch18.POS.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDJBatch18.POS
{
    public partial class Form1 : Form
    {
        Presentation.frmBrand brand = new Presentation.frmBrand();
        Presentation.frmTransaction transaction = new Presentation.frmTransaction();
        Presentation.frmPurchase purchase = new Presentation.frmPurchase();
        Presentation.frmLedger ledger = new Presentation.frmLedger();
        Presentation.frmEmployee employee = new Presentation.frmEmployee();
        Presentation.frmProductImage productImage = new Presentation.frmProductImage();
        Presentation.frmCategory category = new Presentation.frmCategory();
        Presentation.frmUnit unit = new Presentation.frmUnit();
        Presentation.frmProduct product = new Presentation.frmProduct();
        Presentation.frmProductPrice productPrice = new Presentation.frmProductPrice();
        Presentation.frmCity city = new frmCity();
        public Form1()
        {
            InitializeComponent();
        }

        private void productImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productImage.IsDisposed)
                productImage = new Presentation.frmProductImage();
            productImage.MdiParent = this;
            productImage.Show();
            productImage.BringToFront();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employee.IsDisposed)
                employee = new Presentation.frmEmployee();
            employee.MdiParent = this;
            employee.Show();
            employee.BringToFront();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ledger.IsDisposed)
                ledger = new Presentation.frmLedger();
            ledger.MdiParent = this;
            ledger.Show();
            ledger.BringToFront();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (purchase.IsDisposed)
                purchase = new Presentation.frmPurchase();
            purchase.MdiParent = this;
            purchase.Show();
            purchase.BringToFront();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (transaction.IsDisposed)
                transaction = new Presentation.frmTransaction();
            transaction.MdiParent = this;
            transaction.Show();
            transaction.BringToFront();
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (brand.IsDisposed)
                brand = new Presentation.frmBrand();
            brand.MdiParent = this;
            brand.Show();
            brand.BringToFront();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (category.IsDisposed)
                category = new Presentation.frmCategory();
            category.MdiParent = this;
            category.Show();
            category.BringToFront();
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (unit.IsDisposed)
                unit = new Presentation.frmUnit();
            unit.MdiParent = this;
            unit.Show();
            unit.BringToFront();
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (product.IsDisposed)
                product = new Presentation.frmProduct();
            product.MdiParent = this;
            product.Show();
            product.BringToFront();
        }

        private void productPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productPrice.IsDisposed)
                productPrice = new Presentation.frmProductPrice();
            productPrice.MdiParent = this;
            productPrice.Show();
            productPrice.BringToFront();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (city.IsDisposed)
                city = new Presentation.frmCity();
            city.MdiParent = this;
            city.Show();
            city.BringToFront();
        }
    }
}
