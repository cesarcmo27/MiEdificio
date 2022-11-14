using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Category> Categories { get; set; }


        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Group>()
            .HasMany(c => c.Categories)
            .WithOne(d => d.Group);

            builder.Entity<Receipt>(x => x.HasKey(a => new { a.PeriodId, a.ApartmentId }));

            builder.Entity<Receipt>()
            .HasOne(u => u.Period)
            .WithMany(a => a.Receipts)
            .HasForeignKey(b => b.PeriodId);

            builder.Entity<Receipt>()
            .HasOne(u => u.Apartment)
            .WithMany(a => a.Receipts)
            .HasForeignKey(b => b.ApartmentId);
        }
    }
}