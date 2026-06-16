using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace pharmacy8.Models
{
    public partial class pharmacyContext : DbContext
    {
        public pharmacyContext()
        {
        }

        public pharmacyContext(DbContextOptions<pharmacyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database= pharmacy;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsRegular).HasColumnName("is_regular");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Drug>(entity =>
            {
                entity.ToTable("drugs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AvailabilityStatus).HasColumnName("availability_status");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("category");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("date")
                    .HasColumnName("expiration_date");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("manufacturer");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");

                entity.Property(e => e.QuantityInStock).HasColumnName("quantity_in_stock");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.ToTable("receipts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DrugId).HasColumnName("drug_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnType("date")
                    .HasColumnName("receipt_date");

                entity.Property(e => e.ReceiptPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("receipt_price");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.HasOne(d => d.Drug)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.DrugId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("receipts_drug_id_fkey");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("receipts_supplier_id_fkey");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DrugId).HasColumnName("drug_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SaleDate)
                    .HasColumnType("date")
                    .HasColumnName("sale_date");

                entity.Property(e => e.UnitPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("unit_price");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sales_customer_id_fkey");

                entity.HasOne(d => d.Drug)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.DrugId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sales_drug_id_fkey");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("suppliers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
