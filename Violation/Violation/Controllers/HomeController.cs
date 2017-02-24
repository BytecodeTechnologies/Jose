using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using Violation.Models;
using System.Net;

namespace Violation.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Aboutus()
        {
            return View();
        }
        public ActionResult contactUs()
        {
            return View();

        }
        public ActionResult FightMyTicket()
        {
            return View();
        }
        public ActionResult RadioAds()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }
        public ActionResult OurOffices()
        {
            return View();
        }
        public ActionResult SendEnqueryEmail(string Name, string Email, string phoneno, string Messeage, string RequestFrom)
        {
            Name = Name.Trim();
            Email = Email.Trim();
            phoneno = phoneno.Trim();
            Messeage = Messeage.Trim();
            if (Name != "" && Email != "" && phoneno != "" && Messeage != "")
            {
                string result = "";
                string to = "request@stabilelawfirm.com";
                string from = "request@stabilelawfirm.com";
                string body = "<h2>New enquiry request from 1877(" + RequestFrom + ")</h2><br/>";
                body = body + "<p><b>From: </b>" + Name + "</p><p><b>Email: </b>" + Email + "</p><p><b>Contact No: </b>" + phoneno + "  </p><p><b>Message: </b>" + Messeage + "  </p>";
                MailMessage mail = new MailMessage(from, to);
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "mail.newjerseydefensivedriving.net";
                mail.Subject = "New enquiry request from 1877";
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



                return Json(result, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json("All Fields are Required", JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult SendQuoteEmail(QuoteModel quote)
        {
            var firstname = quote.FirstName.Trim();
            var lastname = quote.LastName.Trim();
            var Emailid = quote.EmailID.Trim();
            var PhoneNumber = quote.Phoneno.Trim();


            if (firstname != "" && lastname != "" && Emailid != "" && PhoneNumber != "")
            {
                string result = "";
                string to = "request@stabilelawfirm.com";
                string from = "request@stabilelawfirm.com";
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
            border-color: #e09836;
        }

        table th {
            height: 70%;
            width: 50%;
            background-color: #e09836;
            color: white;
            font-size: 100%;
        }
    </style>
</head>
<body>

   <div><table border=""1"" style='width:100%;'>
     
                <thead>
                    <tr style='background:#e09836;'>
                        <th colspan=""2"" style='height: 70%;
            width: 50%;
            background-color: #e09836;
            color: white;
            font-size: 100%;'>TICKET INFORMATION</th>

                    </tr>
           </thead>
             <tbody>
                      
                    <tr>
                        <td style='height: 100%; ;width: 50%; color:black; border-color: #e09836;'>Citation # :</td>
                        <td style='height: 100%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.Citation + @"</td>
                    </tr>
                    <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #e09836;'>State :</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.State + @"</td>
                    </tr>
                      <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #e09836;'>County :</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.Country + @"</td>
                    </tr>
   </tbody>
</table >

<table border=""1"" style='width:100%;'>
 <tbody>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Ticketed for :</td>
                       <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.Ticketedfor + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Date of Ticket :</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.TicketDate + @"</td>

                    </tr>
  </tbody>
</table>


<table border=""1"" style='width:100%;'>
 <tbody>
             
 <thead>
                    <tr style='background:#e09836;'>
                        <th colspan='2' style='height: 70%;  width: 100%; background-color: #e09836; color: white;font-size: 100%;' >PERSONAL INFORMATION</th>

                    </tr>
                </thead>
                         <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>License Number :</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.LicenseNumber + @"</td>

                    </tr>
 <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #e09836;'>First Name :</td>
                       <td style='height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.FirstName + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Last Name:</td>
                         <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.LastName + @"</td>

                    </tr>
   </tbody>
</table >
<table border=""1"" style='width:100%;'>
 <tbody>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Email :</td>
                       <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.EmailID + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Phone :</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.Phoneno + @"</td>

                    </tr>

 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Work/Cell :</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.Work + @"</td>

                    </tr>
  </tbody>
</table>
<table border=""1"" style='width:100%;'>
 <tbody>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Mailing Address :</td>
                         <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.MailingAddress + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Apt # :</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.Apt + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>City :</td>
                         <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.City + @"</td>

                    </tr>
  </tbody>
</table>
<table border=""1"" style='width:100%;'>
 <tbody>
<tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>State :</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.State1 + @"</td>

                    </tr>
<tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Zip :</td>
                         <td style=' height: 30%;width: 50%; border-color: #e09836;'>&nbsp;" + quote.Zip + @"</td>

                    </tr>
<tr>
                        <td style=' height: 30%;width: 50%;color:black;width: 50%; border-color: #e09836;'>How did you hear about us?:</td>
                        <td style=' height: 30%;width: 50%; color:black;width: 50%; border-color: #e09836;'>&nbsp;" + quote.HearABoutUs + @"</td>

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
                mail.Subject = "1877violation.com has sent you another lead! - From free quote form of " + quote.RequestFrom + " ";
                mail.IsBodyHtml = true;
                mail.Body = body;
                try
                {
                    client.Send(mail);
                    result = "Email Sent succesfully";
                }
                catch (Exception ex)
                {
                    result = ex.Message + "....... Inner exception is: " + ex.InnerException;
                }

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("All highlight Fields are required", JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult SendEmail(QuoteModel quote)
        {
            string result = "";

            var message = new MailMessage();
            message.To.Add(new MailAddress("vipan.rinku@gmail.com"));
            message.From = new MailAddress("Vipan.rinku@gmail.com");
            message.CC.Add("jo_sujan21@hotmail.co.uk");
            // message.CC.Add("gurvinder0206@gmail.com");
            //  message.CC.Add("satvinder.singh26@gmail.com");
            //  message.CC.Add("goyalsunny1990@gmail.com");
            message.Subject = "newjerseytraffictickets.com has sent you another lead! - From free quote form of "+ quote.RequestFrom+"";

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
            border-color: #e09836;
        }

        table th {
            height: 70%;
            width: 50%;
            background-color: #e09836;
            color: white;
            font-size: 100%;
        }

    </style>
</head>
<body>

   <div><table border=""1"" style='width:100%;'>
     
                <thead>
                    <tr style='background:#e09836;'>
                        <th colspan=""2"" style='height: 70%;
            width: 50%;
            background-color: #e09836;
            color: white;
            font-size: 100%;'>TICKET INFORMATION</th>

                    </tr>
           </thead>
             <tbody>
                      
                    <tr>
                        <td style='height: 100%; ;width: 50%; color:black; border-color: #e09836;'>Citation # :</td>
                        <td style='height: 100%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.Citation + @"</td>
                    </tr>
                    <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #e09836;'>State :</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.State + @"</td>
                    </tr>
                      <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #e09836;'>County :</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.Country + @"</td>
                    </tr>
   </tbody>
</table >

<table border=""1"" style='width:100%;'>
 <tbody>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Ticketed for :</td>
                       <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.Ticketedfor + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Date of Ticket :</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.TicketDate + @"</td>

                    </tr>
  </tbody>
</table>


<table border=""1"" style='width:100%;'>
 <tbody>
             
 <thead>
                    <tr style='background:#e09836;'>
                        <th colspan='2' style='height: 70%;  width: 100%; background-color: #e09836; color: white;font-size: 100%;' >PERSONAL INFORMATION</th>

                    </tr>
                </thead>
                         <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>License Number :</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.LicenseNumber + @"</td>

                    </tr>
 <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #e09836;'>First Name :</td>
                       <td style='height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.FirstName + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Last Name:</td>
                         <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.LastName + @"</td>

                    </tr>
   </tbody>
</table >
<table border=""1"" style='width:100%;'>
 <tbody>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Email :</td>
                       <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.EmailID + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Phone :</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.Phoneno + @"</td>

                    </tr>

 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Work/Cell :</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.Work + @"</td>

                    </tr>
  </tbody>
</table>
<table border=""1"" style='width:100%;'>
 <tbody>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Mailing Address :</td>
                         <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.MailingAddress + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Apt # :</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.Apt + @"</td>

                    </tr>
 <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>City :</td>
                         <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.City + @"</td>

                    </tr>
  </tbody>
</table>
<table border=""1"" style='width:100%;'>
 <tbody>
<tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>State :</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>&nbsp;" + quote.State1 + @"</td>

                    </tr>
<tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #e09836;'>Zip :</td>
                         <td style=' height: 30%;width: 50%; border-color: #e09836;'>&nbsp;" + quote.Zip + @"</td>

                    </tr>
<tr>
                        <td style=' height: 30%;width: 50%;color:black;width: 50%; border-color: #e09836;'>How did you hear about us?:</td>
                        <td style=' height: 30%;width: 50%; color:black;width: 50%; border-color: #e09836;'>&nbsp;" + quote.HearABoutUs + @"</td>

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
                      UserName = "vipan.rinku@gmail.com",
                      Password = "panjlachaudhary"
                  };
                  smtp.Credentials = credential;
                  smtp.Host = "smtp.gmail.com";
                  smtp.Port = 587;
                  smtp.EnableSsl = true;

                  try
                  {
                      smtp.Send(message);
                      result = "Email Sent succesfully";
                  }
                  catch (Exception ex)
                  {
                      result = ex.Message + "....... Inner exception is: " + ex.InnerException;
                  }
              }
              return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
