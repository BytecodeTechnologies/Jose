
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel.Model;

namespace Excel
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var id = Request.Cookies["LoginRole"].Value.ToString();
                hdnRole.Value = id;
            }
            catch (Exception ex)
            { }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<NJ_Users> Employees(string Search = "", int PageIndex = 0)
        {
            NJ_Users obj = new NJ_Users();
            var Result = obj.Employee(Search);

            //for paging
            int PageSize = 15;
            int skip = PageIndex * PageSize;
            double PageCount = Convert.ToDouble(Math.Ceiling((double)((double)Result.Count() / (double)PageSize)));
            List<NJ_Users> query = Result.Skip(skip).Take(PageSize).ToList();
            return query;
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static String DeleteEmployee(int Id = 0)
        {
            NJ_Users obj = new NJ_Users();
            obj.DeleteCallLog(Id);
            return "1";
        }


    }
}