using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;

namespace SimCard.APP.Persistence
{
    public class SimCardDBContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Configuration> Configurations { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Cashbook> Cashbook { get; set; }

        public DbSet<Bankbook> Bankbook { get; set; }

        public DbSet<Network> Networks { get; set; }

        public DbSet<ImportReceipt> ImportReceipts { get; set; }

        public DbSet<ImportReceiptProducts> ImportReceiptProducts { get; set; }

        public DbSet<ExportReceipt> ExportReceipts { get; set; }

        public DbSet<ExportReceiptProducts> ExportReceiptProducts { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public SimCardDBContext(DbContextOptions<SimCardDBContext> options) : base(options)
        {

        }
    }
}