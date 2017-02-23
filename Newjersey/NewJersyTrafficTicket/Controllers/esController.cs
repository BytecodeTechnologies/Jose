using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewJersyTrafficTicket.Controllers
{
    public class esController : Controller
    {
        //
        // GET: /es/

        public ActionResult Índice()  //Índice
        {
            return View("Index");
        }


           [ActionName("Sobre-nosotros")]
      //  [ActionName("About-Us")]   //Sobre nosotros
        public ActionResult About_Us()
        {
            return View("About_Us");
        }


         [ActionName("Porque-nosotros")]
       // [ActionName("Why-Us")]  //Porque nosotros
        public ActionResult Why_Us()
        {
            return View("Why_Us");
        }



         [ActionName("Nuestros-servicios")] 
       // [ActionName("Our-Services")]  //Nuestros servicios
        public ActionResult Our_Services()
        {
            return View("Our_Services");
        }



        //public ActionResult Resources()  //recursos
        //{
        //    return View();
        //}
        public ActionResult recursoss()  //recursos
        {
            return View("Resources");
        }


         [ActionName("Cuota-gratis")]
       // [ActionName("Free-Quote")]  //Cuota gratis
        public ActionResult Free_Quote()
        {
            return View("Free_Quote");
        }

         [ActionName("multas-de-tráfico")] 

        //[ActionName("Traffic-Tickets")]  //multas de tráfico
        public ActionResult Traffic_Tickets()
        {
            return View("Traffic_Tickets");
        }



         [ActionName("e-infracciones")]  //e infracciones
        //[ActionName("Speeding-Tickets")]  //e infracciones
        public ActionResult Speeding_Tickets()
        {
            return View("Speeding_Tickets");
        }


          [ActionName("Sin-seguro-de-coche")]
        //[ActionName("No-Car-Insurance")]  //Sin seguro de coche
        public ActionResult No_Car_Insurance()
        {
            return View("No_Car_Insurance");
        }



        [ActionName("Conducción-temeraria")]
        //[ActionName("Reckless-Driving")]   //Conducción temeraria
        public ActionResult Reckless_Driving()
        {
            return View("Reckless_Driving");
        }



         [ActionName("conducción-descuidada")]
        //[ActionName("Careless-Driving")]  //conducción descuidada
        public ActionResult Careless_Driving()
        {
            return View("Careless_Driving");
        }



         [ActionName("Dui-DWI-Abogados-de-Defensa")]
        //[ActionName("Dui-Dwi-Defense-Lawyers")]  //Dui DWI Abogados de Defensa
        public ActionResult Dui_Dwi_Defense_Lawyers()
        {
            return View("Dui_Dwi_Defense_Lawyers");
        }



         [ActionName("Con-suspensión-de-licencia")]
       // [ActionName("Suspended-License")]   //Suspended License
        public ActionResult Suspended_License()
        {
            return View("Suspended_License");
        }



        [ActionName("Puntos-y-sobrecargos")]
       // [ActionName("Points-and-Surcharges")]   //Puntos y sobrecargos
        public ActionResult Points_and_Surcharges()
        {
            return View("Points_and_Surcharges");
        }



        [ActionName("Batir-su-tráfico-de-entradas")]
        //[ActionName("Beat-Your-Traffic-Ticket")]  //Batir su tráfico de entradas
        public ActionResult Beat_Your_Traffic_Ticket()
        {
            return View("Beat_Your_Traffic_Ticket");
        }



        [ActionName("Lo-a-hacer-con-suspensión-de-licencia")]
        //[ActionName("What-to-do-suspended-license")]  //Lo-a-hacer-con suspensión de licencia
        public ActionResult What_to_do_suspended_license()
        {
            return View("What_to_do_suspended_license");
        }



        [ActionName("Restore-Licencia")]
       // [ActionName("Restore-License")]   //Restore-Licencia
        public ActionResult Restore_License()
        {
            return View("Restore_License");
        }



        //public ActionResult Penalties()  //sanciones
        //{
        //    return View();
        //}
         [ActionName("sanciones")]
        public ActionResult Penalties()  
        {
            return View("Penalties");
        }



        [ActionName("¿Qué-hacer-cuando-se-detuvo-por-la-policíae")]
        //[ActionName("What-to-do-when-stoped-by-police")]  //¿Qué hacer cuando se detuvo por la policía
        public ActionResult What_to_do_when_stoped_by_police()
        {
            return View("What_to_do_when_stoped_by_police");
        }



        [ActionName("¿Por-qué-alquiler-a-new-jersey-de-tráfico-son-abogados")]
       // [ActionName("Why-hire-a-new-jersey-traffic-lawyers")]  //¿Por qué-alquiler-a-new-jersey de tráfico son abogados
        public ActionResult Why_hire_a_new_jersey_traffic_lawyers()
        {
            return View("Why_hire_a_new_jersey_traffic_lawyers");
        }



        [ActionName("Dui-Penalidades")] 
        //[ActionName("Dui-Penalties")]   //Dui-Penalidades
        public ActionResult Dui_Penalties()
        {
            return View("Dui_Penalties");
        }




         [ActionName("chupar-rueda")]
        public ActionResult Tailgating()  //chupar rueda
        {
            return View("Tailgating");
        }



        [ActionName("Si-no-se-detiene-para-semáforo")] 
        //[ActionName("Failure-to-stop-for-traffic-light")]  //Si no se detiene para semáforo
        public ActionResult Failure_to_stop_for_traffic_light()
        {
            return View("Failure_to_stop_for_traffic_light");
        }



        [ActionName("autobús-escolar-que-pasa-inadecuada")]
        //[ActionName("Improper-passing-school-bus")]   //autobús escolar que pasa inadecuada
        public ActionResult Improper_passing_school_bus()
        {
            return View("Improper_passing_school_bus");
        }


         [ActionName("Preguntas-frecuentess")]
        //[ActionName("Frequently-asked-questions")]   //Preguntas frecuentes
        public ActionResult Frequently_asked_questions()
        {
            return View("Frequently_asked_questions");
        }



	}
}