using ProjectClothers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;//Add  
using System.Xml;
using PagedList;

namespace ProjectClothers.Models.Function
{
    public class ProductDao
    {
        DbClothers context = null;

        public ProductDao()
        {
            context = new DbClothers();
        }

        public IEnumerable<Product> getAllProduct(int page, int pagesize)
        {
            return context.Products.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pagesize);

        }


        public IEnumerable<Product> getAllProductCate(int id, int sex, int page, int pagesize)
        {
            return context.Products.OrderByDescending(x => x.CreatedDate).Where(m => (m.CategoryId == id) && (m.Sex == sex)).ToPagedList(page, pagesize);

        }
        public Product getDeital(int id)
        {
            return context.Products.Where(m => m.ID == id).FirstOrDefault();
        }

        public IEnumerable<Product> getProductRelated(int categoryid)
        {
            return context.Products.OrderByDescending(x => x.CreatedDate).Skip(0).Take(3);
        }
        //public IEnumerable<string> getAllImage(Product product)
        //{


        //}
        public int Create(Product product)
        {
            var temp = context.Products.Find(product.ID);

            if (temp == null)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return product.ID;
            }
            return 0;
        }
        public int Edit(Product product,HttpPostedFileBase Image)
        {
            var temp = context.Products.Find(product.ID);
            if (temp != null)
            {
                temp.ID = product.ID;
                temp.Name = product.Name;
                
                temp.Price = product.Price;
                temp.Sex = product.Sex;
                temp.Decription = product.Decription;
                temp.CategoryId = product.CategoryId;
                temp.CreatedBy = product.CreatedBy;
                temp.CreatedDate = temp.CreatedDate;

                if(Image != null)
                {
                    temp.Image = product.Image;
                }

                context.SaveChanges();
            }
            return temp.ID;
        }
    }
}