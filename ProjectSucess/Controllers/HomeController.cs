using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSucess.Data;
using ProjectSucess.Models;
using ReflectionIT.Mvc.Paging;

namespace ProjectSucess.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext _db)

        {
            db = _db;

        }

      
        public IActionResult Index(string searching)
        {
            return View(db.TotalProducts.Where(x => x.ProductDescription.Contains(searching) || searching == null).ToListAsync());
        }


        [HttpGet]
        public async Task <IActionResult> Index()
        {
            return View(await db.Category.Include(c => c.TotalProducts).ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //public IActionResult Addtocart(int? Id)
        //{

        //    TotalProduct p = db.TotalProducts.Where(x => x.ProductId == Id).SingleOrDefault();
        //    return View(p);
        //}


        //[HttpPost]
        //public ActionResult Addtocart(TotalProduct total, string qty, int Id)
        //{
        //    TotalProduct p = db.TotalProducts.Where(x => x.ProductId == Id).SingleOrDefault();

        //    cart c = new cart();
        //    c.productid = p.ProductId;
        //    c.productname = p.ProductName;
        //    c.price = (float)p.ProductPrice;
        //    c.qty = Convert.ToInt32(qty);
        //    c.bill = c.price * c.qty;

        //    if (TempData["Cart"] == null)
        //    {
        //        List<cart> li = new List<cart>();
        //        li.Add(c);
        //        TempData["Cart"] = li;

        //    }
        //    else
        //    {
        //        List<cart> li2 = TempData["Cart"] as List<cart>;
        //        li2.Add(c);
        //        TempData["Cart"] = li2;
        //    }
        //    TempData.Keep();
        //    return RedirectToAction("Index");
        //}
        //public ActionResult checkout()
        //{
        //    TempData.Keep();


        //    return View();
        //}

        //public ActionResult Adcart (int productId )
        //{
        //    var item = new List<cart>();
        //    var product = db.TotalProducts.Find(productId);
        //    item.Add(new cart()
        //    {
        //     ttlProduct=product,
        //     qty=1,

        //    });
        //   Session["item"] = item;
        //    return View();
        //}

        //public IActionResult Show()
        //{
        //    if (TempData["cart"] != null)
        //    {
        //        float x = 0;
        //        List<Cart> li2 = TempData["Cart"] as List<Cart>;
        //        foreach (var item in li2)
        //        {
        //            x += item.bill;

        //        }

        //        TempData["total"] = x;
        //    }
        //    TempData.Keep();
        //    return View(db.TotalProducts.OrderByDescending(x => x.ProductId).ToList());
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
