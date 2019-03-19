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
        public DbSet<Product> Products{get; set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Event> Events { get; set;}
        public DbSet<Supplier> Suppliers {get; set;}
        public DbSet<Cashbook> Cashbook {get; set; }
        public DbSet<Bankbook> Bankbook {get; set; }
        public DbSet<Network> Networks {get; set; }
        public DbSet<ImportReceipt> ImportReceipts {get; set; }
        public DbSet<ExportReceipt> ExportReceipts {get; set; }

        
        // Configure composite key through Fluent API only 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImportReceipt>().HasKey(x => new {x.Prefixid, x.Suffixid});

        }
    }
}