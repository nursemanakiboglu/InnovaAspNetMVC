using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace InnovaAspNetMVC.Models
{
    // LoginViewModel sınıfı tanımlanıyor.
    public class LoginViewModel
    {
        // LoginViewModelFormData sınıfından bir nesne olan FormData tanımlanıyor.
        public LoginViewModelFormData FormData { get; set; }

        // LoginViewModelData sınıfından bir nesne olan Data tanımlanıyor ve bu nesne örnekleniyor.
        public LoginViewModelData Data { get; set; } = new();
    }

    // LoginViewModelFormData sınıfı tanımlanıyor.
    public class LoginViewModelFormData
    {
        // "HasUserName" adlı bir actiona ve "FormAndModelBinding" adlı bir kontrolöre uzaktan doğrulama yapılacak.
        [Remote(action: "HasUserName", controller: "FormAndModelBinding")]
        // "UserName" alanı zorunlu olduğu belirtiliyor ve kullanıcıya hata mesajı gösteriliyor.
        [Required(ErrorMessage = "username alanı gereklidir")]
        // "UserName" alanının tipi metin (text) olarak belirtiliyor.
        [DataType(DataType.Text)]
        // "UserName" alanının görünen adı "UserName :" olarak belirtiliyor.
        [Display(Name = "UserName :")]
        public string UserName { get; set; } = null!;

        // "Email" alanı zorunlu olduğu belirtiliyor ve kullanıcıya hata mesajı gösteriliyor.
        [Required(ErrorMessage = "email alanı gereklidir")]
        // "Email" alanının tipi e-posta adresi olarak belirtiliyor.
        [DataType(DataType.EmailAddress)]
        // "Email" alanının görünen adı "Email :" olarak belirtiliyor.
        [Display(Name = "Email :")]
        public string Email { get; set; } = null!;

        // "Password" alanı en fazla 8 karakter uzunluğunda olabilir, zorunlu olduğu belirtiliyor ve kullanıcıya hata mesajı gösteriliyor.
        [StringLength(8, ErrorMessage = "password en fazla 8 karakter olabilir")]
        [Required(ErrorMessage = "password alanı gereklidir")]
        // "Password" alanının tipi şifre (password) olarak belirtiliyor.
        [DataType(DataType.Password)]
        // "Password" alanının görünen adı "Password :" olarak belirtiliyor.
        [Display(Name = "Password :")]
        public string Password { get; set; } = null!;

        // "Country" alanı zorunlu olduğu belirtiliyor ve kullanıcıya hata mesajı gösteriliyor.
        [Required(ErrorMessage = "ülke seçimi yapınız")]
        // "Country" alanının görünen adı "Country :" olarak belirtiliyor.
        [Display(Name = "Country :")]
        public int? Country { get; set; }

        // "RememberMe" alanı, "RememberMe :" olarak görünecek bir onay kutusu (checkbox) alanı olarak belirtiliyor.
        [Display(Name = "RememberMe :")]
        public bool RememberMe { get; set; }

        // "Gender" alanı zorunlu olduğu belirtiliyor ve kullanıcıya hata mesajı gösteriliyor.
        [Required(ErrorMessage = "cinsiyet alanı gereklidir")]
        // "Gender" alanının görünen adı "Gender :" olarak belirtiliyor.
        [Display(Name = "Gender :")]
        public int? Gender { get; set; }
    }

    // LoginViewModelData sınıfı tanımlanıyor.
    public class LoginViewModelData
    {
        // "CountryMenu" adında SelectList tipinde bir özellik tanımlanıyor ve bu özellik null olarak atanıyor.
        [ValidateNever]
        public SelectList CountryMenu { get; set; } = null!;

        // "GenderMenu" adında GenderViewModel sınıfından oluşan bir liste tanımlanıyor ve bu liste boş bir liste olarak örnekleniyor.
        [ValidateNever]
        public List<GenderViewModel> GenderMenu { get; set; } = new();
    }
}
