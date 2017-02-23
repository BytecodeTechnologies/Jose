using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hubtechnology.Controllers
{
    public class esController : Controller
    {
        //
        // GET: /es/

        public ActionResult Inicio()    // index
        {
            return View();
        }
        public ActionResult Acerca()  // about us
        {
            return View();
        }
        public ActionResult Servicios()
        {
            return View();
        }

        public ActionResult Portafolio()
        {
            return View();
        }
        public ActionResult Contacto()
        {
            return View();
        }

    }
}
