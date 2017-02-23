using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewJersyTrafficTicket.Models
{
    public class LoginModel
    {
        public int Userid { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Nullable<int> tblUserRoleId { get; set; }
        public string UserName { get; set; }


        public LoginModel login(LoginModel logins)
        {
            LoginModel model = new LoginModel();
            dd_NJTrafficTicketsEntities dbentity = new dd_NJTrafficTicketsEntities();
            var result = dbentity.tblUsers.FirstOrDefault(a => a.UserName == logins.UserName && a.Password == logins.Password);
            if (result != null)
            {
                model.Name = result.Name;
                model.Userid = result.tblUserId;
                model.UserName = result.UserName;
                model.tblUserRoleId = result.tblUserRoleId;
            }
            return model;
        }

    }

}