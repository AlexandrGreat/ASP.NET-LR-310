using LR9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace LR9.Components
{
    public class Task2Component : ViewComponent
    {
        public IViewComponentResult Invoke(string city,string country)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city},{country}&appid=a28598d19e603a2c376487760c42e48b&units=metric";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            Console.WriteLine(response);
            WeatherResponse weatherResponse  = JsonSerializer.Deserialize<WeatherResponse>(response);
            ViewBag.WeatherData = weatherResponse;
            ViewData["Header"] = $"TASK 2:";
            return View();
        }
    }
}
