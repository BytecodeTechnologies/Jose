using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StabileResults.Models;
using System.Web.Security;

namespace StabileResults.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserLogin(string UserName, string Password)
        {
            try
            {
                Login obj = new Login();
                var result = obj.UserLogin(UserName, Password);
                if (result.Userid != 0)
                {
                    string username = result.UserName;
                    string UserPwd = result.Password;
                    //login
                    Session["UserId"] = result.Userid;
                    Session["UserName"] = result.UserName;
                    Session["tblUserRoleId"] = result.tblUserRoleId;
                    FormsAuthentication.SetAuthCookie(username, false);
                    //FormsAuthentication.SetAuthCookie(UserPwd, false);
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("0", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [Authorize(Roles = "1")]
        public ActionResult Signup(int id = 0)
        {
            User obj = new User();

            STtblUser objresultuser = new STtblUser();
            if (id > 0)
            {
                objresultuser = obj.GetRecordByid(id);
            }

            return View(objresultuser);
        }
        [Authorize(Roles = "1")]
        public ActionResult UserReg(User objUser)
        {
            try
            {
                User obj = new User();
                if (objUser.UserId > 0)
                {
                    obj.UpdateUser(objUser);
                    return Json("User Update Successfully", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var result = obj.CheckEmail(objUser.Email);
                    if (result == null)
                    {
                        obj.AddUser(objUser);
                        return Json("User Save Successfully", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("1", JsonRequestBehavior.AllowGet);
                    }
                }

            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [Authorize(Roles = "1")]
        public ActionResult Users()
        {
            return View();
        }
        [Authorize(Roles = "1")]
        public ActionResult GetAllUser()
        {
            User objUser = new User();
            var result = objUser.GetAllUser();
            return PartialView("/Views/Home/_Users.cshtml", result);
        }
        [Authorize(Roles = "1")]
        public ActionResult DeleteUser(int id)
        {
            User objUser = new User();
            objUser.DeleteUser(id);
            var result = objUser.GetAllUser();
            return PartialView("/Views/Home/_Users.cshtml", result);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session["UserId"] = 0;
            Session["UserName"] = "";
            return View("Index");
        }

    }
}
