using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Excel
{
    public partial class NJ_ClientAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var val = Request.Cookies.AllKeys.Contains("LoginRole");
                if (Request.Cookies["LoginRole"].Value != "1" && Request.Cookies["LoginRole"].Value != "2")
                {
                    Response.Redirect("Logins.aspx");
                }
                Session["LoginRole"] = Request.Cookies["LoginRole"].Value;
                Session["LoginId"] = Request.Cookies["LoginId"].Value;
                HdnUserRole.Value = Convert.ToString(Request.Cookies["LoginRole"].Value);
            }
            catch (Exception ex)
            {
                Response.Redirect("Logins.aspx");
            }
            }
        }
    }
