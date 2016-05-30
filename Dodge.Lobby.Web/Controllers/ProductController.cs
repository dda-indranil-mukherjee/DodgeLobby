using Dodge.Lobby.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dodge.Lobby.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [Authorize]
        public ActionResult Index(int id)
        {
            ViewBag.Message = "Your List of Subscribed Products";

            Product p = new Product();
            List<Product> prodList = p.GetProducts(id);

            return View(prodList);
        }
    }
}