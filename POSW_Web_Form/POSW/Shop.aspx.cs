using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSW
{
    public partial class Shop : System.Web.UI.Page
    {
        string ids = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int category = Convert.ToInt32(Request.QueryString["category"]);

                ids += category.ToString();

                loadCategory(category);


                SqlDataSource1.SelectCommand = "SELECT [id], [name], [code], [description], [brand], [category], [createDate], [price], [image], [brandId], [categoryId] FROM [vwProductImage] where categoryId in("+ids+")";

            }
            catch {
                SqlDataSource1.SelectCommand = "SELECT top(100) [id], [name], [code], [description], [brand], [category], [createDate], [price], [image], [brandId], [categoryId] FROM [vwProductImage] ";
            }
        }

        public void loadCategory(int cid = 0)
        {
            DAL.Category ctg = new DAL.Category();

            System.Data.DataTable dt = ctg.SelectMenu(cid).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ids += ", " + dt.Rows[i].ItemArray[0].ToString();
                loadCategory((int)dt.Rows[i].ItemArray[0]);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            List<Models.CartItem> cart = (List<Models.CartItem>)Session["cart"];

            int productId = Convert.ToInt32(btn.CommandArgument);


            if(btn.Text == "Add")
            {
                btn.Text = "Remove";

                DAL.Product p = new DAL.Product();
                p.Id = productId;
                p.selectById();

                Models.CartItem ci = new Models.CartItem();
                ci.ProductId = productId;
                ci.Product = p.Name;
                ci.Qty = 1;
                ci.Rate = (float)p.Price;
                
                cart.Add(ci);
            }
            else
            {
                btn.Text = "Add";

                var v = cart.Where(ci=>ci.ProductId == productId).First();

                cart.Remove(v);

            }

            Session["cart"] = cart;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT [id], [name], [code], [description], [brand], [category], [createDate], [price], [image], [brandId], [categoryId] FROM [vwProductImage] where id > 0 ";

            if (txtSearch.Text != "")
            {
                string search =  txtSearch.Text.Replace("'", "\'").Replace("?", "??"); //make secured the data here
                SqlDataSource1.SelectCommand += " and (name like '%"+ search + "%' or code like '%" + search + "%' or description like '%" + search + "%')";
            }

            double priceFrom = 0;
            double priceTo = 0;

            try
            {
                priceFrom = Convert.ToDouble(txtPriceFrom.Text);
            }
            catch { }
            try
            {
                priceTo = Convert.ToDouble(txtPriceTo.Text);
            }
            catch { }

            if(priceTo > 0 && priceTo > priceFrom)
            {
                SqlDataSource1.SelectCommand += " and price between "+ priceFrom.ToString() +" and " + priceTo.ToString();
            }

            if(ddlBrand.SelectedIndex > 0)
            {
                SqlDataSource1.SelectCommand += " and brandId = " + ddlBrand.SelectedValue.ToString();
            }

            if(ddlUnit.SelectedIndex > 0)
            {
                SqlDataSource1.SelectCommand += " and unitId = " + ddlUnit.SelectedValue.ToString();
            }

            

            Repeater1.DataBind();
        }
    }
}