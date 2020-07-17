using Microsoft.EntityFrameworkCore;
//using Quarto.Api.Models;

namespace Quarto.Api.EF
{
    public partial class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.EnableSensitiveDataLogging(false);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
