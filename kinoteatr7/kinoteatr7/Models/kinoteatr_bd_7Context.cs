using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace kinoteatr7.Models
{
    public partial class kinoteatr_bd_7Context : DbContext
    {
        public kinoteatr_bd_7Context()
        {
        }

        public kinoteatr_bd_7Context(DbContextOptions<kinoteatr_bd_7Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=kinoteatr_bd_7;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("full_name");

                entity.Property(e => e.IsRegular)
                    .HasColumnName("is_regular")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("full_name");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("position");
            });

            modelBuilder.Entity<Hall>(entity =>
            {
                entity.ToTable("halls");

                entity.Property(e => e.HallId).HasColumnName("hall_id");

                entity.Property(e => e.HallName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("hall_name");

                entity.Property(e => e.TotalSeats).HasColumnName("total_seats");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movies");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("genre");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("sessions");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.BasePrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("base_price");

                entity.Property(e => e.HallId).HasColumnName("hall_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.SessionDate).HasColumnName("session_date");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.HallId)
                    .HasConstraintName("sessions_hall_id_fkey");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("sessions_movie_id_fkey");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("tickets");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RowNumber).HasColumnName("row_number");

                entity.Property(e => e.SeatNumber).HasColumnName("seat_number");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("tickets_client_id_fkey");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("tickets_employee_id_fkey");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("tickets_session_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
