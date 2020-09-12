//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using LearnASPNETCoreMVCWithRealApps.Helpers;
//using Microsoft.AspNetCore.Mvc;
//using ProjectSucess.Data;
//using ProjectSucess.Models;

//namespace ProjectSucess.Controllers
//{
//    [Route("cart")]

//    public class CartController : Controller
//    {
//        private ApplicationDbContext db;

//        public CartController(ApplicationDbContext _db)

//        {
//            db = _db;

//        }

//        [Route("index")]
//        public IActionResult Index()
//        {
//            var cart = SessionHelper.GetObjectFromJson<List<cart>>(HttpContext.Session, "cart");
//            ViewBag.cart = cart;
//            ViewBag.total = cart.Sum(item => item.totalProduct.ProductPrice * item.qty);
//            return View();
//        }

//        [Route("buy/{id}")]
//        public IActionResult Buy(string id)
//        {
//            TotalProduct totalProduct = new TotalProduct();
//            if (SessionHelper.GetObjectFromJson<List<cart>>(HttpContext.Session, "cart") == null)
//            {
//                List<cart> cart = new List<cart>();
//                cart.Add(new cart { totalProduct = totalProduct.find(id), qty = 1 });
//                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
//            }
//            else
//            {
//                List<cart> cart = SessionHelper.GetObjectFromJson<List<cart>>(HttpContext.Session, "cart");
//                int index = isExist(id);
//                if (index != -1)
//                {
//                    cart[index].qty++;
//                }
//                else
//                {
//                    cart.Add(new cart { totalProduct = totalProduct.find(id), qty = 1 });
//                }
//                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
//            }
//            return RedirectToAction("Index");
//        }

//        [Route("remove/{id}")]
//        public IActionResult Remove(string id)
//        {
//            List<cart> cart = SessionHelper.GetObjectFromJson<List<cart>>(HttpContext.Session, "cart");
//            int index = isExist(id);
//            cart.RemoveAt(index);
//            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
//            return RedirectToAction("Index");
//        }

//        private int isExist(string id)
//        {
//            List<cart> cart = SessionHelper.GetObjectFromJson<List<cart>>(HttpContext.Session, "cart");
//            for (int i = 0; i < cart.Count; i++)
//            {
//                if (cart[i].totalProduct.ProductId.Equals(id))
//                {
//                    return i;
//                }
//            }
//            return -1;
//        }
//    }
//}
