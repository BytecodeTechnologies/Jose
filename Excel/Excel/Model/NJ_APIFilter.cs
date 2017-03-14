using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Excel.Model
{
    public class NJ_APIFilter
    {
        public string ViolationDate { get; set; }
        public string ViolationDescription { get; set; }
        public string Disposition { get; set; }
        public string AdjudicatedDate { get; set; }
        public string AdjudicatedDescription { get; set; }
        public string StateCode { get; set; }
        public string countryCode { get; set; }
        public string DMVPoints { get; set; }
        public string INSPoints { get; set; }
        public string CourtDate { get; set; }
        public string CaseType { get; set; }
        public string ChargeCount { get; set; }
        public string Docket { get; set; }
        public string Summons { get; set; }
        public string ViolationAcdCode { get; set; }
        public string AdjudicatedAcdCode { get; set; }
        public string AdjudicatedStatute { get; set; }
        public string ViolationStatute { get; set; }
        public string AdjudicatedCustomerCode { get; set; }
        public string ViolationCustomerCode { get; set; }
        public string ViolationStateCode { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string zip { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}