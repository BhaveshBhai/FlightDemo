using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Flight.API.Models
{
    public partial class FlightManagmentContext : DbContext
    {
        public FlightManagmentContext()
        {
        }

        public FlightManagmentContext(DbContextOptions<FlightManagmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=BN\\SQLEXPRESS;Initial Catalog=FlightManagment;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BarrivalCity)
                    .HasColumnName("BArrivalCity")
                    .HasMaxLength(20);

                entity.Property(e => e.Bdate)
                    .HasColumnName("BDate")
                    .HasMaxLength(30);

                entity.Property(e => e.BdepartCity)
                    .HasColumnName("BDepartCity")
                    .HasMaxLength(20);

                entity.Property(e => e.BookId)
                    .HasColumnName("BookID")
                    .HasMaxLength(20);

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.PassengerName).HasMaxLength(30);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK_Booking_Flights");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Booking_User");
            });

            modelBuilder.Entity<Flights>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArrivalCity).HasMaxLength(30);

                entity.Property(e => e.DepartCity).HasMaxLength(30);

                entity.Property(e => e.EndDate).HasMaxLength(30);

                entity.Property(e => e.FlightNo).HasMaxLength(20);

                entity.Property(e => e.StartDate).HasMaxLength(30);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("ID");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Users_Roles");
            });
        }
    }
}
