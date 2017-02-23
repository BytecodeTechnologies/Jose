using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewJersyTrafficTicket.Models;
using System.Net.Mail;
using System.Net;
using NewJersyTrafficTicket.Capcha;
using System.Text.RegularExpressions;





namespace NewJersyTrafficTicket.Controllers
{
    public class NewJerseyController : Controller
    {
        // GET: NewJersey
        public ActionResult Index()
        {
            ResultModel objResultModel = new ResultModel();
            var item = objResultModel.GetResult();
            List<ResultModel> query = item.Take(4).ToList();

            return View(query);
        }

        public ActionResult generateCaptcha()
        {
            System.Drawing.FontFamily family = new System.Drawing.FontFamily("Arial");
            CaptchaImage img = new CaptchaImage(250, 100, family);
            string text = img.CreateRandomText(4) + " " + img.CreateRandomText(3);
            img.SetText(text);
            img.GenerateImage();
            img.Image.Save(Server.MapPath("~/CapchaImage/") +
            this.Session.SessionID.ToString() + ".png",
            System.Drawing.Imaging.ImageFormat.Png);
            Session["captchaText"] = text;
            return Json("../CapchaImage/" + this.Session.SessionID.ToString() + ".png?t=" +
            DateTime.Now.Ticks, JsonRequestBehavior.AllowGet);
        }



        public ActionResult ShowResult(int id)
        {
            ResultModel objResultModel = new ResultModel();
            var item = objResultModel.getrecordbyid(id);
            return View(item);
        }

