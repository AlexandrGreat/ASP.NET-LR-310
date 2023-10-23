using LR8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LR8.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ProductModel> products = new List<ProductModel>
            {
                new ProductModel(1, "Glock", 2000.4, "12.10.2003"),
                new ProductModel(2, "Desert Eagle", 4000, "12.12.2006"),
                new ProductModel(3, "Tec-9", 3000.2, "07.09.2009"),
                new ProductModel(4, "Sg-553", 5000.5, "22.08.2005"),
                new ProductModel(5, "Negev", 8000.5, "01.02.2000"),
                new ProductModel(6, "Five-Seven", 3000, "05.07.2015"),
                new ProductModel(7, "AWP", 6000.7, "04.06.2010"),
            };
            return View(products);
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