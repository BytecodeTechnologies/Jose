using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel.Model;

namespace Excel
{
    public partial class Users1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Search"] != null)
            {
                hdnSearch.Value = Convert.ToString(Request.QueryString["Search"]);
            }
            if (Request.QueryString["Contains"] != null)
            {
                hdnContains.Value = Convert.ToString(Request.QueryString["Contains"]);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<Nj_Detail> List(string Column = "", string SearchItem = "")
        {
            Nj_Detail obj = new Nj_Detail();
            List<Nj_Detail> nj = obj.UserList(Column, SearchItem);
            return nj;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<string> GetLastNames(string prefix = "")
        {
            Nj_Detail obj = new Nj_Detail();
            List<string> nj = obj.GetLastNames(prefix);
            return nj;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<string> GetFirstNames(string prefix = "")
        {
            Nj_Detail obj = new Nj_Detail();
            List<string> nj = obj.GetFirstNames(prefix);
            return nj;
        }
    }
}

