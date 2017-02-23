using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Landscapes.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pools_Spas()
        {

            return View();
        }

        public ActionResult DriveWays()
        {
            return View();
        }
        public ActionResult Kitchens_Fireplaces()
        {
            return View();
        }
        public ActionResult Gates()
        {
            return View();
        }
        public ActionResult Decorative_Accents()
        {
            return View();
        }
        public ActionResult Landscape_Designs()
        {
            return View();
        }

        public ActionResult Under_Construction()
        {
            return View();
        }
        public ActionResult Iron_Works()
        {
            return View();
        }
        public ActionResult Masonary()
        {
            return View();
        }
        public ActionResult Aboutus()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Testimonials()
        {
            return View();
        }
        public ActionResult Contact_Us()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(string Name = "", string Email = "", string PhoneNumber = "", string Subject = "", string Message = "")
        {
            string result = "";
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
            font-size: 100%;'>INFORMATION</th>

                    </tr>
           </thead>
             <tbody>
                      
                    <tr>
                        <td style='height: 100%; ;width: 50%; color:black; border-color: #13A0B2;'>Name:</td>
                        <td style='height: 100%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + Name + @"</td>
                    </tr>


                    <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Email:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + Email + @"</td>

                    </tr>

                      <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Phone:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + PhoneNumber + @"</td>

                    </tr>
                      <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Subject:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + Subject + @"</td>

                    </tr>
   </tbody>
</table >
<table border=""1"" style='width:100%;'>
 <tbody>
                         <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Message:</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + Message + @"</td>

                    </tr>
  </tbody>
            </table>

        </div>
</body>
<html>
";
            var message = new MailMessage();
            message.To.Add(new MailAddress("info@vision-landscapes.com"));
            message.From = new MailAddress("");
            message.Subject = "Contact-Us";
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = WebConfigurationManager.AppSettings["UserName"],
                    Password = WebConfigurationManager.AppSettings["Password"]
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
    

         [HttpPost]
        public ActionResult SendEmailforEstimate(string Service="", string Name = "", string Email = "", string PhoneNumber = "")
        {
            string result = "";
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
            font-size: 100%;'>INFORMATION</th>

                    </tr>
           </thead>
             <tbody>
 <tr>
                        <td style='height: 100%; ;width: 50%; color:black; border-color: #13A0B2;'>Service:</td>
                        <td style='height: 100%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + Service + @"</td>
                    </tr>
                    <tr>
                        <td style='height: 100%; ;width: 50%; color:black; border-color: #13A0B2;'>Name:</td>
                        <td style='height: 100%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + Name + @"</td>
                    </tr>


                    <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Email:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + Email + @"</td>

                    </tr>

                      <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Phone:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + PhoneNumber + @"</td>

                    </tr>
   </tbody>
</table >
        </div>
</body>
<html>
";
            var message = new MailMessage();
            message.To.Add(new MailAddress("sandeepshira25@gmail.com"));
            message.From = new MailAddress("chouhan.dharam151@gmail.com");
            message.Subject = "Request An Estimate";
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = WebConfigurationManager.AppSettings["UserName"],
                    Password = WebConfigurationManager.AppSettings["Password"]
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

         public ActionResult Freequote()
         {
             return View();
         }
    }
}

