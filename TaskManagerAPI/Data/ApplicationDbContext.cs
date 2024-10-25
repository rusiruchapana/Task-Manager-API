using Microsoft.EntityFrameworkCore;
using Task = TaskManagerAPI.Models.Task;

namespace TaskManagerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }  // Map Task entity to the Tasks table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasKey(t => t.Id);  // Specify primary key explicitly if needed
        }
    }
}