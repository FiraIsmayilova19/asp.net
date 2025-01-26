using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using intro.entity;
using intro.Models;
using Intro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace intro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private List<Drink> drinks = new List<Drink> {
            new Drink
            {
                id = 1,
                name = "Coca-cola",
                description = "cold drink",
                price =2
                },
            new Drink
            {
                id = 2,
                name = "Fanta",
                description = "cold drink",
                price =2
            },

            new Drink
            {
                id = 3,
                name ="tea",
                description ="hot drink",
                price =1
            }
};


        private List<FastFood> fastFoods = new List<FastFood>
        {
            new FastFood
            {
                id=1,
                name = "French Fries",
                description = "potatoes",
                price =3
            },

            new FastFood
            {
                id=2,
                name = "chicken burger",
                description = "burger",
                price =4
            },
            new FastFood
            {
                id=3,
                name = "nuggets",
                description = "chicken bites",
                price =3
            }


        };
        private List<HotMeal> hotmeals = new List<HotMeal>
        {
            new HotMeal
            {
                id=1,
                name = "Ash",

                price =7
            },

            new HotMeal
            {
                id=2,
                name = "Dolma",

                price =4
            },
            new HotMeal
            {
                id=3,
                name = "Merci supu",

                price =3
            }
            };
    
        public IActionResult Index()
        {
            var vm = new RestaurtantViewModel
            {
                Drink=drinks,
                FastFood=fastFoods,
                HotMeal=hotmeals
            };
            return View(vm);
        }
        public IActionResult Drinks()
        {
            return View(drinks);
        }
        public IActionResult FastFood()
        {
            return View(fastFoods);
        }
        public IActionResult HotMeal()
        {
            return View(hotmeals);
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
