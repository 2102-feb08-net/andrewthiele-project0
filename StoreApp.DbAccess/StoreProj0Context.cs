using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreApp.DbAccess
{
    public partial class StoreProj0Context : DbContext
    {
        public StoreProj0Context()
        {
        }

        public StoreProj0Context(DbContextOptions<StoreProj0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("customerID");

                entity.Property(e => e.Balance)
                    .HasColumnType("money")
                    .HasColumnName("balance")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("firstName")
                    .HasDefaultValueSql("('Bob')");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("lastName")
                    .HasDefaultValueSql("('Jones')");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.InvoiceId)
                    .ValueGeneratedNever()
                    .HasColumnName("InvoiceID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.TimeOfOrder)
                    .HasColumnName("timeOfOrder")
                    .HasDefaultValueSql("(sysdatetimeoffset())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Invoices__Custom__1332DBDC");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Invoices__Locati__151B244E");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId)
                    .ValueGeneratedNever()
                    .HasColumnName("locationID");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address1")
                    .HasDefaultValueSql("('THIS STREET')");

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address2")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("city")
                    .HasDefaultValueSql("('CITYTOWN')");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(100)
                    .HasColumnName("nickname")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("state")
                    .HasDefaultValueSql("('STATE')");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("orderID");

                entity.Property(e => e.InvoiceId).HasColumnName("invoiceID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK__Orders__invoiceI__17F790F9");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Orders__productI__18EBB532");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("productID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .HasDefaultValueSql("('product')");

                entity.Property(e => e.Price)
                    .HasColumnType("smallmoney")
                    .HasColumnName("price")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
