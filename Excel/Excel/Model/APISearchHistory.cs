using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace Excel.Model
{
    public class APISearchHistory
    {
        NJTicketEntities db = new NJTicketEntities();

        public int ID { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public string DOB { get; set; }
        public string Search_By { get; set; }
        public string Search_Date { get; set; }
        public int TotalCount { get; set; }

        public List<APISearchHistory> GetHistory()
        {
            List<APISearchHistory> history = new List<APISearchHistory>();
            var query = (from a in db.tbl_APISearchHistory
                         join e in db.NJ_User on a.SearchBy equals e.tblUserId
                         select new
                         {
                             ID = a.ID,
                             FirstName = a.First_Name,
                             LastName = a.Last_Name,
                             DOB = a.DOB,
                             SearchBy = e.First_Name,
                             SearchDate = a.SearchDate,
                             TotalCount = (from a2 in db.tbl_APISearchHistory
                                           join e2 in db.NJ_User
                                           on a2.SearchBy equals e2.tblUserId                                           
                                           select a2).Count()
                         }).ToList();
            foreach (var items in query)
            {
                history.Add(new APISearchHistory()
                {
                    ID = items.ID,
                    F_Name = items.FirstName,
                    L_Name = items.LastName,
                    DOB = items.DOB,
                    Search_By = items.SearchBy,
                    Search_Date = items.SearchDate.ToString(),
                    TotalCount = items.TotalCount
                });
            }
            return history;
        }
    }
}