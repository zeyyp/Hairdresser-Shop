using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Models
{
    public class KullaniciKayitViewModel
    {
        [Required(ErrorMessage ="Lütfen ad ve soyad giriniz.")]
        public string adSoyad { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adı giriniz.")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Lütfen email giriniz.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen sifrenizi giriniz.")]
        [MinLength(6,ErrorMessage = "sifreniz en az 6 karakter olmalıdır.")]
        public string sifre { get; set; }


        [Required(ErrorMessage = "Lütfen sifrenizi tekrar giriniz.")]
        [Compare("sifre",ErrorMessage ="Sıfreler uyumlu değil ")]
        public string sifreTekrar { get; set; }
        
    }
}
