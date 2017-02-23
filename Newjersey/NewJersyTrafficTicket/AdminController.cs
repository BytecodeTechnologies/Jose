using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewJersyTrafficTicket.Models;
using System.Web.Security;

namespace NewJersyTrafficTicket.Controllers
{
    public class AdminController : Controller
    {
        ResultModel objResultModel = new ResultModel();
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserLogin(LoginModel logins)
        {
            LoginModel login = new LoginModel();
            var result = login.login(logins);
            if (result.Userid != 0)
            {
                Session["UserId"] = result.Userid;
                Session["UserRollId"] = result.tblUserRoleId;
                FormsAuthentication.SetAuthCookie(result.UserName, false);
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            else {
                return Json("0", JsonRequestBehavior.AllowGet);
            
            }
          
        }
        public ActionResult AddResult()
        {
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                tblResult objtblResult = new tblResult();
                return View(objtblResult);
            }
            else
            {
              return  Redirect("/Admin/index");
            }
        }
        public ActionResult AddingResult(ResultModel data)
        {
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                if (data.tblResultId == 0)
                {
                    data.tblUserId = Convert.ToInt32(Session["UserId"]);

                    objResultModel.SaveResult(data);
                    return Json("Result Added Succesfully", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    objResultModel.updateresult(data);
                    return Json("Result Updated Succesfully", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Redirect("/Admin/index");
            }
        }
       
        public ActionResult Result()
        {
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                var item = objResultModel.GetResult();
                return View(item);
            }
            else
            {
                return Redirect("/Admin/index");
            }
        }

        public ActionResult DeleteUser(int id = 0,string sort = "",int page = 0)
        {
           
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                if (sort != "" && page != 0)
                { 
                     var item = objResultModel.GetResult();
                   return View("Result", item);
                }
                else 
                {
                    objResultModel.DeleteUser(id);
                    return Redirect("/Admin/Result");
                
        }
        }
         else
            {
                return Redirect("/Admin/index");
            }
        }
        public ActionResult EditUser(int id)
        {
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                var result = objResultModel.getrecordbyid(id);
                return View("AddResult", result);
            }
            else
            {
                return Redirect("/Admin/index");
            }
        }

        public ActionResult Categories()
        {
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                CategoryModel model = new CategoryModel();
                return View(model);
            }
            else {
                return Redirect("/Admin/index");
            }
        }

        public ActionResult AddCategory(CategoryModel Category)
        {
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                CategoryModel categories = new CategoryModel();
                if (Category.categoryId == 0)
                {
                    categories.AddCategory(Category);
                    return Json("Category added Succesfully ", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    categories.UpdateCategory(Category);
                    return Json("Category Update Succesfully ", JsonRequestBehavior.AllowGet);
                }
            }
            else 
            {
                return Redirect("/Admin/index");
            }
        }

        public ActionResult CategoryList()
        {
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                CategoryModel model = new CategoryModel();
                var Categories = model.GetCategory();
                return View(Categories);
            }
            else
            {
                return Redirect("/Admin/index");
            }
        }

        public ActionResult EditCategory(int id)
        {
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                CategoryModel model = new CategoryModel();
                var Categories = model.GetCategoryById(id);
                return View("Categories", Categories);
            }
            else
            {
                return Redirect("/Admin/index");
            }
        }

        public ActionResult DeleteCategory(int id, string sort = "", int page = 0)
        {
            if (Convert.ToInt32(Session["UserRollId"]) == 1)
            {
                CategoryModel categories = new CategoryModel();
                if (sort != "" && page != 0)
                {
                    var Categories = categories.GetCategory();
                    return View("CategoryList", Categories);
                }
                else
                {
                    categories.DeleteCategory(id);
                    return Redirect("/Admin/CategoryList");
                }
            }
            else
            { 
                return Redirect("/Admin/index"); 
            }
        }

       
          

      


	}
}