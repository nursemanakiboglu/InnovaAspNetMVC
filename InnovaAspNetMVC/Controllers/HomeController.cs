using InnovaAspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InnovaAspNetMVC.Controllers
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
        public IActionResult Example()
        {
            var name = "ahmet";
            ViewData["namekey"] = name;
            ViewBag.namekey2 = "mehmet";

            // "ViewBag" kullanılarak "product" adında bir dinamik özellik oluşturuluyor ve içine yeni bir "Product" nesnesi atanıyor.
            ViewBag.product = new Product { Id = 1, Name = "kalem 1", Price = 100 };

            // "ViewData" sözlüğü kullanılarak "product2" adında bir veri oluşturuluyor ve içine yeni bir "Product" nesnesi atanıyor.
            ViewData["product2"] = new Product { Id = 1, Name = "kalem 2", Price = 100 };

            //aşağıdaki kavramlar performans açısından zararlıdır
            // int tipini => object tipine çevirmek (boxing)
            // object tipini => int tipne çevirmek (unboxing)

            // "productList" adında bir liste oluşturuluyor ve içine üç "Product" nesnesi ekleniyor.
            var productList = new List<Product>
            {
                new() { Id = 1, Name = "Kalem 1", Price = 100 },

                new() { Id = 2, Name = "Kalem 2", Price = 200 },

                new() { Id = 3, Name = "Kalem 3", Price = 300 }
            };
            var productList2 = new List<Product>
            {
                new() { Id = 1, Name = "Kalem 1", Price = 100 },

                new() { Id = 2, Name = "Kalem 2", Price = 200 },

                new() { Id = 3, Name = "Kalem 3", Price = 300 }
            };

            // "ViewBag" kullanılarak "productList" adında bir dinamik özellik oluşturuluyor ve içine "productList" listesi atanıyor.
            ViewBag.productList = productList;

            //return View(Tuple.Create(productList, productList2))

            // TempData kullanılarak "email" adında bir geçici veri oluşturuluyor ve içine "nursema@outlook.com" değeri atanıyor.
            TempData["email"] = "nursema@outlook.com"; //email datası taşınır.

            // TempData.Keep("email");

            // "Example" sayfasına productList ve productList2 verilerini taşıyan bir modelle gönderim yapılıyor.
            return View((productList, productList2));
        }
        public IActionResult Example2()
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