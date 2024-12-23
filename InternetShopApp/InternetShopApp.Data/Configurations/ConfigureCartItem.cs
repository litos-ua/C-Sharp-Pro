//using InternetShopApp.Data.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;


//namespace InternetShopApp.Data.Configurations
//{
//    public class ConfigureCartItem : IEntityTypeConfiguration<CartItem>
//    {
//        public void Configure(EntityTypeBuilder<CartItem> builder)
//        {
//            builder.HasKey(ci => ci.Id); // Настройка первичного ключа

//            builder.HasOne(ci => ci.User) // Связь с User
//                .WithMany(u => u.CartItems)
//                .HasForeignKey(ci => ci.UserId)
//                .OnDelete(DeleteBehavior.Cascade); // Указание поведения при удалении

//            builder.HasOne(ci => ci.Product) // Связь с Product
//                .WithMany()
//                .HasForeignKey(ci => ci.ProductId)
//                .OnDelete(DeleteBehavior.Cascade); // Указание поведения при удалении

//            builder.Property(ci => ci.Quantity) // Настройка свойства Quantity
//                .IsRequired()
//                .HasDefaultValue(1); // Значение по умолчанию
//            builder.Property(ci => ci.CreatedAt)
//                .IsRequired()
//                .HasColumnType("datetime2");
//            builder.Property(ci => ci.Quantity)
//                   .IsRequired()
//                   .HasDefaultValue(0);

//        }
//    }
//}

using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace InternetShopApp.Data.Configurations
{
    public class ConfigureCartItem : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id); // Настройка первичного ключа

            builder.HasOne(ci => ci.Cart) // Связь с Cart
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade); // Указание поведения при удалении

            builder.HasOne(ci => ci.Product) // Связь с Product
                .WithMany()
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // Указание поведения при удалении

            builder.Property(ci => ci.Quantity) // Настройка свойства Quantity
                .IsRequired()
                .HasDefaultValue(1); // Значение по умолчанию

            builder.Property(ci => ci.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime2");
        }
    }
}
