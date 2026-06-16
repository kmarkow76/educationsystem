using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace service15.Models
{
    public partial class service_bd_15Context : DbContext
    {
        public service_bd_15Context()
        {
        }

        public service_bd_15Context(DbContextOptions<service_bd_15Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Master> Masters { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=service_bd_15;Username=postgres;Password=1234");
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
                    .HasMaxLength(150)
                    .HasColumnName("full_name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Master>(entity =>
            {
                entity.ToTable("masters");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("full_name");

                entity.Property(e => e.Rating)
                    .HasPrecision(3, 2)
                    .HasColumnName("rating");

                entity.Property(e => e.Specialty)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("specialty");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ExecutionAddress)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("execution_address");

                entity.Property(e => e.ExecutionDate)
                    .HasColumnType("date")
                    .HasColumnName("execution_date");

                entity.Property(e => e.MasterId).HasColumnName("master_id");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("order_status")
                    .HasDefaultValueSql("'Новая'::character varying");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("fk_order_client");

                entity.HasOne(d => d.Master)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MasterId)
                    .HasConstraintName("fk_order_master");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("fk_order_service");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BasePrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("base_price");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("service_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
