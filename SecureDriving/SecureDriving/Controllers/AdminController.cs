using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecureDriving.Models;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.UI;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


namespace SecureDriving.Controllers
{
    public class AdminController : Controller
    {
        dd_databaseEntities db = new dd_databaseEntities();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserList()
        {
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 1)
            {
                return Redirect("/Home/Video");
            }
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 0)
            {
                return Redirect("/User/NotActiveUser");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 0))
            {
                return Redirect("/Admin/NotActiveAdmin");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 1))
            {

                return View();
            }
            else
            {
                return Redirect("/Home/Login");
            }

        }
        public ActionResult NotActiveAdmin()
        {
            return View();
        }

        public ActionResult UserLists(string SearchName = "", int SearchRole = 0, string SearchStatus = "-1", int page = 0, string sort = "")
        {
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 1)
            {
                return Redirect("/Home/Video");
            }
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 0)
            {
                return Redirect("/User/NotActiveUser");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 0))
            {
                return Redirect("/Admin/NotActiveAdmin");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 1))
            {
                if (page > 0 || !string.IsNullOrEmpty(sort))
                {
                    return PartialView("/Views/Admin/_Userlist.cshtml", Session["UsersList"]);
                }
                var userList = db.video_usuarios.Where(t => (SearchName == "" || t.vfullname.Contains(SearchName) || t.vemail.Contains(SearchName) || t.vcon.Contains(SearchName)) && t.vdeleted == "0" && (SearchRole == 0 || t.nusuariotipo == SearchRole) && (SearchStatus == "-1" || t.vestusuario == SearchStatus)).ToList();
                List<UserList> list = new List<UserList>();
                foreach (var i in userList)
                {
                    list.Add(new UserList
                    {
                        id = i.ncodusua,
                        Name = i.vfullname,
                        password = i.vcon,
                        creationDate = i.vcreation,
                        active = i.vestusuario,
                        Email = i.vemail,
                        Role = i.nusuariotipo,
                        Iscompleted = i.IsCompleted

                    });

                }
                list = list.OrderByDescending(l => l.creationDate).ToList();
                Session["UsersList"] = list;

                return PartialView("/Views/Admin/_Userlist.cshtml", list);
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }

        public ActionResult ActiveDeactiveUser(string id, string SearchName = "", int SearchRole = 0, string SearchStatus = "-1", int page = 0, string sort = "")
        {
            if (id != null)
            {
                int idd = Convert.ToInt32(id);
                var userList = db.video_usuarios.FirstOrDefault(a => a.ncodusua == idd && a.vdeleted == "0");

                if (userList.vestusuario == "1")
                {

                    userList.vestusuario = Convert.ToString(0);
                    db.SaveChanges();
                }
                else
                {
                    userList.vestusuario = Convert.ToString(1);
                    db.SaveChanges();
                    SendEmail(userList.vemail, userList.vcon);
                }

            }
            var list = MethodGetList(SearchName, SearchRole, SearchStatus, page, sort);
            return PartialView("/Views/Admin/_Userlist.cshtml", list);
        }


        public ActionResult DeleteUser(string id, string SearchName = "", int SearchRole = 0, string SearchStatus = "-1", int page = 0, string sort = "")
        {
            if (id != null)
            {
                int idd = Convert.ToInt32(id);
                var userList = db.video_usuarios.FirstOrDefault(a => a.ncodusua == idd);
                userList.vdeleted = Convert.ToString(1);
                db.SaveChanges();
            }
            var list = MethodGetList(SearchName, SearchRole, SearchStatus, page, sort);
            return PartialView("/Views/Admin/_Userlist.cshtml", list);
        }


        public ActionResult DeletedList()
        {
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 1)
            {
                return Redirect("/Home/Video");
            }
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 0)
            {
                return Redirect("/User/NotActiveUser");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 0))
            {
                return Redirect("/Admin/NotActiveAdmin");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 1))
            {
                return View();
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }


        public ActionResult GetDeletedList(string SearchName = "", int SearchRole = 0, string SearchStatus = "-1", int page = 0, string sort = "")
        {
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 1)
            {
                return Redirect("/Home/Video");
            }
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 0)
            {
                return Redirect("/User/NotActiveUser");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 0))
            {
                return Redirect("/Admin/NotActiveAdmin");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 1))
            {
                if (page > 0 || !string.IsNullOrEmpty(sort))
                {
                    return PartialView("/Views/Admin/_DeletedList.cshtml", Session["DeletedList"]);
                }
                var userList = db.video_usuarios.Where(t => (SearchName == "" || t.vfullname.Contains(SearchName) || t.vemail.Contains(SearchName) || t.vcon.Contains(SearchName)) && t.vdeleted == "1" && (SearchRole == 0 || t.nusuariotipo == SearchRole) && (SearchStatus == "-1" || t.vestusuario == SearchStatus)).ToList();
                List<UserList> list = new List<UserList>();
                foreach (var i in userList)
                {
                    list.Add(new UserList
                    {
                        id = i.ncodusua,
                        Name = i.vfullname,
                        password = i.vcon,
                        creationDate = i.vcreation,
                        active = i.vestusuario,
                        Email = i.vemail

                    });
                    list = list.OrderByDescending(l => l.creationDate).ToList();
                    Session["DeletedList"] = list;
                }
                return PartialView("/Views/Admin/_DeletedList.cshtml", list);
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }


        public ActionResult UserReturnToList(int id = 0, string SearchName = "", int SearchRole = 0, string SearchStatus = "-1", int page = 0, string sort = "")
        {
            if (id != 0)
            {
                var userList = db.video_usuarios.FirstOrDefault(a => a.ncodusua == id);
                userList.vdeleted = Convert.ToString(0);
                db.SaveChanges();
            }
            List<UserList> list = MethodGetDeletedList(SearchName, SearchRole, SearchStatus, page, sort);
            return PartialView("/Views/Admin/_DeletedList.cshtml", list);
        }


        public ActionResult UserPermanentDeleted(int id = 0, string SearchName = "", int SearchRole = 0, string SearchStatus = "-1", int page = 0, string sort = "")
        {
            if (id != 0)
            {
                var userList = db.video_usuarios.FirstOrDefault(a => a.ncodusua == id);
                db.video_usuarios.Remove(userList);
                db.SaveChanges();
            }
            List<UserList> list = MethodGetDeletedList(SearchName, SearchRole, SearchStatus, page, sort);
            return PartialView("/Views/Admin/_DeletedList.cshtml", list);
        }


        public List<UserList> MethodGetDeletedList(string SearchName = "", int SearchRole = 0, string SearchStatus = "-1", int page = 0, string sort = "")
        {
            if (page > 0 || !string.IsNullOrEmpty(sort))
            {
                return Session["SearchResultdeletedList"] as List<UserList>;
            }
            else
            {
                var userList = db.video_usuarios.Where(t => (SearchName == "" || t.vfullname.Contains(SearchName) || t.vemail.Contains(SearchName) || t.vcon.Contains(SearchName)) && t.vdeleted == "1" && (SearchRole == 0 || t.nusuariotipo == SearchRole) && (SearchStatus == "-1" || t.vestusuario == SearchStatus)).ToList();

                List<UserList> list = new List<UserList>();
                foreach (var i in userList)
                {
                    list.Add(new UserList
                    {
                        id = i.ncodusua,
                        Name = i.vfullname,
                        password = i.vcon,
                        creationDate = i.vcreation,
                        active = i.vestusuario,
                        Email = i.vemail
                    });
                }
                list = list.OrderByDescending(l => l.creationDate).ToList();
                Session["SearchResultdeletedList"] = list;
                return list;
            }
        }

        public ActionResult GenrateStudentInfoPdf(int id)
        {
            CreateStudentInfoPDF(id);
            string path = "/NewPDF/" + "/" + id + ".pdf";
            return File(path, "application/pdf");
        }

        public void CreateStudentInfoPDF(int id)
        {
            var userList = db.video_usuarios.FirstOrDefault(a => a.ncodusua == id);
            var doc = new Document(PageSize.A4, 50, 50, 5, 5);

            //PdfWriter.GetInstance(doc, new FileStream("D:/VK/SecureDriving/SecureDriving/PDF/" + "/"+ id +".pdf", FileMode.Create));
            PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("/NewPDF/" + "/" + id + ".pdf"), FileMode.Create));

            // Set the page size
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            doc.Open();

            iTextSharp.text.Image myImg = iTextSharp.text.Image.GetInstance(Server.MapPath("/img/PdfDefensive.jpg"));
            myImg.Alignment = Element.ALIGN_LEFT;
            myImg.ScaleToFit(800, 800);

            doc.Add(myImg);
            string htmlText = @"<html><title></title>
              <head>
