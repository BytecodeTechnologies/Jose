using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StableLawFirm.Model;

namespace StableLawFirm
{
    public partial class Contact : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ResultModel model = new ResultModel();
                var result = model.GetResult();

                Repeater2.DataSource = result;
                Repeater2.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }

        }
    }
}