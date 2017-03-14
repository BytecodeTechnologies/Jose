using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Excel.Model
{
    public class Nj_Detail
    {
        NJTicketEntities db = new NJTicketEntities();

        public int Id { get; set; }
        public string List_Type { get; set; }
        public string File_Date { get; set; }
        public string Court_Name { get; set; }
        public string CourtDate { get; set; }
        public string L_Name { get; set; }
        public string F_Name { get; set; }
        public string MI { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ST { get; set; }
        public string ZIP { get; set; }
        public string DOB { get; set; }
        public string Violation { get; set; }
        public string Description { get; set; }
        public string DateIssued { get; set; }
        public string Salutation { get; set; }
        public string Summons { get; set; }
        public Nullable<bool> IsUser { get; set; }
        public string NJ_CourtID { get; set; }
        public string Muncipality { get; set; }
        public string Complaint { get; set; }
        public string Title { get; set; }
        public string Payment_Type { get; set; }
        public Nullable<double> Payment_Total { get; set; }
        public Nullable<double> Payment_Paid { get; set; }
        public Nullable<double> Payment_Balance { get; set; }
        public Nullable<System.DateTime> MarkClientDate { get; set; }
        public string Payment_Cardno { get; set; }
        public string Payment_Card_ExpDate { get; set; }
        public Nullable<int> Payment_CVV { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsPotentialClient { get; set; }
        public bool IsDeleted { get; set; }
        public string Comment { get; set; }
        public Nullable<int> IsAddedBy { get; set; }


        public string IsaddedbyFirstName { get; set; }
        public string IsaddedbyLastName { get; set; }
        public int TotalRecords { get; set; }

        public string FullName { get; set; }
        public string SourceComm { get; set; }
        public bool IsPotential { get; set; }

        //public int clientID { get; set; }
        public string fileCertificatePath { get; set; }

        public bool IsClient(int id = 0)
        {
            return db.NJ_Clients.Any(cl => cl.Id == id && cl.IsPotentialClient == false);
        }


        public NJ_Details UserDetail(int id = 0)
        {

            var result1 = db.NJ_Details.FirstOrDefault(a => a.Id == id);
            return result1;
        }
        public NJ_Clients UserDetailFromClient(int id = 0)
        {
            var result2 = db.NJ_Clients.FirstOrDefault(a => a.Id == id);
            return result2;
        }
        public List<Nj_Detail> UserList(string Column = "", string SearchItem = "")
        {

            List<Nj_Detail> nj = new List<Nj_Detail>();
            List<string> njs = new List<string>();
            if (Column == "F_Name")
            {
                var result = (((from s in db.NJ_Clients
                                where (s.F_Name.Contains(SearchItem))
                                select new
                                {
                                    Id = s.Id,
                                    firstname = s.F_Name,
                                    LastName = s.L_Name,
                                    Address = s.Address1,
                                    city = s.City,
                                    state = s.ST,
                                    IsUser = s.IsUser,
                                    Summons = s.Summons,
                                    IsPotential = true
                                }).Union((from s in db.NJ_Details
                                          where (s.F_Name.Contains(SearchItem))
                                          select new
                                          {
                                              Id = s.Id,
                                              firstname = s.F_Name,
                                              LastName = s.L_Name,
                                              Address = s.Address1,
                                              city = s.City,
                                              state = s.ST,
                                              IsUser = s.IsUser,
                                              Summons = s.Summons,
                                              IsPotential = false
                                          }))).Distinct().ToList());
                result = result.GroupBy(x => new { x.firstname, x.LastName, x.city, x.state, x.Summons }).Select(y => y.First()).ToList();
                foreach (var item in result)
                {
                    nj.Add(new Nj_Detail
                    {
                        Id = item.Id,
                        F_Name = item.firstname,
                        L_Name = item.LastName,
                        City = item.city,
                        ST = item.state,
                        IsUser = item.IsUser,
                        FullName = item.firstname + item.LastName + item.city + item.state,
                        IsPotential = item.IsPotential

                    });
                }
            }

            else if (Column == "L_Name")
            {
                var result =
                    (((from s in db.NJ_Clients
                       where (s.L_Name.Contains(SearchItem))
                       select new
                       {
                           Id = s.Id,
                           firstname = s.F_Name,
                           LastName = s.L_Name,
                           city = s.City,
                           state = s.ST,
                           IsUser = s.IsUser,
                           Summons = s.Summons,
                           IsPotential = true
                       }).ToList()).Union((from s in db.NJ_Details
                                           where (s.L_Name.Contains(SearchItem))
                                           select new
                                           {
                                               Id = s.Id,
                                               firstname = s.F_Name,
                                               LastName = s.L_Name,
                                               city = s.City,
                                               state = s.ST,
                                               IsUser = s.IsUser,
                                               Summons = s.Summons,
                                               IsPotential = false
                                           }).ToList()));
                result = result.GroupBy(x => new { x.firstname, x.LastName, x.city, x.state, x.Summons }).Select(y => y.First()).ToList();
                foreach (var item in result)
                {
                    nj.Add(new Nj_Detail
                    {
                        Id = item.Id,
                        F_Name = item.firstname,
                        L_Name = item.LastName,
                        City = item.city,
                        ST = item.state,
                        IsUser = item.IsUser,
                        FullName = item.firstname + item.LastName + item.city + item.state,
                        IsPotential = item.IsPotential

                    });
                }
            }

            else if (Column == "ST")
            {
                var data = (((from s in db.NJ_Clients
                              where (s.ST.Contains(SearchItem))
                              select new
                              {
                                  Id = s.Id,
                                  firstname = s.F_Name,
                                  LastName = s.L_Name,
                                  Address = s.Address1,
                                  city = s.City,
                                  state = s.ST,
                                  IsUser = s.IsUser,
                                  Summons = s.Summons,
                                  IsPotential = true
                              }).ToList()).Union((from s in db.NJ_Details
                                                  where (s.ST.Contains(SearchItem))
                                                  select new
                                                  {
                                                      Id = s.Id,
                                                      firstname = s.F_Name,
                                                      LastName = s.L_Name,
                                                      Address = s.Address1,
                                                      city = s.City,
                                                      state = s.ST,
                                                      IsUser = s.IsUser,
                                                      Summons = s.Summons,
                                                      IsPotential = false
                                                  }).ToList()));
                data = data.GroupBy(x => new { x.firstname, x.LastName, x.city, x.state, x.Summons }).Select(y => y.First()).ToList();
                foreach (var item in data)
                {
                    nj.Add(new Nj_Detail
                    {
                        Id = item.Id,
                        F_Name = item.firstname,
                        L_Name = item.LastName,
                        City = item.city,
                        ST = item.state,
                        IsUser = item.IsUser,
                        FullName = item.firstname + item.LastName + item.city + item.state,
                        IsPotential = item.IsPotential
                    });
                }
            }
            else if (Column == "City")
            {
                var data = (((from s in db.NJ_Clients
                              where (s.City.Contains(SearchItem))
                              select new
                              {
                                  Id = s.Id,
                                  firstname = s.F_Name,
                                  LastName = s.L_Name,
                                  Address = s.Address1,
                                  city = s.City,
                                  state = s.ST,
                                  IsUser = s.IsUser,
                                  Summons = s.Summons,
                                  IsPotential = true
                              }).ToList()).Union((from s in db.NJ_Details
                                                  where (s.City.Contains(SearchItem))
                                                  select new
                                                  {
                                                      Id = s.Id,
                                                      firstname = s.F_Name,
                                                      LastName = s.L_Name,
                                                      Address = s.Address1,
                                                      city = s.City,
                                                      state = s.ST,
                                                      IsUser = s.IsUser,
                                                      Summons = s.Summons,
                                                      IsPotential = false
                                                  }).ToList()));
                data = data.GroupBy(x => new { x.firstname, x.LastName, x.city, x.state, x.Summons }).Select(y => y.First()).ToList();
                foreach (var item in data)
                {
                    nj.Add(new Nj_Detail
                    {
                        Id = item.Id,
                        F_Name = item.firstname,
                        L_Name = item.LastName,
                        City = item.city,
                        ST = item.state,
                        IsUser = item.IsUser,
                        FullName = item.firstname + item.LastName + item.city + item.state,
                        IsPotential = item.IsPotential

                    });
                }
            }
            else if (Column == "Full")
            {
                var data = (((from s in db.NJ_Clients
                              where ((s.F_Name + " " + s.L_Name).Contains(SearchItem))
                              select new
                              {
                                  Id = s.Id,
                                  firstname = s.F_Name,
                                  LastName = s.L_Name,
                                  Address = s.Address1,
                                  city = s.City,
                                  state = s.ST,
                                  IsUser = s.IsUser,
                                  Summons = s.Summons,
                                  IsPotential = true
                              }).ToList()).Union((from s in db.NJ_Details
                                                  where ((s.F_Name + " " + s.L_Name).Contains(SearchItem))
                                                  select new
                                                  {
                                                      Id = s.Id,
                                                      firstname = s.F_Name,
                                                      LastName = s.L_Name,
                                                      Address = s.Address1,
                                                      city = s.City,
                                                      state = s.ST,
                                                      IsUser = s.IsUser,
                                                      Summons = s.Summons,
                                                      IsPotential = false
                                                  }).ToList()));
                data = data.GroupBy(x => new { x.firstname, x.LastName, x.city, x.state, x.Summons }).Select(y => y.First()).ToList();
                foreach (var item in data)
                {
                    nj.Add(new Nj_Detail
                    {
                        Id = item.Id,
                        F_Name = item.firstname,
                        L_Name = item.LastName,
                        City = item.city,
                        ST = item.state,
                        IsUser = item.IsUser,
                        FullName = item.firstname + item.LastName + item.city + item.state,
                        IsPotential = item.IsPotential

                    });
                }
            }

            // nj = nj.ToList().Distinct().Select(x => x.FullName);
            return nj;
        }
        public void MakeClient(string id = "", string Type = "", string Total = "", string Paid = "", string Balance = "", string Cardno = "", string CardExpireyDate = "", string CVV = "", string Phone = "", string Email = "", string PotentialClient = "", string comment = "", int LoginId = 0,
              string FName = "", string LName = "", string CourtName = "", string Address1 = "", string Address2 = "", string City = "", string State = "", string Zip = "",
                   string Description = "", string DOB = "", string MI = "", string Violation = "", string Dateissued = "", string Salutation = "", string Summons = "",
                    string CourtID = "", string Muncipality = "", string Complaint = "", string Title = "", string ListType = "", string SourceComm = "", string AddedBy = "")
        {
            NJTicketEntities db = new NJTicketEntities();

            NJ_Clients objNj_Client = new NJ_Clients();
            objNj_Client.List_Type = ListType;
            //objNj_Client.File_Date = result.File_Date;
            objNj_Client.Court_Name = CourtName;
            //objNj_Client.CourtDate = CourtDate;
            objNj_Client.L_Name = LName;
            objNj_Client.F_Name = FName;
            objNj_Client.MI = MI;
            objNj_Client.Address1 = Address1;
            objNj_Client.Address2 = Address2;
            objNj_Client.City = City;
            objNj_Client.ST = State;
            objNj_Client.ZIP = Zip;
            objNj_Client.DOB = DOB;
            objNj_Client.Violation = Violation;
            objNj_Client.Description = Description;
            objNj_Client.DateIssued = Dateissued;
            objNj_Client.Salutation = Salutation;
            objNj_Client.Summons = Summons;
            objNj_Client.NJ_CourtID = CourtID;
            objNj_Client.Muncipality = Muncipality;
            objNj_Client.Complaint = Complaint;
            objNj_Client.Title = Title;
            objNj_Client.Payment_Type = Type;
            objNj_Client.SourceOfComm = SourceComm;

            if (Total != "")
            {
                objNj_Client.Payment_Total = Convert.ToInt32(Total);
            }
            if (Paid != "")
            {
                objNj_Client.Payment_Paid = Convert.ToInt32(Paid);
            }
            if (Balance != "")
            {
                objNj_Client.Payment_Balance = Convert.ToInt32(Balance);
            }

            objNj_Client.Payment_Cardno = Cardno;
            objNj_Client.Payment_Card_ExpDate = CardExpireyDate;
            objNj_Client.MarkClientDate = DateTime.Now;
            objNj_Client.Phone = Phone;
            objNj_Client.Email = Email;

            if (CVV != "")
            {
                objNj_Client.Payment_CVV = Convert.ToInt32(CVV);
            }
            int addedBy = Convert.ToInt32(AddedBy);
            objNj_Client.IsAddedBy = addedBy;
            objNj_Client.IsPotentialClient = Convert.ToBoolean(PotentialClient);
            //if (objNj_Client.IsPotentialClient == false)
            //{
            //    objNj_Client.IsAddedBy = LoginId;
            //}
            //    objNj_Client.Comment = comment;
            db.NJ_Clients.Add(objNj_Client);
            if (id != "")
            {
                int ids = Convert.ToInt32(id);
                var result = db.NJ_Details.FirstOrDefault(a => a.Id == ids);
                result.IsUser = true;
            }
            db.SaveChanges();
            var comments = comment.Trim();
            if (comments != "" && comment != null)
            {
                var Insertid = objNj_Client.Id;
                NJ_tblComment objtblcomment = new NJ_tblComment();
                objtblcomment.Comment = comment;
                objtblcomment.UserId = Insertid;
                objtblcomment.Comment_By = LoginId;
                objtblcomment.Comment_Date = DateTime.Now;
                db.NJ_tblComment.Add(objtblcomment);
                db.SaveChanges();
            }
        }



        public List<Nj_Detail> ClientList(string Search = "", string id = "", string sDate = "", string eDate = "")
        {
            DateTime startdate = DateTime.Now;
            DateTime LastDate = DateTime.Now;
            //UserList user = new UserList();

            switch (Search)
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
                //case ("13"):
                //    startdate = DateTime.Today.AddDays(-2);
                //    LastDate = DateTime.Today.AddDays(-1);
                //    break;
                //ThisWeek
                case ("3"):
                    startdate = StartOfWeek(DateTime.Now);
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
                    startdate = StartOfWeek(DateTime.Now).AddDays(-7);
                    LastDate = EndOfWeek(DateTime.Now).AddDays(-7);
                    break;
                //LastTwoWeeks
                case ("8"):
                    startdate = StartOfWeek(DateTime.Now).AddDays(-14);
                    LastDate = EndOfWeek(DateTime.Now).AddDays(-7);
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
                //Custom
                case ("14"):
                    startdate = Convert.ToDateTime(sDate);
                    LastDate = Convert.ToDateTime(eDate).AddHours(24);
                    break;
                default:
                    startdate = new DateTime(1900, 1, 1);
                    LastDate = DateTime.Now;
                    break;
            }
            List<Nj_Detail> objnjdetail = new List<Nj_Detail>();
            if (id != "")
            {
                int ids = Convert.ToInt32(id);
                var query = (from a in db.NJ_Clients
                             where (a.IsPotentialClient == false && a.IsDeleted == false && a.IsAddedBy == ids && a.MarkClientDate <= LastDate || (a.MarkClientDate == null && startdate == new DateTime(1900, 1, 1))) && (a.MarkClientDate >= startdate || (a.MarkClientDate == null && startdate == new DateTime(1900, 1, 1)))
                             select new Nj_Detail
                             {
                                 Id = a.Id,
                                 L_Name = a.L_Name,
                                 F_Name = a.F_Name,
                                 ST = a.ST,
                                 City = a.City,
                                 Muncipality= a.Muncipality,
                                 SourceComm = a.SourceOfComm,
                                 Payment_Total = a.Payment_Total,
                                 Payment_Paid = a.Payment_Paid,
                                 Payment_Balance = a.Payment_Balance,
                                 IsAddedBy = a.IsAddedBy,
                                 MarkClientDate = a.MarkClientDate,
                                 IsaddedbyFirstName = db.NJ_User.FirstOrDefault(c => c.tblUserId == a.IsAddedBy).First_Name,
                                 IsaddedbyLastName = db.NJ_User.FirstOrDefault(c => c.tblUserId == a.IsAddedBy).Last_Name,
                                 TotalRecords = (from a2 in db.NJ_Clients
                                                 where (a2.IsPotentialClient == false && a2.IsDeleted == false && a2.IsAddedBy == ids && a2.MarkClientDate <= LastDate || (a2.MarkClientDate == null && startdate == new DateTime(1900, 1, 1))) && (a2.MarkClientDate >= startdate || (a2.MarkClientDate == null && startdate == new DateTime(1900, 1, 1)))
                                                 select a2).Count()
                             }).ToList();
                var data = query.OrderByDescending(x => x.MarkClientDate).ToList();
                return data;
            }
            else
            {
                var query = (from a in db.NJ_Clients
                             where (a.IsPotentialClient == false && a.IsDeleted == false && a.MarkClientDate <= LastDate || (a.MarkClientDate == null && startdate == new DateTime(1900, 1, 1))) && (a.MarkClientDate >= startdate || (a.MarkClientDate == null && startdate == new DateTime(1900, 1, 1)))
                             select new Nj_Detail
                             {
                                 Id = a.Id,
                                 L_Name = a.L_Name,
                                 F_Name = a.F_Name,
                                 ST = a.ST,
                                 City = a.City,
                                 Muncipality = a.Muncipality,
                                 Payment_Total = a.Payment_Total,
                                 Payment_Paid = a.Payment_Paid,
                                 Payment_Balance = a.Payment_Balance,
                                 IsAddedBy = a.IsAddedBy,
                                 SourceComm = a.SourceOfComm,
                                 MarkClientDate = a.MarkClientDate,
                                 IsaddedbyFirstName = db.NJ_User.FirstOrDefault(c => c.tblUserId == a.IsAddedBy).First_Name,
                                 IsaddedbyLastName = db.NJ_User.FirstOrDefault(c => c.tblUserId == a.IsAddedBy).Last_Name,
                                 TotalRecords = (from a2 in db.NJ_Clients
                                                 where (a2.IsPotentialClient == false && a2.IsDeleted == false && a2.MarkClientDate <= LastDate || (a2.MarkClientDate == null && startdate == new DateTime(1900, 1, 1))) && (a2.MarkClientDate >= startdate || (a2.MarkClientDate == null && startdate == new DateTime(1900, 1, 1)))
                                                 select a2).Count()
                             }).ToList();


                var data = query.OrderByDescending(x => x.MarkClientDate).ToList();
                return data;
            }

        }

        public NJ_Clients ClientDetail(int id = 0)
        {

            var result = db.NJ_Clients.FirstOrDefault(a => a.Id == id);           
            return result;
        }

        public void ClientCertificateFiles(int id, string filePath)
        {
            var no = db.tbl_CertificateFiles.FirstOrDefault(s => s.Nj_ClientsID == id && s.FilePath==filePath);
            if (no == null)
            {
                tbl_CertificateFiles file_path = new tbl_CertificateFiles();
                file_path.FilePath = filePath;
                file_path.Nj_ClientsID = id;
                file_path.CreatedDate = DateTime.Now.Date;
                db.tbl_CertificateFiles.Add(file_path);
                db.SaveChanges();
            }
            else
            {               
                    db.Entry(no).State = System.Data.EntityState.Deleted;
                    db.SaveChanges();
                    tbl_CertificateFiles file_path = new tbl_CertificateFiles();
                    file_path.FilePath = filePath;
                    file_path.Nj_ClientsID = id;
                    file_path.CreatedDate = DateTime.Now.Date;
                    db.tbl_CertificateFiles.Add(file_path);
                    db.SaveChanges();                
            }
        }

        public void UpdateClient(string id = "", string F_Name = "", string LastName = "", string ListType = "", string CourtName = "", string FileDate = "",
            string CourtDate = "", string Address1 = "", string Address2 = "", string City = "", string State = "", string Zip = "", string Description = "",
            string MI = "", string Violation = "", string DateIssue = "", string Salutation = "", string Summons = "", string CourtId = "", string Muncipality = "",
            string Complaint = "", string Title = "", string PaymentType = "", string PaymentTotal = "", string PaymentPaid = "", string PaymentBalance = "",
            string CardNo = "", string ExpDate = "", string CVV = "", string Email = "", string Phone = "", string DOB = "", string Comment = "", int LoginId = 0, string SourceOfCoummunication="")
        {
            int ids = Convert.ToInt32(id);
            var result = db.NJ_Clients.FirstOrDefault(a => a.Id == ids);

            result.SourceOfComm = SourceOfCoummunication;
            result.F_Name = F_Name;
            result.L_Name = LastName;
            result.List_Type = ListType;
            result.Court_Name = CourtName;
            result.File_Date = FileDate;
            result.CourtDate = CourtDate;
            result.Address1 = Address1;
            result.Address2 = Address2;
            result.City = City;
            result.ST = State;
            result.ZIP = Zip;
            result.Description = Description;
            result.MI = MI;
            //  result.Comment = Comment;
            result.Violation = Violation;
            result.DateIssued = DateIssue;
            result.Salutation = Salutation;
            result.Summons = Summons;
            result.NJ_CourtID = CourtId;
            result.Muncipality = Muncipality;
            result.Complaint = Complaint;
            result.Title = Title;
            result.Payment_Type = PaymentType;
            result.DOB = DOB;
            if (PaymentTotal != "")
            {
                result.Payment_Total = Convert.ToInt32(PaymentTotal);
            }
            if (PaymentPaid != "")
            {
                result.Payment_Paid = Convert.ToInt32(PaymentPaid);
            }
            if (PaymentBalance != "")
            {
                result.Payment_Balance = Convert.ToInt32(PaymentBalance);
            }
            result.Payment_Cardno = CardNo;
            result.Payment_Card_ExpDate = ExpDate;
            if (CVV != "")
            {
                result.Payment_CVV = Convert.ToInt32(CVV);
            }
            result.Email = Email;
            if (Phone != "")
            {
                result.Phone = Phone;
            }
            db.SaveChanges();
            var comments = Comment.Trim();
            if (comments != "" && comments != null)
            {
                NJ_tblComment objtblcomment = new NJ_tblComment();
                objtblcomment.Comment = Comment;
                objtblcomment.UserId = ids;
                objtblcomment.Comment_By = LoginId;
                objtblcomment.Comment_Date = DateTime.Now;
                db.NJ_tblComment.Add(objtblcomment);
                db.SaveChanges();
            }


        }

        public DateTime StartOfWeek(DateTime d)
        {
            if (d == DateTime.MinValue)
            {
                return d;
            }
            var result = d.DayOfWeek - DayOfWeek.Sunday;

            if (result < 0)
            {
                result += 7;
            }

            return d.AddDays(result * -1);
        }

        public DateTime EndOfWeek(DateTime d)
        {
            if (d == DateTime.MinValue)
            {
                return d;
            }
            return this.StartOfWeek(d).AddDays(6);
        }

        public List<string> GetLastNames(string prefix = "")
        {
            var result = ((from u in db.NJ_Details.Where(x => x.L_Name.Contains(prefix))
                           select u.L_Name).Union(from c in db.NJ_Clients
                                                  where c.IsPotentialClient == true && c.L_Name.Contains(prefix)
                                                  select c.L_Name)).Distinct().ToList();
            return result;
            //OLD code
            //var result = (from u in db.NJ_Details.Where(x => x.L_Name.Contains(prefix))
            //              select u.L_Name).Distinct().ToList();
            //return result;
        }
        public List<string> GetFirstNames(string prefix = "")
        {

            var result = ((from u in db.NJ_Details.Where(x => x.F_Name.Contains(prefix))
                           select u.F_Name).Union(from c in db.NJ_Clients
                                                  where c.IsPotentialClient == true && c.F_Name.Contains(prefix)
                                                  select c.F_Name)).Distinct().ToList();
            return result;
            //OLD Code
            //var result = (from u in db.NJ_Details.Where(x => x.F_Name.Contains(prefix))
            //              select u.F_Name).Distinct().ToList();
            //return result;
        }


        public List<Nj_Detail> PotentialClientList(string Search = "", string sDate = "", string eDate = "")
        {

            DateTime startdate = DateTime.Now;
            DateTime LastDate = DateTime.Now;
            //string strdate = "", endDate = "";

            //  UserList user = new UserList();

            switch (Search)
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
                    startdate = StartOfWeek(DateTime.Now);
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
                    startdate = StartOfWeek(DateTime.Now).AddDays(-7);
                    LastDate = EndOfWeek(DateTime.Now).AddDays(-7);
                    break;
                //LastTwoWeeks
                case ("8"):
                    startdate = StartOfWeek(DateTime.Now).AddDays(-14);
                    LastDate = EndOfWeek(DateTime.Now).AddDays(-7);
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
                //Custom
                case("13"):
                    startdate = Convert.ToDateTime(sDate);
                    LastDate = Convert.ToDateTime(eDate).AddHours(24);
                    break;
                default:
                    startdate = new DateTime(1900, 1, 1);
                    LastDate = DateTime.Now;
                    break;
            }
            var query = (from a in db.NJ_Clients
                         where (a.IsPotentialClient == true && a.IsDeleted == false && a.MarkClientDate <= LastDate || (a.MarkClientDate == null && startdate == new DateTime(1900, 1, 1))) && (a.MarkClientDate >= startdate || (a.MarkClientDate == null && startdate == new DateTime(1900, 1, 1))) 
                         select new Nj_Detail
                         {
                             Id = a.Id,
                             L_Name = a.L_Name,
                             F_Name = a.F_Name,
                             ST = a.ST,
                             City = a.City,
                             Payment_Total = a.Payment_Total,
                             Payment_Paid = a.Payment_Paid,
                             Payment_Balance = a.Payment_Balance,
                             MarkClientDate = a.MarkClientDate,
                             IsAddedBy = a.IsAddedBy,
                             IsaddedbyFirstName = db.NJ_User.FirstOrDefault(c => c.tblUserId == a.IsAddedBy).First_Name,
                             IsaddedbyLastName = db.NJ_User.FirstOrDefault(c => c.tblUserId == a.IsAddedBy).Last_Name,
                             TotalRecords = (from a2 in db.NJ_Clients
                                             where (a2.IsPotentialClient == true && a2.IsDeleted == false && a2.MarkClientDate <= LastDate || (a2.MarkClientDate == null && startdate == new DateTime(1900, 1, 1))) && (a2.MarkClientDate >= startdate || (a2.MarkClientDate == null && startdate == new DateTime(1900, 1, 1)))
                                             select a2).Count()
                         }).ToList();

            var data = query.OrderByDescending(x => x.MarkClientDate).ToList();
            return data;


        }

        public NJ_Clients PotentialClientDetail(int id = 0)
        {

            var result = db.NJ_Clients.FirstOrDefault(a => a.Id == id);
            return result;
        }

        public List<string> GetLastForPotentialClients(string prefix = "")
        {

            var result = (from u in db.NJ_Clients.Where(x => x.L_Name.Contains(prefix) && x.IsPotentialClient == true)
                          select u.L_Name).ToList();
            return result;
        }

        public void ChangeClient_ToPotentialClient(string id = "", string Type = "", string Total = "", string Paid = "", string Balance = "", string Cardno = "",
            string CardExpireyDate = "", string CVV = "", string Phone = "", string Email = "", int Addedby = 0, string comment = "", string SourceComm = "")
        {
            int Id = Convert.ToInt32(id);
            var result = db.NJ_Clients.FirstOrDefault(a => a.Id == Id);
            result.Payment_Type = Type;
            if (Total != "")
            {
                result.Payment_Total = Convert.ToInt32(Total);
            }
            if (Paid != "")
            {
                result.Payment_Paid = Convert.ToInt32(Paid);
            }
            if (Balance != "")
            {
                result.Payment_Balance = Convert.ToInt32(Balance);
            }
            result.Payment_Cardno = Cardno;
            //     result.Comment = comment;
            result.Payment_Card_ExpDate = CardExpireyDate;
            if (CVV != "")
            {
                result.Payment_CVV = Convert.ToInt32(CVV);
            }
            result.Phone = Phone;
            result.Email = Email;
            result.IsAddedBy = Addedby;
            result.IsPotentialClient = false;
            result.MarkClientDate = DateTime.Now;
            result.SourceOfComm = SourceComm;
            db.SaveChanges();
            var Comments = comment.Trim();
            if (Comments != "" && Comments != null)
            {
                NJ_tblComment objtblcomment = new NJ_tblComment();
                objtblcomment.Comment = comment;
                objtblcomment.UserId = Id;
                objtblcomment.Comment_By = Addedby;
                objtblcomment.Comment_Date = DateTime.Now;
                db.NJ_tblComment.Add(objtblcomment);
                db.SaveChanges();
            }
        }

        public void DeleteClient(int id = 0)
        {
            var result = db.NJ_Clients.FirstOrDefault(a => a.Id == id);
            result.IsDeleted = true;
            db.SaveChanges();
        }

        public List<Nj_Detail> BindDropdownAddedBy()
        { 
            List<Nj_Detail> listaddedby=new List<Nj_Detail>();
            var query = ((from a in db.NJ_Clients
                          join e in db.NJ_User on a.IsAddedBy equals e.tblUserId
                          select new
                          {
                              ID = a.IsAddedBy,
                              FirstName = e.First_Name
                          }).Distinct().ToList());
            foreach (var item in query)
            {
                listaddedby.Add(new Nj_Detail()
                 {
                     IsAddedBy = item.ID,
                     IsaddedbyFirstName = item.FirstName
                 });
            }
            return listaddedby;
        }

        //---------------------------------------Deol

        public void MakeNewClient(string ListType = "", string Filedate = "", string CourtName = "", string CourtDate = "", string LName = "", string FName = "", string MI = "", string Address1 = "", string Address2 = "", string City = "", string St = "", string Zip = "", string Dob = "",
            string Violation = "", string Description = "", string DateIssued = "", string Salution = "", string Summons = "", string CourtId = "", string Muncipality = "", string Complaint = "", string Title = "",
            string Type = "", string Total = "", string Paid = "", string Balance = "", string Cardno = "", string CardExpireyDate = "", string CVV = "", string Phone = "", string Email = "", string PotentialClient = "", string comment = "", int LoginId = 0, string SourceComm = "")
        {
            NJTicketEntities db = new NJTicketEntities();

            NJ_Clients objNj_Client = new NJ_Clients();
            objNj_Client.List_Type = ListType;
            objNj_Client.File_Date = Filedate;
            objNj_Client.Court_Name = CourtName;
            objNj_Client.CourtDate = CourtDate;
            objNj_Client.L_Name = LName;
            objNj_Client.F_Name = FName;
            objNj_Client.MI = MI;
            objNj_Client.Address1 = Address1;
            objNj_Client.Address2 = Address2;
            objNj_Client.City = City;
            objNj_Client.ST = St;
            objNj_Client.ZIP = Zip;
            objNj_Client.DOB = Dob;
            objNj_Client.Violation = Violation;
            objNj_Client.Description = Description;
            objNj_Client.DateIssued = DateIssued;
            objNj_Client.Salutation = Salutation;
            objNj_Client.Summons = Summons;
            objNj_Client.NJ_CourtID = CourtId;
            objNj_Client.Muncipality = Muncipality;
            objNj_Client.Complaint = Complaint;
            objNj_Client.Title = Title;
            objNj_Client.Payment_Type = Type;
            objNj_Client.SourceOfComm = SourceComm;
            if (Total != "")
            {
                objNj_Client.Payment_Total = Convert.ToInt32(Total);
            }
            if (Paid != "")
            {
                objNj_Client.Payment_Paid = Convert.ToInt32(Paid);
            }
            if (Balance != "")
            {
                objNj_Client.Payment_Balance = Convert.ToInt32(Balance);
            }
            objNj_Client.Payment_Cardno = Cardno;
            objNj_Client.Payment_Card_ExpDate = CardExpireyDate;
            objNj_Client.MarkClientDate = DateTime.Now;
            objNj_Client.Phone = Phone;
            objNj_Client.Email = Email;

            if (CVV != "")
            {
                objNj_Client.Payment_CVV = Convert.ToInt32(CVV);
            }
            objNj_Client.IsPotentialClient = Convert.ToBoolean(PotentialClient);
            if (objNj_Client.IsPotentialClient == false)
            {
                objNj_Client.IsAddedBy = LoginId;
            }
            objNj_Client.Comment = comment;
            db.NJ_Clients.Add(objNj_Client);
            db.SaveChanges();
            if (comment != "")
            {
                var Insertid = objNj_Client.Id;
                NJ_tblComment objtblcomment = new NJ_tblComment();
                objtblcomment.Comment = comment;
                objtblcomment.UserId = Insertid;
                objtblcomment.Comment_By = LoginId;
                objtblcomment.Comment_Date = DateTime.Now;
                db.NJ_tblComment.Add(objtblcomment);
                db.SaveChanges();
            }
        }
    }
}
