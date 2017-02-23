using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Landscapes.Models;

namespace Landscapes.Controllers
{
    public class SubcategoryController : Controller
    {
        IronWork objIronWork = new IronWork();
        //
        // GET: /Subcategory/

        public ActionResult Index(int id)
        {
            var result = objIronWork.GetCategorybyId(id);
            ViewBag.Categoryname = result.CategoryName;
            ViewBag.LogoImage = result.LogoPath;
            Session["logoImage"] = result.LogoPath;
            return View();
        }
        public ActionResult GetCategories(int PageIndex = 0, int id = 0)
        {
            var result = objIronWork.Get_Subcategories(id);
            int PageSize = 5;
            int skip = PageIndex * PageSize;
            double PageCount = Convert.ToDouble(Math.Ceiling((double)((double)result.Count() / (double)PageSize)));
            ViewBag.PageCount = PageCount;
            ViewBag.CurrentPageIndex = PageIndex;
            List<Ls_SubCategory> query = result.Skip(skip).Take(PageSize).ToList();
            ViewBag.totalRecord = query.Count();
            return PartialView("_Index", query);
        }

        public ActionResult ChildCategory(int SubCategoryId, int CategoryId)
        {
            var results = objIronWork.GetCategorybyId(CategoryId);
            ViewBag.LogoImage = results.LogoPath;
            SubCategory obj = new SubCategory();
            var data = obj.Getsubcategory(SubCategoryId);
            ViewBag.SubcategoryName = data.SubCategory_Name;
            ChildCategory objchild = new ChildCategory();
            var result = objchild.ChildImages(SubCategoryId);
            return View(result);
        }


    }
}
