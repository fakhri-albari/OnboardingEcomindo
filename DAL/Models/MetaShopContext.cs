using Microsoft.EntityFrameworkCore;

namespace OnboardingEcomindo.DAL.Models
{
    public class MetaShopContext : DbContext
    {
        public MetaShopContext(DbContextOptions<MetaShopContext> options) : base(options)
        {
        }

        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<DetailTransaction> DetailTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cashier>().ToTable("FCashier");
            modelBuilder.Entity<Item>().ToTable("FItem");
            modelBuilder.Entity<Transaction>().ToTable("FTransaction");
            modelBuilder.Entity<DetailTransaction>().ToTable("FDetailTransaction");
        }
    }
}
