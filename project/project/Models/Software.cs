using System.ComponentModel.DataAnnotations;

namespace project.Models;

public class Software
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = String.Empty;
    [Required]
    public string Description { get; set; } = String.Empty;
    [Required]
    public string Category { get; set; } = String.Empty;
    
    public ICollection<Contract> Contracts = new List<Contract>();
    public ICollection<Versioin> Versioins = new List<Versioin>();
}