using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewJersyTrafficTicket.Models;
using System.IO;
using System.Net.Mail;
using System.Net;


namespace NewJersyTrafficTicket.Controllers
{
    
    public class BlogController : Controller
    {
        Blog objblog = new Blog();
        //
        // GET: /Blog/
        public ActionResult Index()
        {
            
            return View();
          
        }
        public ActionResult Index1(int PageIndex = 0, int categoryID = 0, string SearchItem = "")
        {
            var BlogList = objblog.getBlog(categoryID, SearchItem);
            dd_NJTrafficTicketsEntities dbentity = new dd_NJTrafficTicketsEntities();

            int PageSize = 3;
            int skip = PageIndex * PageSize;
            double PageCount = Convert.ToDouble(Math.Ceiling((double)((double)BlogList.Count() /(double) PageSize)));
            ViewBag.PageCount = PageCount;
            ViewBag.CurrentPageIndex = PageIndex;
            List<Blog> query = BlogList.Skip(skip).Take(PageSize).ToList();
            ViewBag.totalRecord = query.Count();
            return PartialView("/Views/Blog/_index.cshtml", query);

        }

        public ActionResult Add_New()
        {
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                CategoryModel model = new CategoryModel();
                ViewBag.Categories = model.GetCategory();
                Blog objtblResult = new Blog();
                return View(objtblResult);
            }
            else
            {
                return Redirect("/Admin/index");
            }
        }

