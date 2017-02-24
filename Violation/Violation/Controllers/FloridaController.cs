using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Violation.Controllers
{
    public class FloridaController : Controller
    {
        //
        // GET: /Florida/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Moving_Violation()
        {
            return View();
        }
        public ActionResult Criminal_Violation()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Florida_PointSystem()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult FreeQuote()
        {
            return View();
        }
        public ActionResult Counties(string id)
        {
            ViewBag.countiesId = id;

            return View();

        }

    }
}
