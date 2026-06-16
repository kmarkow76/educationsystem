using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace komunalka11.Models
{
    public partial class komunalka_bd_11Context : DbContext
    {
        public komunalka_bd_11Context()
        {
        }

        public komunalka_bd_11Context(DbContextOptions<komunalka_bd_11Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Accrual> Accruals { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<MeterReading> MeterReadings { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=komunalka_bd_11;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");

                entity.HasIndex(e => e.AccountNumber, "accounts_account_number_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("account_number");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("address");

                entity.Property(e => e.CitizenId).HasColumnName("citizen_id");

                entity.HasOne(d => d.Citizen)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CitizenId)
                    .HasConstraintName("fk_account_citizen");
            });

            modelBuilder.Entity<Accrual>(entity =>
            {
                entity.ToTable("accruals");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AccrualDate)
                    .HasColumnType("date")
                    .HasColumnName("accrual_date");

                entity.Property(e => e.BaseAmount)
                    .HasPrecision(10, 2)
                    .HasColumnName("base_amount");

                entity.Property(e => e.DiscountAmount)
                    .HasPrecision(10, 2)
                    .HasColumnName("discount_amount");

                entity.Property(e => e.FinalAmount)
                    .HasPrecision(10, 2)
                    .HasColumnName("final_amount");

                entity.Property(e => e.IsPaid).HasColumnName("is_paid");

                entity.Property(e => e.PenaltyAmount)
                    .HasPrecision(10, 2)
                    .HasColumnName("penalty_amount");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Accruals)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("fk_accrual_account");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Accruals)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("fk_accrual_service");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.ToTable("citizens");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("full_name");

                entity.Property(e => e.HasPrivilege).HasColumnName("has_privilege");
            });

            modelBuilder.Entity<MeterReading>(entity =>
            {
                entity.ToTable("meter_readings");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CurrentReading)
                    .HasPrecision(10, 2)
                    .HasColumnName("current_reading");

                entity.Property(e => e.PreviousReading)
                    .HasPrecision(10, 2)
                    .HasColumnName("previous_reading");

                entity.Property(e => e.ReadingDate)
                    .HasColumnType("date")
                    .HasColumnName("reading_date")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.Volume)
                    .HasPrecision(10, 2)
                    .HasColumnName("volume")
                    .HasComputedColumnSql("(current_reading - previous_reading)", true);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.MeterReadings)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("fk_reading_account");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.MeterReadings)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("fk_reading_service");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccrualId).HasColumnName("accrual_id");

                entity.Property(e => e.AmountPaid)
                    .HasPrecision(10, 2)
                    .HasColumnName("amount_paid");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("payment_date")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.HasOne(d => d.Accrual)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.AccrualId)
                    .HasConstraintName("fk_payment_accrual");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("service_name");

                entity.Property(e => e.Tariff)
                    .HasPrecision(10, 2)
                    .HasColumnName("tariff");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
