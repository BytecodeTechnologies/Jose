using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewJersyTrafficTicket.Models
{
   
    public class ResultModel
    {
        dd_NJTrafficTicketsEntities dbentity = new dd_NJTrafficTicketsEntities();

        public int tblResultId { get; set; }
        public string Result_Text { get; set; }
        public DateTime ?Result_Date { get; set; }
        public string Result_Heading { get; set; }
        public int ?tblUserId { get; set; }

        public string Date { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }
        public string Result_Text_st { get; set; }

        public string Result_Heading_st { get; set; }

        public void SaveResult(ResultModel data)
        {
            tblResult objtblResult = new tblResult();
            objtblResult.Result_Date = DateTime.Now;
            objtblResult.Result_Heading = data.Result_Heading;
            objtblResult.Result_Text = data.Result_Text;
            objtblResult.tblUserId = data.tblUserId;
            dbentity.tblResults.Add(objtblResult);
            dbentity.SaveChanges();
        }

         public void updateresult(ResultModel data)
        {
            var Result = dbentity.tblResults.FirstOrDefault(a => a.tblResultId == data.tblResultId);
            Result.Result_Heading = data.Result_Heading;
            Result.Result_Text = data.Result_Text;
            dbentity.SaveChanges();
        }
      
        public List<ResultModel> GetResult()
        {
            List<ResultModel> objResultModel = new List<ResultModel>();
             dd_NJTrafficTicketsEntities dbentity = new dd_NJTrafficTicketsEntities();
             var result = (from s in dbentity.tblUsers
                           join sa in dbentity.tblResults on s.tblUserId equals sa.tblUserId
                           select new
                           {
                               tblResultId = sa.tblResultId,
                               tblUserId = sa.tblUserId,
                               UserName = s.UserName,
                               Result_Date = sa.Result_Date,
                               Result_Heading = sa.Result_Heading,
                               Result_Text = sa.Result_Text,
                               Name = s.Name

                           }).ToList();

             foreach (var item in result)
             {
                 objResultModel.Add(new ResultModel
                   {
                       tblResultId = item.tblResultId,
                       tblUserId = item.tblUserId,
                       UserName = item.UserName,
                       Result_Date = item.Result_Date,
                       Date = Convert.ToDateTime(item.Result_Date).ToShortDateString(),
                       Result_Heading = item.Result_Heading,
                       Result_Text = item.Result_Text.Substring(0, Math.Min(item.Result_Text.Length, 400)),
                       Result_Text_st = item.Result_Text.Substring(0, Math.Min(item.Result_Text.Length, 140)),
                       Name = item.Name,
                       Result_Heading_st = item.Result_Heading.Substring(0, Math.Min(item.Result_Heading.Length, 40)),
                   });
             }
             objResultModel = objResultModel.OrderByDescending(l => l.Result_Date).ToList();
             return objResultModel;

        }

        public void DeleteUser(int id)
        {
            var Result = dbentity.tblResults.FirstOrDefault(a => a.tblResultId == id);
            dbentity.tblResults.Remove(Result);
            dbentity.SaveChanges();
        
        }

        public ResultModel getrecordbyid(int id)
        { 
               Blog tblblogObj = new Blog();
            var Result = (from s in dbentity.tblUsers
                          join sa in dbentity.tblResults.Where(s => s.tblResultId == id) on s.tblUserId equals sa.tblUserId
                          select new
                          {
                              tblResultId = sa.tblResultId,
                              Result_Text = sa.Result_Text,
                              Result_Heading = sa.Result_Heading,
                              Result_Date = sa.Result_Date,
                              UserName = s.Name
                          }).FirstOrDefault();

            //var Result = dbentity.tblResults.FirstOrDefault(a => a.tblResultId == id);
            ResultModel objtblResult = new ResultModel();
            objtblResult.tblResultId = Result.tblResultId;
            objtblResult.Result_Text = Result.Result_Text;
            objtblResult.Result_Heading = Result.Result_Heading;
            objtblResult.Result_Date = Result.Result_Date;
            objtblResult.Date = Convert.ToDateTime(Result.Result_Date).ToShortDateString();
            objtblResult.Name = Result.UserName;
            return objtblResult;


        }

    }
}