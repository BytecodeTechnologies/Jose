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

namespace Excel
{
    public partial class WEBSERVICE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                WebReference.wsSubjectPrescreenPlus obj = new WebReference.wsSubjectPrescreenPlus();
                WebReference.iSubject[] iSubjects = new WebReference.iSubject[1];
                //string LicenseKey = "99211A79-8523-430B-9F0B-4821C8359C22";
                string LicenseKey = "81260495-1056-4D14-8CE8-5EA21C7CED9F";
                string SearchID = "10234435424565";
                string Reference = "refer to v";
                string LicensePlateStateCode = "2";
                string LicensePlateNumber = "3";
                string LookbackStart = "04/12/2016";
                string LookbackEnd = "04/12/2016";

                //-- make the iSubject
                iSubjects[0] = new WebReference.iSubject();
                iSubjects[0].Number = "1"; //-- assign a unique number to the subject (required)
                //-- make an iName (required)
                iSubjects[0].Name = new WebReference.iName[1];
                iSubjects[0].Name[0] = new WebReference.iName();
                iSubjects[0].Name[0].FirstName = "Jason";
                iSubjects[0].Name[0].LastName = "Taylor";
                iSubjects[0].Name[0].Type = "MAIDEN";
                iSubjects[0].Name[0].Source = "Input";
                //-- make an iDOB (required)
                iSubjects[0].DOB = new WebReference.iDOB[1];
                iSubjects[0].DOB[0] = new WebReference.iDOB();
                iSubjects[0].DOB[0].Year = "1975";
                iSubjects[0].DOB[0].Month = "02";
                iSubjects[0].DOB[0].Day = "13";
                iSubjects[0].DOB[0].Source = "Input";

                string[] product = new string[3];
                product[0] = "PSAL";
                product[1] = "PSPN";
                product[2] = "PSPA";


                WebReference.SubjectSearchResults results = obj.SubjectSearch(LicenseKey, SearchID, "12312312", "1234567891230", product, "Q", iSubjects, "NJ", "", "", "", "IN");
                Response.Write("ErrorCode:" + results.ErrorCode);
                Response.Write(@"<br />" + "SearchID: " + results.SearchID);
                Response.Write(@"<br />" + "DriverRank: " + results.DriverRank.ToString());
                Response.Write(@"<br />" + "Reference: " + results.Reference.ToString());

                foreach (WebReference.oSubject subject in results.Subject)
                {
                    if (subject.DriverViolation != null)
                    {
                        foreach (WebReference.oDriverViolation violation in subject.DriverViolation)
                        {
                            //Response.Write(@"<br />" + "Court Date: " + violation.CourtDate);
                            //Response.Write(@"<br />" + "Points: " + violation.DMVPoints);
                            //Response.Write(@"<br />" + "Ins Points: " + violation.INSPoints);
                            //Response.Write(@"<br />" + "Violation ACD Code: " + violation.ViolationAcdCode);
                            //Response.Write(@"<br />" + "FName " + violation.FName);
                            //Response.Write(@"<br />" + "MName " + violation.MName);
                            //Response.Write(@"<br />" + "LName " + violation.LName);
                            if (violation.StateSpecific != null)
                            {
                                foreach (WebReference.StateSpecificItemType x in violation.StateSpecific)
                                {
                                    Response.Write(@"<br />" + x.Key + x.Value);
                                    Response.Write(@"<br />");
                                }
                            }
                        }
                    }

                    else
                    {
                        Response.Write(@"<br />" + "No data in Driverviolation");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}


