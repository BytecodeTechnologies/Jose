using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landscapes;

namespace Landscapes.Models
{
   
    
    public class User
    {
       
        LandscapesEntities Db = new LandscapesEntities();
        public string UserName { get; set; }
        public string Password { get; set; }

        public Ls_User LoginUser(User user)
        {
            var result = Db.Ls_User.FirstOrDefault(a =>a.Useraname == user.UserName && a.Password == user.Password);
            return result;
        }
    }
}