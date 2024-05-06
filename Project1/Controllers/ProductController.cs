using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Project1.Controllers
{
    public class ProductController : Controller
    {
       private ProductContext context { get; set; }
        public ProductController(ProductContext conx)
        {
            context = conx;

        }
       public ActionResult ShowDetails(int Id)
        {
            var P = context.Products.ToList();
            foreach (var d in P)
           {
                 if (d.ProductId== Id)
                    return View(d);
            }

            return View();
          
        }
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public IActionResult Edit(int id )
        {
            ViewBag.p = context.Products.OrderBy(g => g.ProductName).ToList();
            var product = context.Products.Find(id);
            return View(product);
        } 
        [HttpPost]
        public IActionResult Edit(Product up)
        {

           
            if (ModelState.IsValid)
            {
                context.Products.Update(up);
                context.SaveChanges();
                return RedirectToAction("BackToCategory", "Login");
            }
            else
                return View(up);
           
        }

    }



}