        public ActionResult Image(Blog blg)
        {
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                string _imgname = string.Empty;
                var imgPath2 = string.Empty;
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var pic = System.Web.HttpContext.Current.Request.Files["file"];
                    if (pic.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(pic.FileName);
                        var _ext = Path.GetExtension(pic.FileName);

                        _imgname = Guid.NewGuid().ToString();
                        var _comPath = Server.MapPath("~/Content/Blog_Images/") + _imgname + _ext;
                        var imgPath = "~/Content/Blog_Images/" + _imgname + _ext;
                        imgPath2 = "/Content/Blog_Images/" + _imgname + _ext;

                        var path = _comPath;
                        pic.SaveAs(path);
                        if (blg.tblBlog_Id == 0)
                        {
                            objblog.saveBlog(blg, imgPath2, Convert.ToInt32(Session["UserId"]));
                            return Json("Blog Added Succesfully", JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            objblog.UpdateBlog(blg, imgPath2);
                            return Json("Blog Updated Succesfully", JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                objblog.UpdateBlog(blg, imgPath2);
                return Json("Blog Updated Succesfully", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Redirect("/Admin/index");
            }
        }

        public ActionResult List()
        {
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                var BlogList = objblog.getBlog();
                return View(BlogList);
            }
            else
            {
                return Redirect("/Admin/index");
            }

        }

        public ActionResult EditBlog(int id)
        {
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                var Blog = objblog.getBlogbyid(id);
                CategoryModel model = new CategoryModel();
                ViewBag.Categories = model.GetCategory();
                return View("Add_New", Blog);
            }
            else
            {
                return Redirect("/Admin/index");
            }
        }

        public ActionResult DeleteBlog(int id)
        {
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                var path = objblog.DeleteBlog(id);
                FileInfo file = new FileInfo(Server.MapPath(path));
                if (file.Exists)
                {
                    file.Delete();
                }
                return Redirect("/Blog/List");
            }
            else
            {
                return Redirect("/Admin/index");
            }
        }

        public ActionResult ShowBlog(int id)
        {
            var result = objblog.getBlogbyids(id);
            CategoryModel model = new CategoryModel();
            ViewBag.Categories = model.GetCategory();
            return View(result);
        }

        public ActionResult AddComment(CommentModel objCommentModel)
        {
            CommentModel objcomment = new CommentModel();
         int id = objcomment.AddComment(objCommentModel);
          
            var result = objcomment.GetCommentById(Convert.ToInt32(objCommentModel.Blog_Id));
         SendEmailToUser(id);
         //   SendEmail(id);
           // return Json(JsonRequestBehavior.AllowGet);
            
            return PartialView("~/Views/Blog/_Comment.cshtml",result);
        }
        public ActionResult SendEmail(int id)
        {
            string result = "";

            var message = new MailMessage();
            message.To.Add(new MailAddress("vipan.rinku@gmail.com"));
            message.From = new MailAddress("Vipan.rinku@gmail.com");
            message.CC.Add("ravi2495Kumar@gmail.com");
            message.CC.Add("ravi_20kumar@yahoo.com");
         //   string body = "<p>Please Click on this Link to approve this comment:  http://www.bostontraffictickets.org/Blog/ApproveComment/" + id + "  </p>";
            string body = "<p>Please Click on this Link to approve this comment:  http://localhost:7119//Blog/ApproveComment/" + id + "  </p>";
            message.Subject = "Registration Succesfull";


            message.IsBodyHtml = true;
            message.Body = body;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "vipan.rinku@gmail.com",
                    Password = "panjlachaudhary"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;


                try
                {

                    smtp.Send(message);
                    result = "Email Sent";
                }
                catch (Exception ex)
                {
                    result = ex.Message + "....... Inner exception is: " + ex.InnerException;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public string SendEmailToUser(int id)
        {
            string result = "";
            string to = "request@stabilelawfirm.com";
            string from = "request@stabilelawfirm.com";
            string body = "<h2>New Comment For Approval</h2>";
            body = body + "<p>Please Click on this Link to approve this comment:  http://www.bostontraffictickets.org/Blog/ApproveComment/" + id + "  </p>";
            MailMessage mail = new MailMessage(from, to);
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.newjerseydefensivedriving.net";
            mail.Subject = "NewJerseyTrafficTickets.com: New Blog Comment For Approval";
            mail.IsBodyHtml = true;
            mail.Body = body;
            try
            {
                client.Send(mail);
                result = "Email Sent";
            }
            catch (Exception ex)
            {
                result = ex.Message + "....... Inner exception is: " + ex.InnerException;
            }
            return result;
        }


        public ActionResult GetCommentByBlogID(int id)
        {
            CommentModel objcomment = new CommentModel();
            var result = objcomment.GetCommentById(id);
            return PartialView("~/Views/Blog/_Comment.cshtml", result);
        }
       
        public ActionResult ApproveComment(int id )
        {
            var Result = objblog.getCommentForApprove(id);
        return View(Result);
        }

        public ActionResult CommentDecline(int CommentId)
        {
            objblog.CommentDecline(CommentId);
            return Json("Comment Decline Succesfully",JsonRequestBehavior.AllowGet);
        }

        public ActionResult CommentApproved(int CommentId)
        {
            objblog.CommentApproved(CommentId);
            return Json("Comment Approve Succesfully", JsonRequestBehavior.AllowGet);

        }

        public ActionResult Comment()
       {
            dd_NJTrafficTicketsEntities dbentity = new dd_NJTrafficTicketsEntities();
            var list = dbentity.tblComments.ToList();

            return View(list);
        }

        public ActionResult DeleteComment(int id)
        {
            dd_NJTrafficTicketsEntities dbentity = new dd_NJTrafficTicketsEntities();
            var Result = dbentity.tblComments.FirstOrDefault(a => a.Comment_Id == id);

            dbentity.tblComments.Remove(Result);
            dbentity.SaveChanges();



            return Redirect("/Blog/Comment");
        }

        public ActionResult SaveImage()
        {
            try
            {
                string _imgname = string.Empty;
                var imgPath2 = string.Empty;
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var pic = System.Web.HttpContext.Current.Request.Files["file"];
                    if (pic.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(pic.FileName);
                        var _ext = Path.GetExtension(pic.FileName);

                        _imgname = Guid.NewGuid().ToString();
                        var _comPath = Server.MapPath("~/Content/Test_Image/") + _imgname + _ext;
                        var imgPath = "~/Content/Test_Image/" + _imgname + _ext;
                        imgPath2 = "/Content/Test_Image/" + _imgname + _ext;

                        var path = _comPath;
                        pic.SaveAs(path);
                        return Json("Image save Successfully", JsonRequestBehavior.AllowGet);
                    }
                }
                return Json("Please Select Image", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

        }

        
	}
}