using BudgetTool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BudgetTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult transactionHistory()
        {
            var transactionHistory = new TransactionHistory();
            return View();
        }

        public IActionResult category()
        {
            var category = new Category();
            return View();
        }

        [HttpPost]
        public IActionResult SaveTransaction(TransactionHistory model)
        {
            if (ModelState.IsValid)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Invalid data" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
