using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using System;
using System.Collections.Specialized;
using System.Linq;

namespace Project1.Controllers
{
    public class CategoryController : Controller
    {

        private ProductContext context { get; set; }
        public CategoryController(ProductContext conx)
        {
            context = conx;

        }




        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewProduct(int id)
        {
            var P = context.Products.Where(s => s.Category.Idcategory==id ).ToList();
           
         

 return View(P);

}


        




        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
           // check if session exits here
            string s = HttpContext.Session.GetString("email");
            if (s != null)
            {var p = context.Products.Find(id);
            context.Products.Remove(p);
            context.SaveChanges();

            return RedirectToAction( "BackToCategory" ,"Login");
            }

            return RedirectToAction("Login","Login");

            
           
        }
        [HttpGet]
        public IActionResult Add(int id)
        {

            return View(new Category());
        }
        [HttpPost]
        public IActionResult Add(Category  p)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(p);
                context.SaveChanges();
                return RedirectToAction("BackToCategory", "Login");
            }
            else
                return View(p);
        }

    }
}
