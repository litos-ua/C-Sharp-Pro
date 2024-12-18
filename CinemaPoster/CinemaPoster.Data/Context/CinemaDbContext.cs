using Microsoft.EntityFrameworkCore;
using CinemaPoster.Data.Configurations;
using CinemaPoster.Domain.Models;

namespace CinemaPoster.Data.Context
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

