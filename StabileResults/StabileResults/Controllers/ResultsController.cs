using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StabileResults.Models;

namespace StabileResults.Controllers
{
    public class ResultsController : Controller
    {
        //
        // GET: /Results/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult GetAllResult()
        {
            Result objResult = new Result();
            var result = objResult.GetAllResult();
            return PartialView("~/Views/Results/_Index.cshtml", result);
        }
        [Authorize]
        public ActionResult AddResult(int id = 0)
        {

            Result obj = new Result();
            STtblResult objresult = new STtblResult();
            if (id > 0)
            {
                objresult = obj.Getresultbyid(id);

            }
            return View(objresult);
        }
        [Authorize]
        public ActionResult AddRes(Result objres)
        {
            try
            {
                Result obj = new Result();
                if (objres.tblResultId > 0)
                {
                    obj.updateresult(objres);
                    return Json("Result Updated Successfully", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    obj.SaveResult(objres, Convert.ToInt32(Session["UserId"]));
                    return Json("Result Added Successfully", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

        }
        [Authorize]
        public ActionResult Deleteresult(int id)
        {
            Result objres = new Result();
            objres.DeleteResult(id);
            var result = objres.GetAllResult();
            return PartialView("~/Views/Results/_Index.cshtml", result);

        }


    }
}
