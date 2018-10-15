using Microsoft.EntityFrameworkCore;
using SimCard.API.Models;
using SimCard.API.Models.RelationalClasses;

namespace SimCard.API.Persistence
{
    public class SimCardDBContext : DbContext
    {
        public SimCardDBContext(DbContextOptions<SimCardDBContext> options) : base(options) {}

        public DbSet<Shop> Shops{get; set;}
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductShop>()
                .HasKey(k => new { k.ShopID, k.ProductID });

            modelBuilder.Entity<ProductShop>()
                .HasOne(pro => pro.Product)
                .WithMany(ps => ps.ProductShops)
                .HasForeignKey(pro => pro.ProductID);

            modelBuilder.Entity<ProductShop>()
                .HasOne(sh => sh.Shop)
                .WithMany(ps => ps.ProductShops)
                .HasForeignKey(sh => sh.ShopID);
        }
    }
}