using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InnovaAspNetMVC.TagHelpers
{
    // ThumbnailImageTagHelper adında bir TagHelper sınıfı tanımlanıyor.
    public class ThumbnailImageTagHelper : TagHelper
    {
        // ImageUrl adında bir özellik tanımlanıyor. Bu özellik, görüntünün URL'sini tutacak.
        // Özellik başlangıçta null olabilir.
        public string ImageUrl { get; set; } = null!;

        // Process metodu, TagHelper sınıfından miras alınan ve override edilen bir metottur.
        // Bu metot, TagHelper'ın etiket özelliklerini işlemek için kullanılır.

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Etiket adı "img" olarak ayarlanıyor. Yani, bu TagHelper'ı kullandığımızda oluşturulacak etiket "<img>" olacaktır.
            output.TagName = "img";

            // ImageUrl'den dosya adını ve dosya uzantısını almak için gerekli işlemler yapılıyor.

            // Dosya adını almak için, ImageUrl özelliği nokta (.) karakterine göre bölünüyor ve dosya adı alınıyor.
            string fileName = ImageUrl.Split(".")[0];

            // Dosya uzantısını almak için, Path sınıfı kullanılıyor.
            // Path.GetExtension(ImageUrl) metodu, ImageUrl'deki dosya uzantısını döndürür.
            // Örneğin, "car.jpg" için ".jpg" döndürecektir.
            string fileExt = Path.GetExtension(ImageUrl);

            // Oluşturulacak <img> etiketine "src" özelliği ekleniyor.
            // "src" özelliği, görüntünün URL'sini belirler.
            // Dosya adı ve uzantısının arasına "-250x250" eklendiğinde, 250x250 boyutunda bir önizleme görüntüsü URL'si elde edilir.
            // Örneğin, "car.jpg" için "car-250x250.jpg" gibi bir URL oluşturulur.
            output.Attributes.SetAttribute("src", $"{fileName}-250x250{fileExt}");
        }
    }
}
