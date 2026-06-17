using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace vetclinic3.Models
{
    public partial class vetclinic_bd_3Context : DbContext
    {
        public vetclinic_bd_3Context()
        {
        }

        public vetclinic_bd_3Context(DbContextOptions<vetclinic_bd_3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Vet> Vets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=vetclinic_bd_3;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("animals");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AgeYears).HasColumnName("age_years");

                entity.Property(e => e.Breed)
                    .HasMaxLength(100)
                    .HasColumnName("breed");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.Property(e => e.PetName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pet_name");

                entity.Property(e => e.Species)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("species");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_animal_owner");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnimalId).HasColumnName("animal_id");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnName("appointment_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Diagnosis)
                    .IsRequired()
                    .HasColumnName("diagnosis")
                    .HasDefaultValueSql("'На обследовании'::text");

                entity.Property(e => e.MedsCost)
                    .HasPrecision(10, 2)
                    .HasColumnName("meds_cost")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.ServicesCost)
                    .HasPrecision(10, 2)
                    .HasColumnName("services_cost");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'Запланирован'::character varying");

                entity.Property(e => e.Treatment).HasColumnName("treatment");

                entity.Property(e => e.VetId).HasColumnName("vet_id");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.AnimalId)
                    .HasConstraintName("fk_appointment_animal");

                entity.HasOne(d => d.Vet)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.VetId)
                    .HasConstraintName("fk_appointment_vet");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("owners");

                entity.Property(e => e.Id).HasColumnName("id");

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

            modelBuilder.Entity<Vet>(entity =>
            {
                entity.ToTable("vets");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("doctor_name");

                entity.Property(e => e.Specialization)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("specialization");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
