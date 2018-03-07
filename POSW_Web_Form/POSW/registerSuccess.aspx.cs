using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSW
{
    public partial class registerSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string getInfo()
        {
            string s = "";
            if(Request.QueryString["email"] != "")
            {
                DAL.Employee emp = new DAL.Employee();
                emp.Email = Request.QueryString["email"];

                if(emp.selectByEmail())
                {
                    string message = string.Format("Hello {0}<br>you have register to our system recently. <br> Please click the following link <a href=\"activate.aspx?id={1}\">Activate My Account</a> to activate your account. <br> Best Regard BDJobs Team", emp.Name, emp.Id);

                    s = message;
                    //email to user email address
                }
                else
                {
                    //invalid request
                }
            }
            return s;
        }
    }
}