using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Excel.Model
{

    public class Nj_Comments
    {
        NJTicketEntities db = new NJTicketEntities();
        public int Comment_Id { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int Comment_By { get; set; }
        public DateTime? Comment_Date { get; set; }
        public string CommentByFirst_Name { get; set; }
        public string CommentByLast_Name { get; set; }
       
        public string StComment_Date { get; set; }

        public List<Nj_Comments> GetCommentByid(int id = 0)
        {
            // List<NJ_Clients> obj = new List<NJ_Clients>();
            var data = (from s in db.NJ_tblComment
                        where s.UserId == id
                        join n in db.NJ_User on s.Comment_By equals n.tblUserId
                       into joined
                        from sm in joined.DefaultIfEmpty()
                        select new Nj_Comments
                        {
                            Comment = s.Comment,
                            Comment_Date = s.Comment_Date,
                            CommentByFirst_Name = sm.First_Name,
                            CommentByLast_Name = sm.Last_Name,
                          //  StComment_Date = Convert.ToDateTime(s.Comment_Date).ToString("MM-dd-yyyy h:mmtt"),
                         //   StComment_Date = s.Comment_Date.ToString(),
                        }

                        
             ).ToList();
            List<Nj_Comments> obj = new List<Nj_Comments>();
            foreach (var item in data)
            {
                obj.Add(new Nj_Comments
                {
             Comment = item.Comment,
             Comment_Date = item.Comment_Date,
             CommentByFirst_Name = item.CommentByFirst_Name,
             CommentByLast_Name = item.CommentByLast_Name,
             StComment_Date = Convert.ToDateTime(item.Comment_Date).ToString("MM-dd-yyyy h:mmtt"),
                });

            }

            return obj;

        }

    }
}