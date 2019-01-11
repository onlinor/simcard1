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
    }
}