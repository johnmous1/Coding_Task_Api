using Coding_Task_Api.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Coding_Task_Api.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Customer>().OwnsOne(c => c.FullName);
                modelBuilder.Entity<Customer>().OwnsOne(c => c.Address);
                modelBuilder.Entity<Order>().HasMany(o => o.Items).WithOne().IsRequired();
            }
    }

}
