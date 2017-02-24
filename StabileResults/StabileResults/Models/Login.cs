using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StabileResults.Models
{
    public class Login
    {
        public int Userid { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Nullable<int> tblUserRoleId { get; set; }
        public string UserName { get; set; }

        StabileLawFirmEntities db = new StabileLawFirmEntities();
        public Login UserLogin(string userId, string Password)
        {
            Login model = new Login();
            var result = db.STtblUsers.FirstOrDefault(a => a.UserName == userId && a.Password == Password);
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