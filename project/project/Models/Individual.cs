using System.ComponentModel.DataAnnotations;

namespace project.Models;

public class Individual: Client
{
    [Required]
    public string FirstName { get; set; } = String.Empty;
    [Required]
    public string LastName { get; set; } = String.Empty;
    [Required]
    public long PESEL { get; set; }

    public bool IsDeleted { get; set; } = false;
}