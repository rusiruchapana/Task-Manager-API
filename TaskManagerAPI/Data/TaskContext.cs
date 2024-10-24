using Microsoft.EntityFrameworkCore;

namespace TaskManagerAPI.Data;

public class TaskContext: DbContext
{
    public DbSet<Task> Tasks { get; set; } 
    
    public TaskContext(DbContextOptions<TaskContext> options): base(options)
    {
    }
}