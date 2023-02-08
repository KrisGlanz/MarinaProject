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


        public MarinaDBContext(DbContextOptions<MarinaDBContext> options)
            : base(options) {


        }

        

    }
}
