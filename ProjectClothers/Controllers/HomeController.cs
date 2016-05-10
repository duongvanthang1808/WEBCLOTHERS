using ProjectClothers.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectClothers.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        
        public ActionResult Index()
        {
            var model = new ProductDao().getAllProduct(1, 4);
            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[Common.SessionName.CART_SESSION];
            
            var lcart = new List<Cart>();

            if (cart != null)
            {
                lcart = (List<Cart>)cart;
            }

            return PartialView(lcart);
        }
    }
}
