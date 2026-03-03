using DapperDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DapperDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        // EF Core DbSet for Company
        public DbSet<Company> Companies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // explicit primary key
            modelBuilder.Entity<Company>()
                .HasKey(c => c.CompanyId);

            // seed data - tracked by migrations
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    CompanyId = 1,
                    Name = "Acme Corp",
                    Address = "1 Acme Way",
                    City = "Metropolis",
                    State = "CA",
                    PostalCode = "90001"
                },
                new Company
                {
                    CompanyId = 2,
                    Name = "Contoso Ltd",
                    Address = "42 Contoso Blvd",
                    City = "Redmond",
                    State = "WA",
                    PostalCode = "98052"
                },
                new Company
                {
                    CompanyId = 3,
                    Name = "Fabrikam",
                    Address = "500 Main St",
                    City = "Seattle",
                    State = "WA",
                    PostalCode = "98101"
                }
            );
        }
    }
}
