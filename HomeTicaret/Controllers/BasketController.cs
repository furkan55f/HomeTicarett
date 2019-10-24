using HomeTicaretCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeTicaret.Controllers
{
    public class BasketController : AppControllerBase
    {
        // GET: Basket
        [HttpPost]
        public JsonResult AddProduct(int productID, int quantity)
        {
            var db = new AppDb();
            db.Baskets.Add(new HomeTicaretCore.Entity.Basket
            {
                CreateDate =DateTime.Now,
                CreateUserID = LoginUserID,
                ProductID = productID,
                Quantity = quantity,
                UserID =LoginUserID
            });
            var rt = db.SaveChanges();
            return Json(rt, JsonRequestBehavior.AllowGet);
        }
        [Route("Sepetim")]
        public ActionResult Index()
        {
            var db = new AppDb();
            var data = db.Baskets.Include("Product").Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var db = new AppDb();
            var deleteitem = db.Baskets.Where(x => x.ID == id).FirstOrDefault();
            db.Baskets.Remove(deleteitem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}