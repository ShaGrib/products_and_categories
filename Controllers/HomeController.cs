using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using products_and_categories.Models;
using Microsoft.EntityFrameworkCore;

namespace products_and_categories.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> AllCategories = _context.Categories.ToList();
            ViewBag.AllCategories = AllCategories;
            return View();
        }

        [Route("allproducts")]
        public IActionResult AllProducts()
        {
            List<Product> AllProducts = _context.Products.ToList();
            ViewBag.AllProducts = AllProducts;
            return View();
        }

        [HttpPost("addCategory")]
        public IActionResult addCategory(Category newCat)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(newCat);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                List<Category> AllCategories = _context.Categories.ToList();
                ViewBag.AllCategories = AllCategories;
                return View("Index");
            }
        }

        [HttpPost("addProduct")]
        public IActionResult addProduct(Product newProd)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(newProd);
                _context.SaveChanges();
                return RedirectToAction("allproducts");
            }
            else
            {
                List<Product> AllProducts = _context.Products.ToList();
                ViewBag.AllProducts = AllProducts;
                return View("allproducts");
            }
        }

        [HttpGet("{cid}")]
        public IActionResult OneCategory(int cid)
        {
            Category OneCategory = _context.Categories.Include(c => c.Products).ThenInclude(p => p.Product).FirstOrDefault(i => i.CategoryId == cid);
            ViewBag.AllProducts = _context.Products.Include(a => a.Categories).Where(a => !a.Categories.Any(c=>c.CategoryId == cid)).ToList();
            return View(OneCategory);
        }

        [HttpPost("catprodassociation")]
        public IActionResult catprodassociation(Association newAssociation)
        {
            _context.Associations.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("products/{pid}")]
        public IActionResult OneProduct(int pid)
        {
            Product OneProduct = _context.Products.Include(p => p.Categories).ThenInclude(c => c.Category).FirstOrDefault(i => i.ProductId == pid);
            ViewBag.AllCategories = _context.Categories.ToList();
            return View(OneProduct);
        }

        [HttpPost("prodcatassociation")]
        public IActionResult prodcatassociation(Association newAssociation)
        {
            _context.Associations.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("allproducts");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
