using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;

namespace SimCard.APP.Persistence
{
    public class SimCardDBContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductExchange> ProductExchanges { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Debtbook> Debtbook { get; set; }

        public DbSet<Configuration> Configurations { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Cashbook> Cashbook { get; set; }

        public DbSet<Bankbook> Bankbook { get; set; }

        public DbSet<Network> Networks { get; set; }

        public DbSet<NetworkRange> NetworkRanges { get; set; }

        public DbSet<ImportReceipt> ImportReceipts { get; set; }

        public DbSet<ImportReceiptProducts> ImportReceiptProducts { get; set; }

        public DbSet<ExportReceipt> ExportReceipts { get; set; }

        public DbSet<ExportReceiptProducts> ExportReceiptProducts { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<User> Users { get; set; }

        public SimCardDBContext(DbContextOptions<SimCardDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var salt = PasswordHelper.GetSalt();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "",
                    LastName = "",
                    Username = "admin",
                    PasswordSalt = salt,
                    Password = PasswordHelper.HashPassword("admin", salt),
                    Role = Role.Company
                },
                new User
                {
                    Id = 2,
                    FirstName = "Sang",
                    LastName = "Tran",
                    Username = "transang",
                    PasswordSalt = salt,
                    Password = PasswordHelper.HashPassword("!@#$%", salt),
                    Role = Role.Branch
                },
                new User
                {
                    Id = 3,
                    FirstName = "Galvin",
                    LastName = "Nguyen",
                    Username = "branch",
                    PasswordSalt = salt,
                    Password = PasswordHelper.HashPassword("!@#$%", salt),
                    Role = Role.Branch
                }
            );
            modelBuilder.Entity<Shop>().HasData(
                new Shop
                {
                    Id = 1,
                    Name = "Tổng Công Ty"
                },
                new Shop
                {
                    Id = 2,
                    Name = "Sim Toàn Cầu"
                },
                new Shop
                {
                    Id = 3,
                    Name = "Alo Sim"
                },
                new Shop
                {
                    Id = 4,
                    Name = "Sim Thần Tài"
                }
            );
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier
                {
                    Id = 1,
                    Name = "Viettel"
                },
                new Supplier
                {
                    Id = 2,
                    Name = "Vinaphone"
                },
                new Supplier
                {
                    Id = 3,
                    Name = "Mobiphone"
                },
                new Supplier
                {
                    Id = 4,
                    Name = "Vietnam Mobile"
                }
            );
        }
    }
}