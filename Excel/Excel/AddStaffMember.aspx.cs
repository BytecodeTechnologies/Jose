using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel.Model;

namespace Excel
{
    public partial class AddStaffMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                var userid = Request.QueryString["id"].ToString();
                Userid.Value = userid;
            }
            if (Convert.ToInt32(Request.Cookies["LoginRole"].Value) != 1)
            {
                Response.Redirect("Logins.aspx");
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static String AddnewStaff(string Id="", string FirstName="", string LastName="", string Email="", string Password="", string Role="")
        {
            if (Id != null && Id != "")
            {
                NJ_Users obj = new NJ_Users();
                obj.UpdatenewUser(Id,FirstName, LastName, Email, Password, Role);
                return "1";
               
            }
            else
            {
                NJ_Users obj = new NJ_Users();
                var value = obj.CheckEmail(Email);
                if (value == "1")
                {
                    obj.AddnewUser(FirstName, LastName, Email, Password, Role);
                    return "1";
                }
                else
                {
                    return "0";
                }
            }

          
        }
         [System.Web.Services.WebMethod(EnableSession = true)]
        public static NJ_Users EditEmployee(int id)
        {
            NJ_Users obj = new NJ_Users();
            NJ_User usr = obj.GetUserbyId(id);
            NJ_Users user = new NJ_Users
            {
                tblUserId = usr.tblUserId,
                First_Name = usr.First_Name,
                Last_Name = usr.Last_Name,
                Password = usr.Password,
                Email = usr.Email,
                tbl_RoleId = usr.tbl_RoleId
            };
            return user;
        }
    }
}