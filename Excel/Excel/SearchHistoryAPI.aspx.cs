using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel.Model;

namespace Excel
{
    public partial class SearchHistoryAPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<APISearchHistory> GetHistory(int PageIndex = 0)
        {
            APISearchHistory obj = new APISearchHistory();
            var result = obj.GetHistory();

            //for paging
            int PageSize = 15;
            int skip = PageIndex * PageSize;
            double PageCount = Convert.ToDouble(Math.Ceiling((double)((double)result.Count() / (double)PageSize)));
            List<APISearchHistory> query = result.Skip(skip).Take(PageSize).ToList();
            return query;
        }
    }
}