using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Entities
{
    public class Earnings
    {
        [Key]
        public int EarningsID { get; set; } // Primary Key
        public int PersonnelID { get; set; } // Foreign Key to Personnel

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } // Kazanç Tarihi
        public decimal TotalEarnings { get; set; } // Günlük Kazanç

        
        public Personnel Personnel { get; set; }
    }
}
