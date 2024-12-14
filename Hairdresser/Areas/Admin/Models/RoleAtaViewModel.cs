using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Areas.Admin.Models
{
    public class RoleAtaViewModel
    {
        public int RoleId { get; set; }
        public string rolAdi { get; set; }
        public bool roleSahipMi { get; set; }
       
        
    }
}
