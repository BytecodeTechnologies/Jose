using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StableLawFirm.Model;

namespace StableLawFirm
{
    public partial class ResultList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ResultModel objresult = new ResultModel();
                var result = objresult.GetAllResult();
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
                    ResultModel objresult = new ResultModel();
                    int id = Convert.ToInt32(e.CommandArgument);
                    objresult.DeleteUser(id);
                    var result = objresult.GetAllResult();
                    repeater2.DataSource = result;
                    repeater2.DataBind();
                }
                if (e.CommandName == "Edit")
                {

                    int id = Convert.ToInt32(e.CommandArgument);

                    Response.Redirect("Addresult.aspx?id=" + id);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }
        }
    }
}
