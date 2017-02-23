using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Landscapes.Controllers
{
    public class LandscapeController : Controller
    {
        //
        // GET: /LandScape/

        public ActionResult Index()
        {
            return View();
        }
        [ActionName("Rock-Gardens")]
        public ActionResult Rock_Gardens()
        {
            return View();
        }
        public ActionResult Gradings()
        {
            return View();
        }
        public ActionResult Design()
        {
            return View();
        }

        public ActionResult RockGardens()
        {
            return View();
        }

        [ActionName("Water-Gardens")]
        public ActionResult Water_Gardens()
        {
            return View();
        }
        public ActionResult Maintenance()
        {
            return View();
        }
        public ActionResult Planting()
        {
            return View();
        }
        public ActionResult Drainage()
        {
            return View();
        }

       
    }
}
