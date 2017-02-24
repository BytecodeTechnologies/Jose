using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StableLawFirm.Model
{
    public class CommentModel
    {

        StabileLawFirmEntities dbentity = new StabileLawFirmEntities();
         public int Comment_Id { get; set; }
        public string Comment_Text { get; set; }
        public DateTime ?Comment_Date { get; set; }

        public string Comment_Date_St { get; set; }
        public string Comment_By { get; set; }
        public string Comment_Email { get; set; }
        public int ?Blog_Id { get; set; }
        public int ?IsApproved { get; set; }

        public int AddComment(string fullname,string Email,string Text,int ids)
        {
            STtblComment objtblComment = new STtblComment();
            objtblComment.Comment_Text = Text;
            objtblComment.Comment_Date = DateTime.Now;
            objtblComment.Comment_Email = Email;
            objtblComment.Comment_By = fullname;
            objtblComment.Blog_Id = ids;
            objtblComment.Isapproved = 0;
            dbentity.STtblComments.Add(objtblComment);
            dbentity.SaveChanges();
            int id = objtblComment.Comment_Id;
            return id;
        }

        public List<CommentModel> GetCommentById(int id)
        {
            var category = dbentity.STtblComments.Where(a => a.Blog_Id == id && a.Isapproved == 1).ToList();
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