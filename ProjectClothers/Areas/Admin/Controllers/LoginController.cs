using ProjectClothers.Areas.Admin.Models;
using ProjectClothers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectClothers.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Index(User user)
        {
            bool check = new LoginDao().CheckLogin(user.Username, user.Password);

            if (check && ModelState.IsValid)
            {
                    Session[Common.SessionName.USER_SESSION] = user.Username;
                    return RedirectToAction("Index", "Category");
            }
            else
            {
                ModelState.AddModelError("", "Ten dang nhap hoac mat khau khong dung");
            }
            return View(user);
        }
        

    }
}