</head>
<body>
<p>
<div><table border=""1"" style='width:100%;'>
<thead>
</thead>
             <tbody>
                      
                    <tr >
                        <td align='center' colspan=""2""> Name</td>
 <td  align='center' colspan=""2""> Complete Address</td>
  <td  align='center' colspan=""2"" >NJ Drivers License No</td>
  <td  align='center'>Sex</td>
  <td  align='center'>Date Of Birth</td>
 <td  align='center'>Eye Color</td>
                
                    </tr>
<tr>
<td align='center' colspan=""2"">&nbsp; " + userList.vfullname + @" </td>
<td align='center'colspan=""2""> &nbsp; " + userList.Address + "," + userList.State + "," + userList.City + "," + userList.Zip + @" </td>
<td align='center' colspan=""2""> &nbsp; " + userList.NJDL_ + @" </td>
<td align='center'>  &nbsp; " + userList.Gender + @"</td>
<td align='center'> &nbsp; " + Convert.ToDateTime(userList.DOB).ToShortDateString() + @" </td>
<td align='center'> &nbsp; " + userList.EyeColor + @" </td>
        </tr>
<tr>
<td colspan=""2"">&nbsp;  </td>
<td colspan=""2""> &nbsp; </td>
<td  colspan=""2""> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp;  </td>
        </tr>

