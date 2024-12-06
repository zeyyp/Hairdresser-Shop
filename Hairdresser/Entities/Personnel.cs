namespace Hairdresser.Entities
{
    public class Personnel
    {
        public int personnelID { get; set; } // Primary Key
        public string ?personnelName { get; set; }

        public string? personnelPassword { get; set; }
        public string? personnelEmail { get; set; }
        public string ?availableHours { get; set; } // Çalışanın müsait olduğu saatler
        public int salonID { get; set; } // Foreign Key
        public Salon ?salon { get; set; }  // Navigation property (Salon ile ilişki kurma)

        public Expertise ?expertises { get; set; } // Çalışanın uzmanlık alanları
       
        public ICollection<Appointment> ?appointments { get; set; }   // Çalışan ile ilişkilendirilmiş randevular
    }
   
}
