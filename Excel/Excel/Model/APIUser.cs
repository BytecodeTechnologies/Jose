using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Cache;
using iTextSharp.xmp.impl;
using System.EnterpriseServices;
using System.Web.Services;
namespace Excel.Model
{
    public class APIUser
    {

        public string CourtDate { get; set; }

        public int DMVPoints { get; set; }

        public int INSPoints { get; set; }

        public int ChargeCount { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string MName { get; set; }

        public string Suffix { get; set; }

        public string BirthYear { get; set; }

        public string BirthMonth { get; set; }

        public string BirthDay { get; set; }

        public string Gender { get; set; }

        public string EyeColor { get; set; }

        public string Summons { get; set; }

        public string ViolationStateCode { get; set; }

        public string ViolationDate { get; set; }

        public string ViolationStatute { get; set; }

        public string ViolationDescription { get; set; }

        public string ViolationAcdCode { get; set; }

        public string ViolationCustomerCode { get; set; }

        public string ViolationEVC { get; set; }

        public string AdjudicatedDate { get; set; }

        public string AdjudicatedStatute { get; set; }

        public string AdjudicatedDescription { get; set; }

        public string AdjudicatedAcdCode { get; set; }

        public string AdjudicatedCustomerCode { get; set; }

        public string AdjudicatedEVC { get; set; }

        public string Disposition { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string StateCode { get; set; }

        public string zip { get; set; }

        public string countryCode { get; set; }

        public string LicensePlateNumber { get; set; }

        public string LicensePlateState { get; set; }

        public string LicensePlateCountry { get; set; }

        public string DriverLicesnsenumber { get; set; }

        public string DriverLicesnsestate { get; set; }

        public string DriverLicesnsecountry { get; set; }

        public string Docket { get; set; }

        public string CaseType { get; set; }

        public List<StateSpecified> statespecified { get; set; }

        public List<APIUser> GetUSerInfo(string FirstName, string LastName, string DOB)
        {
            string[] db = DOB.Split('/');
            WebReference.wsSubjectPrescreenPlus obj = new WebReference.wsSubjectPrescreenPlus();
            WebReference.iSubject[] iSubjects = new WebReference.iSubject[1];

            string LicenseKey = "81260495-1056-4D14-8CE8-5EA21C7CED9F";
            string SearchID = "10234435424565";

            //-- make the iSubject
            iSubjects[0] = new WebReference.iSubject();
            iSubjects[0].Number = "1";
            //-- make an iName (required)
            iSubjects[0].Name = new WebReference.iName[1];
            iSubjects[0].Name[0] = new WebReference.iName();
            //iSubjects[0].Name[0].FirstName = "Jason";
            //iSubjects[0].Name[0].LastName = "Taylor";
            iSubjects[0].Name[0].FirstName = FirstName;
            iSubjects[0].Name[0].LastName = LastName;

            iSubjects[0].Name[0].Type = "MAIDEN";
            iSubjects[0].Name[0].Source = "Input";
            //-- make an iDOB (required)
            iSubjects[0].DOB = new WebReference.iDOB[1];
            iSubjects[0].DOB[0] = new WebReference.iDOB();

            iSubjects[0].DOB[0].Year = db[2];
            iSubjects[0].DOB[0].Month = db[0];
            iSubjects[0].DOB[0].Day = db[1];
            //iSubjects[0].DOB[0].Year = "1975";
            //iSubjects[0].DOB[0].Month = "02";
            //iSubjects[0].DOB[0].Day = "13";
            iSubjects[0].DOB[0].Source = "Input";

            string[] product = new string[3];
            product[0] = "PSAL";
            product[1] = "PSPN";
            product[2] = "PSPA";

            WebReference.SubjectSearchResults results = obj.SubjectSearch(LicenseKey, SearchID, "12312312", "1234567891230", product, "Q", iSubjects, "NJ", "", "", "", "IN");
            List<APIUser> objApi = new List<APIUser>();

            foreach (WebReference.oSubject subject in results.Subject)
            {
                if (subject.DriverViolation != null)
                {
                    foreach (WebReference.oDriverViolation violation in subject.DriverViolation)
                    {
                        List<StateSpecified> objstate = new List<StateSpecified>();
                        if (violation.StateSpecific != null)
                        {
                            foreach (WebReference.StateSpecificItemType x in violation.StateSpecific)
                            {
                                objstate.Add(new StateSpecified
                                {
                                    Key = x.Key,
                                    value = x.Value,
                                });
                            }
                        }
                        objApi.Add(new APIUser
                        {
                            CourtDate = violation.CourtDate,
                            DMVPoints = violation.DMVPoints,
                            INSPoints = violation.INSPoints,
                            ChargeCount = violation.ChargeCount,
                            FName = violation.FName,
                            LName = violation.LName,
                            MName = violation.MName,
                            Suffix = violation.Suffix,
                            BirthYear = violation.BirthYear,
                            BirthMonth = violation.BirthMonth,
                            BirthDay = violation.BirthDay,
                            Gender = violation.Gender,
                            EyeColor = violation.EyeColor,
                            Summons = violation.Summons,
                            // viuolation
                            ViolationStateCode = violation.ViolationStateCode,
                            ViolationDate = violation.ViolationDate,
                            ViolationStatute = violation.ViolationStatute,
                            ViolationDescription = violation.ViolationDescription,
                            ViolationAcdCode = violation.ViolationAcdCode,
                            ViolationCustomerCode = violation.ViolationCustomerCode,
                            ViolationEVC = violation.ViolationEVC,
                            // adjucated
                            AdjudicatedDate = violation.AdjudicatedDate,
                            AdjudicatedStatute = violation.AdjudicatedStatute,
                            AdjudicatedDescription = violation.AdjudicatedDescription,
                            AdjudicatedAcdCode = violation.AdjudicatedAcdCode,
                            AdjudicatedEVC = violation.AdjudicatedEVC,
                            Disposition = violation.Disposition,

                            Address1 = violation.Address.Address1,
                            Address2 = violation.Address.Address2,
                            City = violation.Address.City,
                            StateCode = violation.Address.StateCode,
                            zip = violation.Address.Zip,
                            countryCode = violation.Address.CountryCode,
                            LicensePlateNumber = violation.LicensePlate.Number,
                            LicensePlateState = violation.LicensePlate.StateCode,
                            LicensePlateCountry = violation.LicensePlate.CountryCode,
                            DriverLicesnsenumber = violation.DriversLicense.Number,
                            DriverLicesnsestate = violation.DriversLicense.StateCode,
                            DriverLicesnsecountry = violation.DriversLicense.CountryCode,
                            Docket = violation.Docket,
                            CaseType = violation.CaseType,
                            statespecified = objstate
                        });
                    }
                }

            }
            return objApi;
        }

        public void AddSearchHistory(string FirstName, string LastName, string DOB)
        {
            NJTicketEntities db = new NJTicketEntities();
            tbl_APISearchHistory history = new tbl_APISearchHistory();
            history.First_Name = FirstName;
            history.Last_Name = LastName;
            history.DOB = DOB;
            history.SearchBy = Convert.ToInt32(HttpContext.Current.Request.Cookies["LoginId"].Value); ;
            history.SearchDate = DateTime.Now;
            db.tbl_APISearchHistory.Add(history);
            db.SaveChanges();
        }
    }
}