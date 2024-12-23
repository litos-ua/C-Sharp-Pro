//using InternetShopApp.Data.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;


//namespace InternetShopApp.Data.Configurations
//{
//    public class ConfigureUser : IEntityTypeConfiguration<User>
//    {
//        public void Configure(EntityTypeBuilder<User> builder)
//        {
//                builder.HasKey(u => u.Id);
//                builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
//                builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
//                builder.Property(u => u.CreatedAt)
//                       .IsRequired()
//                       .HasColumnType("datetime2");
//        }
//    }
//}


using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace InternetShopApp.Data.Configurations
{
    public class ConfigureUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id); // Настройка первичного ключа

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50); // Ограничение длины имени пользователя

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100); // Ограничение длины email

            builder.Property(u => u.Fullname)
                .IsRequired()
                .HasMaxLength(100); // Ограничение длины полного имени

            builder.Property(u => u.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime2"); // Тип данных для CreatedAt

            builder.HasMany(u => u.Carts) // Связь с Cart
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Поведение при удалении пользователя
        }
    }
}