using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Landscapes.Models
{
    public class SubCategory
    {
        LandscapesEntities Db = new LandscapesEntities();
        public int Category { get; set; }
        public string Subcategory { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }
        public string Image { get; set; }
        public int SubCategoryId { get; set; }

        public void AddSubcategory(SubCategory objSubCategory, string imgpath)
        {
            Ls_SubCategory objCategory = new Ls_SubCategory();
            objCategory.Category_Id = objSubCategory.Category;
            objCategory.SubCategory_Name = objSubCategory.Subcategory;
            objCategory.Description = objSubCategory.Description;
            objCategory.Image = imgpath;
            Db.Ls_SubCategory.Add(objCategory);
            Db.SaveChanges();
        }

        public List<SubCategory> GetAllsub_Category()
        {
            var result = (from subcat in Db.Ls_SubCategory
                          join cat in Db.Categories on subcat.Category_Id equals cat.CategoryID
                          select new SubCategory
                          {
                              CategoryName = cat.CategoryName,
                              CategoryID = cat.CategoryID,
                              Subcategory = subcat.SubCategory_Name,
                              Image = subcat.Image,
                              Description = subcat.Description,
                              SubCategoryId = subcat.SubCategory_Id,
                          }).ToList();

            return result;
        }

        public void Delete_Subcategory(int id)
        {
            var data = Db.Ls_ChildCategory.Where(a => a.SubcategoryID == id).ToList();
            foreach (var item in data)
            {
                var Path = item.Image;
                Db.Ls_ChildCategory.Remove(item);
                Db.SaveChanges();
                FileInfo files = new FileInfo(HttpContext.Current.Server.MapPath(Path));
                if (files.Exists)
                {
                    files.Delete();
                }
            }
            var result = Db.Ls_SubCategory.FirstOrDefault(a => a.SubCategory_Id == id);
            var path = result.Image;
            Db.Ls_SubCategory.Remove(result);
            Db.SaveChanges();
            FileInfo file = new FileInfo(HttpContext.Current.Server.MapPath(path));
            if (file.Exists)
            {
                file.Delete();
            }

        }
        public Ls_SubCategory Getsubcategory(int id)
        {
            var result = Db.Ls_SubCategory.FirstOrDefault(a => a.SubCategory_Id == id);
            return result;
        }
        public void UpdateSubCategory(SubCategory objSubCategory, string imgpath)
        {
            var result = Db.Ls_SubCategory.FirstOrDefault(a => a.SubCategory_Id == objSubCategory.SubCategoryId);
            result.Category_Id = objSubCategory.Category;
            result.SubCategory_Name = objSubCategory.Subcategory;
            result.Description = objSubCategory.Description;
            if (imgpath != "")
            {
                result.Image = imgpath;
            }
            Db.SaveChanges();
        }
        public List<Ls_SubCategory> GetSubCategory_ByCAtegory(int id)
        {
            var result = Db.Ls_SubCategory.Where(a => a.Category_Id == id).ToList();
            return result;
        }
    }
}