using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StableLawFirm.Model
{
    public class BlogModel
    {
        StabileLawFirmEntities nj = new StabileLawFirmEntities();
        public int tblBlog_Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime? Post_Date { get; set; }
        public DateTime? published_Date { get; set; }
        public int tbluserid { get; set; }

        public string UserName { get; set; }

        public string Post_Date_st { get; set; }

        public string published_Date_st { get; set; }


        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }

        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int Commentcount { get; set; }
        public int comment_id { get; set; }
        public string commentText { get; set; }

        public string CommentAddedBy { get; set; }
        public string CommentBy_Email { get; set; }

        public string CommentDate { get; set; }


        public int day { get; set; }
        public string Month { get; set; }

        public string str_month { get; set; }

        public int year { get; set; }



        public List<BlogModel> getBlog(int categoryId = 0, string SearchItem = "")
        {
            List<BlogModel> objBlogmodel = new List<BlogModel>();

            var result = (from s in nj.STtblUsers
                          join sa in nj.STtblBlogs on s.tblUserId equals sa.tbluserid
                          join ma in nj.STtblCategories on sa.tblCategory_Id equals ma.tblCategory_Id
                          where (ma.tblCategory_Id == categoryId || categoryId == 0) && (sa.Title.Contains(SearchItem))
                          select new
                          {
                              tblBlog_Id = sa.tblBlog_Id,
                              Image = sa.Image,
                              Title = sa.Title,
                              Text = sa.Text,
                              Post_Date = sa.Post_Date,
                              published_Date = sa.Published_Date,
                              UserName = s.Name,
                              CategoryName = ma.caregory_Name,
                              comment = nj.STtblComments.Where(x => x.Blog_Id == sa.tblBlog_Id && x.Isapproved == 1).Count()
                          }).ToList();
            foreach (var items in result)
            {
                objBlogmodel.Add(new BlogModel
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
                    Commentcount = items.comment,
                    day = (Convert.ToDateTime(items.Post_Date).Day),
                    Month = (Convert.ToDateTime(items.Post_Date).ToString("MMMM").Substring(0, 3)),
                    year = (Convert.ToDateTime(items.Post_Date).Year),

                });
            }
            objBlogmodel = objBlogmodel.OrderByDescending(l => l.Post_Date).ToList();
            return objBlogmodel;
        }


        public List<BlogModel> getBlogbyids(int id)
        {
          List<BlogModel> tblblogObj = new List<BlogModel>();
            var Result = (from s in nj.STtblUsers
                          join sa in nj.STtblBlogs.Where(s => s.tblBlog_Id == id) on s.tblUserId equals sa.tbluserid
                          select new
                          {
                              tblBlog_Id = sa.tblBlog_Id,
                              Image = sa.Image,
                              Title = sa.Title,
                              Text = sa.Text,
                              Post_Date = sa.Post_Date,
                              published_Date = sa.Published_Date,
                              UserName = s.Name
                          }).ToList();


            foreach (var items in Result)
            {
                tblblogObj.Add(new BlogModel
                {
                    tblBlog_Id = items.tblBlog_Id,
                    Image = items.Image,
                    Title = items.Title,
                    Text = items.Text,
                    Post_Date = items.Post_Date,
                    published_Date_st = Convert.ToDateTime(items.published_Date).ToShortDateString(),
                    Post_Date_st = Convert.ToDateTime(items.Post_Date).ToShortDateString(),
                    published_Date = items.published_Date,
                    UserName = items.UserName,
                    day = (Convert.ToDateTime(items.Post_Date).Day),
                    Month = (Convert.ToDateTime(items.Post_Date).ToString("MMMM").Substring(0, 3)),
                    year = (Convert.ToDateTime(items.Post_Date).Year),
                });
            }
            return tblblogObj;
        }



        public void saveBlog(string Title, string Text, DateTime publishDate, int Category, string imgPath2,int Userid)
        {
            try
            {
                STtblBlog objBlog = new STtblBlog();
                objBlog.Image = imgPath2;
                objBlog.Title = Title;
                objBlog.Text = Text;
                objBlog.Published_Date = Convert.ToDateTime(publishDate);
                objBlog.Post_Date = DateTime.Now;
                objBlog.tbluserid = 1;
                objBlog.tblCategory_Id = Category;
                nj.STtblBlogs.Add(objBlog);
                nj.SaveChanges();
            }
            catch (Exception cc)
            {
                throw cc;
            }
        }

        public string DeleteBlog(int id)
        {
            var result = nj.STtblComments.Where(x => x.Blog_Id == id).ToList();
            foreach (var items in result)
            {
                nj.STtblComments.Remove(items);
                nj.SaveChanges();
            }
            var Result = nj.STtblBlogs.FirstOrDefault(a => a.tblBlog_Id == id);
            var path = Result.Image;
            nj.STtblBlogs.Remove(Result);
            nj.SaveChanges();
            return path;
        }

        public BlogModel getBlogbyid(int id)
        {
            var Result = nj.STtblBlogs.FirstOrDefault(a => a.tblBlog_Id == id);
            BlogModel tblblogObj = new BlogModel();
            tblblogObj.tblBlog_Id = Result.tblBlog_Id;
            tblblogObj.Text = Result.Text;
            tblblogObj.published_Date = Result.Published_Date;
            tblblogObj.Title = Result.Title;
            tblblogObj.published_Date_st = Convert.ToDateTime(Result.Published_Date).ToShortDateString();
            tblblogObj.Post_Date_st = Convert.ToDateTime(Result.Post_Date).ToShortDateString();
            tblblogObj.Image = Result.Image;
            tblblogObj.CategoryId = Result.tblCategory_Id;

            return tblblogObj;
        }


        public void UpdateBlog(string Title, string Text, DateTime publishDate, int Category, string imgPath2, int Userid,string BlogId)
        {
            if (BlogId != "")
            {
                int blogIds = Convert.ToInt32(BlogId);

                var blogs = nj.STtblBlogs.FirstOrDefault(a => a.tblBlog_Id == blogIds);
                blogs.Title = Title;
                blogs.Text = Text;
                blogs.Published_Date = publishDate;
                blogs.tblCategory_Id = Category;
                if (imgPath2 != "")
                {
                    blogs.Image = imgPath2;
                }
                nj.SaveChanges();
            }

        }


        public List<BlogModel> getCommentForApprove(int CommentId)
        {

           List<BlogModel> tblblogObj = new List<BlogModel>();
            var id = nj.STtblComments.FirstOrDefault(a => a.Comment_Id == CommentId);

            if (id != null)
            {

                var Result = (from s in nj.STtblBlogs
                              join sa in nj.STtblComments.Where(s => s.Comment_Id == CommentId) on s.tblBlog_Id equals sa.Blog_Id
                              join san in nj.STtblUsers on s.tbluserid equals san.tblUserId into joined
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
                              }).ToList();
                foreach (var item in Result)
                {
                    tblblogObj.Add(new BlogModel
                    {
                        tblBlog_Id = item.tblBlog_Id,
                        Text = item.Text,
                        comment_id = item.Comment_Id,
                        commentText = item.Comment_Text,
                        CommentAddedBy = item.Comment_BY,
                        CommentBy_Email = item.Email,
                        Title = item.Title,
                        Post_Date_st = Convert.ToDateTime(item.Post_Date).ToShortDateString(),
                        Image = item.Image,
                        CommentDate = Convert.ToDateTime(item.comment_Date).ToShortDateString(),
                        UserName = item.addedby,
                    });
                }
                return tblblogObj;

            }
            else
            {
                return tblblogObj;
            }
        }

        public void CommentDecline(int commentid)
        {
            var Result = nj.STtblComments.FirstOrDefault(a => a.Comment_Id == commentid);

            nj.STtblComments.Remove(Result);
            nj.SaveChanges();

        }
        public void CommentApproved(int commentid)
        {

            var Result = nj.STtblComments.FirstOrDefault(a => a.Comment_Id == commentid);
            Result.Isapproved = 1;
            nj.SaveChanges();
        }

    }
}