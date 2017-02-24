using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StableLawFirm.Model;

namespace StableLawFirm
{
    public partial class Add_Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ResultModel objResultModel = new ResultModel();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                if (id != 0)
                {
                    var result = objResultModel.Getresultbyid(id);
                    txtResultHeading.Text = result.Result_Heading;
                    TxtResult.Text = result.Result_Text;
                    lblHeadText.Text = "Update Result";
                    btnSaveResult.Text = "Upadte";
                    Updateid.Value = Convert.ToString(id);
                }
                else
                {
                    lblHeadText.Text = "Add Result";
                    btnSaveResult.Text = "Save";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }
        }

        [System.Web.Services.WebMethod]
        public static string AddResults(string Result_Heading = "", string Result_Text = "", string updateid = "")
        {
            try
            {
                ResultModel objResultModel = new ResultModel();
                if (updateid != "")
                {
                    int id = Convert.ToInt32(updateid);
                    objResultModel.updateresult(Result_Heading, Result_Text, id);
                    return "Result Updated Succesfully";
                }
                else
                {
                    objResultModel.SaveResult(Result_Heading, Result_Text);
                    return "Result save SuccesFully";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}