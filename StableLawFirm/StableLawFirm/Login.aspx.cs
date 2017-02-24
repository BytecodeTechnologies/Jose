using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StableLawFirm.Model;
using System.Web.Security;

namespace StableLawFirm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string Logins(string UserName ="",string Password ="")
        {
           LoginModel obj = new LoginModel();
       
           var result =  obj.login(UserName,Password);
           if (result.Userid != 0)
           {
               HttpContext.Current.Session["LoginId"] = result.Userid;
               HttpContext.Current.Session["LoginRole"] = result.tblUserRoleId;
               return "1";
           }
           else
           {
               return "0";
           }
        }
    }
}