using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDJBatch18.POS.Presentation.Templates
{
    public partial class frmNewEdit : Form
    {
        protected ErrorProvider ep = new ErrorProvider();
        public frmNewEdit()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNewEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
