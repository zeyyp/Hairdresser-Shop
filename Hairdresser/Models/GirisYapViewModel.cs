using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Models
{
    public class GirisYapViewModel
    {
        [Required(ErrorMessage = "Lütfen email giriniz.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen sifrenizi giriniz.")]
        [MinLength(6, ErrorMessage = "sifreniz en az 6 karakter olmalıdır.")]
        public string sifre { get; set; }
    }
}
