using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSW
{
    public partial class ProductImageNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            FileUpload fle = (FileUpload)DetailsView1.FindControl("fleImage");
            e.Values["fileName"] = System.IO.Path.GetFileName(fle.FileName);
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            FileUpload fle = (FileUpload)DetailsView1.FindControl("fleImage");

            fle.SaveAs(Server.MapPath("uploads/productImages/" + System.IO.Path.GetFileName(fle.FileName)));

            lblMessage.Text = "Images Inserted";
        }
    }
}