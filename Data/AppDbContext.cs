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
        
    }
}