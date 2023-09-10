using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations;
using WebCourseProject_Vasilyev.Model.Entity;
using Npgsql;

namespace WebCourseProject_Vasilyev.Model
{
    public class DBContext : DbContext
    {
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartComponent> ShoppingCartComponents { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключения
            string connectionStringKey = configuration.GetSection("UseConnection").Value;
            optionsBuilder.UseNpgsql(configuration.GetConnectionString(connectionStringKey));

        }
    }

}
