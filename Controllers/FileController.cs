using LR7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace LR7.Controllers
{
    public class FileController : Controller
    {
        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile(string Name, string Surname, string FileName)
        {
            byte[] mas = Encoding.ASCII.GetBytes($"{Name} {Surname}");
            string file_type = "text/plain";
            string file_name = $"{FileName}.txt";
            return File(mas, file_type, file_name);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
