using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stabile_DUI.Controllers
{
    public class ResourcesController : Controller
    {
        //
        // GET: /Resources/

        public ActionResult Index()
        {
            return View();
        }
        [ActionName("DUI-in-School-Zone-or-School-Crossing")]
        public ActionResult DUI_in_School_Zone_or_School_Crossing()
        {
            return View("DUI-in-School-Zone-or-School-Crossing");
        }
        [ActionName("Refusing-the-Chemical-Test")]
        public ActionResult Refusing_the_Chemical_Test()
        {
            return View("Refusing-the-Chemical-Test");
        }
        [ActionName("Refusing-Chemical-Test-in-School-Zone-or-Crossing")]
        public ActionResult Refusing_Chemical_Test_in_School_Zone_or_Crossing()
        {
            return View("Refusing-Chemical-Test-in-School-Zone-or-Crossing");
        }
        [ActionName("Boaters-convicted-of-driving-under-the-influence")]
        public ActionResult Boaters_convicted_of_driving_under_the_influence()
        {
            return View("Boaters-convicted-of-driving-under-the-influence");
        }
        [ActionName("Driving-Under-the-Influence-of-Alcohol")]
        public ActionResult Driving_Under_the_Influence_of_Alcohol()
        {
            return View("Driving-Under-the-Influence-of-Alcohol");
        }

        [ActionName("The-legal-age-in-NJ-to-purchase-an-alcoholic-beverage")]
        public ActionResult The_legal_age_in_NJ_to_purchase_an_alcoholic_beverage()
        {
            return View("The-legal-age-in-NJ-to-purchase-an-alcoholic-beverage");
        }
        [ActionName("Interlock-Device-Requirements")]
        public ActionResult Interlock_Device_Requirements()
        {
            return View("Interlock-Device-Requirements");
        }
        [ActionName("Surcharges-Alcohol-Violations")]
        public ActionResult Surcharges_Alcohol_Violations()
        {
            return View("Surcharges-Alcohol-Violations");
        }
    }
}
