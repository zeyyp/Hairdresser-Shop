namespace Hairdresser.Entities
{
   
    public class Appointment
    {
        public int appointmentID { get; set; } // Primary Key
        public DateTime appointmentDate { get; set; }       // Randevu tarihi
        public TimeSpan appointmentHour { get; set; }       // Randevu saati
     
        public int customerID { get; set; } // Foreign Key (Müşteri)

        public string customerName { get; set; } = string.Empty;
        public AppUser ?Customer { get; set; }

        public int personnelID { get; set; }    // Foreign Key (Çalışan)
        public Personnel ?personnel { get; set; }

        public int serviceID { get; set; }   // Foreign Key (Hizmet)

        public string serviceName { get; set; }
        public Service ?service { get; set; }

        public bool IsConfirmed { get; set; }   // Randevunun onaylanıp onaylanmadığı
        public string notes { get; set; } 
        public string phone { get; set; } 


    }
}
