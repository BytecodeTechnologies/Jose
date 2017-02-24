using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StableLawFirm.Model;

namespace StableLawFirm
{
    public partial class Blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    //for results
                    ResultModel model = new ResultModel();
                    var result = model.GetResult();
                    Repeater2.DataSource = result;
                    Repeater2.DataBind();

                    //for blogs
                   string Text = Convert.ToString(Request.QueryString["SearchText"]);
                   int categoryId =Convert.ToInt32(Request.QueryString["CategoryId"]);
                   SearchPaging.Value = Convert.ToString(categoryId);
                 
                    BlogModel objblogModel = new BlogModel();
                    var results = objblogModel.getBlog(categoryId);
                    if (results.Count() == 0)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "No Item to Dispaly";
                    }

                    int PageIndex = 0;
                    int PageSize = 3;
                    int skip = PageIndex * PageSize;
                    int PageCount = Convert.ToInt32(Convert.ToDouble(Math.Ceiling((double)((double)results.Count() / (double)PageSize))));
                    List<BlogModel> query = results.Skip(skip).Take(PageSize).ToList();
                    BlogRepeater.DataSource = query;
                    BlogRepeater.DataBind();
                    List<PageModel> paging = new List<PageModel>();
                    Boolean active = false;
                    for (int i = 0; i < PageCount; i++)
                    {
                        if (i == 0)
                        {
                            active = true;
                        }
                        else
                        {

                            active = false;
                        }
                        paging.Add(new PageModel
                        {
                            pageindex = i,
                            pagename = i + 1,
                            pageactive = active,
                        });
                    }
                    Repeater1.DataSource = paging;
                    Repeater1.DataBind();

                    //for categories
                    CategoryModel objcategory = new CategoryModel();
                    var categories = objcategory.GetCategory();
                    RepeaterCategories.DataSource = categories;
                    RepeaterCategories.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }


        }

        protected void RepeaterCategories_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                lblMessage.Visible = false;
                lblMessage.Text = "";

                if (e.CommandName == "GetCategoriesById")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    BlogModel objblogModel = new BlogModel();
                    var results = objblogModel.getBlog(id);
                    if (results.Count() == 0)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "No Item to Dispaly";
                    }

                    int PageIndex = 0;
                    int PageSize = 3;
                    int skip = PageIndex * PageSize;
                    int PageCount = Convert.ToInt32(Convert.ToDouble(Math.Ceiling((double)((double)results.Count() / (double)PageSize))));
                    List<BlogModel> query = results.Skip(skip).Take(PageSize).ToList();
                    BlogRepeater.DataSource = query;
                    BlogRepeater.DataBind();
                    List<PageModel> paging = new List<PageModel>();
                    Boolean active = false;
                    for (int i = 0; i < PageCount; i++)
                    {
                        if (i == 0)
                        {
                            active = true;
                        }
                        else
                        {

                            active = false;
                        }
                        paging.Add(new PageModel
                        {
                            pageindex = i,
                            pagename = i + 1,
                            pageactive = active,
                        });
                    }
                    Repeater1.DataSource = paging;
                    Repeater1.DataBind();
                    SearchPaging.Value = Convert.ToString(id);


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Paging")
                {
                    int PageIndex = Convert.ToInt32(e.CommandArgument);
                    var value = SearchPaging.Value;
                    BlogModel objblogModel = new BlogModel();

                    if (value != "")
                    {
                        int id = Convert.ToInt32(value);
                        var results = objblogModel.getBlog(id);

                        int PageSize = 3;
                        int skip = PageIndex * PageSize;
                        int PageCount = Convert.ToInt32(Convert.ToDouble(Math.Ceiling((double)((double)results.Count() / (double)PageSize))));
                        List<BlogModel> query = results.Skip(skip).Take(PageSize).ToList();
                        BlogRepeater.DataSource = query;
                        BlogRepeater.DataBind();
                        List<PageModel> paging = new List<PageModel>();
                        Boolean active = false;
                        for (int i = 0; i < PageCount; i++)
                        {
                            if (i == PageIndex)
                            {
                                active = true;
                            }
                            else
                            {

                                active = false;
                            }
                            paging.Add(new PageModel
                            {
                                pageindex = i,
                                pagename = i + 1,
                                pageactive = active,
                            });
                        }
                        Repeater1.DataSource = paging;
                        Repeater1.DataBind();
                        SearchPaging.Value = Convert.ToString(value);
                    }
                    else
                    {
                        var results = objblogModel.getBlog();
                        int PageSize = 3;
                        int skip = PageIndex * PageSize;
                        int PageCount = Convert.ToInt32(Convert.ToDouble(Math.Ceiling((double)((double)results.Count() / (double)PageSize))));
                        List<BlogModel> query = results.Skip(skip).Take(PageSize).ToList();
                        BlogRepeater.DataSource = query;
                        BlogRepeater.DataBind();
                        List<PageModel> paging = new List<PageModel>();
                        Boolean active = false;
                        for (int i = 0; i < PageCount; i++)
                        {
                            if (i == PageIndex)
                            {
                                active = true;
                            }
                            else
                            {

                                active = false;
                            }
                            paging.Add(new PageModel
                            {
                                pageindex = i,
                                pagename = i + 1,
                                pageactive = active,
                            });
                        }
                        Repeater1.DataSource = paging;
                        Repeater1.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }
        }



    }
}