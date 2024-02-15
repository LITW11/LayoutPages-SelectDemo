using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Northwnd; Integrated Security=true;";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyOtherPage()
        {
            return View();
        }

        public IActionResult Products()
        {
            var db = new NorthwindDb(_connectionString);
            return View(new ProductsViewModel
            {
                Products = db.GetProducts()
            });
        }
    }
}

//Create a .Net Core MVC Application. Get rid of the Privacy page. On the home
//page, display a list of orders from the northwind database.
