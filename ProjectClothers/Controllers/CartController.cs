using ProjectClothers.Models.Entities;
using ProjectClothers.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectClothers.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        private string CARTSESSION = Common.SessionName.CART_SESSION;
        public ActionResult Index()
        {
            var cart = Session[CARTSESSION];

            var lcart = new List<Cart>();

            if (cart != null)
            {
                lcart = (List<Cart>)cart;
            }
            return View(lcart);
        }

        public ActionResult AddCart(int id)
        {
            var cart = Session[CARTSESSION];
            var product = new ProductDao().getDeital(id);

            if (cart != null)
            {
                var lcart = (List<Cart>)cart;

                if (lcart.Exists(p => p.product.ID == id))
                {
                    foreach (var item in lcart)
                    {
                        if (item.product.ID == id)
                        {
                            item.quantity++;
                        }
                    }
                }
                else
                {
                    var item = new Cart();
                    item.product = product;
                    item.quantity = 1;

                    lcart.Add(item);
                   
                }
            }
            else
            {
                var item = new Cart();
                item.product = product;
                item.quantity = 1;

                var list = new List<Cart>();
                list.Add(item);
                Session[CARTSESSION] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult DeleteCart(int id)
        {
            var lcart = (List<Cart>)Session[CARTSESSION];

            lcart.RemoveAll(x => x.product.ID == id);

            Session[CARTSESSION] = lcart;

            return Json(new
            {
                status = true
            });
        }

    }
}
