using Excel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Excel
{
    public partial class PotentialClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<Nj_Detail> ClientList(string Search = "", int PageIndex = 0, string sDate = "", string eDate = "")
        {
            Nj_Detail obj = new Nj_Detail();
            var nj = obj.PotentialClientList(Search, sDate, eDate);
            // for paging
            int PageSize = 15;
            int skip = PageIndex * PageSize;
            double PageCount = Convert.ToDouble(Math.Ceiling((double)((double)nj.Count() / (double)PageSize)));
            List<Nj_Detail> query = nj.Skip(skip).Take(PageSize).ToList();
            return query;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<Nj_Detail> PrintPotentialClients(string Search = "", string sDate = "", string eDate = "")
        {
            Nj_Detail obj = new Nj_Detail();
            var nj = obj.PotentialClientList(Search, sDate, eDate);            
            return nj;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<Nj_Detail> Payment(string Search = "")
        {
            Nj_Detail obj = new Nj_Detail();
            var nj = obj.PotentialClientList(Search);
            return nj;
        }




        [System.Web.Services.WebMethod(EnableSession = true)]
        public static NJ_Clients ClientDetail(int id = 0)
        {
            Nj_Detail obj = new Nj_Detail();
            var result = obj.ClientDetail(id);
            return result;
        }



    }
}