// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using QBank.Models;

namespace QBank.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Authentication> Authentications { get; set; }
        public DbSet<BankSlip> BankSlips { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<DebitCard> DebitCards { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<PIX> PIXs { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}