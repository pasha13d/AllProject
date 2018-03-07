using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSW
{
    public partial class Login : System.Web.UI.Page
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
            if (emp.Login())
            {
                //if user is in active table then set session
                //else redirect user to registration success page              
                    Session["id"] = emp.Id;
                    Session["name"] = emp.Name;
                    Session["type"] = emp.Type;
                if(chkRemember.Checked)
                {
                    //HttpCookie hk = new HttpCookie("type", "U");
                    //hk.Expires = DateTime.Now.AddHours(300);
                    
                }

                    if (Session["rdr"].ToString() == "")
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        Response.Redirect(Session["rdr"].ToString());
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