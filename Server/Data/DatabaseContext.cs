using Microsoft.EntityFrameworkCore;
using TusklaBlazor.Server.Models;
using TusklaBlazor.Shared.Models;

namespace TusklaBlazor.Server.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VehicleOrderItems> VehicleOrderItems { get; set; } = null!;
        public virtual DbSet<VehicleOrderInfo> VehicleOrderInfo { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductOrderItems> ProductOrderItems { get; set; } = null!; // Added DbSet for ProductOrderItems
        public virtual DbSet<ProductOrderInfo> ProductOrderInfo { get; set; } = null!; // Added DbSet for ProductOrderInfo

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleOrderItems>(entity =>
            {
                entity.ToTable("vehicle_order_items");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OrderId).HasColumnName("OrderId");
                entity.Property(e => e.Description).IsRequired().HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Price); // You may want to specify the type and constraints for the Price property
            });

            modelBuilder.Entity<VehicleOrderInfo>(entity =>
            {
                entity.ToTable("vehicle_order_info");
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.OrderId).HasColumnName("OrderId");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Address).IsRequired().HasMaxLength(500).IsUnicode(false);
                entity.Property(e => e.City).IsRequired().HasMaxLength(500).IsUnicode(false);
                entity.Property(e => e.State).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Zip).IsRequired().HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.ProductId).HasColumnName("ProductId").ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Price).IsRequired(); // Remove MaxLength and Unicode constraints for integer type
                entity.Property(e => e.Category).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.imageSource).IsRequired().HasMaxLength(50).IsUnicode(false); // Adjust property naming convention
                entity.Property(e => e.isAvailable); // Assuming IsAvailable is a boolean property, specify type and constraints if needed
            });

            modelBuilder.Entity<ProductOrderItems>(entity => // Added configuration for ProductOrderItems
            {
                entity.ToTable("product_order_items");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OrderId).HasColumnName("OrderId");
                entity.Property(e => e.Description).IsRequired().HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Price); // You may want to specify the type and constraints for the Price property
                entity.Property(e => e.Quantity); // You may want to specify the type and constraints for the Price property

            });

            modelBuilder.Entity<ProductOrderInfo>(entity => // Added configuration for ProductOrderInfo
            {
                entity.ToTable("product_order_info");
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.OrderId).HasColumnName("OrderId");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Address).IsRequired().HasMaxLength(500).IsUnicode(false);
                entity.Property(e => e.City).IsRequired().HasMaxLength(500).IsUnicode(false);
                entity.Property(e => e.State).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Zip).IsRequired().HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
