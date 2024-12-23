using InternetShopApp.Domain.Entities;
using InternetShopApp.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace InternetShopApp.Data
{
    public class InternetShopContext : DbContext
    {
        public InternetShopContext(DbContextOptions<InternetShopContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigureProduct());
            modelBuilder.ApplyConfiguration(new ConfigureCategory());
            modelBuilder.ApplyConfiguration(new ConfigureOrder());
            modelBuilder.ApplyConfiguration(new ConfigureOrderItem());
            modelBuilder.ApplyConfiguration(new ConfigureCart());
            modelBuilder.ApplyConfiguration(new ConfigureCartItem());
            modelBuilder.ApplyConfiguration(new ConfigureUser());
            modelBuilder.ApplyConfiguration(new ConfigureStock());
        }        
    }
}
