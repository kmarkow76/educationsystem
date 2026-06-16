using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace agentstvo13.Models
{
    public partial class agentstvo_bd_13Context : DbContext
    {
        public agentstvo_bd_13Context()
        {
        }

        public agentstvo_bd_13Context(DbContextOptions<agentstvo_bd_13Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Contractor> Contractors { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventDetail> EventDetails { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=agentstvo_bd_13;Username=postgres;Password=1234");
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

                entity.Property(e => e.IsRepeat).HasColumnName("is_repeat");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.ToTable("contractors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContractorName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("contractor_name");

                entity.Property(e => e.ServiceCost)
                    .HasPrecision(10, 2)
                    .HasColumnName("service_cost");

                entity.Property(e => e.ServiceType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("service_type");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("events");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("date")
                    .HasColumnName("contract_date")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.EventDate)
                    .HasColumnType("date")
                    .HasColumnName("event_date");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("event_name");

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("payment_status")
                    .HasDefaultValueSql("'Не оплачено'::character varying");

                entity.Property(e => e.VenueId).HasColumnName("venue_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("fk_event_client");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.VenueId)
                    .HasConstraintName("fk_event_venue");
            });

            modelBuilder.Entity<EventDetail>(entity =>
            {
                entity.ToTable("event_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContractorId).HasColumnName("contractor_id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.EventDetails)
                    .HasForeignKey(d => d.ContractorId)
                    .HasConstraintName("fk_details_contractor");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventDetails)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("fk_details_event");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.ToTable("venues");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("address");

                entity.Property(e => e.RentalPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("rental_price");

                entity.Property(e => e.VenueName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("venue_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
