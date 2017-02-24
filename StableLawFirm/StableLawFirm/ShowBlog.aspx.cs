using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StableLawFirm.Model;
using System.Net.Mail;
using System.Net;

namespace StableLawFirm
{
    public partial class ShowBlog : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                //----- for Result -------------------
                ResultModel model = new ResultModel();
                var result = model.GetResult();
                Repeater2.DataSource = result;
                Repeater2.DataBind();

                //-----------    for Blog------------------
                BlogModel obj = new BlogModel();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                var results = obj.getBlogbyids(id);
                hdnBlogId.Value = Convert.ToString(id);
                ShowBlogs.DataSource = results;
                ShowBlogs.DataBind();

                //---------------------for Categories --------------------
                CategoryModel objcategoryModel = new CategoryModel();
                var data = objcategoryModel.GetCategory();
                Repeater1.DataSource = data;
                Repeater1.DataBind();

                //----------------------- for comments ----------------------

                CommentModel objcommentmodel = new CommentModel();
                var items = objcommentmodel.GetCommentById(id);
                int totalcomment = items.Count();
                TotalComment.Text = Convert.ToString(totalcomment);
                comments.DataSource = items;
                comments.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }
        }

        [System.Web.Services.WebMethod]
        public static string ADDComment(string fullname = "", string Email = "", string Text = "", string blogid = "")
        {
            if (blogid != "")
            {
                int id = Convert.ToInt32(blogid);
                CommentModel objComment = new CommentModel();
                int ids = objComment.AddComment(fullname, Email, Text, id);
                ShowBlog objblog = new ShowBlog();
                objblog.sendemail(ids);
                return "Comment Added Succesfully";
            }
            else
                return "Comment Not Added Succesfully";

           
        }
        public string sendemail(int id)
        {
            {
                string result = "";
                string to = "request@stabilelawfirm.com";
                string from = "request@stabilelawfirm.com";
                string body = "<h2>New Comment For Approval</h2>";
                body = body + "<p>Please Click on this Link to approve this comment:  http://www.StabileLawfirm.com/ApproveComment.aspx?id=" + id + "  </p>";
                MailMessage mail = new MailMessage(from, to);
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "mail.newjerseydefensivedriving.net";
                mail.Subject = "StabileLawFirm.com: New Blog Comment For Approval";
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
        }
    }
}