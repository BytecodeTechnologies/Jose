using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Excel
{
    public partial class ActiveUserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NJTicketEntities db = new NJTicketEntities();
            bool isusers = Convert.ToBoolean(1);
            var result = db.NJ_Details.Where(a => a.IsUser == isusers).ToList();
            repeater2.DataSource = result;
            repeater2.DataBind();
        }
    }
}