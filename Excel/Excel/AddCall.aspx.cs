using Excel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Excel
{
    public partial class AddCall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["CallId"] != null)
            {
                hdnCallId.Value = Request.QueryString["CallId"];
            }
            else
            {
                hdnCallId.Value = "0";
            }
            
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static String AddCallLog(int Id=0,string FirstName = "", string LastName = "", string Phone = "", string Notes = "")
        {
            NJ_CallLogs obj = new NJ_CallLogs();
            //if (Convert.ToInt32(HttpContext.Current.Session["LoginId"]) != 0)
            //{
                obj.AddCallLog(Id, FirstName, LastName, Phone, Notes);
                return "1";
            //}
            //else
            //{
            //    return "2";
            //}
        }

        public void data(string[] a)
        { 
        
        }

         [System.Web.Services.WebMethod(EnableSession = true)]
        public static String AddandEmailCallLog(int Id = 0, string FirstName = "", string LastName = "", string Phone = "", string Notes = "", string EmailToUser = "")
        {
            string success = "0";
            NJ_CallLogs obj = new NJ_CallLogs();
            obj.AddCallLog(Id, FirstName, LastName, Phone, Notes, EmailToUser);
            

            //Send Email
            string result = "";
            //string to = EmailToUser;
            //string from = "request@stabilelawfirm.com";
            string from = HttpContext.Current.Request.Cookies["UserName"].Value;
            string body = "<h2>Call Detail</h2>";
            body = body + "<p><table><tr><td>FirstName : " + FirstName + " </td></tr><tr><td>Last Name : " + LastName + "</td></tr><tr><td>Phone : " + Phone + "</td></tr><tr><td>Notes : " + Notes + "</td></tr></table></p>";
            //MailMessage mail = new MailMessage(from, to);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            string[] multipleIDs = EmailToUser.Split(',');
             foreach(string multi in multipleIDs)
             {
                 mail.To.Add(new MailAddress(multi));
             }
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.newjerseydefensivedriving.net";
            //mail.Subject = "Call Log Details from Driving Users app";
            mail.Subject = "Phone call message from " + FirstName + " " + LastName;
            mail.IsBodyHtml = true;
            mail.Body = body;
            mail.CC.Add(new MailAddress(from));
            mail.CC.Add(new MailAddress("Call-logs@stabilelawfirm.com"));
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

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static NJ_CallLogs CallLogDetails(int id = 0)
        {
            NJ_CallLogs obj = new NJ_CallLogs();
           var Result = obj.CallLogDetails(id);
            return Result;
        }
    }
}