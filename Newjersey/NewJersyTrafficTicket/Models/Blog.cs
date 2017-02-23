using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewJersyTrafficTicket.Models
{
    public class Blog
    {

        dd_NJTrafficTicketsEntities dbentity = new dd_NJTrafficTicketsEntities();
        public int tblBlog_Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime ?Post_Date { get; set; }
        public DateTime ?published_Date { get; set; }
        public int tbluserid { get; set; }

        public string UserName { get; set; }

        public string Post_Date_st { get; set; }

        public string published_Date_st { get; set; }

       
        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }

        public int ?CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int Commentcount { get; set; }
        public int comment_id { get; set; }
        public string commentText { get; set; }

        public string CommentAddedBy { get; set; }
        public string CommentBy_Email { get; set; }

        public string CommentDate { get; set; }

        public void saveBlog(Blog blog, string FileName, int userid)
        {
            try
            {
                tblBlog objBlog = new tblBlog();
                objBlog.Image = FileName;
                objBlog.Title = blog.Title;
                objBlog.Text = blog.Text;
                objBlog.published_Date = blog.published_Date;
                objBlog.Post_Date = DateTime.Now;
                objBlog.tbluserid = Convert.ToInt32(userid);
                objBlog.tblCategory_Id = blog.CategoryId;


                dbentity.tblBlogs.Add(objBlog);
                dbentity.SaveChanges();

            }
            catch (Exception cc)
            {
                throw cc;
            }
        }

        public List<Blog> getBlog(int categoryId = 0, string SearchItem = "")
        {
            List<Blog> objBlogmodel = new List<Blog>();

            var result = (from s in dbentity.tblUsers
                          join sa in dbentity.tblBlogs on s.tblUserId equals sa.tbluserid
                          join ma in dbentity.tblCategories on sa.tblCategory_Id equals ma.tblCategory_Id
                          where (ma.tblCategory_Id == categoryId || categoryId == 0) && (sa.Title.Contains(SearchItem))      
                          select new
                          {
                              tblBlog_Id = sa.tblBlog_Id,
                              Image = sa.Image,
                              Title = sa.Title,
                              Text = sa.Text,
                              Post_Date = sa.Post_Date,
                              published_Date = sa.published_Date,
                              UserName = s.Name,
                              CategoryName = ma.Caregory_Name,
                              comment=dbentity.tblComments.Where(x=>x.Blog_Id==sa.tblBlog_Id && x.Isapproved == 1).Count()
                          }).ToList();
            foreach (var items in result)
            {
                objBlogmodel.Add(new Blog
                    {
                        tblBlog_Id = items.tblBlog_Id,
                        Image = items.Image,
                        Title = items.Title,
                        Text = items.Text.Substring(0, Math.Min(items.Text.Length, 400)), 
                       
                        Post_Date = items.Post_Date,
                        published_Date_st = Convert.ToDateTime(items.published_Date).ToShortDateString(),
                       CategoryName = items.CategoryName,
                        Post_Date_st = Convert.ToDateTime(items.Post_Date).ToShortDateString(),
                        published_Date = items.published_Date,
                        UserName = items.UserName,
                        Commentcount =items.comment

                    });
            }
            objBlogmodel = objBlogmodel.OrderByDescending(l => l.Post_Date).ToList();
            return objBlogmodel;
        }

        public Blog getBlogbyid(int id)
        {
            var Result = dbentity.tblBlogs.FirstOrDefault(a => a.tblBlog_Id == id);
            Blog tblblogObj = new Blog();
            tblblogObj.tblBlog_Id = Result.tblBlog_Id;
            tblblogObj.Text = Result.Text;
            tblblogObj.published_Date = Result.published_Date;
            tblblogObj.Title = Result.Title;
            tblblogObj.published_Date_st = Convert.ToDateTime(Result.published_Date).ToShortDateString();
            tblblogObj.Post_Date_st = Convert.ToDateTime(Result.Post_Date).ToShortDateString();
            tblblogObj.Image = Result.Image;
            tblblogObj.CategoryId = Result.tblCategory_Id;
           
            return tblblogObj;
        }

        public Blog getBlogbyids(int id)
        {
            Blog tblblogObj = new Blog();
            var Result = (from s in dbentity.tblUsers
                          join sa in dbentity.tblBlogs.Where(s => s.tblBlog_Id == id) on s.tblUserId equals sa.tbluserid
                          select new
                          {
                              tblBlog_Id = sa.tblBlog_Id,
                              Image = sa.Image,
                              Title = sa.Title,
                              Text = sa.Text,
                              Post_Date = sa.Post_Date,
                              published_Date = sa.published_Date,
                              UserName = s.Name
                          }).FirstOrDefault();

            tblblogObj.tblBlog_Id = Result.tblBlog_Id;
            tblblogObj.Text = Result.Text;
            tblblogObj.published_Date = Result.published_Date;
            tblblogObj.Title = Result.Title;
            tblblogObj.published_Date_st = Convert.ToDateTime(Result.published_Date).ToShortDateString();
            tblblogObj.Post_Date_st = Convert.ToDateTime(Result.Post_Date).ToShortDateString();
            tblblogObj.Image = Result.Image;
            tblblogObj.UserName = Result.UserName;
            return tblblogObj;
        }

        public void UpdateBlog(Blog blog, string FileName)
        {

            var blogs = dbentity.tblBlogs.FirstOrDefault(a => a.tblBlog_Id == blog.tblBlog_Id);
            blogs.Title = blog.Title;
            blogs.Text = blog.Text;
            blogs.published_Date = blog.published_Date;
            blogs.tblCategory_Id = blog.CategoryId;
            if (FileName != "")
            {
                blogs.Image = FileName;
            }
            dbentity.SaveChanges();
        
        }

        public string DeleteBlog(int id)
        {
            var result = dbentity.tblComments.Where(x => x.Blog_Id == id).ToList();
            foreach (var items in result)
            {
                dbentity.tblComments.Remove(items);
                dbentity.SaveChanges();
            }
            var Result = dbentity.tblBlogs.FirstOrDefault(a => a.tblBlog_Id == id);
            var path = Result.Image;
            dbentity.tblBlogs.Remove(Result);
            dbentity.SaveChanges();
            return path;
        }

        public Blog getCommentForApprove(int CommentId)
        {

            Blog tblblogObj = new Blog();
            var id = dbentity.tblComments.FirstOrDefault(a => a.Comment_Id == CommentId);

            if (id != null)
            {

                var Result = (from s in dbentity.tblBlogs
                              join sa in dbentity.tblComments.Where(s => s.Comment_Id == CommentId) on s.tblBlog_Id equals sa.Blog_Id
                              join san in dbentity.tblUsers on s.tbluserid equals san.tblUserId into joined
                              from sm in joined.DefaultIfEmpty()

                              select new
                              {
                                  Comment_Id = sa.Comment_Id,
                                  Comment_Text = sa.Comment_Text,
                                  tblBlog_Id = s.tblBlog_Id,
                                  Comment_BY = sa.Comment_By,
                                  Email = sa.Comment_Email,
                                  Title = s.Title,
                                  Text = s.Text,
                                  Post_Date = s.Post_Date,
                                  Image = s.Image,
                                  comment_Date = sa.Comment_Date,
                                  addedby = sm.Name
                              }).FirstOrDefault();

                tblblogObj.tblBlog_Id = Result.tblBlog_Id;
                tblblogObj.Text = Result.Text;
                tblblogObj.comment_id = Result.Comment_Id;
                tblblogObj.commentText = Result.Comment_Text;
                tblblogObj.CommentAddedBy = Result.Comment_BY;
                tblblogObj.CommentBy_Email = CommentBy_Email;
                tblblogObj.Title = Result.Title;
                tblblogObj.Post_Date_st = Convert.ToDateTime(Result.Post_Date).ToShortDateString();
                tblblogObj.Image = Result.Image;
                tblblogObj.CommentDate = Convert.ToDateTime(Result.comment_Date).ToShortDateString();
                tblblogObj.CommentBy_Email = Result.Email;
                tblblogObj.UserName = Result.addedby;

                return tblblogObj;

            }
            else {
                return tblblogObj;
            
            }
        }

        public void CommentDecline(int commentid)
        {
            var Result = dbentity.tblComments.FirstOrDefault(a => a.Comment_Id == commentid);

            dbentity.tblComments.Remove(Result);
            dbentity.SaveChanges();
        
        }
        public void CommentApproved(int commentid)
        {
         
            var Result = dbentity.tblComments.FirstOrDefault(a => a.Comment_Id == commentid);
            Result.Isapproved = 1;
            dbentity.SaveChanges();
        }


       
      
    }
}