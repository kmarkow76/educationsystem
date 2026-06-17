using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace skladpredprieatie1.Models
{
    public partial class skladpredprieatie_bd_1Context : DbContext
    {
        public skladpredprieatie_bd_1Context()
        {
        }

        public skladpredprieatie_bd_1Context(DbContextOptions<skladpredprieatie_bd_1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<WarehouseOperation> WarehouseOperations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=skladpredprieatie_bd_1;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("full_name");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("position");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("category");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("product_name");

                entity.Property(e => e.QuantityInStock).HasColumnName("quantity_in_stock");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.UnitOfMeasure)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("unit_of_measure");

                entity.Property(e => e.UnitPrice)
                    .HasPrecision(12, 2)
                    .HasColumnName("unit_price");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("fk_product_supplier");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("suppliers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("company_name");

                entity.Property(e => e.ContactPhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("contact_phone");

                entity.Property(e => e.IsPermanent).HasColumnName("is_permanent");
            });

            modelBuilder.Entity<WarehouseOperation>(entity =>
            {
                entity.ToTable("warehouse_operations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.OperationDate)
                    .HasColumnType("date")
                    .HasColumnName("operation_date")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("operation_type");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.RecipientName)
                    .HasMaxLength(150)
                    .HasColumnName("recipient_name");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.WarehouseOperations)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_operation_employee");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WarehouseOperations)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_operation_product");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
