namespace Hairdresser.Entities
{
    public class Expertise
    {
        public int expertiseID { get; set; } // Primary Key
        public string ?expertiseName { get; set; }  // Saç Kesimi, Saç Boyama vb.
  
        public ICollection<Personnel> ?personnels { get; set; }          // Uzmanlık alanı ile ilişkilendirilmiş çalışanlar
    }
}
