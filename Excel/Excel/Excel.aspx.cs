
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel;
using System.IO;
using System.Data.OleDb;
using OfficeOpenXml;
using System.Web.UI;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;


namespace Excel
{
    public partial class Excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(Session["LoginRole"]) != 1)
            //{
            //    Response.Redirect("Logins.aspx");
            //}

        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                string _imgname = string.Empty;
                var imgPath2 = string.Empty;

                if (Request.Files.Count > 10)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "bootbox.alert", "bootbox.alert('Please choose 10 files only')", true);
                }
                else
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFile PostedFile = Request.Files[i];
                        if (PostedFile.ContentLength > 0)
                        {
                            var file = PostedFile;
                            //   var file = System.Web.HttpContext.Current.Request.Files["file"];
                            if (file.FileName != "")
                            {
                                string fileName = file.FileName;
                                string fileContentType = file.ContentType;
                                var _ext = Path.GetExtension(file.FileName);
                                _imgname = Guid.NewGuid().ToString();
                                var _comPath = Server.MapPath("/ExcelFiles/") + _imgname + _ext;
                                var imgPath = "/ExcelFiles/" + _imgname + _ext;
                                imgPath2 = "/ExcelFiles/" + _imgname + _ext;
                                var path = _comPath;
                                file.SaveAs(path);
                                DataSet ds = new DataSet();
                                string excelConnectionString = string.Empty;
                                string FilePath = path;
                                if (_ext == ".xls")
                                {
                                    excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                                         FilePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";

                                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                                   
                                    excelConnection.Open();                                    
                                    DataTable dt = new DataTable();

                                    dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                    String[] excelSheets = new String[dt.Rows.Count];
                                    int t = 0;
                                    //excel data saves in temp file here.
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        excelSheets[t] = row["TABLE_NAME"].ToString();
                                        t++;
                                    }
                                    OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);                                  
                                    string query = string.Format("Select * from [{0}]", excelSheets[0]);                                   
                                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                                    {
                                        dataAdapter.Fill(ds);
                                    }

                                    int column = ds.Tables[0].Columns.Count;
                                   
                                    NJTicketEntities db = new NJTicketEntities();
                                    ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 0;
                                   // var data = ds.GetXml();
                                    NJ_Details details = new NJ_Details();
                                    if (column == 18)
                                    {
                                        for (int n = 0; n < ds.Tables[0].Rows.Count; n++)
                                        {
                                            details.List_Type = ds.Tables[0].Rows[n]["ListType"].ToString();
                                            details.File_Date = ds.Tables[0].Rows[n]["FileDate"].ToString();
                                            details.Court_Name = ds.Tables[0].Rows[n]["CourtName"].ToString();
                                            details.CourtDate = ds.Tables[0].Rows[n]["CourtDate"].ToString();
                                            details.L_Name = ds.Tables[0].Rows[n]["LName"].ToString();
                                            details.F_Name = ds.Tables[0].Rows[n]["FName"].ToString();
                                            details.MI = ds.Tables[0].Rows[n]["MI"].ToString();
                                            details.Address1 = ds.Tables[0].Rows[n]["Addr1"].ToString();
                                            details.Address2 = ds.Tables[0].Rows[n]["Addr2"].ToString();
                                            details.City = ds.Tables[0].Rows[n]["City"].ToString();
                                            details.ST = ds.Tables[0].Rows[n]["ST"].ToString();
                                            details.ZIP = ds.Tables[0].Rows[n]["Zip"].ToString();
                                            details.DOB = ds.Tables[0].Rows[n]["DOB"].ToString();
                                            details.Violation = ds.Tables[0].Rows[n]["Violation"].ToString();
                                            details.Description = ds.Tables[0].Rows[n]["Description"].ToString();
                                            details.DateIssued = ds.Tables[0].Rows[n]["DateIssued"].ToString();
                                            details.Salutation = ds.Tables[0].Rows[n]["Salutation"].ToString();
                                            details.Summons = ds.Tables[0].Rows[n]["Summons"].ToString();

                                            //details.NJ_CourtID = ds.Tables[0].Rows[n]["NJCourtID"].ToString();
                                            //details.Muncipality = ds.Tables[0].Rows[n]["Municipality"].ToString();
                                            //details.Complaint = ds.Tables[0].Rows[n]["Complaint"].ToString();
                                            //details.Title = ds.Tables[0].Rows[n]["Title"].ToString();
                                            db.NJ_Details.Add(details);
                                            db.SaveChanges();
                                        }
                                        //db.Materials_new(data,"0");
                                        //db.Database.ExecuteSqlCommand("exec Materials @JobMaterialsXml", new SqlParameter("@JobMaterialsXml", data));
                                    }
                                    else
                                    {
                                        for (int n = 0; n < ds.Tables[0].Rows.Count; n++)
                                        {
                                            details.List_Type = ds.Tables[0].Rows[n]["ListType"].ToString();
                                            details.File_Date = ds.Tables[0].Rows[n]["FileDate"].ToString();
                                            details.Court_Name = ds.Tables[0].Rows[n]["CourtName"].ToString();
                                            details.CourtDate = ds.Tables[0].Rows[n]["CourtDate"].ToString();
                                            details.L_Name = ds.Tables[0].Rows[n]["LName"].ToString();
                                            details.F_Name = ds.Tables[0].Rows[n]["FName"].ToString();
                                            details.MI = ds.Tables[0].Rows[n]["MI"].ToString();
                                            details.Address1 = ds.Tables[0].Rows[n]["Addr1"].ToString();
                                            details.Address2 = ds.Tables[0].Rows[n]["Addr2"].ToString();
                                            details.City = ds.Tables[0].Rows[n]["City"].ToString();
                                            details.ST = ds.Tables[0].Rows[n]["ST"].ToString();
                                            details.ZIP = ds.Tables[0].Rows[n]["Zip"].ToString();
                                            details.DOB = ds.Tables[0].Rows[n]["DOB"].ToString();
                                            details.Violation = ds.Tables[0].Rows[n]["Violation"].ToString();
                                            details.Description = ds.Tables[0].Rows[n]["Description"].ToString();
                                            details.DateIssued = ds.Tables[0].Rows[n]["DateIssued"].ToString();
                                            details.Salutation = ds.Tables[0].Rows[n]["Salutation"].ToString();
                                            details.Summons = ds.Tables[0].Rows[n]["Summons"].ToString();

                                            details.NJ_CourtID = ds.Tables[0].Rows[n]["NJCourtID"].ToString();
                                            details.Muncipality = ds.Tables[0].Rows[n]["Municipality"].ToString();
                                            details.Complaint = ds.Tables[0].Rows[n]["Complaint"].ToString();
                                            details.Title = ds.Tables[0].Rows[n]["Title"].ToString();
                                            db.NJ_Details.Add(details);
                                            db.SaveChanges();
                                        }
                                       // db.Materials_new(data,"1");
                                       // db.Database.ExecuteSqlCommand("exec Materials @JobMaterialsXml,@Tableid", new SqlParameter("@JobMaterialsXml", data), new SqlParameter("@Tableid", 1));
                                    }
                                }
                                else
                                {
                                    NJTicketEntities db = new NJTicketEntities();
                                    ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 0;
                                    NJ_Details da = new NJ_Details();
                                    byte[] fileBytes = new byte[file.ContentLength];
                                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

                                    using (var package = new ExcelPackage(file.InputStream))
                                    {
                                        var currentSheet = package.Workbook.Worksheets;
                                        var workSheet = currentSheet.First();
                                        var noOfCol = workSheet.Dimension.End.Column;
                                        var noOfRow = workSheet.Dimension.End.Row;

                                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                        {

                                            {
                                                if (workSheet.Cells[rowIterator, 1].Value != null)
                                                {
                                                    da.List_Type = workSheet.Cells[rowIterator, 1].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.List_Type = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 2].Value != null)
                                                {
                                                    da.File_Date = workSheet.Cells[rowIterator, 2].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.File_Date = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 3].Value != null)
                                                {
                                                    da.Court_Name = workSheet.Cells[rowIterator, 3].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.Court_Name = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 4].Value != null)
                                                {
                                                    da.CourtDate = workSheet.Cells[rowIterator, 4].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.CourtDate = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 5].Value != null)
                                                {
                                                    da.L_Name = workSheet.Cells[rowIterator, 5].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.L_Name = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 6].Value != null)
                                                {
                                                    da.F_Name = workSheet.Cells[rowIterator, 6].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.F_Name = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 7].Value != null)
                                                {
                                                    da.MI = workSheet.Cells[rowIterator, 7].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.MI = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 8].Value != null)
                                                {
                                                    da.Address1 = workSheet.Cells[rowIterator, 8].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.Address1 = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 9].Value != null)
                                                {
                                                    da.Address2 = workSheet.Cells[rowIterator, 9].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.Address2 = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 10].Value != null)
                                                {
                                                    da.City = workSheet.Cells[rowIterator, 10].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.City = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 11].Value != null)
                                                {
                                                    da.ST = workSheet.Cells[rowIterator, 11].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.ST = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 12].Value != null)
                                                {
                                                    da.ZIP = workSheet.Cells[rowIterator, 12].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.ZIP = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 13].Value != null)
                                                {
                                                    da.DOB = workSheet.Cells[rowIterator, 13].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.DOB = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 14].Value != null)
                                                {
                                                    da.Violation = workSheet.Cells[rowIterator, 14].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.Violation = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 15].Value != null)
                                                {
                                                    da.Description = workSheet.Cells[rowIterator, 15].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.Description = "";
                                                }

                                                if (workSheet.Cells[rowIterator, 16].Value != null)
                                                {
                                                    da.DateIssued = workSheet.Cells[rowIterator, 16].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.DateIssued = "";
                                                }

                                                if (workSheet.Cells[rowIterator, 17].Value != null)
                                                {
                                                    da.Salutation = workSheet.Cells[rowIterator, 17].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.Salutation = "";
                                                }
                                                if (workSheet.Cells[rowIterator, 18].Value != null)
                                                {
                                                    da.Summons = workSheet.Cells[rowIterator, 18].Value.ToString();
                                                }
                                                else
                                                {
                                                    da.Summons = "";
                                                }
                                                da.IsUser = Convert.ToBoolean(0);
                                                db.NJ_Details.Add(da);
                                                db.SaveChanges();
                                            }
                                        }
                                    }
                                }
                            }
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "bootbox.alert", "bootbox.alert('User details saved sucessfully')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "bootbox.alertMessage", "bootbox.alert('Please Select a File')", true);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    }
}