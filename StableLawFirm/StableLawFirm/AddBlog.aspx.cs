using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StableLawFirm.Model;
using System.IO;

namespace StableLawFirm
{
    public partial class AddBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    CategoryModel objCategoryModel = new CategoryModel();
                    BlogModel objblog = new BlogModel();
                    var result = objCategoryModel.GetCategory();
                    ddlCategory.DataSource = result;
                    ddlCategory.DataValueField = "categoryId";
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataBind();
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    if (id != 0)
                    {
                        lblHeadText.Text = "Update Blog";
                        btnSaveblog.Text = "Update";
                        var results = objblog.getBlogbyid(id);
                        ddlCategory.SelectedValue = Convert.ToString(results.CategoryId);
                        txtText.Text = results.Text;
                        txtTitle.Text = results.Title;
                        txtPublishDate.Text = Convert.ToString(results.published_Date_st);
                        img.ImageUrl = results.Image;
                        Updateid.Value = Convert.ToString(results.tblBlog_Id);
                    }

                    else
                    {
                        lblHeadText.Text = "Save Blog";
                        btnSaveblog.Text = "Save";

                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }
        }

        protected void btnSaveblog_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel objBlogModel = new BlogModel();
                string _imgname = string.Empty;
                var imgPath2 = string.Empty;

                var file = FileUpload.PostedFile;

                var Title = txtTitle.Text;
                var Text = txtText.Text;
                string publishDate = txtPublishDate.Text;
                int Category = Convert.ToInt32(ddlCategory.SelectedValue);
                string updateid = Updateid.Value;
                DateTime PublishDaate = Convert.ToDateTime(publishDate);

                if (file.ContentLength > 0)
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    var _ext = Path.GetExtension(file.FileName);
                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("/BlogImages/") + _imgname + _ext;
                    var imgPath = "/BlogImages/" + _imgname + _ext;
                    imgPath2 = "/BlogImages/" + _imgname + _ext;
                    var path = _comPath;
                    file.SaveAs(path);

                    if (updateid == "")
                    {
                        objBlogModel.saveBlog(Title, Text, PublishDaate, Category, imgPath2, Convert.ToInt32(Session["LoginId"]));
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Blog saved sucessfully');window.location ='BlogList.aspx';", true);
                    }
                    else
                    {
                        objBlogModel.UpdateBlog(Title, Text, PublishDaate, Category, imgPath2, Convert.ToInt32(Session["LoginId"]), updateid);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Blog Update sucessfully');window.location ='BlogList.aspx';", true);
                    }
                }
                if (updateid != "" && file.ContentLength == 0)
                {
                    objBlogModel.UpdateBlog(Title, Text, PublishDaate, Category, imgPath2, Convert.ToInt32(Session["LoginId"]), updateid);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Blog Update sucessfully');window.location ='BlogList.aspx';", true);
                }
            }
            catch (Exception ex)
            {
		ShowErrorMessage.Text = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string _imgname = string.Empty;
                var imgPath2 = string.Empty;

                var files = FileUpload.FileName.ToString();

                var file = FileUpload.PostedFile;

                var Title = txtTitle.Text;
                var Text = txtText.Text;
                var publishDate = txtPublishDate.Text;
                var Category = ddlCategory.DataValueField;

                if (file.FileName != null)
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    var _ext = Path.GetExtension(file.FileName);
                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("/BlogImages/") + _imgname + _ext;
                    var imgPath = "/BlogImages/" + _imgname + _ext;
                    imgPath2 = "/BlogImages/" + _imgname + _ext;
                    var path = _comPath;
                    file.SaveAs(path);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }
        }
    }

}