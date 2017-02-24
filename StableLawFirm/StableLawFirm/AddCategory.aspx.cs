using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StableLawFirm.Model;

namespace StableLawFirm
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CategoryModel objResultModel = new CategoryModel();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                if (id != 0)
                {
                    var result = objResultModel.GetCategoryById(id);

                    txtCategory.Text = result.CategoryName;
                    lblHeadText.Text = "Update Result";
                    btnSaveCategory.Text = "Upadte";
                    Updateid.Value = Convert.ToString(result.categoryId);
                }
                else
                {
                    lblHeadText.Text = "Add Category";
                    btnSaveCategory.Text = "Save";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }
        }


        [System.Web.Services.WebMethod]
        public static string AddCategorys(string categoryName = "", string updateid = "")
        {
            try
            {
                CategoryModel objCategoryModel = new CategoryModel();
                if (updateid != "")
                {
                    int id = Convert.ToInt32(updateid);
                    objCategoryModel.UpdateCategory(categoryName, id);
                    return "Category Updated Succesfully";
                }
                else
                {
                    objCategoryModel.SaveCategory(categoryName);
                    return "Category save SuccesFully";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            }
        
    }
}