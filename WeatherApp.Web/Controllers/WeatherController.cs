using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Web.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.Web.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<WeatherModel> ReturnDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22");
                var data = await response.Content.ReadAsStringAsync();
                WeatherModel model = JsonConvert.DeserializeObject<WeatherModel>(data);
                return model;
            }
        }
       
        public async Task<IActionResult> Index()
        {
            var data = await ReturnDataAsync();
            return View(data);
        }
    }
}
