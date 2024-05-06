
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        private ProductContext context { get; set; }
        public HomeController(ProductContext conx)
        {
            context = conx;
              
                }
        //redicrects the user to the website's home page
        public IActionResult ProductList()
        {
            var Pro= context.Products.OrderBy(p=> p.ProductName).ToList();
            return View(Pro);
        }

        //redicrects the user to the about page
        public IActionResult About()
        {
            return View();
        }

        //redicrects the user to the contact us page
        public IActionResult ContactUs()
        {
            return View();
        }
      
        public  IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
