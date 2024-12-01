namespace Hairdresser.Entities
{
    public class Admin
    {
        public int adminID { get; set; } // Primary Key
        public string ?adminEmail { get; set; }
        public string ?adminPassword { get; set; }  
    }
}
