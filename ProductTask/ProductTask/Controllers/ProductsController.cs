using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductTask.Entities;
using ProductTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductTask.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>
        {
        new Product
        {
            Id = 1,
            Name="Dress",
            Description="Red and cotton",
            Price=50,
            Discount=10
        },
        new Product {
            Id = 2,
            Name="Trousers",
            Description="Jeans",
            Price=30,
            Discount=20
        },
          new Product {
            Id = 3,
            Name="T-Shirts",
            Description="Green",
            Price=20,
            Discount=15
        }

        };
        public IActionResult Index()
        {
            return View(products);
        }


        public IActionResult Delete(int id)
        {
            var item = products.FirstOrDefault(p =>p.Id == id);
            if (item != null)
            {
                products.Remove(item);
                TempData["Message"] = $"{item.Name} deleted successfully";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var product = new Product();
            return View(product);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = (new Random()).Next(1, 10000);
                products.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = products.FirstOrDefault(p => p.Id == id);
            return View(item);

        }
        [HttpPost]
        public IActionResult Update(Product product) 
        {
            if (ModelState.IsValid) {
                var item = products.FirstOrDefault(p => p.Id == product.Id);
                if (item != null)
                {
                    products.Remove(item);
                    products.Add(product);
                    return RedirectToAction("Index");
                }

            }
            return View(product);
        }
    }
}

