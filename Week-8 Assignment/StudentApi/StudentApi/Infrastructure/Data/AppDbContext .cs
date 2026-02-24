using Microsoft.EntityFrameworkCore;
using StudentApi.Domain.Entities;

namespace StudentApi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<AppUser> Users => Set<AppUser>();
        public DbSet<StudyMaterial> StudyMaterials => Set<StudyMaterial>();
        public DbSet<Feedback> Feedbacks => Set<Feedback>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Student)
                .WithMany()
                .HasForeignKey(f => f.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Trainer)
                .WithMany()
                .HasForeignKey(f => f.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
