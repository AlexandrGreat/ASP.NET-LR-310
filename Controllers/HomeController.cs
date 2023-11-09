using LR10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LR10.Controllers
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

        [HttpPost]
        public IActionResult Index(RegistrationModel registration)
        {
            if (registration.Date.DayNumber < DateOnly.FromDateTime(DateTime.Now).DayNumber)
            {
                ModelState.AddModelError("Date", "You can`t register for passed day (Invent a time machine to do it).");
            }
            if (registration.Date.DayOfWeek.ToString() == "Saturday" || registration.Date.DayOfWeek.ToString() == "Sunday") 
            {
                ModelState.AddModelError("Date", "You can`t register on Saturday or Sunday at all");
            }
            if (registration.Product=="Basics" && registration.Date.DayOfWeek.ToString() == "Monday")
            {
                ModelState.AddModelError("Date", $"You can`t register on Monday for this product ({registration.Product})");
            }
            if (ModelState.IsValid)
                return Content($"{registration.Name} ({registration.Email}) was successfully registered for {registration.Date} ({registration.Date.DayOfWeek}).\nConsulting for {registration.Product}.");
           return View(registration);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}