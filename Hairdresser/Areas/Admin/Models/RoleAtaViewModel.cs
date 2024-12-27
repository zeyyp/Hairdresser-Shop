using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Areas.Admin.Models
{
    public class RoleAtaViewModel
    {
        public int? Id { get; set; } // Kullanıcının benzersiz ID'si 

        public IList<string>? selectedRoles { get; set; }  // Kullanıcıya atanacak rollerin listesi (null olabilir)
    }
}
