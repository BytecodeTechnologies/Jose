using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel.Model;

namespace Excel
{
    public partial class SearchUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<APIUser> GetUSerInfo(string FirstName = "", string LastName = "", string DOB = "")
        {
            APIUser obj = new APIUser();
            var result = obj.GetUSerInfo(FirstName, LastName, DOB);           
            if (result != null)
            {
                if (result.Count > 0)
                {
                    obj.AddSearchHistory(FirstName, LastName, DOB);
                }
            }
            return result;
        }

        //[System.Web.Services.WebMethod(EnableSession = true)]
        //public static List<APISearchHistory> GetHistory()
        //{
        //    APISearchHistory obj = new APISearchHistory();
        //    var result = obj.GetHistory();
        //    return result;
        //}

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string SaveInfo(string ViolationDate = "", string ViolationDescription = "", string Disposition = "", string AdjudicatedDate = "", string AdjudicatedDescription = "",
                           string StateCode = "", string countryCode = "", string DMVPoints = "", string INSPoints = "", string CourtDate = "", string CaseType = "", string ChargeCount = "", string Docket = "",
                          string Summons = "", string ViolationAcdCode = "", string AdjudicatedAcdCode = "", string AdjudicatedStatute = "", string ViolationStatute = "", string AdjudicatedCustomerCode = "", string ViolationCustomerCode = "",
                          string ViolationStateCode = "", string FName = "", string LName = "", string Address1 = "", string Address2 = "", string City = "", string State = "", string zip = "", string DOB = "", string Phone = "", string Email = "", string Gender = "")
        {
            NJ_APIFilter obj = new NJ_APIFilter();
            obj.ViolationDate = ViolationDate;
            obj.ViolationDescription = ViolationDescription;
            obj.Disposition = Disposition;
            obj.AdjudicatedDate = AdjudicatedDate;
            obj.AdjudicatedDescription = AdjudicatedDescription;
            obj.StateCode = StateCode;
            obj.countryCode = countryCode;
            obj.DMVPoints = DMVPoints;
            obj.INSPoints = INSPoints;
            obj.CourtDate = CourtDate;
            obj.CaseType = CaseType;
            obj.ChargeCount = ChargeCount;
            obj.Docket = Docket;
            obj.Summons = Summons;
            obj.ViolationAcdCode = ViolationAcdCode;
            obj.AdjudicatedAcdCode = AdjudicatedAcdCode;
            obj.AdjudicatedStatute = AdjudicatedStatute;
            obj.ViolationStatute = ViolationStatute;
            obj.AdjudicatedCustomerCode = AdjudicatedCustomerCode;
            obj.ViolationCustomerCode = ViolationCustomerCode;
            obj.ViolationStateCode = ViolationStateCode;
            obj.FName = FName;
            obj.LName = LName;
            obj.Address1 = Address1;
            obj.Address2 = Address2;
            obj.City = City;
            obj.State = State;
            obj.zip = zip;
            obj.DOB = DOB;
            obj.Phone = Phone;
            obj.Email = Email;
            obj.Gender = Gender;
            HttpContext.Current.Session["UserDate"] = obj;
            return "done";
        }

    }
}