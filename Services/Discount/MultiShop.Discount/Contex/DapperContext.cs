using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Contex
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("defaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
            optionsBuilder.UseSqlServer("server=192.168.1.17,1450;User Id=sa;Password=Password123+;initial Catalog=MultiShopDiscountDb");
        }
        public DbSet<Coupon> Coupones { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
