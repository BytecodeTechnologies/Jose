using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewJersyTrafficTicket.Models
{
    public class FreeQuote
    {
        
        public string fullname { get; set; }
        public string CellNo { get; set; }
        public string Email { get; set; }
        public string offences1 { get; set; }
        public string offences2 { get; set; }
        public string offences3 { get; set; }
        public string violation { get; set; }
        public string pointno { get; set; }
        public string ddldwi { get; set; }
        public string ticketnumber { get; set; }
        public string dateissue { get; set; }
        public string location { get; set; }
        public string state { get; set; }
        public string five { get; set; }
        public string Accident { get; set; }
        public string HadOtherOffence { get; set; }
        public string Message { get; set; }
    }
}