using Microsoft.AspNetCore.Mvc;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class SelectDemoController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Northwnd; Integrated Security=true;";

        private List<ColorOption> _colorOptions = new()
        {
            new(){Color = "Red", Id = 1},
            new(){Color = "Green", Id = 2},
            new(){Color = "Blue", Id = 3},
            new(){Color = "Purple", Id = 4},
            new(){Color = "Orange", Id = 5},
        };

        public IActionResult Index()
        {
            return View(_colorOptions);
        }

        public IActionResult SelectPost(int colorId)
        {
            return View(new SelectDemoViewModel
            {
                ColorOption = _colorOptions.FirstOrDefault(c => c.Id == colorId)
            });
        }

        public IActionResult Employees()
        {
            var db = new NorthwindDb(_connectionString);
            return View(new EmployeeVideModel
            {
                Employees = db.GetEmployees()
            });
        }
    }
}
