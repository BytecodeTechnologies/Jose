using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewJersyTrafficTicket.Models
{
    public class CategoryModel
    {

        dd_NJTrafficTicketsEntities dbentity = new dd_NJTrafficTicketsEntities();
        public int categoryId { get; set; }

        public string CategoryName { get; set; }
        public void AddCategory(CategoryModel category) 
        {
            tblCategory objtblCategory = new tblCategory();
            objtblCategory.Caregory_Name = category.CategoryName;
            dbentity.tblCategories.Add(objtblCategory);
            dbentity.SaveChanges();
       
       
        }

        public void UpdateCategory(CategoryModel category)
        {
            var Result = dbentity.tblCategories.FirstOrDefault(a => a.tblCategory_Id == category.categoryId);
            Result.Caregory_Name = category.CategoryName;
            dbentity.SaveChanges();
        }

        public List<CategoryModel> GetCategory()
        {
            var category = dbentity.tblCategories.ToList();
            List<CategoryModel> objCategoryModel = new List<CategoryModel>();
            foreach(var row in category)
            {
             objCategoryModel.Add(new CategoryModel
             {
             categoryId = row.tblCategory_Id,
             CategoryName = row.Caregory_Name
             });
            }

            return objCategoryModel;
        }

        public CategoryModel GetCategoryById(int id)
        {
            CategoryModel category = new CategoryModel();
            var result = dbentity.tblCategories.FirstOrDefault(a => a.tblCategory_Id == id);
            category.categoryId = result.tblCategory_Id;
            category.CategoryName = result.Caregory_Name;
            return category;
        }

        public void DeleteCategory(int id)
        {
            var Result = dbentity.tblCategories.FirstOrDefault(a => a.tblCategory_Id == id);
            dbentity.tblCategories.Remove(Result);
            dbentity.SaveChanges();
        }
    }
}