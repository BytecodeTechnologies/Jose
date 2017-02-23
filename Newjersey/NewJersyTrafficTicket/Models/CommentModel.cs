using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewJersyTrafficTicket.Models
{
    public class CommentModel
    {
        dd_NJTrafficTicketsEntities dbentity = new dd_NJTrafficTicketsEntities();
        public int Comment_Id { get; set; }
        public string Comment_Text { get; set; }
        public DateTime ?Comment_Date { get; set; }

        public string Comment_Date_St { get; set; }
        public string Comment_By { get; set; }
        public string Comment_Email { get; set; }
        public int ?Blog_Id { get; set; }
        public int ?IsApproved { get; set; }

        public int AddComment(CommentModel objCommentModel)
        {
            tblComment objtblComment = new tblComment();
            objtblComment.Comment_Text = objCommentModel.Comment_Text;
            objtblComment.Comment_Date = DateTime.Now;
            objtblComment.Comment_Email = objCommentModel.Comment_Email;
            objtblComment.Comment_By = objCommentModel.Comment_By;
            objtblComment.Blog_Id = objCommentModel.Blog_Id;
            objtblComment.Isapproved = 0;
            dbentity.tblComments.Add(objtblComment);
            dbentity.SaveChanges();
            int id = objtblComment.Comment_Id;
            return id;
        }

        public List<CommentModel> GetCommentById(int id)
        {
            var category = dbentity.tblComments.Where(a => a.Blog_Id == id && a.Isapproved == 1).ToList();
            List<CommentModel> objCommentModel = new List<CommentModel>();

            foreach (var row in category)
            {
                objCommentModel.Add(new CommentModel
                {
                 Blog_Id = row.Blog_Id,
                 Comment_By = row.Comment_By,
                 Comment_Date = row.Comment_Date,
                 Comment_Date_St = Convert.ToDateTime(row.Comment_Date).ToShortDateString(),
                 Comment_Email = row.Comment_Email,
                 Comment_Text = row.Comment_Text,
                 Comment_Id = row.Comment_Id
                });
            }

            return objCommentModel;
        }

      

    }
}