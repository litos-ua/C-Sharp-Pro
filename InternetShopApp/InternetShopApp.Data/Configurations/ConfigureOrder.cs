using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShopApp.Data.Configurations
{
    public class ConfigureOrder : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Настройка первичного ключа
            builder.HasKey(o => o.Id);

            // Связь с User
            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Настройка поля Amount
            builder.Property(o => o.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            // Настройка поля CreatedAt
            builder.Property(o => o.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime2");

            // Поле DeliveryRequirement (булевое)
            builder.Property(o => o.DeliveryRequirement)
                   .IsRequired()
                   .HasDefaultValue(false);

            // Поле ReceivedStatus (булевое)
            builder.Property(o => o.ReceivedStatus)
                   .IsRequired()
                   .HasDefaultValue(false);

            // Поле TypeOfPayment
            builder.Property(o => o.TypeOfPayment)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasDefaultValue("Card");

            // Поле PaymentStatus
            builder.Property(o => o.PaymentStatus)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasDefaultValue("not paid");

            // Связь с OrderItems
            builder.HasMany(o => o.OrderItems)
                   .WithOne(oi => oi.Order)
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}

