using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Excel.Model
{
    public class CertificateFiles
    {
        NJTicketEntities db = new NJTicketEntities();
        public int ID { get; set; }
        public string FilePath { get; set; }
        public int? Nj_ClientsID { get; set; }
        public string FileName { get; set; }
        public string CreatedDate { get; set; }

        public List<CertificateFiles> filePathList(int id, string currentDate = "")
        {
            DateTime dd = Convert.ToDateTime(currentDate);
            var filesno = db.tbl_CertificateFiles.Where(s => s.Nj_ClientsID == id && s.CreatedDate == dd).OrderByDescending(s => s.ID).Take(3);
            List<CertificateFiles> fileList = new List<CertificateFiles>();
            foreach (var items in filesno)
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(items.FilePath);
                fileList.Add(new CertificateFiles()
                {
                    ID = items.ID,
                    FilePath = items.FilePath,
                    Nj_ClientsID = items.Nj_ClientsID,
                    FileName = name,
                    CreatedDate = Convert.ToString(items.CreatedDate)
                });
            }
            return fileList;
        }

       

    }
}