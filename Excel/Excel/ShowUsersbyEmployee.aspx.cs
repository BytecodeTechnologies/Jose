using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel.Model;

namespace Excel
{
    public partial class ShowUsersbyEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NJ_Users objUser = new NJ_Users();
            var userid = Request.QueryString["id"];
            Userid.Value = userid;
            var result = objUser.GetUserbyId(Convert.ToInt32(userid));
            lblAddedby.Text = result.First_Name + " " + result.Last_Name;
            HdnUserRole.Value = Convert.ToString(Request.Cookies["LoginRole"].Value);
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<Nj_Detail> UserDetailsbyEmployeeAdded(string Search = "", string id = "", int PageIndex = 0, string sDate = "", string eDate = "")
        {
            Nj_Detail obj = new Nj_Detail();
            var nj = obj.ClientList(Search,id,sDate,eDate);

            int PageSize = 15;
            int skip = PageIndex * PageSize;
            double PageCount = Convert.ToDouble(Math.Ceiling((double)((double)nj.Count() / (double)PageSize)));
            List<Nj_Detail> query = nj.Skip(skip).Take(PageSize).ToList();
            return query;
        }
         [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<Nj_Detail> ShowPayment(string Search = "", string id = "", string sDate = "", string eDate = "")
        {
            Nj_Detail obj = new Nj_Detail();
            var nj = obj.ClientList(Search, id,sDate,eDate);
            return nj;
        }


    }
}