using InnovaAspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovaAspNetMVC.Filters
{
    // NotFountFilter adında bir filtre sınıfı tanımlanıyor ve ActionFilterAttribute sınıfından kalıtım alıyor.
    public class NotFountFilter : ActionFilterAttribute
    {
        // productList adında statik bir ürün listesi tanımlanıyor.
        private static List<Product> productList = new List<Product>()
        {
            new() { Id = 1, Name = "kalem 1" }
        };

        // Eylem (action) çalıştırılmadan önce bu asenkron metot çağrılacak.
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // İlgili eylem argümanlarında "Id" anahtarına sahip bir değeri var mı kontrol edilir.
            var hasId = context.ActionArguments.FirstOrDefault();

            // "Guard" veya "Fast fail" yöntemiyle, eğer "Id" anahtarına sahip bir değer yoksa, işlem sonlandırılır ve sonraki adıma geçilir.
            if (hasId.Value == null)
            {
                await next();
                return;
            }

            // Eğer "Id" değeri bir tamsayıya çevrilemezse, işlem sonlandırılır ve sonraki adıma geçilir.
            if (!int.TryParse(hasId.Value.ToString(), out int id))
            {
                await next();
                return;
            }

            // Eğer ürün listesinde "Id" değerine sahip bir ürün yoksa, işlem sonlandırılır ve kullanıcı "Error" adında bir eyleme yönlendirilir.
            if (productList.Any(x => x.Id == id))
            {
                await next();
                return;
            }

            // Eğer yukarıdaki koşullar sağlanmazsa, kullanıcı "Home" den "Error" adındaki eyleme yönlendirilir.
            context.Result = new RedirectToActionResult("Error", "Home", null);
        }
    }
}
