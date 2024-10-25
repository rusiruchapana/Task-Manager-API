using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerAPI.Models;
public class Activity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id{ get; set; }
    
    [Required]
    [StringLength(100)]
    public string? Title { get; set; }
    
    [Required]
    [StringLength(100)]
    public string? Description { get; set; }
    
    
    public bool IsCompleted { get; set; }
    
    
    //Full args & No args constructors.
    public Activity()
    {
    }

    public Activity(int id, string? title, string? description, bool isCompleted)
    {
        Id = id;
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
    }

    public Activity(string? title, string? description, bool isCompleted)
    {
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
    }
}