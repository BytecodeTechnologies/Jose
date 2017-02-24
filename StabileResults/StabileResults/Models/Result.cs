using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StabileResults.Models
{
    public class Result
    {
        StabileLawFirmEntities dbentity = new StabileLawFirmEntities();

        public int tblResultId { get; set; }
        public string Result_Text { get; set; }
        public DateTime? Result_Date { get; set; }
        public string Result_Heading { get; set; }
        public int? tblUserId { get; set; }

        public string Date { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }
        public string Result_Text_st { get; set; }

        public string Result_Heading_st { get; set; }

        public string Image { get; set; }
        public int day { get; set; }
        public string Month { get; set; }

        public string str_month { get; set; }

        public int year { get; set; }


        public List<Result> GetAllResult()
        {
            List<Result> objResultModel = new List<Result>();
            StabileLawFirmEntities dbentity = new StabileLawFirmEntities();
            var result = (from s in dbentity.STtblUsers
                          join sa in dbentity.STtblResults on s.tblUserId equals sa.tblUserId
                          select new
                          {
                              tblResultId = sa.tblResultId,
                              tblUserId = sa.tblUserId,
                              UserName = s.UserName,
                              Result_Date = sa.Result_Date,
                              Result_Heading = sa.Result_Heading,
                              Result_Text = sa.Result_Text,
                              Name = s.Name

                          }).OrderByDescending(l => l.Result_Date).ToList();


            foreach (var item in result)
            {
                objResultModel.Add(new Result
                {
                    tblResultId = item.tblResultId,
                    tblUserId = item.tblUserId,
                    UserName = item.UserName,
                    Result_Date = item.Result_Date,
                    Date = Convert.ToDateTime(item.Result_Date).ToShortDateString(),
                    Result_Heading = item.Result_Heading,
                    Result_Text = item.Result_Text.Substring(0, Math.Min(item.Result_Text.Length, 400)),
                    //Result_Text_st = item.Result_Text.Substring(0, Math.Min(item.Result_Text.Length, 140)),
                    Name = item.Name,
                    //Result_Heading_st = item.Result_Heading.Substring(0, Math.Min(item.Result_Heading.Length, 40)),
                    //day = (Convert.ToDateTime(item.Result_Date).Day),
                    //Month = (Convert.ToDateTime(item.Result_Date).ToString("MMMM").Substring(0, 3)),
                    //year = (Convert.ToDateTime(item.Result_Date).Year),
                });
            }
            return objResultModel;
        }

        public void SaveResult(Result obj, int Userid)
        {
            STtblResult objtblResult = new STtblResult();
            objtblResult.Result_Date = DateTime.Now;
            objtblResult.Result_Heading = obj.Result_Heading;
            objtblResult.Result_Text = obj.Result_Text;
            objtblResult.tblUserId = Userid;
            dbentity.STtblResults.Add(objtblResult);
            dbentity.SaveChanges();
        }

        public void DeleteResult(int id)
        {
            var Result = dbentity.STtblResults.FirstOrDefault(a => a.tblResultId == id);
            dbentity.STtblResults.Remove(Result);
            dbentity.SaveChanges();

        }
        public STtblResult Getresultbyid(int id)
        {
            var Result = dbentity.STtblResults.FirstOrDefault(a => a.tblResultId == id);
            return Result;
        }
        public void updateresult(Result obj)
        {
            var Result = dbentity.STtblResults.FirstOrDefault(a => a.tblResultId == obj.tblResultId);
            Result.Result_Heading = obj.Result_Heading;
            Result.Result_Text = obj.Result_Text;
            dbentity.SaveChanges();
        }


    }
}