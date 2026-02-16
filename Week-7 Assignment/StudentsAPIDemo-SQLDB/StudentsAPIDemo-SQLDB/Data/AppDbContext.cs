namespace StudentsAPIDemo_SQLDB.Data
{
    using Microsoft.EntityFrameworkCore;
    using StudentsAPIDemo_SQLDB.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Computer Science" },
                new Department { Id = 2, Name = "Mechanical" },
                new Department { Id = 3, Name = "Civil" }
            );

            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Bharath", Age = 22, DepartmentId = 1 },
                new Student { Id = 2, Name = "Rahul", Age = 21, DepartmentId = 2 },
                new Student { Id = 3, Name = "Anita", Age = 23, DepartmentId = 1 }
            );
        }
    }

}
