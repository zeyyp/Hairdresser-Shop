using Hairdresser.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hairdresser.Context
{

    public class ApplicationDbContext : IdentityDbContext<AppUser,Role,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Salon>? salons { get; set; }
        public DbSet<Personnel>? personnels { get; set; }
        public DbSet<Expertise>? expertises { get; set; }
        public DbSet<Service>? services { get; set; }
        public DbSet<Appointment>? appointments { get; set; }
      //  public DbSet<Customer>? customers { get; set; }
      
       // public DbSet<Admin>? admins { get; set; }
        //  public DbSet<Photo> Photos { get; set; }

        


    }
}
