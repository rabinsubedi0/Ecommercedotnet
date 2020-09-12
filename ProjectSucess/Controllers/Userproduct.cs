using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnASPNETCoreMVCWithRealApps.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ProjectSucess.Data;
using ProjectSucess.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectSucess.Controllers
{

    public class Userproduct : Controller
    {
        private readonly ApplicationDbContext db;

        public Userproduct(ApplicationDbContext _db)

        {
            db = _db;

        }

        public IActionResult selecttype()
        {
            return View();

        }

        public async Task<IActionResult> Index()

        {
            return View(await db.Category.Include(c => c.TotalProducts).ToListAsync());
        }

        public async Task<IActionResult> Buy(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var pro = await db.TotalProducts.FindAsync(id);
            if (pro == null)
            {
                return NotFound();
            }


            return View(pro);
        }

    
        public async Task<IActionResult> Checkout( int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var produ = await db.TotalProducts.FindAsync(id);
            if (produ == null)
            {
                return NotFound();
            }

            return View(produ);
        }



        //[HttpGet]
        //public int GetPriceByproduct(int category)
        //{
        //    int Price = db.TotalProducts.FirstOrDefault(x =>x.ProductId== category).ProductPrice;
        //    return Price;
        //}


        //[HttpPost]
        //public IActionResult Save(checkout add)
        //{
        //    add.CheckoutId = DateTime.Now;
        //    db.Add(add);
        //    db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
    }

}
    

