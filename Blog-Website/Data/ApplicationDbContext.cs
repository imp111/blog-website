using Blog_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_Website.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Post>? Posts { get; set; } // Table Posts added
    }
}
