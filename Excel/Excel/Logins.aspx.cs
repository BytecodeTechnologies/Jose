using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel.Model;

namespace Excel
{
    public partial class Logins : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    hdnUserNameField.Value = Request.Cookies["UserName"].Value;
                    hdnPasswordField.Value = Request.Cookies["Password"].Value;
                }
            }

        }
        
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string LoginUser(string UserName = "", string Password = "", string RememberMe="")
        {
            NJ_Users obj_NjUser = new NJ_Users();
            var data = obj_NjUser.UserLogin(UserName, Password);
            if (data != null)
            {
                if (RememberMe == "true")
                {
                    HttpContext.Current.Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    HttpContext.Current.Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    HttpContext.Current.Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                }

                HttpContext.Current.Response.Cookies["UserName"].Value = UserName.Trim();
                HttpContext.Current.Response.Cookies["Password"].Value = Password.Trim();

                if (data.tbl_RoleId == 1)
                {
                    HttpContext.Current.Response.Cookies["LoginRole"].Value = data.tbl_RoleId.ToString();
                    HttpContext.Current.Response.Cookies["LoginId"].Value = data.tblUserId.ToString();
                    return "1";
                }
                else
                {
                    HttpContext.Current.Response.Cookies["LoginRole"].Value = data.tbl_RoleId.ToString();
                    HttpContext.Current.Response.Cookies["LoginId"].Value = data.tblUserId.ToString();
                    return "2";
                }
            }
            else
            {
                return "0";
            }

            
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static void LogOut()
        {
            HttpContext.Current.Session["LoginRole"] = 0;
            HttpContext.Current.Response.Cookies["LoginRole"].Value = Convert.ToString(0);
            HttpContext.Current.Response.Cookies["LoginId"].Value = Convert.ToString(0);
        }
    }

}