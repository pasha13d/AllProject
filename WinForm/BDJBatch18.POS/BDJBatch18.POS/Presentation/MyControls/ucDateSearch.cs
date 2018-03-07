using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation.MyControls
{
    public partial class ucDateSearch : UserControl
    {
        public ucDateSearch()
        {
            InitializeComponent();
        }

        private void ucDateSearch_Load(object sender, EventArgs e)
        {
            checkUncheck();
        }

        private void checkUncheck()
        {
            dtpFrom.Enabled = chkDateSearch.Checked;
            dtpTo.Enabled = chkDateSearch.Checked;
        }
        public DateTime DateFrom
        {
            get
            {
                return dtpFrom.Value;
            }
            set
            {
                dtpFrom.Value = value;
            }
        }
        public DateTime DateTo
        {
            get
            {
                return dtpTo.Value;
            }
            set
            {
                dtpTo.Value = value;
            }
        }
        public bool isEnabled
        {
            get
            {
                return chkDateSearch.Checked;
            }
        }

        private void chkDateSearch_CheckedChanged(object sender, EventArgs e)
        {
            checkUncheck();
        }
    }
}
