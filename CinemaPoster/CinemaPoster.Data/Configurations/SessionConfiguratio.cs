using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CinemaPoster.Domain.Models;
using CinemaPoster.Domain.Enums;

namespace CinemaPoster.Data.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.StartTime)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(s => s.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.RoomName)
                .IsRequired()
                .HasConversion<string>()
                .HasDefaultValue(RoomName.Blue); 

            builder.HasOne(s => s.Movie)
                .WithMany(m => m.Sessions)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Sessions");
        }
    }
}