<tr>
<td colspan=""2"">&nbsp;  </td>
<td colspan=""2""> &nbsp; </td>
<td  colspan=""2""> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp;  </td>

        </tr>

<tr>
<td colspan=""2"">&nbsp;  </td>
<td colspan=""2""> &nbsp; </td>
<td  colspan=""2""> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp;  </td>
        </tr>

<tr>
<td colspan=""2"">&nbsp;  </td>
<td colspan=""2""> &nbsp; </td>
<td  colspan=""2""> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp;  </td>

        </tr>

<tr>
<td colspan=""2"">&nbsp;  </td>
<td colspan=""2""> &nbsp; </td>
<td  colspan=""2""> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp;  </td>

        </tr>

<tr>
<td colspan=""2"">&nbsp;  </td>
<td colspan=""2""> &nbsp; </td>
<td  colspan=""2""> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp;  </td>

        </tr>

<tr>
<td colspan=""2"">&nbsp;  </td>
<td colspan=""2""> &nbsp; </td>
<td  colspan=""2""> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp;  </td>

        </tr>
<tr>
<td colspan=""2"">&nbsp;  </td>
<td colspan=""2""> &nbsp; </td>
<td  colspan=""2""> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp;  </td>

        </tr>
<tr>
<td colspan=""2"">&nbsp;  </td>
<td colspan=""2""> &nbsp; </td>
<td  colspan=""2""> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp;  </td>
        </tr>
<tr>
<td colspan=""2"">&nbsp;  </td>
<td colspan=""2""> &nbsp; </td>
<td  colspan=""2""> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp; </td>
<td> &nbsp;  </td>
        </tr>
   </tbody>
</table >
</p>
<p>Numbers of Student Completing __________________________________</p></n>
<table  style='width:100%;'>
<thead>
</thead>
             <tbody>
                      
                    <tr >
                      
 <td colspan=""4"">Mail report Plus $8 student to : USA Training, P.O Box 26309, Austin,TX 78766-0309 </td>
                
                    </tr>
</tbody>
</table>
        </div>
