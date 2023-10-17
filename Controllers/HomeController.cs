using LR6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LR6.Controllers
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

        public IActionResult OrderBegin()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult OrderForm()
        {
            return View();
        }

        List<PizzaModel> pizzas = new List<PizzaModel>();

        public IActionResult TotalOrderPage()
        {
            return View();
        }

        public IActionResult TotalOrderPage(List<string> pizzaList)
        {
            foreach (string pizza in pizzaList)
            {
                pizzas.Add(new PizzaModel(pizza));
            }
            return View(pizzas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public int ordered=0;
        public int currentOrder = 1;
        public string order="";

        [HttpPost]
        public IActionResult OrderForm(string PizzaType,string Current, string Total,string TotalOrder) 
        {
            int next = int.Parse(Current) + 1;
            string order = TotalOrder + "," + PizzaType;
            ViewBag.ordered = int.Parse(Total);
            ViewBag.currentOrder = next;
            if (order.IndexOf(',') == 0)
            {
                ViewBag.totalOrder = order.Substring(1, order.Length - 1);
            }
            else
                ViewBag.totalOrder = order;
            if (int.Parse(Current) < int.Parse(Total))
            {
                return View("OrderForm");
            }
            else 
            {
                List<string>pizzaList = order.Split(',').ToList();
                TotalOrderPage(pizzaList);
            }
            return View("TotalOrderPage");
        }

        [HttpPost]
        public IActionResult Index(string Count, string Age)
        {
            int age = 0;
            if (int.TryParse(Age, out age))
            {
                if (int.TryParse(Count, out ordered))
                {
                    if (ordered > 0)
                    {
                        if (age >= 16)
                        {
                            ViewBag.ordered = ordered;
                            ViewBag.currentOrder = 1;
                            ViewBag.totalOrder = "";
                            return View("OrderForm");
                        }
                        else
                        {
                            Response.Redirect("ErrorAgePage");
                        }
                    }
                    else
                    {
                        Response.Redirect("ErrorCountPage");
                    }
                }
                else
                {
                    Response.Redirect("ErrorPage");
                }
            }
            else
            {
                Response.Redirect("ErrorPage");
            }
            return View("Index");
        }
    }
}