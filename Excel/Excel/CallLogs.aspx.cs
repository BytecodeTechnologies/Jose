using Excel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Net;

namespace Excel
{
    public partial class CallLogs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["LoginRole"] = Request.Cookies["LoginRole"].Value.ToString();
                HdnUserRole.Value = Convert.ToString(Session["LoginRole"]);
            }
            catch (Exception ex)
            {

            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<NJ_CallLogs> CallLog(string Search = "", int PageIndex = 0, string SearchByName = "")
        {
            NJ_CallLogs obj = new NJ_CallLogs();
            var Result = obj.CallLogs(Search, SearchByName);

            //for paging
            int PageSize = 15;
            int skip = PageIndex * PageSize;
            double PageCount = Convert.ToDouble(Math.Ceiling((double)((double)Result.Count() / (double)PageSize)));
            List<NJ_CallLogs> query = Result.Skip(skip).Take(PageSize).ToList();
            return query;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<NJ_CallLogs> PrintCallLog(string Search = "", string SearchByName = "")
        {
            NJ_CallLogs obj = new NJ_CallLogs();
            var Result = obj.CallLogs(Search, SearchByName);
            return Result;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static String DeleteCallLog(int Id = 0)
        {
            NJ_CallLogs obj = new NJ_CallLogs();
            obj.DeleteCallLog(Id);
            return "1";
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string EmailTodayCallLogs(string Search = "")
        {
            NJ_CallLogs obj = new NJ_CallLogs();
            var Result = obj.CallLogs(Search);
            var doc = new Document(PageSize.A4, 50, 50, 5, 5);

            string PathStart = System.Web.HttpContext.Current.Server.MapPath("/CallLogsPDF");
            if (!System.IO.Directory.Exists(PathStart))
            {
                System.IO.Directory.CreateDirectory(PathStart);
            }
            string FolderNameByDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            PdfWriter.GetInstance(doc, new System.IO.FileStream(System.Web.HttpContext.Current.Server.MapPath("/CallLogsPDF/" + "/" + "CallLog" + FolderNameByDate + ".pdf"), System.IO.FileMode.Create));
            string Filepath = System.Web.HttpContext.Current.Server.MapPath("/CallLogsPDF/" + "/" + "CallLog" + FolderNameByDate + ".pdf");

            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            doc.Open();
            string row = "";
            foreach (var item in Result)
            {
                row = row + @"<tr>
                    <td align='center'  style="" font-size:	11px;"" colspan=""2"">&nbsp; " + item.FirstName + @" </td>
                    <td align='center' style="" font-size:	11px;"" colspan=""2"">&nbsp; " + item.LastName + @" </td>
                       <td align='center' style="" font-size:	11px;"" colspan=""2""> &nbsp; " + item.Phone + @" </td>
                         <td align='center' style="" font-size:	11px;"" colspan=""2"">  &nbsp; " + item.Notes + @"</td>
                             <td align='center' style="" font-size:	11px;"" colspan=""2"">  &nbsp; " + item.AddedName + @"</td>
                                  <td align='center' style="" font-size:11px;"" colspan=""2"">  &nbsp; " + item.Users + @"</td>
                                </tr>";
            }
            string footer = @"</tbody>
           </table >
         <table  style='width:100%;'>
            <thead>
            </thead>
             <tbody>

        </table>
        </div>
      </body>
      <html>";
            string htmlText = @"<html><title></title>
               <p>
               <table  style='width:100%;'>
               <thead>
               </thead>
               <tbody>
               <tr><td>.</td></tr>
                    <tr>
                       <td style=""font-weight:bold"" colspan=""4""align='center'>Call Log Report of " + DateTime.Now.ToShortDateString() + @"</td>
                    </tr>
                      <tr >
                       <td colspan=""4"">.</td>
                    </tr>
              </tbody>
        </table>
              <head>
                </head>
                 <body>
                     <p>
                       <div><table border=""1"" style='width:100%;'>
                 <thead>
                 </thead>
             <tbody>
                    <tr >
                        <td align='center' colspan=""2"" style=""font-weight:bold; font-size:	11px;""> FirstName</td>
                         <td  align='center' colspan=""2"" style=""font-weight:bold; font-size:	11px;""> LastName</td>
                            <td  align='center' colspan=""2"" style=""font-weight:bold; font-size:	11px;"">Phone</td>
                              <td  align='center' colspan=""2"" style=""font-weight:bold; font-size:11px;"">Notes</td>
                                <td  align='center' colspan=""2"" style=""font-weight:bold; font-size:	11px;"">AddedBy</td>
                                    <td  align='center' colspan=""2"" style=""font-weight:bold; font-size:	11px;"">Mail Sent To</td>
                   </tr>" + row + footer;
            iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(doc);
            hw.Parse(new System.IO.StringReader(htmlText));
            doc.Close();
            CallLogs objCalllog = new CallLogs();
            string Emailresult = objCalllog.SendCalllogsEmail(Filepath);
            // string Emailresult = objCalllog.SendEmail(Filepath);
            return Emailresult;
        }

        public string SendCalllogsEmail(string Filepath)
        {
            string result = "";
            string body = "Call Log report of " + DateTime.Now.ToShortDateString();
            string to = "moriundo@stabilelawfirm.com";
            string from = "joriundo@stabilelawfirm.com";
            MailMessage mail = new MailMessage(from, to);
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.newjerseydefensivedriving.net";
            mail.Subject = "Today's Call Log Report";
            mail.IsBodyHtml = true;
            mail.Body = body;
            mail.CC.Add(new MailAddress("joriundo@stabilelawfirm.com"));
            mail.CC.Add(new MailAddress("Steve@stabilelawfirm.com"));
            if (Filepath != null)
            {
                Attachment attachment = new Attachment(Filepath, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = attachment.ContentDisposition;
                disposition.CreationDate = File.GetCreationTime(Filepath);
                disposition.ModificationDate = File.GetLastWriteTime(Filepath);
                disposition.ReadDate = File.GetLastAccessTime(Filepath);
                disposition.FileName = Path.GetFileName(Filepath);
                disposition.Size = new FileInfo(Filepath).Length;
                disposition.DispositionType = DispositionTypeNames.Attachment;
                mail.Attachments.Add(attachment);
            }
            try
            {
                client.Send(mail);
                result = "Today's CallLogs Report Successfully Sent";
            }
            catch (Exception ex)
            {
                result = ex.Message + "....... Inner exception is: " + ex.InnerException;
            }
            return result;
        }
    }
}