using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel.Model;
using OfficeOpenXml;
using System.IO;
using System.Data;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;



namespace Excel
{
    public partial class Clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HdnUserRole.Value = Convert.ToString(Request.Cookies["LoginRole"].Value);
            //Ece();
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<Nj_Detail> ClientList(string Search = "", string id = "", int PageIndex = 0, string sDate = "", string eDate = "")
        {
            Nj_Detail obj = new Nj_Detail();
            var nj = obj.ClientList(Search, id, sDate, eDate);

            // for paging
            // int PageIndex;
            int PageSize = 15;
            int skip = PageIndex * PageSize;
            double PageCount = Convert.ToDouble(Math.Ceiling((double)((double)nj.Count() / (double)PageSize)));
            List<Nj_Detail> query = nj.Skip(skip).Take(PageSize).ToList();
            // end paging
            return query;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<Nj_Detail> PrintClients(string Search = "", string id = "", string sDate = "", string eDate = "")
        {
            Nj_Detail obj = new Nj_Detail();
            var nj = obj.ClientList(Search, id, sDate, eDate);
            return nj;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static NJ_Clients ClientDetail(int id = 0)
        {
            Nj_Detail obj = new Nj_Detail();
            var result = obj.ClientDetail(id);
            return result;
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<Nj_Detail> DropdownList(string Search = "", string id = "", string sDate = "", string eDate = "")
        {
            Nj_Detail obj = new Nj_Detail();
            var nj = obj.ClientList(Search, id, sDate, eDate);

            //  List<Nj_Detail> distinct = nj.GroupBy(n => n.IsAddedBy).Select(g => g.First()).ToList();


            List<Nj_Detail> result = nj.GroupBy(l => l.IsAddedBy).Select(cl => new Nj_Detail
               {
                   IsAddedBy = cl.First().IsAddedBy,
                   IsaddedbyFirstName = cl.First().IsaddedbyFirstName,
                   Payment_Balance = cl.Sum(c => c.Payment_Balance),
                   Payment_Paid = cl.Sum(c => c.Payment_Paid),
                   Payment_Total = cl.Sum(c => c.Payment_Total),
               }).ToList();


            return result;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<Nj_Detail> AddedByDropdownList()
        {
            Nj_Detail obj = new Nj_Detail();
            var nj = obj.BindDropdownAddedBy();

            //  List<Nj_Detail> distinct = nj.GroupBy(n => n.IsAddedBy).Select(g => g.First()).ToList();


            List<Nj_Detail> result = nj.GroupBy(l => l.IsAddedBy).Select(cl => new Nj_Detail
            {
                IsAddedBy = cl.First().IsAddedBy,
                IsaddedbyFirstName = cl.First().IsaddedbyFirstName

            }).ToList();
            return result;
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string ClientTodayReport(string Search = "")
        {
            Nj_Detail obj = new Nj_Detail();
            var nj = obj.ClientList(Search);
            DataSet p_dsSrc = new DataSet();
            DataTable dt = new DataTable("MyTable");
            //dt.Columns.Add(new DataColumn("id", typeof(int)));
            dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dt.Columns.Add(new DataColumn("LastName", typeof(string)));
            //dt.Columns.Add(new DataColumn("State", typeof(string)));
            dt.Columns.Add(new DataColumn("City", typeof(string)));
            dt.Columns.Add(new DataColumn("TotalPayment", typeof(float)));
            dt.Columns.Add(new DataColumn("Paid", typeof(float)));
            dt.Columns.Add(new DataColumn("Balance", typeof(float)));
            dt.Columns.Add(new DataColumn("AddedBy", typeof(string)));
            //dt.Columns.Add(new DataColumn("Source of communication", typeof(string)));
            DataRow dr = dt.NewRow();
            double PaymentTotal = 0;
            double PaymentPaid = 0;
            double PaymentBalance = 0;

            foreach (var item in nj)
            {
                dr = dt.NewRow();
                dr["FirstName"] = item.F_Name;
                dr["LastName"] = item.L_Name;
                //dr["State"] = item.ST;
                dr["City"] = item.Muncipality;
                dr["AddedBy"] = item.IsaddedbyFirstName;
                //dr["Source of communication"] = item.SourceComm;
                if (item.Payment_Total != null)
                {
                    dr["TotalPayment"] = item.Payment_Total;
                    PaymentTotal = PaymentTotal + Convert.ToDouble(item.Payment_Total);
                }
                else
                {
                    dr["TotalPayment"] = 0;
                }
                if (item.Payment_Paid != null)
                {
                    PaymentPaid = PaymentPaid + Convert.ToDouble(item.Payment_Paid);
                    dr["Paid"] = item.Payment_Paid;
                }
                else
                {
                    dr["Paid"] = 0;
                }
                if (item.Payment_Balance != null)
                {
                    PaymentBalance = PaymentBalance + Convert.ToDouble(item.Payment_Balance);
                    dr["Balance"] = item.Payment_Balance;
                }
                else
                {
                    dr["Balance"] = 0;
                }
                dt.Rows.Add(dr);
            }

            for (int i = 0; i <= 4; i++)
            {
                if (i < 4)
                {
                    dt.Rows.Add();
                }
                else
                {
                    dr = dt.NewRow();
                    dr["City"] = "Total";
                    dr["TotalPayment"] = PaymentTotal;
                    dr["Paid"] = PaymentPaid;
                    dr["Balance"] = PaymentBalance;
                    dt.Rows.Add(dr);
                }
            }
            p_dsSrc.Tables.Add(dt);
            Clients objClients = new Clients();
            int GetTotalRow = nj.Count();
            GetTotalRow = GetTotalRow + 6;
            string Filepath = objClients.GenrateEcelTodayReport(p_dsSrc, GetTotalRow);
            string Result = objClients.SendClientsEmail(Filepath);
            return Result;
        }

        //Genrate Excel file
        public string GenrateEcelTodayReport(DataSet p_dsSrc, int GetTotalRow)
        {
            string PathStart = System.Web.HttpContext.Current.Server.MapPath("/ClientExcel");
            if (!System.IO.Directory.Exists(PathStart))
            {
                System.IO.Directory.CreateDirectory(PathStart);
            }
            string FolderNameByDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            string p_strPath = System.Web.HttpContext.Current.Server.MapPath("/ClientExcel/" + "/" + "clients" + FolderNameByDate + ".xlsx");
            using (ExcelPackage objExcelPackage = new ExcelPackage())
            {
                foreach (DataTable dtSrc in p_dsSrc.Tables)
                {
                    //Create the worksheet    
                    ExcelWorksheet objWorksheet = objExcelPackage.Workbook.Worksheets.Add(dtSrc.TableName);
                    //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1    
                    objWorksheet.Cells["A1"].LoadFromDataTable(dtSrc, true);
                    objWorksheet.Cells.Style.Font.SetFromFont(new Font("Calibri", 11));
                    objWorksheet.Cells.AutoFitColumns();
                    objWorksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    objWorksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    //Format the header    
                    using (ExcelRange objRange = objWorksheet.Cells["A1:XFD1"])
                    {
                        objRange.Style.Font.Bold = true;
                        objRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        objRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        objRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        objRange.Style.Fill.BackgroundColor.SetColor(Color.White);
                    }

                    // Style of Total Payment In ExcelSheet 
                    ExcelRange objRangeCellTotal = objWorksheet.Cells[GetTotalRow, 3];
                    objRangeCellTotal.Style.Font.Bold = true;
                    objRangeCellTotal.Style.Font.Size = 12;

                    ExcelRange objRangePaymentTotal = objWorksheet.Cells[GetTotalRow, 4];
                    objRangePaymentTotal.Style.Font.Bold = true;
                    objRangePaymentTotal.Style.Font.Size = 12;
                    objRangePaymentTotal.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    objRangePaymentTotal.Style.Fill.BackgroundColor.SetColor(Color.GreenYellow);

                    ExcelRange objRangePaymentPaid = objWorksheet.Cells[GetTotalRow, 5];
                    objRangePaymentPaid.Style.Font.Bold = true;
                    objRangePaymentPaid.Style.Font.Size = 12;
                    objRangePaymentPaid.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    objRangePaymentPaid.Style.Fill.BackgroundColor.SetColor(Color.GreenYellow);

                    ExcelRange objRangePaymentBalance = objWorksheet.Cells[GetTotalRow, 6];
                    objRangePaymentBalance.Style.Font.Bold = true;
                    objRangePaymentBalance.Style.Font.Size = 12;
                    objRangePaymentBalance.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    objRangePaymentBalance.Style.Fill.BackgroundColor.SetColor(Color.Red);
                }

                //Create excel file on physical disk    
                FileStream objFileStrm = File.Create(p_strPath);
                objFileStrm.Close();

                //Write content to excel file    
                File.WriteAllBytes(p_strPath, objExcelPackage.GetAsByteArray());
                return p_strPath;
            }
        }

        public string SendClientsEmail(string Filepath)
        {
            string result = "";
            string body = "Clients report of " + DateTime.Now.ToShortDateString();
            string to = "moriundo@stabilelawfirm.com";
            string from = "joriundo@stabilelawfirm.com";
            MailMessage mail = new MailMessage(from, to);
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.newjerseydefensivedriving.net";
            mail.Subject = "Today's Clients Report";
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
                result = "Today's Clients Report Successfully Sent";
            }
            catch (Exception ex)
            {
                result = ex.Message + "....... Inner exception is: " + ex.InnerException;
            }
            return result;
        }
    }
}