using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StableLawFirm.Model
{
    public class ResultModel
    {
        StabileLawFirmEntities nj = new StabileLawFirmEntities();

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

        public List<ResultModel> GetResult()
        {
            List<ResultModel> objResultModel = new List<ResultModel>();
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

                          }).OrderByDescending(l => l.Result_Date).Take(3).ToList();
            int i = 0;
            var images = "";

            foreach (var item in result)
            {
                if (i == 0)
                {
                    images = "images/home/9.jpg";
                }
                if (i == 1)
                {
                    images = "images/home/10.jpg";
                }
                if (i == 2)
                {
                    images = "images/home/11.jpg";
                }
                i = i + 1;

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
                    Image = images,
                    day = (Convert.ToDateTime(item.Result_Date).Day),
                    Month = (Convert.ToDateTime(item.Result_Date).ToString("MMMM").Substring(0, 3)),
                    year = (Convert.ToDateTime(item.Result_Date).Year),


                });
            }


            return objResultModel;
        }

        public List<ResultModel> getrecordbyid(int id)
        {

            var Result = (from s in nj.STtblUsers
                          join sa in nj.STtblResults.Where(s => s.tblResultId == id) on s.tblUserId equals sa.tblUserId
                          select new
                          {
                              tblResultId = sa.tblResultId,
                              Result_Text = sa.Result_Text,
                              Result_Heading = sa.Result_Heading,
                              Result_Date = sa.Result_Date,
                              UserName = s.Name

                          }).ToList();

            List<ResultModel> objtblResult = new List<ResultModel>();
            foreach (var item in Result)
            {
                objtblResult.Add(new ResultModel
                   {
                       tblResultId = item.tblResultId,
                       Result_Text = item.Result_Text,
                       Result_Heading = item.Result_Heading,
                       Result_Date = item.Result_Date,
                       Date = Convert.ToDateTime(item.Result_Date).ToShortDateString(),
                       Name = item.UserName,
                       day = (Convert.ToDateTime(item.Result_Date).Day),
                       Month = (Convert.ToDateTime(item.Result_Date).ToString("MMMM").Substring(0, 3)),
                       year = (Convert.ToDateTime(item.Result_Date).Year),
                   });
            }
            return objtblResult;

        }

        public void SaveResult(string Result_Heading, string Result_Text)
        {
            STtblResult objtblResult = new STtblResult();
            objtblResult.Result_Date = DateTime.Now;
            objtblResult.Result_Heading = Result_Heading;
            objtblResult.Result_Text = Result_Text;
            objtblResult.tblUserId = 1;
            nj.STtblResults.Add(objtblResult);
            nj.SaveChanges();
        }

        public List<ResultModel> GetAllResult()
        {
            List<ResultModel> objResultModel = new List<ResultModel>();
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
                    day = (Convert.ToDateTime(item.Result_Date).Day),
                    Month = (Convert.ToDateTime(item.Result_Date).ToString("MMMM").Substring(0, 3)),
                    year = (Convert.ToDateTime(item.Result_Date).Year),
                });
            }
            return objResultModel;
        }

        public void DeleteUser(int id)
        {
            var Result = nj.STtblResults.FirstOrDefault(a => a.tblResultId == id);
            nj.STtblResults.Remove(Result);
            nj.SaveChanges();

        }

        public STtblResult Getresultbyid(int id)
        {
            var Result = nj.STtblResults.FirstOrDefault(a => a.tblResultId == id);
            return Result;
        
        
        }

        public void updateresult(string Result_Heading, string Result_Text, int id)
        {
            var Result = nj.STtblResults.FirstOrDefault(a => a.tblResultId == id);
            Result.Result_Heading = Result_Heading;
            Result.Result_Text = Result_Text;
            nj.SaveChanges();
        }

     
    }
}