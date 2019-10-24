﻿using HomeTicaretCore;
using HomeTicaretCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeTicaret.Controllers.Base
{
    public class OrderController : AppControllerBase
    {
        // GET: Order
        [Route("Siparisver")]
        public ActionResult AddressList()
        {
            var db = new AppDb();
            var data = db.Addresses.Where(x => x.UserID == LoginUserID).ToList();

            return View(data);
        }
        public ActionResult CreateUserAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUserAddress(UserAddress entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.CreateUserID = LoginUserID;
            entity.IsActive = true;
            entity.UserID = LoginUserID;

            var db = new AppDb();
            db.Addresses.Add(entity);
            db.SaveChanges();
            return RedirectToAction("AddressList" + "");
        }
        public ActionResult CreateOrder(int id)
        {
            var db = new AppDb();

            var sepet = db.Baskets.Include("Product").Where(x => x.UserID == LoginUserID).ToList();
            Order order = new Order();
            order.CreateDate = DateTime.Now;
            order.CreateUserID = LoginUserID;
            order.StatusId = 2;

            order.TotalProductPrice = sepet.Sum(x => x.Product.Price);
            order.TotalTaxPrice = sepet.Sum(x => x.Product.Tax);
            order.TotalDiscount = sepet.Sum(x => x.Product.Discount);
            order.TotalPrice = order.TotalProductPrice + order.TotalTaxPrice;
            order.UserAddressID = id;
            order.UserID = LoginUserID;
            order.OrderProducts = new List<OrderProduct>();

            foreach (var item in sepet)
            {
                order.OrderProducts.Add(new OrderProduct
                {
                    CreateDate = DateTime.Now,
                    CreateUserID = LoginUserID,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity
                });
                db.Baskets.Remove(item);
            }
            db.Orders.Add(order);

            db.SaveChanges();
            

            return RedirectToAction("Detail", new { id = order.ID });
        }
        public ActionResult Detail(int id)
        {
            var db = new AppDb();
            var data = db.Orders.Include("OrderProducts")
                .Include("OrderProducts.Product")
                .Include("OrderPayments")
                .Include("Status")
                .Include("UserAddress")
                .Where(x => x.ID == id).FirstOrDefault();

            return View(data);

        }
        [Route ("Siparislerim")]
        public ActionResult Index()
        {
            var db = new AppDb();
            var data = db.Orders.Include("Status ").Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
        }

        public ActionResult Pay(int id)
        {
            var db = new AppDb();
            var order = db.Orders.Where(x => x.ID == id).FirstOrDefault();
            order.StatusId = 7;
            db.SaveChanges();
            return RedirectToAction("Detail", new { id = order.ID });
        }
    }
}