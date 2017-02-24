using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecureDriving.Models;
using System.Net.Mail;
using System.Net;
using System.Net.Configuration;
using System.Web.Configuration;

namespace SecureDriving.Controllers
{
    public class HomeController : Controller
    {
        dd_databaseEntities db = new dd_databaseEntities();

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult AboutUs()
        {

            return View();
        }
        public ActionResult DrivingCourses()
        {

            return View();
        }
        public ActionResult FAQ()
        {

            return View();
        }
        public ActionResult InsuranceDiscount()
        {

            return View();
        }
        public ActionResult ContactUs()
        {

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            Session["LoginId"] = 0;
            Session["UserRoll"] = 0;
            Session["UserActive"] = -1;
            Session["LoginId"] = 0;
            return View("Index");
        }
        public ActionResult Video()
        {
            if (((Convert.ToInt32(Session["UserRoll"]) == 2) && (Convert.ToInt32(Session["UserActive"]) == 1)) || ((Convert.ToInt32(Session["UserRoll"]) == 1) && (Convert.ToInt32(Session["UserActive"]) == 1)))
            {
                return View();
            }
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 0)
            {
                return Redirect("/User/NotActiveUser");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 0))
            {
                return Redirect("/Admin/NotActiveAdmin");
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }

        public ActionResult CompletedCourse()
        {
            try
            {
                int LoginId = Convert.ToInt32(Session["LoginId"]);
                var userList = db.video_usuarios.FirstOrDefault(a => a.ncodusua == LoginId);
                userList.CourseCompletedDate = DateTime.Now;
                userList.IsCompleted = Convert.ToBoolean(1);
                db.SaveChanges();
                return Json("You have Successfully completed your course. Thanks", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Registration()
        {

            List<blogpost> lsp = db.blogposts.ToList();
            return View();
        }
        public ActionResult LoginUser(string Email, string pwd)
        {

            var LoginId = db.video_usuarios.FirstOrDefault(a => a.vemail == Email && a.vcon == pwd && a.vdeleted == "0");
            if (LoginId == null)
            {
                Session["LoginId"] = 0;
                Session["UserRoll"] = 0;
                Session["UserActive"] = -1;///////
                return Json("Check Email or Password", JsonRequestBehavior.AllowGet);

            }
            if (LoginId.nusuariotipo == 2)
            {
                Session["LoginId"] = LoginId.ncodusua;
                Session["UserRoll"] = LoginId.nusuariotipo;
                Session["UserActive"] = LoginId.vestusuario;
                Session["Email"] = LoginId.vemail;
                int[] balance = new int[2];
                balance[0] = Convert.ToInt32(LoginId.nusuariotipo);
                balance[1] = Convert.ToInt32(LoginId.vestusuario);
                ViewBag.UserActive = LoginId.vestusuario;
                return Json(balance, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["LoginId"] = LoginId.ncodusua;
                Session["UserRoll"] = LoginId.nusuariotipo;
                Session["UserActive"] = LoginId.vestusuario;
                Session["Email"] = LoginId.vemail;
                int[] balance = new int[2];
                balance[0] = Convert.ToInt32(LoginId.nusuariotipo);
                balance[1] = Convert.ToInt32(LoginId.vestusuario);
                ViewBag.UserActive = LoginId.vestusuario;
                return Json(balance, JsonRequestBehavior.AllowGet);
            }

            //var LoginId = (from b in db.video_usuarios
            //         .Where(r=>  r.vemail == Email && r.vcon == pwd && r.vdeleted =="0")
            //               select new UserList
            //               {
            //                   Email = b.vemail,
            //                   id = b.ncodusua,
            //                   Role = b.nusuariotipo,
            //                   active = b.vestusuario,
            //               }).FirstOrDefault();
            //if (LoginId == null)
            //{
            //    Session["LoginId"] = 0;
            //    Session["UserRoll"] = 0;
            //    Session["UserActive"] = -1;///////
            //    return Json("Check Email or Password", JsonRequestBehavior.AllowGet);

            //}
            //if (LoginId.Role == 2)
            //{
            //    Session["LoginId"] = LoginId.id;
            //    Session["UserRoll"] = LoginId.Role;
            //    Session["UserActive"] = LoginId.active;
            //    Session["Email"] = LoginId.Email;
            //    int[] balance = new int[2];
            //    balance[0] = Convert.ToInt32(LoginId.Role);
            //    balance[1] = Convert.ToInt32(LoginId.active);
            //    ViewBag.UserActive = LoginId.active;
            //    return Json(balance, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    Session["LoginId"] = LoginId.id;
            //    Session["UserRoll"] = LoginId.Role;
            //    Session["UserActive"] = LoginId.active;
            //    Session["Email"] = LoginId.Email;
            //    int[] balance = new int[2];
            //    balance[0] = Convert.ToInt32(LoginId.id);
            //    balance[1] = Convert.ToInt32(LoginId.active);
            //    ViewBag.UserActive = LoginId.active;
            //    return Json(balance, JsonRequestBehavior.AllowGet);
            //}
        }

        public ActionResult RegisterUser(string FullName, string Phone, string Email, string Comment, string Address, string NJDL, DateTime DOB, string Gender, string State, string City, string Zip, string Eyecolor)
        {
            var email = db.video_usuarios.FirstOrDefault(a => a.vemail == Email);
            if (email == null)
            {
                var password = CreateRandomPassword();
                video_usuarios objvideo_usuarios = new video_usuarios();

                objvideo_usuarios.nusuariotipo = 1;
                objvideo_usuarios.vfullname = FullName;
                objvideo_usuarios.vphone = Phone;
                //objvideo_usuarios.vcelular = Cellular;
                objvideo_usuarios.vemail = Email;
                objvideo_usuarios.vcomments = Comment;
                objvideo_usuarios.vcon = password;
                objvideo_usuarios.vcreation = DateTime.Now;
                objvideo_usuarios.vestusuario = Convert.ToString(0);
                objvideo_usuarios.vdeleted = Convert.ToString(0);
                objvideo_usuarios.Address = Address;
                objvideo_usuarios.EyeColor = Eyecolor;
                objvideo_usuarios.Gender = Gender;
                objvideo_usuarios.NJDL_ = NJDL;
                objvideo_usuarios.DOB = DOB;
                objvideo_usuarios.State = State;
                objvideo_usuarios.City = City;
                objvideo_usuarios.Zip = Zip;
                db.video_usuarios.Add(objvideo_usuarios);

                db.SaveChanges();


                var RegisterUserDetail = db.video_usuarios.FirstOrDefault(a => a.vemail == Email);
                SendEmailToUser(RegisterUserDetail.vemail, RegisterUserDetail.vcon, RegisterUserDetail.ncodusua);           //call function for sending Email

                Session["UserRoll"] = RegisterUserDetail.nusuariotipo;
                Session["UserActive"] = RegisterUserDetail.vestusuario;
                Session["Email"] = RegisterUserDetail.vemail;
                Session["LoginId"] = RegisterUserDetail.ncodusua;



                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        public static string CreateRandomPassword()
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[8];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < 8; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

        public string SendEmailToUser(string Email, string Password, int id)
        {
            string result = "";
            string to = "ddschool@stabilelawfirm.com";
            string from = "ddschool@stabilelawfirm.com";
            string body = "<h2>New User Registered Successfully</h2>";
            body = body + "<p><b>Email: </b>" + Email + "</p><p>Please Click on this Link to view details of this user:  http://www.newjerseydefensivedriving.net/Admin/UserInfo/" + id + "  </p>";
            MailMessage mail = new MailMessage(from, to);
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.newjerseydefensivedriving.net";
            mail.Subject = "New User Registered";
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

        public ActionResult SendEmail()
        {
            string result = "";
            var body = "<h2>Email Testing";
            var message = new MailMessage();
            message.To.Add(new MailAddress("gurvinder0206@gmail.com"));
            message.From = new MailAddress("Vipan.rinku@gmail.com");
            message.Subject = "Registration Succesfull";
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
        public ActionResult Testhtml()
        {
            return View();
        }

        public ActionResult QueryEmail(string Name, string Phone, string Email, string Message)
        {
            var result = "";
            var qFullName = Name.Trim();
            var qEmail = Email.Trim();
            if (qFullName != "" && qEmail != "")
            {
                string to = "ddschool@stabilelawfirm.com";
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
            border-color: #44A1FD;
        }

        table th {
            height: 70%;
            width: 50%;
            background-color: #44A1FD;
            color: white;
            font-size: 100%;
        }

    </style>
</head>
<body>
<div><table border=""1"" style='width:100%;'>
<thead>
<tr style='background:#44A1FD;'>
                        <th colspan=""2"" style='height: 70%;
            width: 50%;
            background-color: #44A1FD;
            color: white;
            font-size: 100%;'>CLIENT INFORMATION</th>

                    </tr>
           </thead>
             <tbody>
                      
                    <tr>
                        <td style='height: 100%; ;width: 50%; color:black; border-color: #44A1FD;'>Full Name:</td>
                        <td style='height: 100%;width: 50%; color:black; border-color: #44A1FD;'>&nbsp;" + Name + @"</td>
                    </tr>


                    <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #44A1FD;'>Phone:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #44A1FD;'>&nbsp;" + Phone + @"</td>

                    </tr>

                      <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #44A1FD;'>Email:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #44A1FD;'>&nbsp;" + Email + @"</td>

                    </tr>
   </tbody>
</table >
<table border=""1"" style='width:100%;'>
 <tbody>
                         <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #44A1FD;'>Comment:</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #44A1FD;'>&nbsp;" + Message + @"</td>

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
                mail.Subject = "New enquiry Request from NewJerseyDefensiveDriving.net";
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
                return Json("All highlighted fields are required.", JsonRequestBehavior.AllowGet);
            }
        }
    }
}



