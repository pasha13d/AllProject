using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSW
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["type"].ToString() == "")
            {
                Session["msg"] = "You have to login to view this page";
                Session["rdr"] = "Product.aspx";
                Response.Redirect("AdminLogin.aspx");
            }
            else if (Session["type"].ToString() == "U")
            {
                Session["msg"] = "You have to login with admin account to view this page";
                Session["rdr"] = "Product.aspx";
                Response.Redirect("AdminLogin.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);

            //delete code here
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Response.Redirect("ProductEdit.aspx?id=" + id);
        }
    }
}