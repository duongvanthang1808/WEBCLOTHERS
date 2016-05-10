using ProjectClothers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectClothers.Models.Function
{
    public class CategoryDao
    {
        DbClothers context = null;
        public CategoryDao()
        {
            context = new DbClothers();
        }

        public IEnumerable<ProductCategory> getAllCategory()
        {
            return context.ProductCategories;
        }

        public ProductCategory getCategory(int id)
        {
            return context.ProductCategories.Where(m => m.ID == id).FirstOrDefault();
        }
        public int Creat(ProductCategory cate)
        {
            var temp = context.ProductCategories.Find(cate.ID);
            if (temp == null)
            {
                context.ProductCategories.Add(cate);
                context.SaveChanges();

                return cate.ID;
            }
            return 0;
        }
        public int Delete(int id)
        {
            var cate = context.ProductCategories.Find(id);
            if (cate != null)
            {
                context.ProductCategories.Remove(cate);
                context.SaveChanges();
                return cate.ID;
            }
            return 0;

        }
        public int Edit(ProductCategory cate)
        {
            var temp = context.ProductCategories.Find(cate.ID);
            if (temp != null)
            {
                temp.ID = cate.ID;
                temp.Name = cate.Name;
                temp.CreatedDate = cate.CreatedDate;
                temp.CreatedBy = cate.CreatedBy;

                context.SaveChanges();
            }
            return temp.ID;
        }
    }
}