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
        public DbSet<Company> Companies { get; set; }
    }
}
