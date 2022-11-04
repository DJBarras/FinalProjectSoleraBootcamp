using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalProject.data
{
    public partial class saulBarrasDatabaseContext : DbContext
    {
        public saulBarrasDatabaseContext()
        {
        }

        public saulBarrasDatabaseContext(DbContextOptions<saulBarrasDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claim> Claims { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=saulBarrasDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("fk_Vehicle");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DriverLicense)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Brand)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("brand");

                entity.Property(e => e.Color)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.OwnerId).HasColumnName("ownerId");

                entity.Property(e => e.Vin)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("vin");

                entity.Property(e => e.Year)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("year");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_Owner");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
