using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSW
{
    public partial class EmployeeNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            DAL.Country cnt = new DAL.Country();

            DropDownList ddl = (DropDownList)DetailsView1.FindControl("ddlCountry");
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add(new ListItem("Select", "0"));

            ddl.DataSource = cnt.Select().Tables[0];
            ddl.DataTextField = "name";
            ddl.DataValueField = "id";
            ddl.DataBind();
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            System.Threading.Thread.Sleep(3000);
            try
            {
                DAL.City ct = new DAL.City();
                ct.CountryId = Convert.ToInt32(((DropDownList)sender).SelectedValue);

                DropDownList ddl = (DropDownList)DetailsView1.FindControl("ddlCity");
                ddl.Items.Clear();

                ddl.AppendDataBoundItems = true;

                ddl.Items.Add(new ListItem("Select", "0"));
                ddl.DataSource = ct.Select().Tables[0];
                ddl.DataTextField = "name";
                ddl.DataValueField = "id";
                ddl.DataBind();
            }
            catch { }
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            e.Values["cityId"] = ((DropDownList)DetailsView1.FindControl("ddlCity")).SelectedValue;
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            lblMessage.Text = "Employee Added";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
    }
}