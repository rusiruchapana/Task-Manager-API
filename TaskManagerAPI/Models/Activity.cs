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
}