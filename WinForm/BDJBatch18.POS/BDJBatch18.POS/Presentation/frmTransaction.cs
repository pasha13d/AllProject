using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation
{
    public partial class frmTransaction : BDJBatch18.POS.Presentation.Templates.frmDisplay
    {
        public frmTransaction()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmTransactionNew().ShowDialog();
            btnSearch.PerformClick();
        }
    }
}
