using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace trackingOfRequests12.Models
{
    public partial class tracking_of_requestsContext : DbContext
    {
        public tracking_of_requestsContext()
        {
        }

        public tracking_of_requestsContext(DbContextOptions<tracking_of_requestsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<RepairRequest> RepairRequests { get; set; }
        public virtual DbSet<RequestPart> RequestParts { get; set; }
        public virtual DbSet<SparePart> SpareParts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=tracking_of_requests;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.IsRegular).HasColumnName("is_regular");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("devices");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("brand");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.DeviceType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("device_type");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("model");

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("serial_number");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("devices_client_id_fkey");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("phone");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("position");
            });

            modelBuilder.Entity<RepairRequest>(entity =>
            {
                entity.ToTable("repair_requests");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BaseWorkPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("base_work_price");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date");

                entity.Property(e => e.DeviceId).HasColumnName("device_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.FaultDescription)
                    .IsRequired()
                    .HasColumnName("fault_description");

                entity.Property(e => e.IsUrgent).HasColumnName("is_urgent");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("status");

                entity.Property(e => e.WorkList)
                    .IsRequired()
                    .HasColumnName("work_list");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.RepairRequests)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("repair_requests_client_id_fkey");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.RepairRequests)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("repair_requests_device_id_fkey");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RepairRequests)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("repair_requests_employee_id_fkey");
            });

            modelBuilder.Entity<RequestPart>(entity =>
            {
                entity.ToTable("request_parts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PartId).HasColumnName("part_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.RequestId).HasColumnName("request_id");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.RequestParts)
                    .HasForeignKey(d => d.PartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("request_parts_part_id_fkey");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestParts)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("request_parts_request_id_fkey");
            });

            modelBuilder.Entity<SparePart>(entity =>
            {
                entity.ToTable("spare_parts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");

                entity.Property(e => e.QuantityInStock).HasColumnName("quantity_in_stock");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
