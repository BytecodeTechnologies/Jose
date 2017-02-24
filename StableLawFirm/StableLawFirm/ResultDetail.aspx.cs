using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StableLawFirm.Model;


namespace StableLawFirm
{
    public partial class ResultDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                ResultModel obj = new ResultModel();
                var result = obj.getrecordbyid(id);
                Repeater1.DataSource = result;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }
        }
    }
}