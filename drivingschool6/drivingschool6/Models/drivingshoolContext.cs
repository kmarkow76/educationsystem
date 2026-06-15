using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace drivingschool6.Models
{
    public partial class drivingshoolContext : DbContext
    {
        public drivingshoolContext()
        {
        }

        public drivingshoolContext(DbContextOptions<drivingshoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host = localhost;Port=5433;Database=drivingshool;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("courses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BasePrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("base_price");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("category");

                entity.Property(e => e.NumberOfLessons).HasColumnName("number_of_lessons");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("enrollments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.InstructorId).HasColumnName("instructor_id");

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("payment_type");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("status");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("enrollments_car_id_fkey");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("enrollments_course_id_fkey");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("enrollments_instructor_id_fkey");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("enrollments_student_id_fkey");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.ToTable("instructors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FamilyCode)
                    .HasMaxLength(20)
                    .HasColumnName("family_code");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.IsStudent).HasColumnName("is_student");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LicensePlate)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("license_plate");

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("make");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
