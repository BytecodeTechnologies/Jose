using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel.Model;

namespace Excel
{
    public partial class PotentialClientDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var id = Request.QueryString["id"];
                hdnId.Value = id;
                UserId.Value = Request.Cookies["LoginRole"].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static NJ_Clients ClientDetail(int id = 0)
        {
            Nj_Detail obj = new Nj_Detail();
            var result = obj.ClientDetail(id);
            return result;
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string MarkasClientToPotentialClient(string id = "", string Type = "", string Total = "", string Paid = "", string Balance = "", string Cardno = "", string CardExpireyDate = "", string CVV = "", string Phone = "", string Email = "", string comment = "", string SourceComm = "", string AddedBy = "")
        {
            Nj_Detail obj = new Nj_Detail();
            obj.ChangeClient_ToPotentialClient(id, Type, Total, Paid, Balance, Cardno, CardExpireyDate, CVV, Phone, Email, Convert.ToInt32(AddedBy), comment, SourceComm);
            return "Potential Client Succesfully Mark as Client";
        }


    }
}