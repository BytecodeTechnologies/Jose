using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landscapes.Models
{
    public class IronWork
    {
        LandscapesEntities Db = new LandscapesEntities();

        public List<Ls_SubCategory> Get_Subcategories(int id)
        {
            var result = Db.Ls_SubCategory.Where(a => a.Category_Id == id).ToList();
            return result;
        }
        public Category GetCategorybyId(int id)
        {
            var result = Db.Categories.FirstOrDefault(a => a.CategoryID == id);
            return result;
        }
    }
}