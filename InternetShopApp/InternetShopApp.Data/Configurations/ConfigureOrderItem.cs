using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShopApp.Data.Configurations
{
    public class ConfigureOrderItem : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);
            builder.HasOne(oi => oi.Order)
              .WithMany(o => o.OrderItems)
              .HasForeignKey(oi => oi.OrderId);
            builder.HasOne(oi => oi.Product)
              .WithMany()
              .HasForeignKey(oi => oi.ProductId);
            builder.Property(oi => oi.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime2");
            builder.Property(oi => oi.Quantity)
                .IsRequired()
                .HasDefaultValue(0);

        }
    }
}