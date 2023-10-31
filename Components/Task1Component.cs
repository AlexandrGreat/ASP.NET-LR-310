using LR9.Models;
using Microsoft.AspNetCore.Mvc;

namespace LR9.Components
{
    public class Task1Component:ViewComponent
    {
        List<ProductModel> products = new List<ProductModel>
        {
            new ProductModel(1, "Glock", 2000.4),
            new ProductModel(2, "Desert Eagle", 4000),
            new ProductModel(3, "Tec-9", 3000.2),
            new ProductModel(4, "Sg-553", 5000.5),
            new ProductModel(5, "Negev", 8000.5),
            new ProductModel(6, "Five-Seven", 3000),
            new ProductModel(7, "AWP", 6000.7),
        };

        public IViewComponentResult Invoke()
        {
            int number = products.Count;
            if (Request.Query.ContainsKey("number"))
            {
                int.TryParse(Request.Query["number"], out number);
            }
            ViewBag.Products = products.Take(number);
            ViewData["Header"] = $"TASK 1:";
            return View();
        }
    }
}
