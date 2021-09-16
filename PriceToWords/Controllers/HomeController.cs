using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PriceToWords.Models;
using PriceToWords.Methods;

namespace PriceToWords.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
   

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(decimal? id)
        {
            if(id != null)
            {
                PriceViewModel vm = new PriceViewModel()
                {
                    Price = (Decimal)id,
                    PriceAsText = NumberToWords.PriceToWords(id.Value)
                };
                return View(vm);
            } 
            else
            {
                return View();

            }
        }

        [HttpGet]
        public IActionResult Convert(decimal? id)
        {
            if (id != null)
            {
                PriceViewModel vm = new PriceViewModel()
                {
                    Price = (Decimal)id,
                    PriceAsText = NumberToWords.PriceToWords(id.Value)
                };
                return View(vm);
            }
            else
            {
                return View();

            }
        }



        [HttpPost]
        public IActionResult ConvertPriceToText(decimal price)
        {
            try
            {
                var priceAsText = NumberToWords.PriceToWords(price);
                return Content(priceAsText);
            }
            catch (Exception ex)
            {
                // TODO: Log error
                Console.WriteLine(ex.Message);
                return Content("There was an issue converting price to words.");
            }     
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
