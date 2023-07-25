using InnovaAspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InnovaAspNetMVC.Controllers;

[Route("[controller]/[action]")]
public class FormAndModelBindingController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        // 1. CountryMenu'yu oluşturma
        var countryMenu = new List<CountryMenu>
        {
            new() { Text = "Türkiye", Value = 1 },
            new() { Text = "Almanya", Value = 2 },
            new() { Text = "Fransa", Value = 3 }
        };



        //var countryMenu2 = new List<SelectListItem>
        //{
        //    new() { Text = "Türkiye", Value = "1" },
        //    new() { Text = "Türkiye", Value = "1" }
        //};
        //ViewBag.countryMenu2 = new SelectList(countryMenu2, "Value", "Text", 1);


        // 2. GenderViewModel'u oluşturma
        var genderMenu = new List<GenderViewModel> //genderMenu değişkeni GenderViewModel türündeki nesneleri içeren bir liste olacaktır.
        {
            new() { Text = "Erkek", Value = 2 },

            new() { Text = "Kadın", Value = 2 }
        };

        
        // 3. LoginViewModel oluşturma ve içine CountryMenu ve GenderMenu'yu atama
        var loginViewModel = new LoginViewModel
        {
            Data =
            {
                CountryMenu = new SelectList(countryMenu, "Value", "Text", 1),
                GenderMenu = genderMenu
            }
        };


        // 4. Login view'ına LoginViewModel'i göndererek geri dönmek
        return View(loginViewModel);
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel request)
    {
        // 1. request parametresiyle LoginViewModel alındı ve ViewBag.userViewModel'a atanarak view içinde erişilebilir hale getirildi.
        ViewBag.userViewModel = request;

        // 2. CountryMenu'yu oluşturma
        var countryMenu = new List<CountryMenu>
        {
            new() { Text = "Türkiye", Value = 1 },
            new() { Text = "Almanya", Value = 2 },
            new() { Text = "Fransa", Value = 3 }
        };



        var genderMenu = new List<GenderViewModel>
        {
            new() { Text = "Erkek", Value = 1,  },

            new() { Text = "Kadın", Value = 2 }
        };


        request.Data.CountryMenu = new SelectList(countryMenu, "Value", "Text", 1);

        request.Data.GenderMenu = genderMenu;




        return View(request);
    }
}