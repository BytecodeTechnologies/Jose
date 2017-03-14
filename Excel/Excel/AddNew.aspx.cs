using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel.Model;

namespace Excel
{
    public partial class AddNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                Session["LoginId"] = Request.Cookies["LoginId"].Value.ToString();
                UserId.Value = HttpContext.Current.Session["LoginId"].ToString();
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static String MakeNewClient(string ListType = "", string Filedate = "", string CourtName = "", string CourtDate = "", string LName = "", string FName = "", string MI = "", string Address1 = "", string Address2 = "", string City = "", string St = "", string Zip = "", string Dob = "",
            string Violation = "", string Description = "", string DateIssued = "", string Salution = "", string Summons = "", string CourtId = "", string Muncipality = "", string Complaint = "", string Title = "",
            string Type = "", string Total = "", string Paid = "", string Balance = "", string Cardno = "", string CardExpireyDate = "", string CVV = "", string Phone = "", string Email = "", string PotentialClient = "", string comment = "", string SourceComm = "", string AddedBy = "")
        {
            Nj_Detail obj = new Nj_Detail();
            obj.MakeNewClient(ListType,Filedate,CourtName, CourtDate,LName,FName,MI,Address1,Address2,City,St,Zip,Dob ,
            Violation,Description,DateIssued ,Salution ,Summons, CourtId,Muncipality,Complaint,Title,
            Type, Total, Paid, Balance, Cardno, CardExpireyDate, CVV, Phone, Email, PotentialClient, comment, Convert.ToInt32(AddedBy));
            return "";
        }
    }
}