using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewJersyTrafficTicket.Capcha;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace Stabile_DUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [ActionName("dwi-and-dui-results")]
        public ActionResult dwi_and_dui_results()
        {
            return View("dwi-and-dui-results");
        }
        [ActionName("terms-and-definitions")]
        public ActionResult terms_and_definitions()
        {
            return View("terms-and-definitions");
        }
        [ActionName("social-network")]
        public ActionResult social_network()
        {
            return View("social-network");
        }

        [ActionName("contact-us")]
        public ActionResult contact_us()
        {
            return View("contact-us");
        }
        //[ActionName("dui-resources")]
        //public ActionResult dui_resources(string id)
        //{
        //    ViewBag.id = id;
        //    return View("dui-resources");
        //}
        //public ActionResult generateCaptcha()
        //{
        //    System.Drawing.FontFamily family = new System.Drawing.FontFamily("Arial");
        //    CaptchaImage img = new CaptchaImage(250, 100, family);
        //    string text = img.CreateRandomText(4) + " " + img.CreateRandomText(3);
        //    img.SetText(text);
        //    img.GenerateImage();
        //    img.Image.Save(Server.MapPath("~/CapchaImage/") +
        //    this.Session.SessionID.ToString() + ".png",
        //    System.Drawing.Imaging.ImageFormat.Png);
        //    Session["captchaText"] = text;
        //    return Json("../CapchaImage/" + this.Session.SessionID.ToString() + ".png?t=" +
        //    DateTime.Now.Ticks, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Error()
        {
           return RedirectToAction("index");
        }


        public ActionResult Sendquery(string fullname = "", string CellNo = "", string Email = "", string Message = "")
        {
            var Name = fullname.Trim();
            var captchatext = Convert.ToString(Session["captchaText"]);
            var captchatexts = Regex.Replace(captchatext, @"\s+", "");
            if (Email != "" && Name != "")
            {
                //if (captchatext == Capcha)
                //{
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
            border-color: #ff6801;
        }

        table th {
            height: 70%;
            width: 50%;
            background-color: #ff6801;
            color: white;
            font-size: 100%;
        }

    </style>
</head>
<body>
<div><table border=""1"" style='width:100%;'>
<thead>
<tr style='background:#ff6801;'>
                        <th colspan=""2"" style='height: 70%;
            width: 50%;
            background-color: #ff6801;
            color: white;
            font-size: 100%;'>Query Form</th>

                    </tr>
           </thead>
             <tbody>
                      
                    <tr>
                        <td style='height: 100%; ;width: 50%; color:black; border-color: #ff6801;'>Full Name:</td>
                        <td style='height: 100%;width: 50%; color:black; border-color: #ff6801;'>&nbsp;" + fullname + @"</td>
                    </tr>


                    <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #ff6801;'>Phone:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #ff6801;'>&nbsp;" + CellNo + @"</td>

                    </tr>

                      <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #ff6801;'>Email:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #ff6801;'>&nbsp;" + Email + @"</td>

                    </tr>

 <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #ff6801;'>Query:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #ff6801;'>&nbsp;" + Message + @"</td>

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
                    mail.Subject = "dui-newjersey.com has sent you another enquery Request!";
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
                
                //else
                //{
                //    return Json("Captcha text is not validated, please try again.", JsonRequestBehavior.AllowGet);
                //}
            }
            else
            {
                return Json("* fields are required", JsonRequestBehavior.AllowGet);
            }
        }

    }
}
