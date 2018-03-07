using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSW
{
    public partial class CountryNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            lblEName.Text = "";
            lblMessage.Text = "";

            if(txtName.Text == "")
            {
                er++;
                lblEName.Text = "Required";
            }

            if (er > 0)
                return;

            DAL.Country cnt = new DAL.Country();
            cnt.Name = txtName.Text;
            if(cnt.Insert())
            {
                lblMessage.Text = "Country Inserted";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                txtName.Text = "";
                txtName.Focus();
            }
            else
            {
                lblMessage.Text = cnt.Error;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}