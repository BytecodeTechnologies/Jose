using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StableLawFirm.Model
{
    public class LoginModel
    {
        StabileLawFirmEntities nj = new StabileLawFirmEntities();
        public int Userid { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Nullable<int> tblUserRoleId { get; set; }
        public string UserName { get; set; }


        public LoginModel login(string  UserName,string  Password)
        {
            LoginModel model = new LoginModel();

            var result = nj.STtblUsers.FirstOrDefault(a => a.UserName == UserName && a.Password == Password);
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