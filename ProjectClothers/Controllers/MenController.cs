using ProjectClothers.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectClothers.Controllers
{
    public class MenController : Controller
    {
        //
        // GET: /Men/

        public ActionResult Index(int id = 1,string name = "",int page = 1, int pagesize = 12)
        {
            var model = new ProductDao().getAllProductCate(id,1,page,pagesize);
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            var model = new ProductDao().getDeital(id);


            var related = new ProductDao().getProductRelated((int)model.CategoryId);
            ViewBag.RELATED = related;

            return View(model);
        }

        public ActionResult _NavigationCategory()
        {
            var model = new CategoryDao().getAllCategory();
            return PartialView(model);
        }


    }
}
