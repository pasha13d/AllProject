using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POSW
{
    public partial class Public : System.Web.UI.MasterPage
    {
        string menuHtml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //check cookie exists in user machine
            
            //if(Request.Cookies["type"] != null)
            //{
            //    Session["id"] = Request.Cookies["id"].Value;



            //}
        }

        public string loadMenu(int pid = 0)
        {
            DAL.Category ctg = new DAL.Category();

            try
            {
                System.Data.DataTable dt = ctg.SelectMenu(pid).Tables[0];

                if (pid > 0 && dt.Rows.Count > 0)
                {
                    menuHtml += "<ul>\n";
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    menuHtml += "<li><a href=\"shop.aspx?category=" + dt.Rows[i].ItemArray[0].ToString() + "\">" + dt.Rows[i].ItemArray[1].ToString() + "</a>\n";
                    loadMenu(Convert.ToInt32(dt.Rows[i].ItemArray[0]));
                    menuHtml += "</li>\n";
                }
                if (pid > 0 && dt.Rows.Count > 0)
                {
                    menuHtml += "</ul>\n";
                }
            }
            catch { }
            return menuHtml;
        }

    }
}