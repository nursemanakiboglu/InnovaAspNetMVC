using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InnovaAspNetMVC.TagHelpers
{
    // ItalicTagHelper adında bir TagHelper sınıfı tanımlanıyor.
    public class ItalicTagHelper : TagHelper
    {
        // Process metodu, TagHelper sınıfının üyesi olarak override ediliyor.
        // Bu metot, TagHelper'ın etiket özelliklerini işlemek için kullanılacak.

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // <i> </i> etiketleri oluşturuluyor.

            // output.PreContent.SetHtmlContent("<i>"); satırı, etiketin ön içeriğine "<i>" metnini eklemek için kullanılır.
            // Yani, TagHelper'ın kullanıldığı HTML etiketinin açılış tag'i ile "<i>" metni arasına "<i>" etiketini ekler.

            // output.PostContent.SetHtmlContent("</i>"); satırı, etiketin son içeriğine "</i>" metnini eklemek için kullanılır.
            // Yani, TagHelper'ın kullanıldığı HTML etiketinin kapanış tag'i ile "</i>" metni arasına "</i>" etiketini ekler.

            // Sonuç olarak, TagHelper'ın kullanıldığı etiket "<i>" ile "</i>" arasında olacak ve bu etiketin içeriği italik (italic) olarak görüntülenecektir.

            output.PreContent.SetHtmlContent("<i>");
            output.PostContent.SetHtmlContent("</i>");
        }
    }
}
