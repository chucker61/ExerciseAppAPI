using Microsoft.EntityFrameworkCore;

namespace ExerciseApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) :
            base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
