using Microsoft.AspNetCore.Identity;

namespace Hairdresser.Entities
{
    public class AppUser :IdentityUser<int>
    {

        public string adSoyad { get; set; }

        public ICollection<Appointment>? appointments { get; set; }       // Müşteri ile ilişkilendirilmiş randevular

    }
}
