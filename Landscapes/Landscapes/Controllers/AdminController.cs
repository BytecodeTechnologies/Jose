using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Landscapes.Models;
using System.IO;
using Landscapes.Models;
using System.Text.RegularExpressions;

namespace Landscapes.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserLogin(User objUser)
        {
            User Userobj = new User();
            var result = Userobj.LoginUser(objUser);
            if (result != null)
            {
                Session["UserId"] = result.Id;
                Session["UserRollId"] = result.Role;
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("0", JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult SubCategories(int id = 0)
        {
            SubCategory objsub = new SubCategory();
            if (id == 0)
            {
                Ls_SubCategory obj = new Ls_SubCategory();
                return View(obj);
            }
            else
            {
                var result = objsub.Getsubcategory(id);
                return View(result);
            }
        }

        public ActionResult AddSubCategories(SubCategory obj)
        {
            SubCategory subobj = new SubCategory();
            string _imgname = string.Empty;
            var imgPath2 = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["file"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);
                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = String.Empty;
                    switch (obj.Category)
                    {
                        case 1:
                            _comPath = Server.MapPath("~/Images/IronWork/") + _imgname + _ext;
                            imgPath2 = "/Images/IronWork/" + _imgname + _ext;
                            break;
                        case 2:
                            _comPath = Server.MapPath("~/Images/Landscape/") + _imgname + _ext;
                            imgPath2 = "/Images/Landscape/" + _imgname + _ext;
                            break;
                        case 3:
                            _comPath = Server.MapPath("~/Images/Masonary/") + _imgname + _ext;
                            imgPath2 = "/Images/Masonary/" + _imgname + _ext;
                            break;
                        case 4:
                            _comPath = Server.MapPath("~/Images/Construction/") + _imgname + _ext;
                            imgPath2 = "/Images/Construction/" + _imgname + _ext;
                            break;
                        case 5:
                            _comPath = Server.MapPath("~/Images/Kitchens/") + _imgname + _ext;
                            imgPath2 = "/Images/Kitchens/" + _imgname + _ext;
                            break;
                        case 6:
                            _comPath = Server.MapPath("~/Images/DriveWays/") + _imgname + _ext;
                            imgPath2 = "/Images/DriveWays/" + _imgname + _ext;
                            break;
                        default:
                            Console.WriteLine("Invalid grade");
                            break;
                    }
                    var path = _comPath;
                    pic.SaveAs(path);

                    if (obj.SubCategoryId == 0)
                    {
                        subobj.AddSubcategory(obj, imgPath2);
                        return Json("SubCategory Added Succesfully", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        subobj.UpdateSubCategory(obj, imgPath2);
                        return Json("Subcategory Updated Succesfully", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            subobj.UpdateSubCategory(obj, imgPath2);
            return Json("SubCategory Updated Succesfully", JsonRequestBehavior.AllowGet);
        }
        public ActionResult ManageSubCategory()
        {
            return View();
        }
        public ActionResult GetAll_SubCategories()
        {
            SubCategory objsub = new SubCategory();
            var result = objsub.GetAllsub_Category();
            return PartialView("_ManageSubCategory", result);
        }
        public ActionResult DeleteSubCategory(int id)
        {
            SubCategory objsub = new SubCategory();
            objsub.Delete_Subcategory(id);
            var result = objsub.GetAllsub_Category();
            return PartialView("_ManageSubCategory", result);
        }
        public ActionResult ManagesubCategories()
        {
            return View();
        }
        public ActionResult ManageChildCategories()
        {
            return View();
        }

        public ActionResult GetAllChildcategories()
        {
            ChildCategory objchild = new ChildCategory();
            var result = objchild.GetAllChild();
            return PartialView("_ManageChildCategories", result);
        }
        public ActionResult DeleteChildCategory(int id)
        {
            ChildCategory objchild = new ChildCategory();
            objchild.DeleteSubCategory(id);
            var result = objchild.GetAllChild();
            return PartialView("_ManageChildCategories", result);
        }
        public ActionResult ChildCategory()
        {
            return View();
        }
        public ActionResult GetSubCategorybyId(int id)
        {
            SubCategory objsub = new SubCategory();
            var result = objsub.GetSubCategory_ByCAtegory(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddChildImage(SubCategory obj)
        {
            ChildCategory objChild = new ChildCategory();
            string _imgname = string.Empty;
            var imgPath2 = string.Empty;
            string SubFolder = obj.Subcategory;
            SubFolder = Regex.Replace(SubFolder, @"\s", "");
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["file"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);
                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = String.Empty;
                    switch (obj.Category)
                    {
                        case 1:
                            //_comPath = Server.MapPath("~/Images/IronWork/") + _imgname + _ext;
                            _comPath = Server.MapPath("~/Images/IronWork/");
                            imgPath2 = "/Images/IronWork/";
                            break;
                        case 2:
                            _comPath = Server.MapPath("~/Images/Landscape/");
                            imgPath2 = "/Images/Landscape/";
                            break;
                        case 3:
                            _comPath = Server.MapPath("~/Images/Masonary/");
                            imgPath2 = "/Images/Masonary/";
                            break;
                        case 4:
                            _comPath = Server.MapPath("~/Images/Construction/");
                            imgPath2 = "/Images/Construction/";
                            break;
                        case 5:
                            _comPath = Server.MapPath("~/Images/Kitchens/");
                            imgPath2 = "/Images/Kitchens/";
                            break;
                        case 6:
                            _comPath = Server.MapPath("~/Images/DriveWays/");
                            imgPath2 = "/Images/DriveWays/";
                            break;
                        default:
                            Console.WriteLine("Invalid grade");
                            break;
                    }

                    var DirectoryImage = _comPath + SubFolder;

                    if (!Directory.Exists(DirectoryImage))
                    {
                        Directory.CreateDirectory(DirectoryImage);
                    }
                    _comPath = _comPath + SubFolder + "/" + _imgname + _ext;
                    imgPath2 = imgPath2 + SubFolder + "/" + _imgname + _ext;
                    var path = _comPath;
                    pic.SaveAs(path);
                    objChild.AddChildImage(obj, imgPath2);
                }
            }
            return Json("Child Category Add Successfully", JsonRequestBehavior.AllowGet);
        }
    }
}
