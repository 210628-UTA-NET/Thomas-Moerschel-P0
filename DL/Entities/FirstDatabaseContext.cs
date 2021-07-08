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
        public virtual DbSet<StoreFront> StoreFronts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {

                entity.ToTable("Customer");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<StoreFront>(entity =>
            {

                entity.ToTable("storeFront");

                entity.Property(e => e.StoreAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("store_address");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("store_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
