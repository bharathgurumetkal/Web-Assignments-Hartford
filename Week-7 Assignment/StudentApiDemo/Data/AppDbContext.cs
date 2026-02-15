using Microsoft.EntityFrameworkCore;
using StudentApiDemo.Models;

namespace StudentApiDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
