using Microsoft.EntityFrameworkCore;
using Quarto.Api.Models;

namespace Quarto.Api.EF
{
    public partial class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public virtual DbSet<EnumListingAccommodationType> EnumListingAccommodationType { get; set; }
        public virtual DbSet<EnumListingAvailabilityType> EnumListingAvailabilityType { get; set; }
        public virtual DbSet<Listing> Listing { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.EnableSensitiveDataLogging(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnumListingAccommodationType>(entity =>
            {
                entity.ToTable("enum.Listing.AccommodationType");

                entity.Property(e => e.ID)
                    .HasColumnType("tinyint")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<EnumListingAvailabilityType>(entity =>
            {
                entity.ToTable("enum.Listing.AvailabilityType");

                entity.Property(e => e.ID)
                    .HasColumnType("tinyint")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Listing>(entity =>
            {
                entity.ToTable("Listing.Data");

                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID);
                
                entity.Property(e => e.Name);
                entity.Property(e => e.ParentListing);
                entity.Property(e => e.Address);
                entity.Property(e => e.City);
                entity.Property(e => e.Province);
                entity.Property(e => e.Country);
                entity.Property(e => e.AccomodationTypeID).HasColumnType("tinyint");
                entity.Property(e => e.AvailabilityTypeID).HasColumnType("tinyint");

                entity.HasOne(e => e.EnumListingAccommodationType)
                    .WithOne(e => e.Listing)
                    .HasForeignKey<Listing>(e => e.AccomodationTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Listing.Data__enum.Listing.AccommodationType");

                entity.HasOne(e => e.EnumListingAvailabilityType)
                    .WithOne(e => e.Listing)
                    .HasForeignKey<Listing>(e => e.AvailabilityTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Listing.Data__enum.Listing.AvailabilityType");
            });
        }
    }
}
