using LeilaoRT.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeilaoRT.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .ToTable("Category");

            modelBuilder.Entity<Item>()
                .ToTable("Item");

            modelBuilder.Entity<ItemCost>()
                .ToTable("ItemCost");

            modelBuilder.Entity<Item>()
                .HasIndex(i => new { i.AuctionId, i.LotNumber })
                .IsUnique();

            modelBuilder.Entity<Item>()
                .Property(i => i.ReferenceValue)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Item>()
                .Property(i => i.EstimatedSaleValue)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Item>()
                .Property(i => i.PurchaseValue)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ItemCost>()
                .Property(c => c.Amount)
                .HasPrecision(18, 2);
            
            modelBuilder.Entity<ItemCost>()
                .HasOne(c => c.Item)
                .WithMany(i => i.Costs)
                .HasForeignKey(c => c.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Location)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCost> Costs { get; set; }
    }
}
