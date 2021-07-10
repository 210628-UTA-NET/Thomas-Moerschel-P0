using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DLEntities
{
    public partial class FirstDatabaseContext : DbContext
    {
        public FirstDatabaseContext()
        {
        }

        public FirstDatabaseContext(DbContextOptions<FirstDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreFront> StoreFronts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("customerAddress");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("customerEmail");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("customerName");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LineItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("lineItemId");

                entity.Property(e => e.LineItemIdName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("lineItemIdName");

                entity.Property(e => e.LineItemQuantity).HasColumnName("lineItemQuantity");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("lineItems_foreign_key2");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("lineItems_foreign_key3");

                entity.HasOne(d => d.Store)
                    .WithMany()
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("lineitems_foreign_key1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.OrderLocation)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("orderLocation");

                entity.Property(e => e.OrderPrice).HasColumnName("orderPrice");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("orders_foreign_key1");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("orders_foreign_key2");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ProductCategory)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("productCategory");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("productPrice");
            });

            modelBuilder.Entity<StoreFront>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__StoreFro__1EA7161391AE2E64");

                entity.ToTable("StoreFront");

                entity.Property(e => e.StoreId)
                    .ValueGeneratedNever()
                    .HasColumnName("storeId");

                entity.Property(e => e.StoreAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("storeAddress");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("storeName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
