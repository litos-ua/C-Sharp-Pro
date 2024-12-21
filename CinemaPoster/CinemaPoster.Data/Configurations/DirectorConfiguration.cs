using CinemaPoster.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaPoster.Data.Configurations
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable("Directors");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Связь с фильмами 
            builder.HasMany(d => d.Movies)
                .WithOne(m => m.Director) 
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}

