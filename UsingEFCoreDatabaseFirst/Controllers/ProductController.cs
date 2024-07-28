using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using UsingEFCoreDatabaseFirst.Data;
using UsingEFCoreDatabaseFirst.Models.db;

namespace UsingEFCoreDatabaseFirst.Controllers
{
    public class ProductController : Controller
    {
        private NorthwindContext _db;

        public ProductController(NorthwindContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            // var products = from p in context.Products select p;
            var products = _db.Products
                              .Include(p => p.Category)  // join table
                              .Include(p => p.Supplier); // join table
            return View(products.ToList());
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_db.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_db.Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product products)
        {
            if (ModelState.IsValid)
            {
                _db.Add(products);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_db.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_db.Suppliers, "SupplierId", "CompanyName");
            return View(products);
        }

        public IActionResult SearchProducts(string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                return View("SearchProducts", _db.Products.ToList());
            }
            else
            {
                return View("SearchProducts", _db.Products.Where(p => p.ProductName.Contains(q)).ToList());
            }
        }

    }
}