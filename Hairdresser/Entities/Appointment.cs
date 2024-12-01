namespace Hairdresser.Entities
{
   
    public class Appointment
    {
        public int appointmentID { get; set; } // Primary Key
        public DateTime appointmentDate { get; set; }       // Randevu tarihi
        public bool IsConfirmed { get; set; }   // Randevunun onaylanıp onaylanmadığı
        public int customerID { get; set; } // Foreign Key (Müşteri)
        public Customer ?Customer { get; set; }

        public int personnelID { get; set; }    // Foreign Key (Çalışan)
        public Personnel ?personnel { get; set; }

        public int serviceID { get; set; }   // Foreign Key (Hizmet)
        public Service ?service { get; set; }

        
    }
}
