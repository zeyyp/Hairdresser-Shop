using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Areas.Admin.Models
{
    public class RoleAtaViewModel
    {
        public int? Id { get; set; }
           
        public IList<string>? selectedRoles { get; set; }
    }
}
