using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShopApp.Data.Configurations
{
    public class ConfigureStock : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
                builder.HasKey(s => s.Id);
                builder.HasOne(s => s.Product)
                       .WithMany()
                       .HasForeignKey(s => s.ProductId);
                builder.Property(s => s.Quantity).IsRequired();
                builder.Property(s => s.CreatedAt)
                       .IsRequired()
                       .HasColumnType("datetime2");
                builder.Property(s => s.Quantity)
                       .IsRequired()
                       .HasDefaultValue(0);

        }
    }
}
