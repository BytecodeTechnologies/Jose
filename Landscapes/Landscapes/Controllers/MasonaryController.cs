using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Landscapes.Controllers
{
    public class MasonaryController : Controller
    {
        //
        // GET: /Masonary/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Driveways()
        {
            return View();
        }
        public ActionResult Kitchens()
        {
            return View();
        }
        [ActionName("Fire-Pits")]
        public ActionResult Fire_Pits()
        {
            return View();
        }
        public ActionResult Walks()
        {
            return View();
        }
        public ActionResult Patios()
        {
            return View();
        }
        public ActionResult Veneer()
        {
            return View();
        }
        public ActionResult Foundations()
        {
            return View();
        }
        [ActionName("Fire-Place")]
        public ActionResult Fire_Place()
        {
            return View();
        }

    }
}
