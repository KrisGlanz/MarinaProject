using MarinaProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MarinaProject.Data
{
    public class MarinaDBContext : IdentityDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<Dock> Docks { get; set; }
        public DbSet<Leases> Leases { get; set; }
        public DbSet<AnnualLease> AnnualLeases { get; set; }
        public DbSet<PowerBoat> PowerBoats { get; set; }
        public DbSet<SailBoat> SailBoats { get; set; }
        public DbSet<Slip> Slips { get; set; }
        public DbSet<Employee> Employees { get; set; }



        public MarinaDBContext(DbContextOptions<MarinaDBContext> options)
            : base(options) {


        }



        public DbSet<MarinaProject.Models.RowBoat> RowBoat { get; set; }



        public DbSet<MarinaProject.Models.DailyLease> DailyLease { get; set; }

        

    }
}
