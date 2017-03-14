using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel.Model;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using System.IO;
using Novacode;
using System.Diagnostics;
//using iTextSharp.text;
using System.Text;
using System.Drawing;
using System.Data;
using iTextSharp.text;

using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Net.Mail;
using System.Net;




namespace Excel
{
    public partial class ClientDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"];
                    hdnId.Value = id;
                }
                UserId.Value = Request.Cookies["LoginRole"].Value.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static NJ_Clients ClientDetail(int id = 0)
        {
            Nj_Detail obj = new Nj_Detail();
            var result = obj.ClientDetail(id);
            return result;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<CertificateFiles> filePathList(int id = 0, string currentDate = "")
        {
            CertificateFiles obj = new CertificateFiles();
            var result = obj.filePathList(id, currentDate);
            return result;
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string ID = Request.QueryString["id"];
            int id = Convert.ToInt32(ID);
            Nj_Detail obj = new Nj_Detail();
            var result = obj.ClientDetail(id);

            var doc = new Document(PageSize.A4, 50, 50, 5, 5);
            //PdfWriter.GetInstance(doc, new FileStream("D:/VK/SecureDriving/SecureDriving/PDF/" + "/"+ id +".pdf", FileMode.Create));
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("~/NewPDF/" + "/" + id + ".pdf"), FileMode.Create));

            // Set the page size
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            doc.Open();


            StringBuilder sb = new StringBuilder();
            string htmlText = "<html><title></title> <head> </head> <body><p><div>";


            sb.Append("<html><title></title> <head> </head> <body><p><div>");
            sb.Append("<table style='width: 100%'>");
            sb.Append("<tr><td><b><span style='font-size:22%;font-weight:bold;padding-left: 260%;'>Client Details</span></b></td></tr>");

            sb.Append("<tr><td>.</td></tr>");

            sb.Append("<tr><td><span style='font-size:17%;font-weight:bold;margin-left: 35%;'>");
            if (result.F_Name != null && result.F_Name != "")
            {

                sb.Append(result.F_Name);
                sb.Append(" ");

            }

            if (result.L_Name != null && result.L_Name != "")
            {
                sb.Append(result.L_Name);
            }
            sb.Append("</span></td></tr>");

            if (result.Address1 != null && result.Address1 != "")
            {
                sb.Append("<tr><td>");
                sb.Append(result.Address1);
                sb.Append("</td></tr>");

            }
            sb.Append("<tr><td>");
            if (result.City != null && result.City != "")
            {
                sb.Append(result.City);
                sb.Append(",");
            }
            if (result.ST != null && result.ST != "")
            {
                sb.Append(result.ST);
                sb.Append(",");
            }
            if (result.ZIP != null && result.ZIP != "")
            {
                sb.Append(result.ZIP);
            }
            sb.Append("</td></tr>");

            sb.Append("<tr><td>");
            if (result.Email != null && result.Email != "")
            {
                sb.Append(result.Email);
            }
            if (result.Phone != null && result.Phone != "")
            {
                sb.Append("   |   ");
                sb.Append(result.Phone);
            }
            sb.Append("</td></tr>");
            sb.Append("<tr><td>.</td></tr>");
            if (result.Comment != null && result.Comment != "")
            {
                sb.Append("<tr><td>");
                sb.Append(result.Comment);
                sb.Append("</td></tr>");

            }
            if (result.Court_Name != null && result.Court_Name != "")
            {
                sb.Append("<tr><td>");
                sb.Append(result.Court_Name);
                sb.Append("</td></tr>");

            }
            if (result.File_Date != null && result.File_Date != "")
            {
                sb.Append("<tr><td>");
                sb.Append(result.File_Date);
                sb.Append("</td></tr>");

            }
            if (result.List_Type != null && result.List_Type != "")
            {
                sb.Append("<tr><td>");
                sb.Append(result.List_Type);
                sb.Append("</td></tr>");

            }
            if (result.NJ_CourtID != null && result.NJ_CourtID != "")
            {
                sb.Append("<tr><td>");
                sb.Append(result.NJ_CourtID);
                sb.Append("</td></tr>");

            }
            if (result.CourtDate != null && result.CourtDate != "")
            {
                sb.Append("<tr><td>");
                sb.Append(result.CourtDate);
                sb.Append("</td></tr>");

            }
            if (result.DateIssued != null && result.DateIssued != "")
            {
                sb.Append("<tr><td>DateIssued - ");
                sb.Append(result.DateIssued);
                sb.Append("</td></tr>");

            }
            if (result.Description != null && result.Description != "")
            {
                sb.Append("<tr><td>");
                sb.Append(result.Description);
                sb.Append("</td></tr>");

            }
            if (result.Violation != null && result.Violation != "")
            {
                sb.Append("<tr><td>");
                sb.Append(result.Violation);
                sb.Append("</td></tr>");

            }
            if (result.Salutation != null && result.Salutation != "")
            {
                sb.Append("<tr><td>");
                sb.Append(result.Salutation);
                sb.Append("</td></tr>");

            }
            if (result.Summons != null && result.Summons != "")
            {
                sb.Append("<tr><td>");
                sb.Append(result.Summons);
                sb.Append("</td></tr>");

            }
            if (result.Muncipality != null && result.Muncipality != "")
            {
                sb.Append("<tr><td>");
                sb.Append(result.Muncipality);
                sb.Append("</td></tr>");

            }
            if (result.Complaint != null && result.Complaint != "")
            {
                sb.Append("<tr><td>");
                sb.Append(result.Complaint);
                sb.Append("</td></tr>");
            }
            sb.Append("<tr><td>.</td></tr>");
            if (result.Payment_Cardno != null && result.Payment_Cardno != "")
            {
                sb.Append("<tr><td><span style='font-size:17%;font-weight:bold;margin-left: 35%;'>Card Details</span>");
                sb.Append("</td></tr>");
                sb.Append("<tr><td>");
                sb.Append(result.Payment_Cardno);
                sb.Append("</td></tr>");

            }
            if (result.Payment_Card_ExpDate != null && result.Payment_Card_ExpDate != "")
            {
                sb.Append("<tr><td>");
                sb.Append(result.Payment_Card_ExpDate);
                sb.Append("</td></tr>");

            }
            if (result.Payment_CVV != null)
            {
                sb.Append("<tr><td>");
                sb.Append(result.Payment_CVV);
                sb.Append("</td></tr>");

            }
            sb.Append("</table>");
            sb.Append("</div></p> </body></html>");

            htmlText += "</table>";
            htmlText += "</div></p> </body></html>";
            string sb1 = sb.ToString();
            iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(doc);
            hw.Parse(new StringReader(sb1));
            doc.Close();
            string FilePath = Server.MapPath("~/NewPDF/" + "/" + id + ".pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<Nj_Comments> GetComments_ByClient(int id = 0)
        {
            Nj_Comments obj = new Nj_Comments();
            var result = obj.GetCommentByid(id);
            return result;
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string DeleteClient(int id = 0)
        {
            Nj_Detail obj = new Nj_Detail();
            obj.DeleteClient(id);
            return "Client Deleted Successfully";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string UpdateUser(string id = "", string F_Name = "", string LastName = "", string ListType = "", string CourtName = "", string FileDate = "", string CourtDate = "", string Address1 = "", string Address2 = "", string City = "", string State = "", string Zip = "", string Description = "", string MI = "", string Violation = "", string DateIssue = "", string Salutation = "",
             string Summons = "", string CourtId = "", string Muncipality = "", string Complaint = "", string Title = "", string PaymentType = "", string PaymentTotal = "",
            string PaymentPaid = "", string PaymentBalance = "", string CardNo = "", string ExpDate = "", string CVV = "", string Email = "", string Phone = "", string DOB = "", string Comment = "", string SourceOfCoummunication = "")
        {
            Nj_Detail obj = new Nj_Detail();
            obj.UpdateClient(id, F_Name, LastName, ListType, CourtName, FileDate, CourtDate, Address1, Address2, City, State, Zip, Description, MI, Violation, DateIssue, Salutation, Summons, CourtId, Muncipality, Complaint, Title, PaymentType, PaymentTotal, PaymentPaid, PaymentBalance, CardNo, ExpDate, CVV, Email, Phone, DOB, Comment, Convert.ToInt32(HttpContext.Current.Session["LoginId"]), SourceOfCoummunication);
            return "Client Save Succesfully";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string CashReceipt(int id = 0)
        {
            ClientDetails obj = new ClientDetails();

            string path = obj.GenrateCashScript(id);
            return path;
        }

        public string GenrateCashScript(int id)
        {
            string PathStart = Server.MapPath("/Template");

            if (!Directory.Exists(PathStart))
            {
                Directory.CreateDirectory(PathStart);
            }

            string FolderNameByDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            string path = PathStart + "/" + FolderNameByDate;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Nj_Detail obj = new Nj_Detail();
            var result = obj.ClientDetail(id);


            string FolderNameByUserName = path + "/" + result.F_Name + result.L_Name;
            if (!Directory.Exists(FolderNameByUserName))
            {
                Directory.CreateDirectory(FolderNameByUserName);
            }
            string openpath = "/Template/" + FolderNameByDate + "/" + result.F_Name + result.L_Name + "/" + "CashReceipt" + ".doc";

            string Filename = FolderNameByUserName + "/" + "CashReceipt" + ".doc";
            var doc = DocX.Create(Filename);

            string headerText = "Cash Receipt";
            var titleFormat = new Formatting();
            titleFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
            titleFormat.Size = 20D;
            titleFormat.Position = 12;
            titleFormat.UnderlineColor = new System.Drawing.Color();

            Novacode.Paragraph title = doc.InsertParagraph(headerText, false, titleFormat);
            title.Alignment = Alignment.center;

            string paraOne = ""
                 + "I  ,";

            string paraOne1 = ""
                 + result.F_Name + " " + result.L_Name;

            string paraOne2 = ""
                 + ", have given the Stabile Law"
                 + Environment.NewLine
                 + "Firm, payment in the amount of, ";


            string paraOne3 = ""
                   + "$" + result.Payment_Paid
                   + Environment.NewLine;

            string paraOne4 = ""
                   + ", in cash on ";

            string paraOne5 = ""
                   + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Day.ToString() + "," + DateTime.Now.Year.ToString() + ",";


            string paraOne6 = ""
                   + "for the services " + Environment.NewLine + " rendered on or to be rendered in the matter "
                   + Environment.NewLine
                   + "of ";

            string paraOne7 = ""
                   + result.Summons;

            string paraOne8 = ""
                   + Environment.NewLine + Environment.NewLine
                          + "Balance Due: ";

            string paraOne9 = ""
                   + result.Payment_Balance + ""
                   + Environment.NewLine + Environment.NewLine;

            string paraOne10 = ""
                    + "                                                               _______________________" + "     " + "    " + "    " + "    "
                    + "   " + "    " + "    " + "    "
                    + "." + "                                           " + "                                ";

            string ParaOne11 = ""
                    + result.F_Name + " " + result.L_Name;

            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraFormat.Size = 20D;
            titleFormat.Position = 12;
            doc.InsertParagraph(Environment.NewLine);
            doc.InsertParagraph(Environment.NewLine);
            var p = doc.InsertParagraph("", false, paraFormat);
            p.Append(paraOne).FontSize(19D).Append(paraOne1).Bold().FontSize(19D).Append(paraOne2).FontSize(19D).Append(paraOne3).FontSize(19D).Bold().Append(paraOne4).FontSize(19D).Append(paraOne5).FontSize(19D).Bold().Append(paraOne6).FontSize(19D).Append(paraOne7).FontSize(19D).Bold().Append(paraOne8).FontSize(19D).Append(paraOne9).FontSize(19D).Bold().Append(paraOne10).FontSize(15D).Append(ParaOne11).FontSize(19D).Bold();

            //doc.InsertParagraph(paraOne, false, paraFormat);
            doc.Save();
            obj.ClientCertificateFiles(id, openpath);
            return openpath;
        }


        //[System.Web.Services.WebMethod(EnableSession = true)]
        //public static string CashReceipt(int id = 0)
        //{
        //    ClientDetails obj = new ClientDetails();
        // CashReceipt
        //    string path = obj.GenrateCashScript(id);
        //    return path;
        //}

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string CheckReceipt(int id = 0)
        {
            ClientDetails obj = new ClientDetails();
            string path = obj.GenrateCheckScript(id);
            return path;
        }

        public string GenrateCheckScript(int id)
        {
            string PathStart = Server.MapPath("/Template");
            if (!Directory.Exists(PathStart))
            {
                Directory.CreateDirectory(PathStart);
            }

            string FolderNameByDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            string path = PathStart + "/" + FolderNameByDate;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Nj_Detail obj = new Nj_Detail();
            var result = obj.ClientDetail(id);

            string FolderNameByUserName = path + "/" + result.F_Name + result.L_Name;
            if (!Directory.Exists(FolderNameByUserName))
            {
                Directory.CreateDirectory(FolderNameByUserName);
            }

            string openpath = "/Template/" + FolderNameByDate + "/" + result.F_Name + result.L_Name + "/" + "CheckReceipt" + ".doc";
            string Filename = FolderNameByUserName + "/" + "CheckReceipt" + ".doc";
            var doc = DocX.Create(Filename);

            string headerText = "Check Receipt";
            var titleFormat = new Formatting();
            titleFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
            titleFormat.Size = 20D;
            titleFormat.Position = 12;
            titleFormat.UnderlineColor = new System.Drawing.Color();

            Novacode.Paragraph title = doc.InsertParagraph(headerText, false, titleFormat);
            title.Alignment = Alignment.center;

            string paraOne = ""
                 + "I  ,";

            string paraOne1 = ""
                 + result.F_Name + " " + result.L_Name;

            string paraOne2 = ""
                 + ", have given the Stabile Law"
                 + Environment.NewLine
                 + "Firm, payment in the amount of, "
                 + "$";

            string paraOne3 = ""
                 + result.Payment_Paid
                  + Environment.NewLine;

            string paraOne4 = ""
                 + " , in cash on ";

            string paraOne5 = ""
                 + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Day.ToString() + "," + DateTime.Now.Year.ToString() + ",";


            string paraOne6 = ""
                 + "for the services" + Environment.NewLine + " rendered on or to be rendered in the  matter"
                 + Environment.NewLine
                 + " of  ";

            string paraOne7 = ""
                 + result.Summons
                 + Environment.NewLine + Environment.NewLine;

            string paraOne8 = ""
                 + "  The balance remaining is ";

            string paraOne9 = ""
                 + result.Payment_Balance + ""
                 + Environment.NewLine + Environment.NewLine;
            string paraOne10 = ""
                 + "                            " + "                                                ______________________                 "
                 + ".                                                                               ";
            string paraOne11 = ""
            + result.F_Name + " " + result.L_Name;

            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraFormat.Size = 20D;
            titleFormat.Position = 12;
            doc.InsertParagraph(Environment.NewLine);
            doc.InsertParagraph(Environment.NewLine);

            var p = doc.InsertParagraph("", false, paraFormat);
            p.Append(paraOne).FontSize(19D).Append(paraOne1).Bold().FontSize(19D).Append(paraOne2).FontSize(19D).Append(paraOne3).FontSize(19D).Bold().Append(paraOne4).FontSize(19D).Append(paraOne5).FontSize(19D).Bold().Append(paraOne6).FontSize(19D).Append(paraOne7).FontSize(19D).Bold().Append(paraOne8).FontSize(19D).Append(paraOne9).FontSize(19D).Bold().Append(paraOne10).FontSize(15D).Append(paraOne11).FontSize(19D).Bold();

            //doc.InsertParagraph(paraOne, false, paraFormat);
            doc.Save();
            obj.ClientCertificateFiles(id, openpath);
            return openpath;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string CardAuthorization(int id = 0)
        {
            ClientDetails obj = new ClientDetails();
            string path = obj.CardAuthorizationdoc(id);
            return path;
        }


        public string CardAuthorizationdoc(int id)
        {
            string PathStart = Server.MapPath("/Template");
            if (!Directory.Exists(PathStart))
            {
                Directory.CreateDirectory(PathStart);
            }

            string FolderNameByDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            string path = PathStart + "/" + FolderNameByDate;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Nj_Detail obj = new Nj_Detail();
            var result = obj.ClientDetail(id);

            string FolderNameByUserName = path + "/" + result.F_Name + result.L_Name;
            if (!Directory.Exists(FolderNameByUserName))
            {
                Directory.CreateDirectory(FolderNameByUserName);
            }


            string openpath = "/Template/" + FolderNameByDate + "/" + result.F_Name + result.L_Name + "/" + "CardAuthorization" + ".doc";
            string Filename = FolderNameByUserName + "/" + "CardAuthorization" + ".doc";
            var doc = DocX.Create(Filename);

            string headerText = "Credit Card Authorization";
            var titleFormat = new Formatting();
            titleFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
            titleFormat.Size = 20D;
            titleFormat.Position = 12;
            titleFormat.UnderlineColor = new System.Drawing.Color();
            Novacode.Paragraph title = doc.InsertParagraph(headerText, false, titleFormat);
            title.Alignment = Alignment.center;

            string paraOne = ""
                 + "I  ,";

            string ParaOne1 = ""
                + result.F_Name + " " + result.L_Name;

            string ParaOne2 = ""
                + ", hereby authorize The Law "
                + Environment.NewLine
                + "Firm, LLC. to charge my Visa, MasterCard, or , "
                + Environment.NewLine
                + "American Express, card ";

            string ParaOne3 = ""
                + result.Payment_Cardno
                + Environment.NewLine;

            string ParaOne4 = ""
                + " with expiration date of ";

            string ParaOne5 = ""
               + result.Payment_Card_ExpDate;

            string ParaOne6 = ""
               + ", the amount of ";

            string ParaOne7 = ""
               + "$" + result.Payment_Total + Environment.NewLine
                + ", on " + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Day.ToString() + "," + DateTime.Now.Year.ToString() + ","          //December 23, 2016,
                 ;

            string ParaOne8 = ""
               + "for the services rendered on " + Environment.NewLine + " or to be rendered in the"
               + " matter of ";

            string ParaOne9 = ""
               + result.Summons;

            string ParaOne10 = ""
                + "."
                + Environment.NewLine + Environment.NewLine
                + "                                                          ____________________________" + "     " + "    " + "    " + "    "
                + "   " + "    " + "    " + "    "
                + "." + "                             " + "                                      ";

            string ParaOne11 = ""
            + result.F_Name + " " + result.L_Name;

            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraFormat.Size = 20D;
            titleFormat.Position = 12;
            doc.InsertParagraph(Environment.NewLine);
            doc.InsertParagraph(Environment.NewLine);

            var p = doc.InsertParagraph("", false, paraFormat);
            p.Append(paraOne).FontSize(19D).Append(ParaOne1).Bold().FontSize(19D).Append(ParaOne2).FontSize(19D).Append(ParaOne3).FontSize(19D).Bold().Append(ParaOne4).FontSize(19D).Append(ParaOne5).FontSize(19D).Bold().Append(ParaOne6).FontSize(19D).Append(ParaOne7).FontSize(19D).Bold().Append(ParaOne8).FontSize(19D).Append(ParaOne9).FontSize(19D).Bold().Append(ParaOne10).FontSize(15D).Append(ParaOne11).FontSize(19D).Bold();

            doc.Save();
            obj.ClientCertificateFiles(id, openpath);
            return openpath;
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string LegalServices(int id = 0)
        {
            ClientDetails obj = new ClientDetails();
            string path = obj.LegalServicesdoc(id);
            return path;
        }


        public string LegalServicesdoc(int id)
        {
            string PathStart = Server.MapPath("/Template");
            if (!Directory.Exists(PathStart))
            {
                Directory.CreateDirectory(PathStart);
            }

            string FolderNameByDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            string path = PathStart + "/" + FolderNameByDate;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Nj_Detail obj = new Nj_Detail();
            var result = obj.ClientDetail(id);

            string FolderNameByUserName = path + "/" + result.F_Name + result.L_Name;
            if (!Directory.Exists(FolderNameByUserName))
            {
                Directory.CreateDirectory(FolderNameByUserName);
            }
            string openpath = "/Template/" + FolderNameByDate + "/" + result.F_Name + result.L_Name + "/" + "LegalServices" + ".doc";
            string Filename = FolderNameByUserName + "/" + "LegalServices" + ".doc";
            var doc = DocX.Create(Filename);
            string headerText = "AGREEMENT TO PROVIDE LEGAL SERVICES";
            string SubHeader = "In Municipal Court";
            var titleFormat = new Formatting();
            titleFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            titleFormat.Size = 12D;
            titleFormat.Position = 10;
            titleFormat.UnderlineColor = new System.Drawing.Color();
            Novacode.Paragraph title = doc.InsertParagraph(headerText, false, titleFormat);
            title.Bold();
            title.Alignment = Alignment.center;
            Novacode.Paragraph title1 = doc.InsertParagraph(SubHeader, false, titleFormat);
            title1.Bold();
            title1.Alignment = Alignment.center;
            string paraOne = ""
                + "    THIS AGREEMENT, dated October 12, 2016 is made between the Client,";
            string paraOne1 = ""
                 + " " + result.F_Name + " " + result.L_Name + "";

            string paraOne2 = ""
                + ", whose address is ";


            string paraOne3 = ""
                + result.Address1 + " " + result.ST + " " + result.City + " " + result.ZIP;
            string ParaOne4 = ""
                    + ", referred to as  the “Client” and The Stabile Law Firm, LLC, hereafter referred to as the “Law Firm.”"
                    + Environment.NewLine
                    + "    1. SUBJECT MATTER OF AGREEMENT"
                          + Environment.NewLine
                 + "    a. The “Law Firm” will represent the client in the following matters: Summons "
                 + result.Summons
                  + Environment.NewLine
            + "    b. This Agreement does not obligate the “Law Firm” to appeal on behalf of the client. If the client wishes to appeal, and the “Law Firm” agrees to represent the client, an additional agreement will be entered into for that purpose."
              + Environment.NewLine
            + "    2. LEGAL SERVICES TO BE RENDERED"
            + Environment.NewLine
            + "    a. The legal services to be provided include all necessary court appearances, legal research, investigation, correspondence, preparation of legal documents, trial preparation and all related work required to properly represent the client in this matter."
            + Environment.NewLine
           + "     b. The above legal services will be performed as needed by the “Law Firm” and without need for consultation with or authorization from the client."
           + Environment.NewLine
           + "    3. LEGAL SERVICES NOT COVERED BY THIS AGREEMENT"
           + Environment.NewLine
           + "    This agreement requires that the law firm represent the client with respect to the above subject matter only. Any other matters, except those incidental to and necessarily included with the above matter, must be the subject of a separate agreement between the “Law Firm” and client."
           + Environment.NewLine
           + "    4. CALCULATION OF LEGAL FEES"
          + Environment.NewLine
          + "    Client agrees to pay the law firm a non-refundable flat fee of $";


            string ParaOne5 = ""
            + result.Payment_Total;

            string ParaOne6 = ""
            + " plus costs to negotiate a plea.  Costs may include, but are not limited to, the cost of discovery; transcript fees; and expert fees.   If you elect to pursue a trial, the fee for trial preparation will be an additional $1000.00 for DUI and Disorderly Persons matters and $500.00 for a Traffic Matter.  If a motion is filed, an additional fee of $500.00 will be charged."
          + Environment.NewLine
          + "    Additionally, if the client fails to appear at any scheduled Court date, the attorney can charge an additional $200.00 appearance fee (unless case is done by affidavit). Additionally, if there is an outstanding balance seven (7) days before the scheduled court appearance, the client authorizes the “Law Firm” to charge the remaining balance to his credit or debit card on file without further notification and/or approval."
          + Environment.NewLine
          + "    This agreement is for the summons listed in Paragraph 1.  If the Attorney arrives at court and other summons or complaints are listed on the docket that are not disclosed to Law Firm, an additional fee will be charged for those summons or complaints."
          + Environment.NewLine
                + "    5.	CONTRACTUAL RELATIONSHIP"
          + Environment.NewLine
          + "    “Law Firm” solely owes a legal duty to the Client regardless if a third party has paid any portion of Client’s fee.  In the event that a third party pays any portion of the aforementioned fee owed by the Client, a contractual financial obligation and relationship is hereby established between the “Law Firm” and third party.  In the event that the client defaults on paragraph 4 of this agreement, said third party agrees to act as a surety with respect to the fees owed by the client.  By entering this agreement, Client affirms that they have given third party adequate notice and the third party has freely and voluntarily acknowledged said surety relationship."
          + Environment.NewLine
          + "    6. AUTHORIZATION AND DECISION MAKING"
          + Environment.NewLine
          + "    The “Law Firm” is authorized to take all actions which the law firm deems advisable on behalf of the client. The “Law Firm” agrees to notify the client promptly of all significant developments in this matter and to consult with the client with respect to any significant decisions related to those developments."
          + Environment.NewLine
          + "    7. CLIENT’S RESPONSIBILITY"
          + Environment.NewLine
          + "    The client must fully cooperate with the “Law Firm” in this matter. The client must provide all information relevant to the subject matter of this agreement. Failure of the client to bring documents to court which is critical to a successful outcome may result in an additional fee of $200.00 per additional appearance at the Firm’s discretion. These documents include but are not limited to: driver’s license, vehicle registration, insurance card, driving abstract and restoration documents from the motor vehicle commission."
          + Environment.NewLine
          + "    8. NO GUARANTEED RESULT"
          + Environment.NewLine
          + "    The “Law Firm” shall act on behalf of the client in a courteous, conscientious and diligent manner at all times to achieve solutions which are reasonable and just for the client. However, the “Law Firm” does not guarantee or predict what the final outcome of this matter will be."
          + Environment.NewLine
          + "    9. SUPERVISING COUNSEL"
          + Environment.NewLine
          + "    The client understands that the “Law Firm” employs several attorneys and attorney assignment to the client’s case will be made by the “Law Firm”. The client further understands that the “Law Firm”, on occasion, refers cases to other competent attorneys who are more familiar with a given Court and that on those occasions the referred to “Law Firm” will share in the fee paid by the client."
          + Environment.NewLine
          + "    10. TERMINATION OF SERVICES"
          + Environment.NewLine
          + "    The “Law Firm” may terminate this agreement if the client is in breach of its obligations under this agreement or if the “Law Firm” is otherwise required to do so in accordance with the rules of professional conduct governing attorneys.  Should the client terminate this agreement, and a dispute arises thereon, it is agreed that the “Law Firm” is entitled to minimally receive a fee of $350.00 per hour for time expended on client’s behalf."
          + Environment.NewLine
          + "    11. INFORMATION TO BE MADE AVAILABLE TO THE CLIENT"
          + Environment.NewLine
          + "    The “Law Firm” agrees to make every effort to inform the client at all times as to the status of the matter and as to the acts which are being taken on behalf of the client. The “Law Firm” will make the file available to the client and when possible will send copies of the material to the client at the client’s expense."
          + Environment.NewLine
          + "    Client understands that matters may be resolved expeditiously or may take a long time. Client further understands that attorneys may want to delay their case for tactical reasons and client agrees to be patient and allow the attorneys to do what they believe is the right course of action in getting the most positive result."
          + Environment.NewLine
          + "    12. COMPLETE AGREEMENT"
          + Environment.NewLine
          + "    This writing includes the entire agreement between the client and the law firm regarding this matter. This agreement can only be modified with another written agreement signed by the client and the law firm. This agreement shall be binding upon both, the client and the law firm and their respective heirs, legal representatives and successors in interest."
          + Environment.NewLine
          + "    13. ACKNOWLEDGEMENT OF TERMS"
          + Environment.NewLine
          + "    Client hereby acknowledges that this agreement can be delivered to Client via email, fax, or regular mail.  Client further acknowledges that if agreement is delivered to Client via email, Client agrees to the terms as written by opening the email and reading the agreement even if Client does not physically sign the agreement."
          + Environment.NewLine
          + "    14. SIGNATURES"
          + Environment.NewLine
          + "    Both the client and the “Law Firm” have read and agreed to this agreement. The “Law Firm” has provided the client with answers to any questions and has further explained this agreement to the complete satisfaction of the client. The client has also been given a copy of this agreement."
          + Environment.NewLine + Environment.NewLine
          + "The Stabile Law Firm, LLC"
          + Environment.NewLine
          + "____________________________________       ____________________________________  For: Stabile Law Firm, LLC." + "            " + "                " + "                ";
            string ParaOne7 = ""
            + result.F_Name + " " + result.L_Name
            + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
            title.Alignment = Alignment.center;
            string paratwo = ""
                + Environment.NewLine
                + "I ";

            string paratwo1 = ""
            + result.F_Name + " " + result.L_Name;

            string paratwo2 = ""
            + ", having retained the services of the Stabile Law Firm, LLC., (hereinafter "
            + "referred to as the “Law Firm” ) in connection with matter(s) pending in ";

            string paratwo3 = ""
            + result.Court_Name;

            string paratwo4 = ""
            + " Court(s), hereby agree to comply with the following:"
                  + Environment.NewLine
             + "1.      I must notify the “Law Firm” as soon as I receive a court notice.  Also, I must call to"
             + " confirm court date two (2) days prior to date. If my phone number, email address or address changes, I must notify the firm and the court immediately."
             + Environment.NewLine
             + "2.      I must arrive on time to Court and inquire with Court staff as to check-in procedure (unless case is being handled by affidavit). I understand that the attorney’s may have other courts and may be delayed on arrival to Court.  I should, if asked by Court personnel or judge, indicate that I am pleading Not Guilty and that I am represented by an attorney."
             + Environment.NewLine
             + "3.      I must bring at the very least $200 to Court for possible fines."
             + Environment.NewLine
             + "4.      If I am charged with a Driving While Suspended, I must contact the Motor Vehicle Commission at 609-292-7500 and take all necessary steps to restore my license. I must bring proof in writing from the Motor Vehicle Commission that I am restored and/or in good standing regarding surcharges."
             + Environment.NewLine
             + "5.      If I am charged with any offense pertaining to Driver’s License, Registration and/or Insurance, I must bring original documents to Court"
             + Environment.NewLine
             + "6.      I acknowledge that if I fail to appear at a scheduled Court date, the Law Firm will charge me an additional appearance fee of $200.00 unless case is done by affidavit."
                + Environment.NewLine + Environment.NewLine
             + "Dated:   " + DateTime.Now.ToShortDateString() + "    " + "    " + "    " + "    " + "    " + "          " + "______________________________" + "    " + "    " + "                            " + ".                                              " + "                    " + "               ";

            string paratwo5 = ""
            + result.F_Name + " " + result.L_Name;

            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Times New Roman");
            paraFormat.Size = 12D;
            titleFormat.Position = 6;
            doc.InsertParagraph(Environment.NewLine);
            var p = doc.InsertParagraph("", false, paraFormat);
            p.Append(paraOne).FontSize(12D).Append(paraOne1).Bold().FontSize(12D).Append(paraOne2).FontSize(12D).Append(paraOne3).FontSize(12D).Bold().Append(ParaOne4).FontSize(12D).Append(ParaOne5).FontSize(12D).Bold()
                .Append(ParaOne6).FontSize(12D).Append(ParaOne7).FontSize(12D).Bold();
            string ChildHeader = "CLIENT RESPONSIBILITIES AGREEMENT";
            Novacode.Paragraph title2 = doc.InsertParagraph(ChildHeader, false, titleFormat);
            title2.Bold();
            title2.Alignment = Alignment.center;
            var pp = doc.InsertParagraph("", false, paraFormat);
            pp.Append(paratwo).FontSize(12D).Append(paratwo1).FontSize(12D).Bold().Append(paratwo2).FontSize(12D).Append(paratwo3).FontSize(12D).Bold().Append(paratwo4).FontSize(12D).Append(paratwo5).FontSize(12D).Bold();
            pp.SetLineSpacing(LineSpacingType.Line, 1.3f);
            p.SetLineSpacing(LineSpacingType.Line, 1.3f);
            doc.Save();
            obj.ClientCertificateFiles(id, openpath);
            return openpath;
        }


    }

}