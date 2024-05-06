using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;




namespace Project1.Controllers
{
    public class LoginController : Controller
    {

        private ProductContext context { get; set; }
        public LoginController(ProductContext conx)
        {
            context = conx;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserData data)
        {
            if(data.Email == "admin@gmail.com" && data.Password == "123")
            {
                HttpContext.Session.SetString("email", data.Email);

                var Pro = context.Categories.ToList();
                return View("Category" ,Pro);
            }
            return View("Login");

        }

        public IActionResult BackToCategory()
        {
            //check if session exits here
            string s = HttpContext.Session.GetString("email");
            if (s != null)
            {
                //get categories from db
                List<Category> categorieslist = context.Categories.ToList();
                return View("Category", categorieslist);
            }

            return View("Login");

        }


        [HttpGet]
        public IActionResult Search(string searchval)
        {
            List<Category> selcategory = context.Categories.Where(e => e.Namecategory.Contains(searchval)).ToList();
            return View("Category",selcategory);
        }
        //public IActionResult Show()
        //{
            

        //        var Pro = context.Categories.ToList();
        //        return View("Category", Pro);
           

        //}



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");

        }




    }
}
