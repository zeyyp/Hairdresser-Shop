

using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Lütfen rol adı giriniz")]
        public string name { get; set; }
    }
}
