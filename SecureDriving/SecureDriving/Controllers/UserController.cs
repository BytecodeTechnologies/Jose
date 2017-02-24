using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecureDriving.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NotActiveUser()
        {
            if (Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 0)
            {
                return View();
            }
            else {
                return Redirect("/Home/Login");
            }
             
        }
      

    }
}
