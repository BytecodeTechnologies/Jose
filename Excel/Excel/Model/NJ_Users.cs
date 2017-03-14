using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Excel.Model
{
    public class NJ_Users
    {
       

        NJTicketEntities db = new NJTicketEntities();

        public int tblUserId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int tbl_RoleId { get; set; }
        public int TotalCount { get; set; }

        public NJ_User UserLogin(string UserName,string Password)
        {
            var data = db.NJ_User.FirstOrDefault(a => a.Email == UserName && a.Password == Password);
            return data;
        }

        public void DeleteCallLog(int id)
        {
            List<NJ_Users> obj = new List<NJ_Users>();
            if (id > 0)
            {
                var clog = db.NJ_User.FirstOrDefault(cl => cl.tblUserId == id);
                if (clog != null)
                {
                    db.NJ_User.Remove(clog);
                    db.SaveChanges();
                }
            }

           
          
        }
       

        public List<NJ_Users> Employee(string Search)
        {
            List<NJ_Users> obj = new List<NJ_Users>();
                int searchby =(Convert.ToInt32(Search));
                var result = db.NJ_User.Where(t => (searchby == 0 || t.tbl_RoleId == searchby)).ToList();
            foreach (var i in result)
            {
                obj.Add(new NJ_Users
                {
                    First_Name = i.First_Name,
                    Last_Name = i.Last_Name,
                    Email = i.Email,
                    tblUserId = i.tblUserId,
                    tbl_RoleId = i.tbl_RoleId,
                    TotalCount = db.NJ_User.Where(t => (searchby == 0 || t.tbl_RoleId == searchby)).ToList().Count(),
                });
            }

            obj = obj.OrderByDescending(x => x.tblUserId).ToList();
            return obj;
        }
        public List<NJ_Users> getAllEmployee()
        {
            List<NJ_Users> obj = new List<NJ_Users>();
           
            var result = db.NJ_User.ToList();
            foreach (var i in result)
            {
                obj.Add(new NJ_Users
                {
                    First_Name = i.First_Name,
                    Last_Name = i.Last_Name,
                    Email = i.Email,
                    tblUserId = i.tblUserId,
                    tbl_RoleId = i.tbl_RoleId,
                    
                });
            }

            obj = obj.OrderByDescending(x => x.tblUserId).ToList();
            return obj;
        }
        public NJ_User GetUserbyId(int id)
        {
            var result = db.NJ_User.FirstOrDefault(a => a.tblUserId == id);
            return result;
        }

        public void AddnewUser(string FirstName = "", string LastName = "", string Email = "", string Password = "", string Role = "")
        {
            NJ_User objNj_User = new NJ_User();
            objNj_User.First_Name = FirstName;
            objNj_User.Last_Name = LastName;
            objNj_User.Email = Email;
            objNj_User.Password = Password;
            objNj_User.tbl_RoleId = Convert.ToInt32(Role);
            db.NJ_User.Add(objNj_User);
            db.SaveChanges();
        }
        public void UpdatenewUser(string Id="",string FirstName = "", string LastName = "", string Email = "", string Password = "", string Role = "")
        {
            int id = Convert.ToInt32(Id);
            var objTable = db.NJ_User.FirstOrDefault(a => a.tblUserId == id);
            objTable.First_Name = FirstName;
            objTable.Last_Name = LastName;
            objTable.Email = Email;
            objTable.Password = Password;
            objTable.tbl_RoleId = Convert.ToInt32(Role);
           
            db.SaveChanges();
           
        }

        public String CheckEmail(string Email)
        {
            var data = db.NJ_User.FirstOrDefault(a => a.Email == Email);
            if (data == null)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

    }

  
}