        public ActionResult SendQuoteForm(FreeQuote quote, string Capcha)
        {
            var captchatext = Convert.ToString(Session["captchaText"]);

            var captchatexts = Regex.Replace(captchatext, @"\s+", "");

            if (quote.Email != null && Capcha != null && quote.fullname != null)
            {
                if (captchatext == Capcha)
                {
                    SendEmailToUser(quote);


                    //  SendEmail(quote);
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Captcha text is not validated, please try again.", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(" * fields are required", JsonRequestBehavior.AllowGet);
            }
        }

        public string SendEmailToUser(FreeQuote quote)
        {
            string result = "";
            var qFullName = quote.fullname.Trim();
            var qEmail = quote.Email.Trim();
            if (qFullName != "" && qEmail != "")
            {
                string to = "request@stabilelawfirm.com";
                string from = qEmail;
                string body = @"<html><title></title>
              <head>
                <style>
body {
            background: none;
        }

        table td {
            height: 30%;
            width: 50%;
            border-color: #13A0B2;
        }

        table th {
            height: 70%;
            width: 50%;
            background-color: #13A0B2;
            color: white;
            font-size: 100%;
        }

    </style>
</head>
<body>
<div><table border=""1"" style='width:100%;'>
<thead>
<tr style='background:#13A0B2;'>
                        <th colspan=""2"" style='height: 70%;
            width: 50%;
            background-color: #13A0B2;
            color: white;
            font-size: 100%;'>CLIENT INFORMATION</th>

                    </tr>
           </thead>
             <tbody>
                      
                    <tr>
                        <td style='height: 100%; ;width: 50%; color:black; border-color: #13A0B2;'>Full Name:</td>
                        <td style='height: 100%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.fullname + @"</td>
                    </tr>


                    <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Phone:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.CellNo + @"</td>

                    </tr>

                      <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Email:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.Email + @"</td>

                    </tr>
   </tbody>
</table >
<table border=""1"" style='width:100%;'>
 <tbody>
             
 <thead>
                    <tr style='background:#13A0B2;'>
                        <th colspan='2' style='height: 70%;  width: 100%; background-color: #13A0B2; color: white;font-size: 100%;' >OFFENCE/TICKET INFORMATION</th>

                    </tr>
                </thead>
                         <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Type of Summons/Offence 1:</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.offences1 + @"</td>

                    </tr>
 <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Type of Summons/Offence 2: </td>
                       <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.offences2 + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Type of Summons/Offence 3: </td>
                         <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.offences3 + @"</td>

                    </tr>
   </tbody>
</table >
<table border=""1"" style='width:100%;'>
 <tbody>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Or type your violation:</td>
                       <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.violation + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Current Number of Points on License:</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.pointno + @"</td>

                    </tr>

 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>DWI or DUI:</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.ddldwi + @"</td>

                    </tr>
  </tbody>
</table>
<table border=""1"" style='width:100%;'>
 <tbody>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Ticket Number:</td>
                         <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.ticketnumber + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Date Ticket Was Issued:</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.dateissue + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Court Location:</td>
                         <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.location + @"</td>

                    </tr>
  </tbody>
</table>
<table border=""1"" style='width:100%;'>
 <tbody>
<tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>State of Your License </td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.state + @"</td>

                    </tr>
<tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Have you used any plea bargains in the last 5 years?</td>
                         <td style=' height: 30%;width: 50%; border-color: #13A0B2;'>&nbsp;" + quote.five + @"</td>

                    </tr>
<tr>
                        <td style=' height: 30%;width: 50%;color:black;width: 50%; border-color: #13A0B2;'>Was the ticket a result of an accident? </td>
                        <td style=' height: 30%;width: 50%; color:black;width: 50%; border-color: #13A0B2;'>&nbsp;" + quote.Accident + @"</td>

                    </tr>
   </tbody>
</table>
<table border=""1"" style='width:100%;'>
 <tbody>
<tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>If DUI and DWI: Have you had any other offences? </td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.HadOtherOffence + @"</td>

                    </tr>
<tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Comments: </td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.Message + @"</td>

                    </tr>
  </tbody>
            </table>

        </div>
</body>
<html>
";
                MailMessage mail = new MailMessage(from, to);
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "mail.newjerseydefensivedriving.net";
                mail.Subject = "newjerseytraffictickets.com has sent you another lead! - From free quote form";
                mail.IsBodyHtml = true;
                mail.Body = body;

                try
                {
                    client.Send(mail);
                    result = "Email Sent";
                }
                catch (Exception ex)
                {
                    result = ex.Message + "....... Inner exception is: " + ex.InnerException;
                }
                return result;

            }
            else
            {
                return "All * fields are required.";
            }
        }





        public ActionResult SendEmail(FreeQuote quote)
        {

            if (quote.fullname.Trim() != "" && quote.Email.Trim() != "")
            {

                string result = "";

                var message = new MailMessage();
                message.To.Add(new MailAddress("vipan.rinku@gmail.com"));
                message.From = new MailAddress("Vipan.rinku@gmail.com");
                message.CC.Add("jo_sujan21@hotmail.co.uk");
                // message.CC.Add("gurvinder0206@gmail.com");
                //  message.CC.Add("satvinder.singh26@gmail.com");
                //  message.CC.Add("goyalsunny1990@gmail.com");

                message.Subject = "newjerseytraffictickets.com has sent you another lead! - From free quote form";

                string body = @"
<html>
<title>
</title>
<head>

    <style>

        body {
            background: none;
        }

        table td {
            height: 30%;
            width: 50%;
            border-color: #13A0B2;
        }

        table th {
            height: 70%;
            width: 50%;
            background-color: #13A0B2;
            color: white;
            font-size: 100%;
        }

    </style>
</head>
<body>

   <div><table border=""1"" style='width:100%;'>
     
                <thead>
                    <tr style='background:#13A0B2;'>
                        <th colspan=""2"" style='height: 70%;
            width: 50%;
            background-color: #13A0B2;
            color: white;
            font-size: 100%;'>CLIENT INFORMATION</th>

                    </tr>
           </thead>
             <tbody>
                      
                    <tr>
                        <td style='height: 100%; ;width: 50%; color:black; border-color: #13A0B2;'>Full Name:</td>
                        <td style='height: 100%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.fullname + @"</td>
                    </tr>


                    <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Phone:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.CellNo + @"</td>

                    </tr>

                      <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Email:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.Email + @"</td>

                    </tr>
   </tbody>
</table >
<table border=""1"" style='width:100%;'>
 <tbody>
             
 <thead>
                    <tr style='background:#13A0B2;'>
                        <th colspan='2' style='height: 70%;  width: 100%; background-color: #13A0B2; color: white;font-size: 100%;' >OFFENCE/TICKET INFORMATION</th>

                    </tr>
                </thead>
                         <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Type of Summons/Offence 1:</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.offences1 + @"</td>

                    </tr>
 <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Type of Summons/Offence 2: </td>
                       <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.offences2 + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Type of Summons/Offence 3: </td>
                         <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.offences3 + @"</td>

                    </tr>
   </tbody>
</table >
<table border=""1"" style='width:100%;'>
 <tbody>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Or type your violation:</td>
                       <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.violation + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Current Number of Points on License:</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.pointno + @"</td>

                    </tr>

 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>DWI or DUI:</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.ddldwi + @"</td>

                    </tr>
  </tbody>
</table>
<table border=""1"" style='width:100%;'>
 <tbody>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Ticket Number:</td>
                         <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.ticketnumber + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Date Ticket Was Issued:</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.dateissue + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Court Location:</td>
                         <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.location + @"</td>

                    </tr>
  </tbody>
</table>
<table border=""1"" style='width:100%;'>
 <tbody>
<tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>State of Your License </td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.state + @"</td>

                    </tr>
<tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Have you used any plea bargains in the last 5 years?</td>
                         <td style=' height: 30%;width: 50%; border-color: #13A0B2;'>&nbsp;" + quote.five + @"</td>

                    </tr>
<tr>
                        <td style=' height: 30%;width: 50%;color:black;width: 50%; border-color: #13A0B2;'>Was the ticket a result of an accident? </td>
                        <td style=' height: 30%;width: 50%; color:black;width: 50%; border-color: #13A0B2;'>&nbsp;" + quote.Accident + @"</td>

                    </tr>
   </tbody>
</table>
<table border=""1"" style='width:100%;'>
 <tbody>
<tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>If DUI and DWI: Have you had any other offences? </td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.HadOtherOffence + @"</td>

                    </tr>
<tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Comments: </td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + quote.Message + @"</td>

                    </tr>
  </tbody>
            </table>

        </div>
</body>
<html>
";

                message.IsBodyHtml = true;
                message.Body = body;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "",
                        Password = ""
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;


                    try
                    {

                        smtp.Send(message);
                        result = "Email Sent";
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message + "....... Inner exception is: " + ex.InnerException;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("All Star Fileds are Requried", JsonRequestBehavior.AllowGet);
            }
        }
        [ActionName("About-Us")]
        public ActionResult About_Us()
        {
            return View("About_Us");
        }


        [ActionName("Why-Us")]
        public ActionResult Why_Us()
        {
            return View("Why_Us");
        }


        [ActionName("Our-Services")]
        public ActionResult Our_Services()
        {
            return View("Our_Services");
        }

        public ActionResult Resources()
        {
            return View();
        }

        [ActionName("Free-Quote")]
        public ActionResult Free_Quote()
        {
            return View("Free_Quote");
        }
        [ActionName("Traffic-Tickets")]
        public ActionResult Traffic_Tickets()
        {
            return View("Traffic_Tickets");
        }

        [ActionName("Speeding-Tickets")]
        public ActionResult Speeding_Tickets()
        {
            return View("Speeding_Tickets");
        }
        [ActionName("No-Car-Insurance")]
        public ActionResult No_Car_Insurance()
        {
            return View("No_Car_Insurance");
        }

        [ActionName("Reckless-Driving")]
        public ActionResult Reckless_Driving()
        {
            return View("Reckless_Driving");
        }

        [ActionName("Careless-Driving")]
        public ActionResult Careless_Driving()
        {
            return View("Careless_Driving");
        }

        [ActionName("Dui-Dwi-Defense-Lawyers")]
        public ActionResult Dui_Dwi_Defense_Lawyers()
        {
            return View("Dui_Dwi_Defense_Lawyers");
        }
        [ActionName("Suspended-License")]
        public ActionResult Suspended_License()
        {
            return View("Suspended_License");
        }
        [ActionName("Points-and-Surcharges")]
        public ActionResult Points_and_Surcharges()
        {
            return View("Points_and_Surcharges");
        }

        [ActionName("Beat-Your-Traffic-Ticket")]
        public ActionResult Beat_Your_Traffic_Ticket()
        {
            return View("Beat_Your_Traffic_Ticket");
        }
        [ActionName("What-to-do-suspended-license")]
        public ActionResult What_to_do_suspended_license()
        {
            return View("What_to_do_suspended_license");
        }
        [ActionName("Restore-License")]
        public ActionResult Restore_License()
        {
            return View("Restore_License");
        }
        public ActionResult Penalties()
        {
            return View();
        }
        [ActionName("What-to-do-when-stoped-by-police")]
        public ActionResult What_to_do_when_stoped_by_police()
        {
            return View("What_to_do_when_stoped_by_police");
        }
        [ActionName("Why-hire-a-new-jersey-traffic-lawyers")]
        public ActionResult Why_hire_a_new_jersey_traffic_lawyers()
        {
            return View("Why_hire_a_new_jersey_traffic_lawyers");
        }
        [ActionName("Dui-Penalties")]
        public ActionResult Dui_Penalties()
        {
            return View("Dui_Penalties");
        }

        public ActionResult Tailgating()
        {
            return View();
        }
        [ActionName("Failure-to-stop-for-traffic-light")]
        public ActionResult Failure_to_stop_for_traffic_light()
        {
            return View("Failure_to_stop_for_traffic_light");
        }
        [ActionName("Improper-passing-school-bus")]
        public ActionResult Improper_passing_school_bus()
        {
            return View("Improper_passing_school_bus");
        }
        [ActionName("Frequently-asked-questions")]
        public ActionResult Frequently_asked_questions()
        {
            return View("Frequently_asked_questions");
        }

        public ActionResult reckless()
        {
            return View("Reckless-Driving");
        }
        public ActionResult ContactUs()
        {
            return View();
        }


        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult Error(string data)
        {
            var url = Request.RawUrl.ToString();

            var stUrl = url.Split('=');

            var Urlt1 = stUrl[1].Replace("/", "");
            var s = Urlt1.ToLower();

            string str = s.Substring(0, 2);

            if (str == "es")
            {
                switch (s)
                {
                    case "esindex":
                        return Redirect("/es/Índice");

                    case "esacerca-de-multas-de-trafico-en-new-jersey":
                        return Redirect("/es/Sobre-nosotros");

                    case "esporque-abogados-de-trafico-en-new-jersey":
                        return Redirect("/es/Porque-nosotros");

                    case "esservicios-de-multas-de-trafico-en-new-jersey":
                        return Redirect("/es/Nuestros-servicios");

                    case "esrecursos-de-multas-de-trafico-en-new-jersey":
                        return Redirect("/es/recursoss");

                    case "esfree-quote":
                        return Redirect("/es/Cuota-gratis");


                    case "esmultas-de-trafico-en-new-jersey":
                        return Redirect("/es/multas-de-tráfico");

                    case "esmultas-por-velocidad":
                        return Redirect("/es/e-infracciones");


                    case "esconductor-o-vehiculo-sin-seguro":
                        return Redirect("/es/Sin-seguro-de-coche");


                    case "esconducir-imprudentemente":
                        return Redirect("/es/Conducción-temeraria");


                    case "eslicencia-suspendida":
                        return Redirect("/es/Con-suspensión-de-licencia");


                    case "eseliminar-multa-de-trafico":
                        return Redirect("/es/Dui-DWI-Abogados-de-Defensa");


                    case "espuntos-y-sobrecargas":
                        return Redirect("/es/Puntos-y-sobrecargos");

                    case "esque-hacer-cuando-su-licencia-es-suspendida":
                        return Redirect("/es/Lo-a-hacer-con-suspensión-de-licencia");

                    case "esrestaurar-licencia-de-conducir":
                        return RedirectToAction("/es/Restore-Licencia");

                    case "espenas-y-multas-de-trafico":
                        return Redirect("/es/sanciones");

                    case "esque-hacer-si-te-detienen-por-violacion-de-trafico":
                        return Redirect("/es/¿Qué-hacer-cuando-se-detuvo-por-la-policíae");


                    case "essistema-de-puntos-de-trafico":
                        return Redirect("/es/Puntos-y-sobrecargos");

                    default:
                        return Redirect("/es/Índice");
                }
            }

            else
            {
                switch (s)
                {
                    case "new-jersey-traffic-tickets-lawyers":
                        return RedirectToAction("About-Us");
                    case "why-new-jersey-traffic-lawyers":
                        return RedirectToAction("Why-Us");
                    case "index":
                        return RedirectToAction("Index");

                    case "new-jersey-traffic-tickets-services":
                        return RedirectToAction("Our-Services");

                    case "new-jersey-traffic-ticket-resources":
                        return RedirectToAction("Resources");

                    case "free-quote":
                        return RedirectToAction("Free-Quote");

                    case "frequently-asked-questions-traffic-tickets":
                        return RedirectToAction("Frequently-asked-questions");

                    case "new-jerseytraffic-tickets":
                        return RedirectToAction("Traffic-Tickets");

                    case "new-jerseyspeeding-tickets":
                        return RedirectToAction("Speeding-Tickets");

                    case "new-jerseyno-car-insurance":
                        return RedirectToAction("No-Car-Insurance");

                    case "new-jerseyreckless":
                    case "new-jerseyreckless-driving":
                        return RedirectToAction("Reckless-Driving");

                    case "new-jerseycareless-driving":
                        return RedirectToAction("Careless-Driving");

                    case "new-jerseysuspended-license":
                        return RedirectToAction("Suspended-License");

                    case "new-jerseydui-dwi-defense-lawyers-for-nj-drunk-driving-offenses":
                        return RedirectToAction("Dui-Dwi-Defense-Lawyers");

                    case "new-jersey-points-and-surcharges":
                        return RedirectToAction("Points_and_Surcharges");
                    case "what-to-do-new-jersey-suspended-license":
                        return RedirectToAction("What-to-do-suspended-license");

                    case "tailgating":
                        return RedirectToAction("Tailgating");

                    case "failure-to-stop-for-traffic-light":
                        return RedirectToAction("Failure-to-stop-for-traffic-light");

                    case "improper-passing-school-bus":
                        return RedirectToAction("Improper-passing-school-bus");

                    case "beat-your-new-jersey-traffic-ticket":
                        return RedirectToAction("Beat-Your-Traffic-Ticket");

                    case "restore-license-new-jersey":
                        return RedirectToAction("Restore-License");

                    case "penalties":
                        return RedirectToAction("Penalties");

                    case "what-to-do-when-stopped-by-the-police":
                        return RedirectToAction("What-to-do-when-stoped-by-police");

                    case "new-jersey-point-system":
                        return RedirectToAction("Points-and-Surcharges");

                    case "new-jerseydui-penalties":
                        return RedirectToAction("Dui-Penalties");

                    case "why-hire-a-new-jersey-traffic-lawyer":
                        return RedirectToAction("Why-hire-a-new-jersey-traffic-lawyers");

                    default:
                        return RedirectToAction("Index");
                }
            }

            //if (s.Contains("new-jersey-traffic-tickets-lawyers"))
            //{
            //    return RedirectToAction("About_Us");
            //}
            //else if (s.Contains("why-new-jersey-traffic-lawyers"))
            //{
            //    return RedirectToAction("Why_Us");
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}
        }


        public ActionResult Sendquery(string fullname = "", string CellNo = "", string Email = "", string Message = "", string Capcha = "")
        {
            var Name = fullname.Trim();
            var captchatext = Convert.ToString(Session["captchaText"]);
            var captchatexts = Regex.Replace(captchatext, @"\s+", "");
            if (Email != "" && Capcha != "" && Name != "")
            {
                if (captchatext == Capcha)
                {
                    string to = "request@stabilelawfirm.com";
                    string from = Email;
                    string body = @"<html><title></title>
              <head>
                <style>
body {
            background: none;
        }

        table td {
            height: 30%;
            width: 50%;
            border-color: #13A0B2;
        }

        table th {
            height: 70%;
            width: 50%;
            background-color: #13A0B2;
            color: white;
            font-size: 100%;
        }

    </style>
</head>
<body>
<div><table border=""1"" style='width:100%;'>
<thead>
<tr style='background:#13A0B2;'>
                        <th colspan=""2"" style='height: 70%;
            width: 50%;
            background-color: #13A0B2;
            color: white;
            font-size: 100%;'>Query Form</th>

                    </tr>
           </thead>
             <tbody>
                      
                    <tr>
                        <td style='height: 100%; ;width: 50%; color:black; border-color: #13A0B2;'>Full Name:</td>
                        <td style='height: 100%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + fullname + @"</td>
                    </tr>


                    <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Phone:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + CellNo + @"</td>

                    </tr>

                      <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Email:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + Email + @"</td>

                    </tr>

 <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Query:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + Message + @"</td>

                    </tr>
   </tbody>
</table >
        </div>
</body>
<html>
";
                    MailMessage mail = new MailMessage(from, to);
                    SmtpClient client = new SmtpClient();
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Host = "mail.newjerseydefensivedriving.net";
                    mail.Subject = "newjerseytraffictickets.com has sent you another enquery Request! - From query form";
                    mail.IsBodyHtml = true;
                    mail.Body = body;

                    try
                    {
                        client.Send(mail);
                        return Json("Email Sent", JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception ex)
                    {
                        return Json(ex.Message, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json("Captcha text is not validated, please try again.", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(" * fields are required", JsonRequestBehavior.AllowGet);
            }
        }
    }
}