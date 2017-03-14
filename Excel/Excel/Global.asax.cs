using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Excel;
using System.Timers;
using System.Data.Objects;
using System.Net.Mail;

namespace Excel
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            System.Timers.Timer myTimer = new System.Timers.Timer();
            DateTime now = DateTime.Now;
            DateTime s = DateTime.Today.AddHours(24);     // 86340000;
            
            int ms = (int)(s - now).TotalMilliseconds;
            myTimer.Interval = 3000;
            myTimer.AutoReset = true;
            myTimer.Elapsed += new ElapsedEventHandler(myTimer_Elapsed);
            myTimer.Enabled = true;
        }

        public void myTimer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            //SendScheduleMail();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        //public void SendScheduleMail()
        //{
        //    NJTicketEntities db = new NJTicketEntities();
        //    DateTime today = DateTime.Now.Date;
            
        //   var todaysUser= from cl in db.NJ_CallLog
        //                        join u in db.NJ_User
        //                        on cl.AddedBy equals u.tblUserId
        //                        where (EntityFunctions.TruncateTime(cl.DateAdded) == today)
        //                        select new
        //                        {
        //                            FirstName = cl.FirstName,
        //                            LastName = cl.LastName,
        //                            Phone = cl.Phone,
        //                            Notes = cl.Notes,
        //                            Id = cl.Id,
        //                            AddedBy = cl.AddedBy,
        //                            AddName = u.First_Name,
        //                            DateAdded = cl.DateAdded                                                                      
        //                        };
        //    string body = "<table><tr><th>First Name</th><th>Last Name</th><th>Phone</th><th>Notes</th><th>Added By</th><th>Added Date</th></tr>";
        //    if (todaysUser != null)
        //    {
        //        foreach (var items in todaysUser)
        //        {
        //            body += "<tr><td>" + items.FirstName + "</td><td>" + items.LastName + "</td><td>" + items.Phone + "</td><td>" + items.Notes + "</td><td>" + items.AddName + "</td><td>" + items.DateAdded + "</td></tr>";
        //        }
        //    }
        //    else
        //    {
        //        body += "<tr><td colspan='6'> No items added Today.</td></tr>";
        //    }

        //    string result = "";
        //    string to = "request@stabilelawfirm.com";
        //    string from = "request@stabilelawfirm.com";
        //    MailMessage mail = new MailMessage(from, to);                      
        //    SmtpClient client = new SmtpClient();
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    client.UseDefaultCredentials = false;
        //    client.Host = "mail.newjerseydefensivedriving.net";
        //    mail.Subject = "Today's Call Log Details";            
        //    mail.IsBodyHtml = true;
        //    mail.Body = body;
        //    mail.CC.Add(new MailAddress(from));           
        //    try
        //    {
        //        client.Send(mail);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = ex.Message + "....... Inner exception is: " + ex.InnerException;
        //    }

        //}
    }
}
