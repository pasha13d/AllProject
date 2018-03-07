using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSW
{
    public partial class Confirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            GridView1.DataSource = (List<Models.CartItem>)Session["cart"];
            GridView1.DataBind();

            Label lbl = (Label)GridView1.FooterRow.FindControl("lblTotal");

            lbl.Text = ((List<Models.CartItem>)Session["cart"]).Sum(ci => ci.SubTotal).ToString();



        }
    }
}