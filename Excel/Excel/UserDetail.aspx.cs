using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel.Model;

namespace Excel
{
    public partial class UserDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    var id = Request.QueryString["id"];
                    hdnId.Value = id;
                }
                if (Request.QueryString["Search"] != null)
                {
                    hdnSearch.Value = Convert.ToString(Request.QueryString["Search"]);
                }
                if (Request.QueryString["Contains"] != null)
                {
                    hdnContains.Value = Convert.ToString(Request.QueryString["Contains"]);
                }
                if (Request.QueryString["IsPotential"] != null)
                {
                    hdIsFirst.Value = Request.QueryString["IsPotential"].ToString();
                }
                UserId.Value = Request.Cookies["LoginRole"].Value.ToString();
            }
            catch (Exception ex)
            { }
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<NJ_Users> GetAllEmployees()
        {
            NJ_Users obj = new NJ_Users();
            var Result = obj.getAllEmployee();
            return Result;


        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static Nj_Detail UserDetails(int id = 0, bool IsPotential = true)
        {
            Nj_Detail objDetails = new Nj_Detail();
            if (!IsPotential)
            {

                Nj_Detail obj = new Nj_Detail();
                var result = obj.UserDetail(id);
                objDetails.F_Name = result.F_Name;
                objDetails.L_Name = result.L_Name;
                objDetails.List_Type = result.List_Type;
                objDetails.Court_Name = result.Court_Name;
                objDetails.File_Date = result.File_Date;
                objDetails.CourtDate = result.CourtDate;
                objDetails.Address1 = result.Address1;
                objDetails.Address2 = result.Address2;
                objDetails.City = result.City;
                objDetails.ST = result.ST;
                objDetails.ZIP = result.ZIP;
                objDetails.Description = result.Description;
                objDetails.MI = result.MI;
                objDetails.Violation = result.Violation;
                objDetails.DateIssued = result.DateIssued;
                objDetails.Salutation = result.Salutation;
                objDetails.Summons = result.Summons;
                objDetails.NJ_CourtID = result.NJ_CourtID;
                objDetails.Muncipality = result.Muncipality;
                objDetails.Complaint = result.Complaint;
                objDetails.Title = result.Title;
                objDetails.DOB = result.DOB;
                objDetails.IsPotential = false;
                objDetails.IsUser = false;
                objDetails.IsAddedBy = 0;
                objDetails.SourceComm = "";
            }
            else
            {
                Nj_Detail obj = new Nj_Detail();
                var result = obj.UserDetailFromClient(id);
                objDetails.F_Name = result.F_Name;
                objDetails.L_Name = result.L_Name;
                objDetails.List_Type = result.List_Type;
                objDetails.Court_Name = result.Court_Name;
                objDetails.File_Date = result.File_Date;
                objDetails.CourtDate = result.CourtDate;
                objDetails.Address1 = result.Address1;
                objDetails.Address2 = result.Address2;
                objDetails.City = result.City;
                objDetails.ST = result.ST;
                objDetails.ZIP = result.ZIP;
                objDetails.Description = result.Description;
                objDetails.MI = result.MI;
                objDetails.Violation = result.Violation;
                objDetails.DateIssued = result.DateIssued;
                objDetails.Salutation = result.Salutation;
                objDetails.Summons = result.Summons;
                objDetails.NJ_CourtID = result.NJ_CourtID;
                objDetails.Muncipality = result.Muncipality;
                objDetails.Complaint = result.Complaint;
                objDetails.Title = result.Title;
                objDetails.DOB = result.DOB;
                objDetails.Phone = result.Phone;
                objDetails.Email = result.Email;
                objDetails.IsPotential = true;
                objDetails.IsUser = false;
                objDetails.IsAddedBy = result.IsAddedBy;
                objDetails.SourceComm = result.SourceOfComm;
            }
            if (objDetails.IsClient(id))
            {
                objDetails.IsUser = true;
            }
            return objDetails;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static String MakeClient(string id = "", string Type = "", string Total = "", string Paid = "", string Balance = "", string Cardno = "", string CardExpireyDate = "", string CVV = "", string Phone = "", string Email = "", string PotentialClient = "", string comment = "",
            string FName = "", string LName = "", string CourtName = "", string Address1 = "", string Address2 = "", string City = "", string State = "", string Zip = "",
                   string Description = "", string DOB = "", string MI = "", string Violation = "", string Dateissued = "", string Salutation = "", string Summons = "",
                    string CourtID = "", string Muncipality = "", string Complaint = "", string Title = "", string ListType = "", string SourceComm = "", string AddedBy = "")
        {
            Nj_Detail obj = new Nj_Detail();
            obj.MakeClient(id, Type, Total, Paid, Balance, Cardno, CardExpireyDate, CVV, Phone, Email, PotentialClient, comment, Convert.ToInt32(HttpContext.Current.Session["LoginId"]),
                  FName, LName, CourtName, Address1, Address2, City, State, Zip, Description, DOB, MI, Violation, Dateissued, Salutation, Summons,
                     CourtID, Muncipality, Complaint, Title, ListType, SourceComm, AddedBy);
            return "";
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static NJ_APIFilter UserDetailsAPI()
        {
            NJ_APIFilter objApi = new NJ_APIFilter();
            objApi = HttpContext.Current.Session["UserDate"] as NJ_APIFilter;
            return objApi;
        }
    }
}