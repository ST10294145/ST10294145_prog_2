using Microsoft.AspNetCore.Mvc;
using ST10294145_prog_2.Models;
using ST10294145_prog_2.Models.ST10294145_prog_2.Models;
using System.Diagnostics;

namespace ST10294145_prog_2.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = InMemoryData.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                ViewBag.Message = "Invalid username or password";
                return View("Index");
            }

            HttpContext.Session.SetString("UserRole", user.Role);
            return RedirectToAction("Dashboard", "Claims");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


    }
}
