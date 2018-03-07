using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSW
{
    public partial class CityNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);

            int er = 0;
            lblEName.Text = "";
            lblECountry.Text = "";
            lblMessage.Text = "";

            if (txtName.Text == "")
            {
                er++;
                lblEName.Text = "Required";
            }

            if(ddlCountry.SelectedIndex <= 0)
            {
                er++;
                lblECountry.Text = "Select One";
            }

            if (er > 0)
                return;

            DAL.City ct = new DAL.City();
            ct.Name = txtName.Text;
            ct.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);

            if (ct.Insert())
            {
               
                lblMessage.Text = "City Inserted";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                txtName.Text = "";
                ddlCountry.SelectedIndex = 0;
                txtName.Focus();
            }
            else
            {
                lblMessage.Text = ct.Error;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}