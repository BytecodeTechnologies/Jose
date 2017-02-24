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
    public partial class BlogList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BlogModel objBlog = new BlogModel();
                var result = objBlog.getBlog();
                repeater2.DataSource = result;
                repeater2.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }


        }

        protected void repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    BlogModel objBlog = new BlogModel();
                    int id = Convert.ToInt32(e.CommandArgument);
                    var path = objBlog.DeleteBlog(id);
                    FileInfo file = new FileInfo(Server.MapPath(path));
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    var result = objBlog.getBlog();
                    repeater2.DataSource = result;
                    repeater2.DataBind();
                }

                if (e.CommandName == "Edit")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    Response.Redirect("AddBlog.aspx?id=" + id);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }
        }

    }
}