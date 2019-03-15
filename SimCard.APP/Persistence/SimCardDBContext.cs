using Microsoft.EntityFrameworkCore;
using SimCard.API.Models;

namespace SimCard.API.Persistence
{
    public class SimCardDBContext : DbContext
    {
        public SimCardDBContext(DbContextOptions<SimCardDBContext> options) : base(options)
        {

        }
        public DbSet<Shop> Shops{get; set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Event> Events { get; set;}
        public DbSet<Product> Products{get; set;}
        public DbSet<Warehouse> Warehouses{get; set;}
        public DbSet<Cashbook> Cashbook {get; set; }
        public DbSet<Bankbook> Bankbook {get; set; }
        public DbSet<Network> Networks {get; set; }
        public DbSet<Phieunhap> Phieunhaps {get; set; }
        
        // Configure composite key through Fluent API only 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phieunhap>().HasKey(p => new { p.Prefixid, p.Suffixid });
        }
    }
}