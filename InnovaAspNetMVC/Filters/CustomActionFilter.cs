using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InnovaAspNetMVC.Filters
{
    // CustomActionFilter adında bir filtre sınıfı tanımlanıyor ve ActionFilterAttribute sınıfından kalıtım alıyor.
    public class CustomActionFilter : ActionFilterAttribute
    {
        // Eylem (action) çalıştırılmadan önce bu metot çağrılacak.
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // "OnActionExecuting çalıştı" mesajı hata ayıklama çıktısına (Output Window) yazdırılır.
            Debug.WriteLine("OnActionExecuting çalıştı");
        }

        // Eylem (action) çalıştırıldıktan sonra bu metot çağrılacak.
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // "OnActionExecuted çalıştı" mesajı hata ayıklama çıktısına (Output Window) yazdırılır.
            Debug.WriteLine("OnActionExecuted çalıştı");
        }
    }
}
