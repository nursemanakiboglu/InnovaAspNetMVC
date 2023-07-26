using InnovaAspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InnovaAspNetMVC.Controllers
{
    // "FormAndModelBindingController" adında bir Controller sınıfı tanımlanıyor.
    // Bu Controller, URL'lerde "[controller]" adlı parametreyi kendi adıyla değiştirerek erişilebilir.
    [Route("[controller]/[action]")]
    public class FormAndModelBindingController : Controller
    {
        // GET metodu, Login sayfasını oluşturmak için kullanılır.
        // İlgili view model ve select listeleri oluşturulur ve view'a gönderilir.
        [HttpGet]
        public IActionResult Login()
        {
            var countryMenu = new List<CountryMenu>
            {
                new() { Text = "Türkiye", Value = 1 },
                new() { Text = "Almanya", Value = 2 },
                new() { Text = "Fransa", Value = 3 }
            };

            var genderMenu = new List<GenderViewModel>
            {
                new() { Text = "Erkek", Value = 2 },
                new() { Text = "Kadın", Value = 2 }
            };

            var loginViewModel = new LoginViewModel
            {
                Data =
                {
                    CountryMenu = new SelectList(countryMenu, "Value", "Text"),
                    GenderMenu = genderMenu
                }
            };

            return View(loginViewModel);
        }

        // POST metodu, Login sayfasından gönderilen veriyi işlemek için kullanılır.
        // Gelen veriler doğrulanır ve işleme tabi tutulur.
        [HttpPost]
        public IActionResult Login(LoginViewModel request)
        {
            var countryMenu = new List<CountryMenu>
            {
                new() { Text = "Türkiye", Value = 1 },
                new() { Text = "Almanya", Value = 2 },
                new() { Text = "Fransa", Value = 3 }
            };

            var genderMenu = new List<GenderViewModel>
            {
                new() { Text = "Erkek", Value = 1 },
                new() { Text = "Kadın", Value = 2 }
            };

            // Form'dan gelen verilerdeki ülke menüsü seçili elemanı atanır.
            request.Data.CountryMenu = new SelectList(countryMenu, "Value", "Text", 1);
            request.Data.GenderMenu = genderMenu;

            // ViewBag ile view'a model gönderilir.
            ViewBag.userViewModel = request;

            // ModelState doğrulaması yapılır.
            // Eğer modelde hatalar varsa, tekrar Login sayfası gösterilir.
            if (!ModelState.IsValid)
                return View(request);

            // Form'dan alınan şifre "12345" içeriyorsa, modelde hata eklenir ve tekrar Login sayfası gösterilir.
            if (request.FormData.Password.Contains("12345"))
            {
                ModelState.AddModelError(string.Empty, "password alanı ardışık sayı içeremez.");
                return View(request);
            }

            // Business işlemleri yapılır ve view gösterilir.
            // Bu örnekte, işlemler yapılmadan tekrar view gösteriliyor.
            return View(request);
        }

        // Bu metot hem GET hem de POST isteklerini kabul eder.
        // "HasUserName" adında bir Ajax doğrulama metodu olarak kullanılır.
        [AcceptVerbs("GET", "POST")]
        public IActionResult HasUserName([Bind(Prefix = "FormData.UserName")] string userName)
        {
            var names = new List<string>() { "ahmet", "mehmet", "hasan" };

            // Kullanıcı adı veritabanında mevcutsa, mesaj döndürülür.
            if (names.Contains(userName))
            {
                return Json("girmiş olduğunuz username veritabanında bulunmaktadır.");
            }

            // Kullanıcı adı veritabanında yoksa, true döndürülür.
            return Json(true);
        }
    }
}
