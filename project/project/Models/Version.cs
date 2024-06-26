using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models;

public class Version
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = String.Empty;
    public int SoftwareId { get; set; }

    [ForeignKey(nameof(SoftwareId))]
    public Software Software = null!;
}