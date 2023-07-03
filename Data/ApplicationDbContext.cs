using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Commments { get; set; }

    }
}