</body>
<html>
";
            iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(doc);
            hw.Parse(new StringReader(htmlText));
            doc.Close();

        }

        public ActionResult GenratePdf(int id)
        {
            CreatePdf(id);
            //string path = "D:/VK/SecureDriving/SecureDriving/PDF/" + "/" +id +".pdf";
            string path = "/PDF/" + "/" + id + ".pdf";
            return File(path, "application/pdf");
        }
        public void CreatePdf(int id)
        {
            var userList = db.video_usuarios.FirstOrDefault(a => a.ncodusua == id);

            string path = Server.MapPath("PDF");
            //  var doc = new Document(PageSize.A4, 50, 50, 70, 50);
            //var doc = new Document(new Rectangle(288f, 144f), 50, 50, 70, 50); 
            var doc = new Document(PageSize.A4, 50, 50, 110, 50);

            //PdfWriter.GetInstance(doc, new FileStream("D:/VK/SecureDriving/SecureDriving/PDF/" + "/"+ id +".pdf", FileMode.Create));
            PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("/PDF/" + "/" + id + ".pdf"), FileMode.Create));

            // ...initialize 'doc'...

            // Set the page size
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            doc.Open();

            iTextSharp.text.Image myImg = iTextSharp.text.Image.GetInstance(Server.MapPath("/img/PdfLogo1.jpg"));
            myImg.Alignment = Element.ALIGN_CENTER;
            myImg.ScaleToFit(900, 900);

            doc.Add(myImg);


            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;

            table.DefaultCell.Border = Rectangle.TOP_BORDER;


            table.AddCell("Name:");
            table.AddCell(userList.vfullname);

            table.AddCell("DL#:");
            table.AddCell("346dh475fhg47");
            PdfPCell cellBlankRow = new PdfPCell(new Phrase(" "));
            cellBlankRow.Colspan = 2;


            cellBlankRow.Border = Rectangle.NO_BORDER;
            cellBlankRow.HorizontalAlignment = 2;
            table.AddCell(cellBlankRow);
            table.AddCell("");
            table.AddCell("");



            table.AddCell("Address:");
            table.AddCell("dsfghjfdgjdghd");

            table.AddCell("Course Complition Date:");
            string date = Convert.ToString(DateTime.Now.ToShortDateString());
            table.AddCell(date);

            PdfPCell cellBlankRows = new PdfPCell(new Phrase(" "));
            cellBlankRows.Colspan = 2;
            cellBlankRows.Border = Rectangle.NO_BORDER;
            table.AddCell(cellBlankRows);
            table.AddCell("");
            table.AddCell("");

            table.AddCell("City State Zip:");
            table.AddCell("Newyork");

            table.AddCell("Instructor Signature:");
            table.AddCell("fghfghgf");
            //myImg.Alignment = Element.ALIGN_LEFT;
            //doc.Add(table);


            //     String htmlText = "<font  " +
            //" color=\"#0000FF\"><b><i>Title One</i></b></font><font   " +
            //" color=\"black\"><br><br>Some text here<br><br><br><font   " +
            //" color=\"#0000FF\"><b><i>Another title here   " +
            //" </i></b></font><font   " +
            //" color=\"black\"><br><br>Text1<br>Text2<br><OL><LI><DIV Style='color:green'>Pham Duy Hoa</DIV></LI><LI>how are u</LI></OL><br/>" +
            //"<table border='1'><tr><td style='color:red;text-align:right;width:20%'>123456</td><td style='color:green;width:60%'>78910</td><td style='color:red;width:20%'>ASFAFA</td></tr><tr><td style='color:red;text-align:right'>123456</td><td style='color:green;width:60%'>78910</td><td style='color:red;width:20%'>DAFSDGAFW</td></tr></table><br/>" +
            //"<div><ol><li>123456</li><li>123456</li><li>123456</li><li>123456</li></ol></div>";

            string htmlText = " <table   width='880'   style='border-spacing:0px;border:1px' class='contact'>" +
                //"<tr> " +
                //"<td colspan='2'>___________________________________________________________</td>" +
                //"<td colspan='2'>___________________________________________________________</td>" +
                //"</tr>" +
                "<tr class='name'> " +
                "<td  ><h3><b>Name</b></h3></td>" +
                "<td ><h3><span class='name12'>" + userList.vfullname + "</span></h3></td>" +
                "<td ><h3><b>DL#</b> </h3></td>" +
                "<td ><h3> <span class='name12'> " + userList.NJDL_ + "</span></h3></td>" +
                "</tr>" +
                "<tr class='name' >" +
                "<td ><h3><b>Address</b></h3></td>" +
                "<td><h3><span class='name12'> " + userList.Address + "</span></h3></td>" +
                "<td><h3><b>Course Completion Date</b> </h3></td>" +
                "<td><h3> <span class='name12'> " + DateTime.Now.ToShortDateString() + "</span></h3></td>" +
                "</tr>" +
                "<tr class='name' >" +
                "<td  ><h3><b>City State Zip</b></h3></td>" +
                "<td><h3><span class='name12'> " + userList.City + "," + userList.State + "," + userList.Zip + "</span></h3></td>" +
                "<td><h3><b>Instructor Signature</b> </h3></td>" +
                "<td><h3> <span class='name12'> </span></h3></td>" +
                "</tr>" +
                "</table>";
            //String htmlText = " <div class='contact' style='display:inline-table'><div class='name'  style='width:40%; float:left;'><h3><b>Name</b> <span class='name12'> Dharmander</span></h3><h3><b>Address</b> <span class='name12'> Dharmander</span></h3> <h3><b>City State Zip</b> <span class='name12'> Dharmander</span></h3></div><div class='name' style='width:40%; float:left;'><h3><b>DL#</b> <span class='name12'> Dharmander</span></h3><h3><b>Course Completion Date</b> <span class='name12'> Dharmander</span></h3></div> </div>";
            iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(doc);
            hw.Parse(new StringReader(htmlText));
            //doc.Add(table);
            doc.Close();
        }

        public ActionResult PrintStudentInfo(int id)
        {
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 1)
            {
                return Redirect("/Home/Video");
            }
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 0)
            {
                return Redirect("/User/NotActiveUser");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 0))
            {
                return Redirect("/Admin/NotActiveAdmin");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 1))
            {
                var userList = db.video_usuarios.FirstOrDefault(a => a.ncodusua == id);
                UserList list = new UserList();
                id = userList.ncodusua;
                list.Name = userList.vfullname;
                list.Address = userList.Address;
                list.NJDL_ = userList.NJDL_;
                list.state = userList.State;
                list.city = userList.City;
                list.Zip = userList.Zip;
                return View(list);
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }
        public ActionResult Reports()
        {
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 1)
            {
                return Redirect("/Home/Video");
            }
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 0)
            {
                return Redirect("/User/NotActiveUser");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 0))
            {
                return Redirect("/Admin/NotActiveAdmin");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 1))
            {
                return View();
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }
        public ActionResult SearchReports(String SearchItem = "0", int page = 0, string sort = "")
        {
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 1)
            {
                return Redirect("/Home/Video");
            }
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 0)
            {
                return Redirect("/User/NotActiveUser");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 0))
            {
                return Redirect("/Admin/NotActiveAdmin");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 1))
            {

                var list = GetreportBysearch(SearchItem, page, sort);
                list = list.OrderByDescending(l => l.creationDate).ToList();
                Session["reportlist"] = list;
                return PartialView("/Views/Admin/_Reports.cshtml", list);
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }

        public List<UserList> MethodGetList(string SearchName = "", int SearchRole = 0, string SearchStatus = "-1", int page = 0, string sort = "")
        {

            if (page > 0 || !string.IsNullOrEmpty(sort))
            {
                return Session["UserlistAfterActivate"] as List<UserList>;
            }
            else
            {
                var userLists = db.video_usuarios.Where(t => (SearchName == "" || t.vfullname.Contains(SearchName) || t.vemail.Contains(SearchName) || t.vcon.Contains(SearchName)) && t.vdeleted == "0" && (SearchRole == 0 || t.nusuariotipo == SearchRole) && (SearchStatus == "-1" || t.vestusuario == SearchStatus)).ToList();
                List<UserList> list = new List<UserList>();
                foreach (var i in userLists)
                {
                    list.Add(new UserList
                    {
                        id = i.ncodusua,
                        Name = i.vfullname,
                        password = i.vcon,
                        creationDate = i.vcreation,
                        active = i.vestusuario,
                        Email = i.vemail,
                        Role = i.nusuariotipo,
                        Iscompleted = i.IsCompleted
                    });
                }
                list = list.OrderByDescending(l => l.creationDate).ToList();
                Session["UserlistAfterActivate"] = list;
                return list;
            }
        }


        public ActionResult ActiveUserOnReportList(string id, String SearchItem = "0", int page = 0, string sort = "")
        {
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 1)
            {
                return Redirect("/Home/Video");
            }
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 0)
            {
                return Redirect("/User/NotActiveUser");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 0))
            {
                return Redirect("/Admin/NotActiveAdmin");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 1))
            {
                if (id != null)
                {
                    int idd = Convert.ToInt32(id);
                    var userList = db.video_usuarios.FirstOrDefault(a => a.ncodusua == idd && a.vdeleted == "0");

                    if (userList.vestusuario == "1")
                    {

                        userList.vestusuario = Convert.ToString(0);
                    }
                    else
                    {
                        userList.vestusuario = Convert.ToString(1);
                    }
                    db.SaveChanges();
                }
                var list = GetreportBysearch(SearchItem, page, sort);
                return PartialView("/Views/Admin/_Reports.cshtml", list);
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }
        public List<UserList> GetreportBysearch(String SearchItem = "0", int page = 0, string sort = "")
        {
            if (page > 0 || !string.IsNullOrEmpty(sort))
            {
                return Session["reportlist"] as List<UserList>;
            }
            else
            {
                DateTime startdate = DateTime.Now;
                DateTime LastDate = DateTime.Now;
                UserList user = new UserList();

                switch (SearchItem)
                {
                    //Today
                    case ("1"):
                        startdate = DateTime.Today;
                        LastDate = DateTime.Now;
                        break;
                    //Yesterday
                    case ("2"):
                        startdate = DateTime.Today.AddDays(-1);
                        LastDate = DateTime.Today;
                        break;
                    //ThisWeek
                    case ("3"):
                        startdate = user.StartOfWeek(DateTime.Now);
                        LastDate = DateTime.Now;
                        break;
                    //ThisMonth
                    case ("4"):
                        startdate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        LastDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                        break;
                    //ThisQuarter
                    case ("5"):
                        var f = (decimal)(DateTime.Now.Month - 1) / 3;
                        var s = (int)Math.Floor(f) * 3 + 1;
                        var e = (int)(Math.Floor(f) + 1) * 3;
                        startdate = new DateTime(DateTime.Now.Year, s, 1);
                        LastDate = new DateTime(DateTime.Now.Year, e, DateTime.DaysInMonth(DateTime.Now.Year, e));
                        break;
                    //This Year
                    case ("6"):
                        var year = DateTime.Now.Year;
                        startdate = new DateTime(year, 1, 1);
                        LastDate = new DateTime(year, 12, DateTime.DaysInMonth(year, 12));
                        break;
                    //LastWeek
                    case ("7"):
                        startdate = user.StartOfWeek(DateTime.Now).AddDays(-7);
                        LastDate = user.EndOfWeek(DateTime.Now).AddDays(-7);
                        break;
                    //LastTwoWeeks
                    case ("8"):
                        startdate = user.StartOfWeek(DateTime.Now).AddDays(-14);
                        LastDate = user.EndOfWeek(DateTime.Now).AddDays(-7);
                        break;
                    //LastMonth
                    case ("9"):
                        var g = DateTime.Today.AddMonths(-1);
                        startdate = new DateTime(g.Year, g.Month, 1);
                        LastDate = new DateTime(g.Year, g.Month, DateTime.DaysInMonth(g.Year, g.Month));
                        break;
                    //LastTwoMonths
                    case ("10"):
                        var b = DateTime.Today.AddMonths(-2);
                        startdate = new DateTime(b.Year, b.Month, 1);
                        LastDate = new DateTime(b.Year, (b.AddMonths(1)).Month, DateTime.DaysInMonth(b.Year, (b.AddMonths(1)).Month));
                        break;
                    //PastSixMonths
                    case ("11"):
                        startdate = DateTime.Now.AddMonths(-6);
                        LastDate = DateTime.Now;
                        break;
                    //LastYear
                    case ("12"):
                        var yr = DateTime.Now.Year - 1;
                        startdate = new DateTime(yr, 1, 1);
                        LastDate = new DateTime(yr, 12, 31);
                        break;
                    default:
                        startdate = new DateTime(1900, 1, 1);
                        LastDate = DateTime.Now;
                        break;
                }

                var query = (from a in db.video_usuarios
                             where (a.vcreation <= LastDate) && (a.vcreation >= startdate) && a.vdeleted == "0"
                             select a).ToList();
                List<UserList> list = new List<UserList>();
                foreach (var i in query)
                {
                    list.Add(new UserList
                    {
                        id = i.ncodusua,
                        Name = i.vfullname,
                        password = i.vcon,
                        creationDate = i.vcreation,
                        active = i.vestusuario,
                        Email = i.vemail

                    });
                }
                list = list.OrderByDescending(l => l.creationDate).ToList();
                Session["reportlist"] = list;
                return list;
            }
        }

        public ActionResult ChangeRole(string id, string SearchName = "", int SearchRole = 0, string SearchStatus = "-1", int page = 0, string sort = "")
        {
            if (id != null)
            {
                int idd = Convert.ToInt32(id);
                var userList = db.video_usuarios.FirstOrDefault(a => a.ncodusua == idd && a.vdeleted == "0");

                if (userList.nusuariotipo == 1)
                {

                    userList.nusuariotipo = 2;
                }
                else
                {
                    userList.nusuariotipo = 1;
                }
                db.SaveChanges();
            }
            var list = MethodGetList(SearchName, SearchRole, SearchStatus, page, sort);
            return PartialView("/Views/Admin/_Userlist.cshtml", list);
        }

        public ActionResult UserInfo(int id)
        {
            var userList = db.video_usuarios.FirstOrDefault(a => a.ncodusua == id);
            var date = String.Format("{0:d/M/yyyy}", userList.DOB);
            UserList list = new UserList();
            id = userList.ncodusua;
            list.Name = userList.vfullname;
            list.PhoneNo = userList.vphone;
            list.Gender = userList.Gender;
            list.Address = userList.Address;
            list.NJDL_ = userList.NJDL_;
            list.state = userList.State;
            list.city = userList.City;
            list.Zip = userList.Zip;
            list.Email = userList.vemail;
            list.DOB = userList.DOB;
            list.password = userList.vcon;
            list.creationDate = userList.vcreation;
            list.ShowDateOfBirth = date;
            list.EyeColor = userList.EyeColor;
            return View(list);
        }

        public string SendEmail(string Email = "", string pwd = "")
        {
            string result = "";
            string to = Email;
            string from = "ddschool@newjerseydefensivedriving.net";
            string body = "<h2>Activation Completed Successfully</h2>";
            body = body + "<p><b>Email: </b>" + Email + "</p><p><b>Password: </b>" + pwd + "  </p>";
            MailMessage mail = new MailMessage(from, to);
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.newjerseydefensivedriving.net";
            mail.Subject = "User Activated at NewJersey Defensive Driving School";
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.CC.Add(new MailAddress("ddschool@stabilelawfirm.com"));
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

        public ActionResult UserCompletedCourse()
        {
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 1)
            {
                return Redirect("/Home/Video");
            }
            if (Convert.ToInt32(Session["LoginId"]) > 0 && Convert.ToInt32(Session["UserRoll"]) == 1 && Convert.ToInt32(Session["UserActive"]) == 0)
            {
                return Redirect("/User/NotActiveUser");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 0))
            {
                return Redirect("/Admin/NotActiveAdmin");
            }
            if (Convert.ToInt32(Session["UserRoll"]) == 2 && (Convert.ToInt32(Session["LoginId"]) > 0) && (Convert.ToInt32(Session["UserActive"]) == 1))
            {
                return View();
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }

        public ActionResult UserCompletedCourseList(String SearchItem = "0")
        {
            DateTime startdate = DateTime.Now;
            DateTime LastDate = DateTime.Now;
            UserList user = new UserList();

            switch (SearchItem)
            {
                //Today
                case ("1"):
                    startdate = DateTime.Today;
                    LastDate = DateTime.Now;
                    break;
                //Yesterday
                case ("2"):
                    startdate = DateTime.Today.AddDays(-1);
                    LastDate = DateTime.Today;
                    break;
                //ThisWeek
                case ("3"):
                    startdate = user.StartOfWeek(DateTime.Now);
                    LastDate = DateTime.Now;
                    break;
                //ThisMonth
                case ("4"):
                    startdate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    LastDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                    break;
                //ThisQuarter
                case ("5"):
                    var f = (decimal)(DateTime.Now.Month - 1) / 3;
                    var s = (int)Math.Floor(f) * 3 + 1;
                    var e = (int)(Math.Floor(f) + 1) * 3;
                    startdate = new DateTime(DateTime.Now.Year, s, 1);
                    LastDate = new DateTime(DateTime.Now.Year, e, DateTime.DaysInMonth(DateTime.Now.Year, e));
                    break;
                //This Year
                case ("6"):
                    var year = DateTime.Now.Year;
                    startdate = new DateTime(year, 1, 1);
                    LastDate = new DateTime(year, 12, DateTime.DaysInMonth(year, 12));
                    break;
                //LastWeek
                case ("7"):
                    startdate = user.StartOfWeek(DateTime.Now).AddDays(-7);
                    LastDate = user.EndOfWeek(DateTime.Now).AddDays(-7);
                    break;
                //LastTwoWeeks
                case ("8"):
                    startdate = user.StartOfWeek(DateTime.Now).AddDays(-14);
                    LastDate = user.EndOfWeek(DateTime.Now).AddDays(-7);
                    break;
                //LastMonth
                case ("9"):
                    var g = DateTime.Today.AddMonths(-1);
                    startdate = new DateTime(g.Year, g.Month, 1);
                    LastDate = new DateTime(g.Year, g.Month, DateTime.DaysInMonth(g.Year, g.Month));
                    break;
                //LastTwoMonths
                case ("10"):
                    var b = DateTime.Today.AddMonths(-2);
                    startdate = new DateTime(b.Year, b.Month, 1);
                    LastDate = new DateTime(b.Year, (b.AddMonths(1)).Month, DateTime.DaysInMonth(b.Year, (b.AddMonths(1)).Month));
                    break;
                //PastSixMonths
                case ("11"):
                    startdate = DateTime.Now.AddMonths(-6);
                    LastDate = DateTime.Now;
                    break;
                //LastYear
                case ("12"):
                    var yr = DateTime.Now.Year - 1;
                    startdate = new DateTime(yr, 1, 1);
                    LastDate = new DateTime(yr, 12, 31);
                    break;
                default:
                    startdate = new DateTime(1900, 1, 1);
                    LastDate = DateTime.Now;
                    break;
            }

            bool iscompleted = Convert.ToBoolean(1);
            var query = (from a in db.video_usuarios
                         where (a.CourseCompletedDate <= LastDate || (a.CourseCompletedDate == null && startdate == new DateTime(1900, 1, 1))) && (a.CourseCompletedDate >= startdate || (a.CourseCompletedDate == null && startdate == new DateTime(1900, 1, 1))) && a.vdeleted == "0" && a.IsCompleted == iscompleted
                         select a).ToList();
            List<UserList> list = new List<UserList>();
            foreach (var i in query)
            {
                list.Add(new UserList
                { 
                    id = i.ncodusua,
                    Name = i.vfullname,
                    password = i.vcon,
                    //creationDate = i.vcreation,
                    active = i.vestusuario,
                    Email = i.vemail,
                    creationDate = i.CourseCompletedDate,

                });
            }
            list = list.OrderByDescending(l => l.creationDate).ToList();
            return PartialView("/Views/Admin/_UserCompletedCourse.cshtml", list);
        }
        [HttpPost]
        public ActionResult CheckedUserList(string List)
        {
            string[] a = List.Split(',');
            CreateStudentCertificateCompleted(a);
            string path = "/NewPDF/" + "/" + "StudentsCertificate" + ".pdf";
            //return File(path, "application/pdf");

            return Json(path, JsonRequestBehavior.AllowGet);
        }

        public void CreateStudentCertificateCompleted(string[] a)
        {
            var doc = new Document(PageSize.A4, 50, 50, 5, 5);
            PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("/NewPDF/" + "/" + "StudentsCertificate" + ".pdf"), FileMode.Create));
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            doc.Open();

            iTextSharp.text.Image myImg = iTextSharp.text.Image.GetInstance(Server.MapPath("/img/PdfDefensive.jpg"));
            myImg.Alignment = Element.ALIGN_LEFT;
            myImg.ScaleToFit(800, 800);
            doc.Add(myImg);
            string row = "";
            string footer = @"</tbody>
           </table >
           </p>
           <p>Numbers of Student Completing  : &nbsp; " + a.Count() + @"</p></n>
         <table  style='width:100%;'>
            <thead>
            </thead>
             <tbody>
                    <tr >
                       <td colspan=""4"">Mail report Plus $8 student to : USA Training, P.O Box 26309, Austin,TX 78766-0309 </td>
                    </tr>
              </tbody>
        </table>
        </div>
      </body>
      <html>";
            foreach (var item in a)
            {
                int id = Convert.ToInt32(item);
                var userList = db.video_usuarios.FirstOrDefault(x => x.ncodusua == id);
                row = row + @"<tr>
                    <td align='center' colspan=""2"">&nbsp; " + userList.vfullname + @" </td>
                     <td align='center'colspan=""2""> &nbsp; " + ((userList.DOB != null) ? userList.Address + "," + userList.State + "," + userList.City + "," + userList.Zip : "") + @" </td>
                       <td align='center' colspan=""2""> &nbsp; " + userList.NJDL_ + @" </td>
                         <td align='center'>  &nbsp; " + userList.Gender + @"</td>
                           <td align='center'> &nbsp; " + ((userList.DOB != null) ? Convert.ToDateTime(userList.DOB).ToShortDateString() : "") + @" </td>
                             <td align='center'> &nbsp; " + userList.EyeColor + @" </td>
                                </tr>";
            }
            string htmlText = @"<html><title></title>
              <head>
                </head>
                 <body>
                     <p>
                       <div><table border=""1"" style='width:100%;'>
                 <thead>
                 </thead>
             <tbody>
                    <tr >
                        <td align='center' colspan=""2""> Name</td>
                         <td  align='center' colspan=""2""> Complete Address</td>
                            <td  align='center' colspan=""2"" >NJ Drivers License No</td>
                              <td  align='center'>Sex</td>
                                <td  align='center'>Date Of Birth</td>
                                  <td  align='center'>Eye Color</td>
                   </tr>" + row + footer;
            iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(doc);
            hw.Parse(new StringReader(htmlText));
            doc.Close();
        }

        public ActionResult CompletedCourse(string id ="", string SearchName = "", int SearchRole = 0, string SearchStatus = "-1", int page = 0, string sort = "")
        {
            if (id != "")
            {
                int LoginId = Convert.ToInt32(id);
                var userList = db.video_usuarios.FirstOrDefault(a => a.ncodusua == LoginId);
                userList.CourseCompletedDate = DateTime.Now;
                userList.IsCompleted = Convert.ToBoolean(1);
                db.SaveChanges();
            }
                var list = MethodGetList(SearchName, SearchRole, SearchStatus, page, sort);
                return PartialView("/Views/Admin/_Userlist.cshtml", list);
        }                                       
    }
}

