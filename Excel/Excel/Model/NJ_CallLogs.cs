using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Excel.Model
{
    public class NJ_CallLogs
    {


        #region "Properties"
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string strDateAdded { get; set; }
        public Nullable<int> AddedBy { get; set; }
        public string AddedName { get; set; }
        public int TotalCount { get; set; }
        public string Users { get; set; }
        #endregion

        #region "Add Call Log"
        public void AddCallLog(int id = 0, string FirstName = "", string LastName = "", string Phone = "", string Notes = "", string User = "")
        {
            HttpContext.Current.Session["LoginId"] = HttpContext.Current.Request.Cookies["LoginId"].Value;
            try
            {
                NJTicketEntities db = new NJTicketEntities();
                NJ_CallLog obj_CallLog = new NJ_CallLog();
                if (id > 0)
                {
                    var clog = db.NJ_CallLog.FirstOrDefault(cl => cl.Id == id);
                    if (clog != null)
                    {
                        clog.FirstName = FirstName;
                        clog.LastName = LastName;
                        clog.Phone = Phone;
                        clog.Notes = Notes;
                        clog.Users = User;
                    }
                }
                else
                {
                    obj_CallLog.FirstName = FirstName;
                    obj_CallLog.LastName = LastName;
                    obj_CallLog.Phone = Phone;
                    obj_CallLog.Notes = Notes;
                    obj_CallLog.DateAdded = DateTime.Now;
                    obj_CallLog.AddedBy = Convert.ToInt32(HttpContext.Current.Session["LoginId"]);
                    obj_CallLog.Users = User;
                    db.NJ_CallLog.Add(obj_CallLog);

                }
                db.SaveChanges();
            }
            catch (Exception cc)
            {
                throw cc;
            }

        }
        #endregion

        #region "CallLogs"
        public List<NJ_CallLogs> CallLogs(string Search = "", string Search1 = "")
        {
            List<NJ_CallLogs> list = new List<NJ_CallLogs>();
            try
            {
                using (NJTicketEntities db = new NJTicketEntities())
                {
                    DateTime startdate = DateTime.Now;
                    DateTime LastDate = DateTime.Now;
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
                        default:
                            startdate = new DateTime(1900, 1, 1);
                            LastDate = DateTime.Now;
                            break;
                    }

                    var clogs = from cl in db.NJ_CallLog
                                join u in db.NJ_User
                                on cl.AddedBy equals u.tblUserId
                                where ((cl.DateAdded <= LastDate || (cl.DateAdded == null && startdate == new DateTime(1900, 1, 1))) && (cl.DateAdded >= startdate || (cl.DateAdded == null && startdate == new DateTime(1900, 1, 1))) && ((cl.FirstName.Contains(Search1) || cl.LastName.Contains(Search1) || (cl.Notes.Contains(Search1) || Search1 == ""))))
                                select new
                                {
                                    FirstName = cl.FirstName,
                                    LastName = cl.LastName,
                                    Phone = cl.Phone,
                                    Notes = cl.Notes,
                                    Id = cl.Id,
                                    AddedBy = cl.AddedBy,
                                    AddName = u.First_Name,
                                    DateAdded = cl.DateAdded,
                                    strDate = cl.DateAdded,
                                    TotalCount = (from cl2 in db.NJ_CallLog
                                                  join u2 in db.NJ_User
                                                  on cl2.AddedBy equals u2.tblUserId
                                                  where ((cl2.DateAdded <= LastDate || (cl2.DateAdded == null && startdate == new DateTime(1900, 1, 1))) && (cl2.DateAdded >= startdate || (cl2.DateAdded == null && startdate == new DateTime(1900, 1, 1))) && ((cl2.FirstName.Contains(Search1) || cl2.LastName.Contains(Search1) || (cl2.Notes.Contains(Search1) || Search1 == ""))))
                                                  select cl2).Count(),
                                    Users = cl.Users
                                };
                    //db.NJ_CallLog.ToList();
                    foreach (var c in clogs)
                    {
                        list.Add(new NJ_CallLogs
                        {
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Phone = c.Phone,
                            Notes = c.Notes,
                            Id = c.Id,
                            AddedBy = c.AddedBy,
                            DateAdded = c.DateAdded,
                            AddedName = c.AddName,
                            strDateAdded = (Convert.ToDateTime(c.strDate)).Month.ToString() + '/' + (Convert.ToDateTime(c.strDate)).Day.ToString() + '/' + (Convert.ToDateTime(c.strDate)).ToString("yy") + ' ' + (Convert.ToDateTime(c.strDate)).ToShortTimeString(),
                            TotalCount = c.TotalCount,
                            Users = c.Users
                        });
                    }
                }
                list = list.OrderByDescending(x => x.DateAdded).ToList();
                return list;
            }
            catch (Exception cc)
            {
                throw cc;
            }
        }
        #endregion


        #region "CallLogs"
        public NJ_CallLogs CallLogDetails(int Id = 0)
        {
            NJ_CallLogs model = new NJ_CallLogs();
            try
            {
                using (NJTicketEntities db = new NJTicketEntities())
                {
                    var data = db.NJ_CallLog.FirstOrDefault(cl => cl.Id == Id);
                    //db.NJ_CallLog.ToList();
                    if (data != null)
                    {
                        model.FirstName = data.FirstName;
                        model.LastName = data.LastName;
                        model.Phone = data.Phone;
                        model.Notes = data.Notes;

                    }
                }
                return model;
            }
            catch (Exception cc)
            {
                throw cc;
            }
        }
        #endregion

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

        #region "Delete Call Log"
        public void DeleteCallLog(int id = 0)
        {
            try
            {
                NJTicketEntities db = new NJTicketEntities();
                NJ_CallLog obj_CallLog = new NJ_CallLog();
                if (id > 0)
                {
                    var clog = db.NJ_CallLog.FirstOrDefault(cl => cl.Id == id);
                    if (clog != null)
                    {
                        db.NJ_CallLog.Remove(clog);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception cc)
            {
                throw cc;
            }

        }
        #endregion



    }
}