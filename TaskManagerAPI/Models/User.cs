using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerAPI.Models;

[Table("users")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string? Username { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string? PasswordHash { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string? Role { get; set; }
    
}