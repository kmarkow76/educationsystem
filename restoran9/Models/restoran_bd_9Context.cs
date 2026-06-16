using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace restoran9.Models
{
    public partial class restoran_bd_9Context : DbContext
    {
        public restoran_bd_9Context()
        {
        }

        public restoran_bd_9Context(DbContextOptions<restoran_bd_9Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderitem> Orderitems { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Table> Tables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=restoran_bd_9;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.IsPermanent)
                    .HasColumnName("is_permanent")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("date")
                    .HasColumnName("registration_date")
                    .HasDefaultValueSql("CURRENT_DATE");
            });

            modelBuilder.Entity<Dish>(entity =>
            {
                entity.ToTable("dishes");

                entity.Property(e => e.DishId).HasColumnName("dish_id");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .HasColumnName("category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .HasColumnName("position");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DiscountPercent)
                    .HasColumnName("discount_percent")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.FinalAmount)
                    .HasPrecision(10, 2)
                    .HasColumnName("final_amount")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'created'::character varying");

                entity.Property(e => e.TableId).HasColumnName("table_id");

                entity.Property(e => e.TotalAmount)
                    .HasPrecision(10, 2)
                    .HasColumnName("total_amount")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("orders_customer_id_fkey");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("orders_employee_id_fkey");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("orders_table_id_fkey");
            });

            modelBuilder.Entity<Orderitem>(entity =>
            {
                entity.ToTable("orderitems");

                entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");

                entity.Property(e => e.DishId).HasColumnName("dish_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PriceAtTime)
                    .HasPrecision(10, 2)
                    .HasColumnName("price_at_time");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.DishId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderitems_dish_id_fkey");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("orderitems_order_id_fkey");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservations");

                entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ReservationTime).HasColumnName("reservation_time");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'active'::character varying");

                entity.Property(e => e.TableId).HasColumnName("table_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("reservations_customer_id_fkey");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("reservations_table_id_fkey");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("tables");

                entity.HasIndex(e => e.TableNumber, "tables_table_number_key")
                    .IsUnique();

                entity.Property(e => e.TableId).HasColumnName("table_id");

                entity.Property(e => e.Seats).HasColumnName("seats");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'free'::character varying");

                entity.Property(e => e.TableNumber).HasColumnName("table_number");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
