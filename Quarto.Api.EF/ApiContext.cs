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
        }
    }
}
