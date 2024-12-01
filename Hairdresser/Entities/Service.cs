namespace Hairdresser.Entities
{
    public class Service
    {
        public int serviceID { get; set; } // Primary Key
        public string ?serviceName { get; set; } // Saç Kesimi, Saç Boyama, vb.
        public int serviceDuration { get; set; } // Dakika cinsinden
        public decimal servicePrice { get; set; } // Fiyat

        public int salonID { get; set; }  // Foreign Key (Hizmet salonuna bağlı)
        public Salon ?salon { get; set; }  // Navigation property (Salon ile ilişki kurma)

       
        public ICollection<Appointment> ?appointments { get; set; }    // Hizmet ile ilişkilendirilmiş randevular
    }
}
