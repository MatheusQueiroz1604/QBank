// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using QBank.Models;

namespace QBank.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para a entidade Account
            modelBuilder.Entity<Account>()
            .Property(a => a.Balance)
            .HasColumnType("decimal(18, 2")
            .HasPrecision(18, 2);

            modelBuilder.Entity<Account>()
            .Property(a => a.availableBalance)
            .HasColumnType("decimal(18, 2")
            .HasPrecision(18, 2);

            modelBuilder.Entity<Account>()
            .Property(a => a.creditLimit)
            .HasColumnType("decimal(18, 2")
            .HasPrecision(18, 2);

            modelBuilder.Entity<Account>()
            .Property(a => a.currentBill)
            .HasColumnType("decimal(18, 2")
            .HasPrecision(18, 2);

            // Configuração para a entidade Transaction
            modelBuilder.Entity<Transaction>()
            .Property(t => t.amount)
            .HasColumnType("decimal(18, 2")
            .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
            .Property(t => t.interestRate)
            .HasColumnType("decimal(18, 4")
            .HasPrecision(18, 4);
    }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Para funcionar, substitua o User Id e a Password com seu usuário no AppDbContext (aqui no caso) e no appsettings
        optionsBuilder.UseSqlServer("Server=dbsqbank.database.windows.net;Database=QBank-DataBase;User Id=<seu_usuario>;Password=<sua_senha>;");
    }
        
    }
}