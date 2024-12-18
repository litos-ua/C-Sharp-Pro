using CinemaPoster.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaPoster.Data.Configurations
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            // Указываем имя таблицы
            builder.ToTable("Directors");

            // Указываем первичный ключ
            builder.HasKey(d => d.Id);

            // Настраиваем свойство Name
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Настраиваем связь с фильмами (один ко многим)
            builder.HasMany(d => d.Movies)
                .WithOne(m => m.Director) // Навигационное свойство в модели Movie
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.Cascade); // Если режиссёр удалён, удаляются его фильмы
        }
    }
}

