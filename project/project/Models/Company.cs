using System.ComponentModel.DataAnnotations;

namespace project.Models;

public class Company: Client
{
    [Required]
    public string Name { get; set; } = String.Empty;
    [Required]
    public long KRS { get; set; }
}