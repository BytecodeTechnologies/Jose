using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace NewJersyTrafficTicket.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveImage()
        {
            try
            {
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
                        var _comPath = Server.MapPath("~/Content/Test_Image/") + _imgname + _ext;
                        var imgPath = "~/Content/Test_Image/" + _imgname + _ext;
                        imgPath2 = "/Content/Test_Image/" + _imgname + _ext;

                        var path = _comPath;
                        pic.SaveAs(path);
                        return Json("Image save Successfully", JsonRequestBehavior.AllowGet);
                    }
                }
                return Json("Please Select Image", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
           
        }
	}
}