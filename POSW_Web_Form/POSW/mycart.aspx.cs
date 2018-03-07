using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSW
{
    public partial class mycart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            GridView1.DataSource = (List<Models.CartItem>)Session["cart"];
            GridView1.DataBind();

            Label lbl = (Label)GridView1.FooterRow.FindControl("lblTotal");

            lbl.Text = ((List<Models.CartItem>)Session["cart"]).Sum(ci=>ci.SubTotal).ToString();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Session["cart"] = (List<Models.CartItem>)GridView1.DataSource;

            List<Models.CartItem> cart = new List<Models.CartItem>();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Models.CartItem ci = new Models.CartItem();
                ci.ProductId = Convert.ToInt32(((Label)GridView1.Rows[i].FindControl("lblProductId")).Text);
                ci.Product = ((Label)GridView1.Rows[i].FindControl("lblProduct")).Text;
                ci.Qty = Convert.ToInt32(((TextBox)GridView1.Rows[i].FindControl("txtQty")).Text);
                ci.Rate = Convert.ToInt32(((Label)GridView1.Rows[i].FindControl("lblRate")).Text);
                cart.Add(ci);
            }

            Session["cart"] = cart;

            GridView1.DataSource = cart;
            GridView1.DataBind();

            Label lbl = (Label)GridView1.FooterRow.FindControl("lblTotal");

            lbl.Text = ((List<Models.CartItem>)Session["cart"]).Sum(ci => ci.SubTotal).ToString();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if(Session["type"].ToString() == "")
            {
                Session["msg"] = "You have to login to order any item";
                Session["rdr"] = "confirm.aspx";
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("confirm.aspx");
            }
        }
    }
}