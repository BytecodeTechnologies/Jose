using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StableLawFirm.Model;
using System.Net.Mail;
using System.Net;

namespace StableLawFirm
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ResultModel model = new ResultModel();
                var result = model.GetResult();
                Repeater1.DataSource = result;
                Repeater1.DataBind();
                Repeater2.DataSource = result;
                Repeater2.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + ex.Message + ")", true);
            }

        }

        [System.Web.Services.WebMethod]
        public static string SendEmail(string Name = "", string Phone = "", string Email = "", string Comment = "", string Recapcha = "")
        {

            string result = "";
            var qFullName = Name.Trim();
            var qEmail = Email.Trim();
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
                        <td style='height: 100%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + Name + @"</td>
                    </tr>


                    <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Phone:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + Phone + @"</td>

                    </tr>

                      <tr>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Email:</td>
                        <td style='height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + Email + @"</td>

                    </tr>
   </tbody>
</table >
<table border=""1"" style='width:100%;'>
 <tbody>
                         <tr>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>Comment:</td>
                        <td style=' height: 30%;width: 50%; color:black; border-color: #13A0B2;'>&nbsp;" + Comment + @"</td>

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
                mail.Subject = "New Request from Stabile Law Firm";
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
                return "All highlighted fields are required.";
            }
        }
    }
}