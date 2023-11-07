using System;
using Microsoft.EntityFrameworkCore;

namespace lotus.DataProvide
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1444;Initial Catalog=lotus;User ID=sa;Password=Test1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.PhotoUrl).HasColumnName("photoUrl").HasMaxLength(999);;

                entity.Property(e => e.Price).HasColumnName("price");

            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.ToTable("ProductDetails");

                entity.Property(e => e.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.HasOne(p => p.Product)
                .WithMany(d => d.ProductDetails)
                .HasForeignKey(p => p.ProductId);

            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.HasOne(p => p.Product)
                .WithMany(d => d.CartItems)
                .HasForeignKey(p => p.ProductId);

                entity.HasOne(p => p.User)
                .WithMany(d => d.CartItems)
                .HasForeignKey(p => p.UserId);

            });


            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

                entity.Property(e => e.Products).HasColumnName("products");

                entity.Property(e => e.IsPaid).HasColumnName("isPaid");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(p => p.User)
                .WithMany(d => d.Orders)
                .HasForeignKey(p => p.UserId);

            });
        }
    }
}


