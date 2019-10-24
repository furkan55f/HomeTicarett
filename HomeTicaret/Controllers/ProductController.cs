
using HomeTicaretCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeTicaret.Controllers
{
    public class ProductController : AppControllerBase
    {
        // GET: Product
        [Route("Urun/{title}/{id}")] // gelen string title önemseme id bilgisini al
        public ActionResult Detail(string title, int id)
        {
            var db = new AppDb();
            ViewBag.IsLogin = this.IsLogin;
            var prod = db.Products.Where(x => x.ID == id).FirstOrDefault();
            return View(prod);
        }
    }
}