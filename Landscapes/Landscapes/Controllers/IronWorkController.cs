using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Landscapes.Models;

namespace Landscapes.Controllers
{
    public class IronWorkController : Controller
    {
        //
        // GET: /IronWork/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Furniture()
        {
            return View();
        }
        [ActionName("Indoor-Railing")]
        public ActionResult INDOOR_RAILING()
        {
            return View("Indoor-Railing");
        }
        [ActionName("OutDoor-Railing")]
        public ActionResult OutDoor_Railing()
        {
            return View("OutDoor-Railing");
        }
        public ActionResult Driveway()
        {
            return View();
        }
        public ActionResult Gates()
        {
            return View();
        }

        public ActionResult Fences()
        {
            return View();
        }
        public ActionResult structure()
        {
            return View();
        }
        //public ActionResult GetCategories(int PageIndex = 0)
        //{
        //    IronWork objIronWork = new IronWork();
        //    var result = objIronWork.Get_Subcategories();
        //    int PageSize = 5;
        //    int skip = PageIndex * PageSize;
        //    double PageCount = Convert.ToDouble(Math.Ceiling((double)((double)result.Count() / (double)PageSize)));
        //    ViewBag.PageCount = PageCount;
        //    ViewBag.CurrentPageIndex = PageIndex;
        //    List<Ls_SubCategory> query = result.Skip(skip).Take(PageSize).ToList();
        //    ViewBag.totalRecord = query.Count();
        //    return PartialView("_Index", result);
        //}

    }
}
