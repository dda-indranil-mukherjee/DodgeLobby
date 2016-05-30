using Dodge.Lobby.Framework.Configuration;
using Dodge.Lobby.Framework.SessionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Dodge.Lobby.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {

            return PartialView("_login");
        }

        [HttpPost]
        public ActionResult Login(Models.UserLoginInfo user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (user.IsValid(user.UserEmail, user.Password))
                    {
                        CookieHelper.WriteCookie(user.UserId.ToString(), user.FirstName, user.Remember);
                        return RedirectToAction("Index", "Product", new { @id = user.UserId });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login data is incorrect!");
                        return View("Index", user);
                    }
                }
                return View(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Logout()
        {
            try
            {
                Session.Abandon();
                CookieHelper.RemoveCookie();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

