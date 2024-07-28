using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingEFCoreDatabaseFirst.Data;

namespace UsingEFCoreDatabaseFirst.Controllers
{
    public class ProductController : Controller
    {
        private NorthwindContext _db = new NorthwindContext();

        public IActionResult Index()
        {
            var products = from p in _db.Products select p;
            return View(products);
        }
    }
}