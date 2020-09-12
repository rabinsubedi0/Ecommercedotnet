using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectSucess.Data;
using ProjectSucess.Models;

namespace ProjectSucess.Controllers
{
    public class ProductController : Controller
    {
        private readonly  ApplicationDbContext db;
        private readonly IWebHostEnvironment env;
        public ProductController(ApplicationDbContext _db,
            IWebHostEnvironment _env)

        {
            db = _db;
            env = _env;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(db.Category, "CategoryId", "CategoryName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TotalProduct bike)
        {
            if (ModelState.IsValid)   // it will check whether our form is valid or not
            {
                if (bike.ProductImage != null)
                {
                    string rootPath = env.WebRootPath;                    // get the root directory i.e. /wwwroot/
                    string uniqueName = Guid.NewGuid().ToString();

                    string fileName = uniqueName + bike.ProductImage.FileName;      // file uploaded name
                    string uploadPath = rootPath + "/Images/" + fileName;       // creating upload path
                    bike.ImageName = fileName;                                 // assing file name to bike>imagename                                                                                    
                    using (var filestream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await bike.ProductImage.CopyToAsync(filestream);
                    }
                }
                db.Add(bike);
                await db.SaveChangesAsync();
                return RedirectToAction("pro");
            }
            return View(bike);
        }



        public  IActionResult Index()
        {
            var query = from b in db.TotalProducts
                        join c in db.Category
                        on b.CategoryId equals c.CategoryId
                        select new TotalProduct
                        {
                            ProductId = b.ProductId,
                            ProductName = b.ProductName,
                            ProductPrice = b.ProductPrice,
                            Stock = b.Stock,
                            ProductDescription = b.ProductDescription,
                            Manufacture = b.Manufacture,
                            Expire = b.Expire,
                            CategoryId=b.CategoryId,
                            CategoryName = c.CategoryName
                        };

            // select * from bikes 
            List<TotalProduct> produ = query.ToList();  // ORM EF Core
            return View(produ);
        }
       
        [HttpPost]

        public IActionResult Index( string searching)
        {
            return View(db.TotalProducts.Where(x => x.ProductName.Contains(searching) || searching == null).ToList());
        }
        public async Task<IActionResult>Details(int? id)
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalProduct = await db.TotalProducts.FindAsync(id);
            if (totalProduct == null)
            {
                return NotFound();
            }
            return View(totalProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TotalProduct totalProduct)
        {
            if (ModelState.IsValid)
            {
                db.Update(totalProduct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(totalProduct);
        }

        public IActionResult Delete(int id)
        {
            // where bikeid = idD:\ProjectSucess\Views\Shared\
            TotalProduct totalProduct = db.TotalProducts.Find(id);
            db.TotalProducts.Remove(totalProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Index([FromForm] Admin_Login login, Manager manager)
        //{
        //    if (login.Admin) 
        //    {
        //        if (db.Admin_Login .Where(b => b.userName == login.userName && b.password == login.password).FirstOrDefault() == null)
        //        {
        //            return View();

        //        }
        //        else
        //        {
        //            return View("~/Views/Product/Create.cshtml");
        //        }
        //    }
        //    else
        //    {
        //        login.userName = manager.userName;
        //        login.password = manager.userPassword;

        //        if (db.manager.Where(c => c.userName == manager.userName && c.userPassword == manager.userPassword).FirstOrDefault() == null)
        //        {

        //            return View();

        //        }
        //        else
        //        {

        //            return View("~/Views/Product/Pro.cshtml");
        //        }
        //    }

        //}

    }
}