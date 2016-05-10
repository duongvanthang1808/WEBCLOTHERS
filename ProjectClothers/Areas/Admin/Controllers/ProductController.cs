using ProjectClothers.Models.Entities;
using ProjectClothers.Models.Function;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectClothers.Areas.Admin.Controllers
{
   [Common.CustomAuthorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        //
        // GET: /Admin/Product/
        
        public ActionResult Index(int page = 1, int pagesize = 9)
        {
            var model = new ProductDao().getAllProduct(page, pagesize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var dao = new CategoryDao().getAllCategory().Where(m => m.Name != null);

            ViewBag.CategoryId = new SelectList(dao, "ID", "Name", null);
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase Image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Image == null)
                    {
                        ModelState.AddModelError("File", "Please Upload Your file");
                    }
                    else if (Image.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(Image.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/client/images"), fileName);
                        Image.SaveAs(path);

                        product.Image = fileName;
                        new ProductDao().Create(product);
                    }

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new CategoryDao().getAllCategory().Where(m => m.Name != null);

            ViewBag.CategoryId = new SelectList(dao, "ID", "Name", null);
            var model = new ProductDao().getDeital(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Product product,HttpPostedFileBase Image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Image == null)
                    {
                        ModelState.AddModelError("File", "Please Upload Your file");
                    }
                    else if (Image.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(Image.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/client/images"), fileName);
                        Image.SaveAs(path);
                        product.Image = fileName;

                        
                        
                    }
                    new ProductDao().Edit(product, Image);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = new ProductDao().getDeital(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Details()
        {
            return View();
        }

    }
}
