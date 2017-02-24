using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StabileResults.Models
{
    public class User
    {

        StabileLawFirmEntities db = new StabileLawFirmEntities();
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Roleid { get; set; }


        public void AddUser(User obj)
        {
            STtblUser objSt = new STtblUser();
            objSt.Name = obj.Name;
            objSt.Password = obj.Password;
            objSt.UserName = obj.Email;
            objSt.tblUserRoleId = obj.Roleid;
            db.STtblUsers.Add(objSt);
            db.SaveChanges();
        }

        public void UpdateUser(User obj)
        {
            var result = db.STtblUsers.FirstOrDefault(a => a.tblUserId == obj.UserId);
            result.Name = obj.Name;
            result.tblUserRoleId = obj.Roleid;
            result.UserName = obj.Email;
            result.Password = obj.Password;
            db.SaveChanges();

        }
        public STtblUser CheckEmail(string Email)
        {
            var result = db.STtblUsers.FirstOrDefault(a => a.UserName == Email);
                return result;
        
        }

        public List<User> GetAllUser()
        {
            List<User> objUsers = new List<User>();
            //var result = db.STtblUsers.ToList();
            var result = (from a in db.STtblUsers
                          join b in db.STtblUserRoles on a.tblUserRoleId equals b.tblUserRoleId
                          select new User
                          {
                              Name = a.Name,
                              Email = a.UserName,
                              UserId = a.tblUserId,
                              Role = b.Name,
                              Password = a.Password
                          }).ToList();

            return result;
        }

        public void DeleteUser(int id)
        {
            var result = db.STtblUsers.FirstOrDefault(a => a.tblUserId == id);
            db.STtblUsers.Remove(result);
            db.SaveChanges();
        }

        public STtblUser GetRecordByid(int id)
        {
            User objUser = new User();
            var result = db.STtblUsers.FirstOrDefault(a => a.tblUserId == id);
            //objUser.Name = result.Name;
            //objUser.Email = result.UserName;
            //objUser.Roleid = Convert.ToInt32(result.tblUserRoleId);
            //objUser.Password = result.Password;
            return result;
        }



    }
}
