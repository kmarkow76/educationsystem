using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace educsys.Models
{
    public partial class educContext : DbContext
    {
        public educContext()
        {
        }

        public educContext(DbContextOptions<educContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host = localhost; Port = 5433; Database = educ; Username = postgres; Password = 1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("courses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HoursCount).HasColumnName("hours_count");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.PricePerHour)
                    .HasPrecision(10, 2)
                    .HasColumnName("price_per_hour");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("courses_teacher_id_fkey");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("grades");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.GradeDate)
                    .HasColumnType("date")
                    .HasColumnName("grade_date");

                entity.Property(e => e.Score)
                    .HasPrecision(5, 2)
                    .HasColumnName("score");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("grades_course_id_fkey");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("grades_student_id_fkey");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasPrecision(10, 2)
                    .HasColumnName("amount");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("payment_date");

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("payment_type");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("payments_student_id_fkey");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EnrollmentDate)
                    .HasColumnType("date")
                    .HasColumnName("enrollment_date");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("full_name");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("group_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teachers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("full_name");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("subject");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
