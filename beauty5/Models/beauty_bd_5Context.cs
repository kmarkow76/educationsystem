using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace beauty5.Models
{
    public partial class beauty_bd_5Context : DbContext
    {
        public beauty_bd_5Context()
        {
        }

        public beauty_bd_5Context(DbContextOptions<beauty_bd_5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AppointmentDetail> AppointmentDetails { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Master> Masters { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=beauty_bd_5;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointments");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.AppointmentDate).HasColumnName("appointment_date");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.MasterId).HasColumnName("master_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'Запланирована'::character varying");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("appointments_client_id_fkey");

                entity.HasOne(d => d.Master)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.MasterId)
                    .HasConstraintName("appointments_master_id_fkey");
            });

            modelBuilder.Entity<AppointmentDetail>(entity =>
            {
                entity.HasKey(e => e.DetailId)
                    .HasName("appointment_details_pkey");

                entity.ToTable("appointment_details");

                entity.Property(e => e.DetailId).HasColumnName("detail_id");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.AppointmentDetails)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("appointment_details_appointment_id_fkey");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.AppointmentDetails)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("appointment_details_service_id_fkey");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("full_name");

                entity.Property(e => e.IsRegular).HasColumnName("is_regular");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Master>(entity =>
            {
                entity.ToTable("masters");

                entity.Property(e => e.MasterId).HasColumnName("master_id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("full_name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("phone");

                entity.Property(e => e.Specialization)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("specialization");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");

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
