using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StableLawFirm.Model;

namespace StableLawFirm
{
    public partial class ApproveComment : System.Web.UI.Page
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
                var results = obj.getCommentForApprove(id);
                hdnBlogId.Value = Convert.ToString(id);
                ShowBlogs.DataSource = results;
                ShowBlogs.DataBind();

                //---------------------for Categories --------------------
                CategoryModel objcategoryModel = new CategoryModel();
                var data = objcategoryModel.GetCategory();
                Repeater1.DataSource = data;
                Repeater1.DataBind();

                //----------------------- for comments ----------------------

                //CommentModel objcommentmodel = new CommentModel();
                //var items = objcommentmodel.getCommentForApprove(id);
                //int totalcomment = items.Count();
                //TotalComment.Text = Convert.ToString(totalcomment);
                comments.DataSource = results;
                comments.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }
        }
        [System.Web.Services.WebMethod]
        public static string ApproveComments(string id)
        {
            if (id != "")
            {
              int  commentid = Convert.ToInt32(id);
                BlogModel objBlog = new BlogModel();
                objBlog.CommentApproved(commentid);
            }
          
            return "Comment Approve Succesfully";
        }
          [System.Web.Services.WebMethod]
          public static string DeclineComment(string id)
        {
            if (id != "")
            {
                int commentid = Convert.ToInt32(id);
                BlogModel objBlog = new BlogModel();
                objBlog.CommentDecline(commentid);
            }
            return "Comment Decline Succesfully";
        }
    }
    }

   
