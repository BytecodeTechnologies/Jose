using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Landscapes.Models 
{


    public class ChildCategory
    {
        public int ChildCategory_Id { get; set; }
        public string Image { get; set; }
        public int? SubCategoryId { get; set; }
        public string SubcategoryName { get; set; }
        LandscapesEntities Db = new LandscapesEntities();
        public List<ChildCategory> GetAllChild()
        {
            var result = (from child in Db.Ls_ChildCategory
                          join sub in Db.Ls_SubCategory on child.SubcategoryID equals sub.SubCategory_Id
                          select new ChildCategory
                          {
                              ChildCategory_Id = child.Child_ID,
                              Image = child.Image,
                              SubCategoryId = sub.Category_Id,
                              SubcategoryName = sub.SubCategory_Name
                          }).ToList();
            return result;
        }
        public void DeleteSubCategory(int id)
        {
            var result = Db.Ls_ChildCategory.FirstOrDefault(a => a.Child_ID == id);
            var Path = result.Image;
            Db.Ls_ChildCategory.Remove(result);
            Db.SaveChanges();
            FileInfo file = new FileInfo(HttpContext.Current.Server.MapPath(Path));
            if (file.Exists)
            {
                file.Delete();
            }


        }
        public void AddChildImage(SubCategory objchild, string Image)
        {
            Ls_ChildCategory obj = new Ls_ChildCategory();
            obj.SubcategoryID = objchild.SubCategoryId;
            obj.Date = DateTime.Now;
            obj.Image = Image;
            Db.Ls_ChildCategory.Add(obj);
            Db.SaveChanges();
        }
        public List<ChildCategory> ChildImages(int id)
        {
            var result = (from child in Db.Ls_ChildCategory
                          join sub in Db.Ls_SubCategory on child.SubcategoryID equals sub.SubCategory_Id where child.SubcategoryID == id
                          select new ChildCategory
                          {
                              ChildCategory_Id = child.Child_ID,
                              Image = child.Image,
                              SubCategoryId = sub.Category_Id,
                              SubcategoryName = sub.SubCategory_Name
                          }).ToList();
            return result;
        
        }
    }
}