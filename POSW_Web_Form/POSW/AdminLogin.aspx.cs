using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSW
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["msg"].ToString() != "")
                lblMessage.Text = Session["msg"].ToString();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DAL.Employee emp = new DAL.Employee();

            emp.Email = txtEmail.Text;
            emp.Password = txtPassword.Text;
            if(emp.Login())
            {
                if (emp.Type == "A")
                {
                    Session["id"] = emp.Id;
                    Session["name"] = emp.Name;
                    Session["type"] = emp.Type;
                    if(Session["rdr"].ToString() == "")
                    {
                        Response.Redirect("DefaultAdmin.aspx");
                    }
                    else
                    {
                        Response.Redirect(Session["rdr"].ToString());
                    }
                }
                else
                {
                    lblMessage.Text = "You have to login with admin account to view these content";
                }
            }
            else
            {
                lblMessage.Text = "Vua Login";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}