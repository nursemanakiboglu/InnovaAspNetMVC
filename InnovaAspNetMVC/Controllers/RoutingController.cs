using Microsoft.AspNetCore.Mvc;

namespace InnovaAspNetMVC.Controllers;

public class RoutingController : Controller
{
    [Route("[controller]/[action]/{name}")] // ifadesi, ASP.NET Core MVC'de bir action methodunun URL'sini belirlemek için kullanılan bir attribute (öznitelik) dir.
    // süslü parantez olarak belirtilen yer parametredir.
    //action ifadesi Index olur
    public IActionResult Index(int name) //name'e gelen parametreye karşılık gelen URl ile çağrıldığında çalışır.
    {
        ViewBag.id = name;

        return View();
    }


    public IActionResult Index2(int userId, string userName)
    {
        ViewBag.userId = userId;
        ViewBag.userName = userName;

        return View();
    }
}