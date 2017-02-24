using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StableLawFirm.Model
{
    public class CategoryModel
    {

        public int categoryId { get; set; }

        public string CategoryName { get; set; }

        StabileLawFirmEntities nj = new StabileLawFirmEntities();
        public void SaveCategory(string category)
        {
            STtblCategory objtblCategory = new STtblCategory();
            objtblCategory.caregory_Name = category;
            nj.STtblCategories.Add(objtblCategory);
            nj.SaveChanges();
        }

        public void UpdateCategory(string category, int id)
        {
            var Result = nj.STtblCategories.FirstOrDefault(a => a.tblCategory_Id == id);
            Result.caregory_Name = category;
            nj.SaveChanges();
        }

        public List<CategoryModel> GetCategory()
        {
            var category = nj.STtblCategories.ToList();
            List<CategoryModel> objCategoryModel = new List<CategoryModel>();
            foreach (var row in category)
            {
                objCategoryModel.Add(new CategoryModel
                {
                    categoryId = row.tblCategory_Id,
                    CategoryName = row.caregory_Name
                });
            }

            return objCategoryModel;
        }


        public void DeleteCategory(int id)
        {
            var Result = nj.STtblCategories.FirstOrDefault(a => a.tblCategory_Id == id);
            nj.STtblCategories.Remove(Result);
            nj.SaveChanges();
        }


        public CategoryModel GetCategoryById(int id)
        {
            CategoryModel category = new CategoryModel();
            var result = nj.STtblCategories.FirstOrDefault(a => a.tblCategory_Id == id);
            category.categoryId = result.tblCategory_Id;
            category.CategoryName = result.caregory_Name;
            return category;
        }



    }

  
}