using Mottu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mottu.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Patio> Patios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moto>().HasKey(m => m.Id);
            modelBuilder.Entity<Patio>().HasKey(p => p.Id);
            modelBuilder.Entity<Patio>()
                .HasMany(p => p.Motos)
                .WithOne(m => m.Patio)
                .HasForeignKey(m => m.PatioId);
        }
    }
}