using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Entities
{
   
    public class Appointment
    {
        public int appointmentID { get; set; } // Primary Key

        [Required(ErrorMessage = "Randevu tarihi gereklidir.")]
       [DataType(DataType.Date)]
        public DateTime appointmentDate { get; set; }       // Randevu tarihi

        [Required(ErrorMessage = "Randevu saati gereklidir.")]
        [DataType(DataType.Time)]
        public TimeSpan appointmentHour { get; set; }       // Randevu saati
     
        public int customerID { get; set; } // Foreign Key (Müşteri)

        [Required(ErrorMessage = "Müsteri adı tarihi gereklidir.")]
        public string customerName { get; set; } = string.Empty;
        public AppUser ?Customer { get; set; }

        [Required(ErrorMessage = "Personel seçimi gereklidir.")]
        public int personnelID { get; set; }    // Foreign Key (Çalışan)
        public Personnel ?personnel { get; set; }

        [Required(ErrorMessage = "Hizmet seçimi gereklidir.")]
        public int serviceID { get; set; }   // Foreign Key (Hizmet)

        public string serviceName { get; set; }
        public Service ?service { get; set; }

        public bool IsConfirmed { get; set; }   // Randevunun onaylanıp onaylanmadığı
        public string notes { get; set; }

        [Required(ErrorMessage = "Telefon numarası gereklidir.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string phone { get; set; } 


    }
}
