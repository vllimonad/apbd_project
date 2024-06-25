using System.ComponentModel.DataAnnotations;

namespace project.Models;

public class Discount
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = String.Empty;
    [Required]
    [Range(1, 100)]
    public string Value { get; set; } = String.Empty;
    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
    
}