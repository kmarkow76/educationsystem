using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace cyberclub14.Models
{
    public partial class cyberclubContext : DbContext
    {
        public cyberclubContext()
        {
        }

        public cyberclubContext(DbContextOptions<cyberclubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BarProduct> BarProducts { get; set; }
        public virtual DbSet<BarSale> BarSales { get; set; }
        public virtual DbSet<ClubMember> ClubMembers { get; set; }
        public virtual DbSet<GameSession> GameSessions { get; set; }
        public virtual DbSet<GameZone> GameZones { get; set; }
        public virtual DbSet<GamingPlace> GamingPlaces { get; set; }
        public virtual DbSet<Tariff> Tariffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=cyberclub;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BarProduct>(entity =>
            {
                entity.ToTable("bar_products");

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

            modelBuilder.Entity<BarSale>(entity =>
            {
                entity.ToTable("bar_sales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SalePrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("sale_price");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BarSales)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bar_sales_product_id_fkey");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.BarSales)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("bar_sales_session_id_fkey");
            });

            modelBuilder.Entity<ClubMember>(entity =>
            {
                entity.ToTable("club_members");

                entity.HasIndex(e => e.Nickname, "club_members_nickname_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.HasClubCard)
                    .HasColumnName("has_club_card")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nickname");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<GameSession>(entity =>
            {
                entity.ToTable("game_sessions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BasePrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("base_price")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.DiscountPercent).HasColumnName("discount_percent");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.PlaceId).HasColumnName("place_id");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'Активна'::character varying");

                entity.Property(e => e.TariffId).HasColumnName("tariff_id");

                entity.Property(e => e.TotalPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("total_price")
                    .HasDefaultValueSql("0.00");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.GameSessions)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("game_sessions_member_id_fkey");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.GameSessions)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_sessions_place_id_fkey");

                entity.HasOne(d => d.Tariff)
                    .WithMany(p => p.GameSessions)
                    .HasForeignKey(d => d.TariffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_sessions_tariff_id_fkey");
            });

            modelBuilder.Entity<GameZone>(entity =>
            {
                entity.ToTable("game_zones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<GamingPlace>(entity =>
            {
                entity.ToTable("gaming_places");

                entity.HasIndex(e => e.PlaceNumber, "gaming_places_place_number_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HardwareSpec).HasColumnName("hardware_spec");

                entity.Property(e => e.IsOccupied)
                    .HasColumnName("is_occupied")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.PlaceNumber).HasColumnName("place_number");

                entity.Property(e => e.ZoneId).HasColumnName("zone_id");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.GamingPlaces)
                    .HasForeignKey(d => d.ZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gaming_places_zone_id_fkey");
            });

            modelBuilder.Entity<Tariff>(entity =>
            {
                entity.ToTable("tariffs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsNightPackage)
                    .HasColumnName("is_night_package")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PricePerHour)
                    .HasPrecision(10, 2)
                    .HasColumnName("price_per_hour");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
