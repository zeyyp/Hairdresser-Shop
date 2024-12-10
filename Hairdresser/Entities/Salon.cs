namespace Hairdresser.Entities
{
    public class Salon 
    {
        public int salonID { get; set; }  // Primary Key
        public string ?salonName { get; set; }
        public string ?salonType { get; set; } // Kuaför veya Berber
        public string ?workingHours { get; set; } // Örneğin: "09:00-18:00"
        public string ?salonAddress { get; set; }

        // Salon ile ilişkilendirilmiş çalışanlar
        public ICollection<Personnel> ?personnels { get; set; }

        // Salon ile ilişkilendirilmiş hizmetler
        public ICollection<Service> ?Services { get; set; }
    }
}
