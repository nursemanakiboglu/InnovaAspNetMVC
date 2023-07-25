using InnovaAspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaAspNetMVC.Controllers;

public class ModelBindingController : Controller
{
    public IActionResult Index()
    {
        return View(new Product());
    }
}