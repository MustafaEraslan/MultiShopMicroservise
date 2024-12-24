using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.1.7,1442;initial Catalog=MultiShopCommentDb;User=sa;Password=Password123+");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
