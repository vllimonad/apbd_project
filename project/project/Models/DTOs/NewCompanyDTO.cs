using System.ComponentModel.DataAnnotations;

namespace project.Models.DTOs;

public class NewCompanyDTO
{
    [Required]
    public string Name { get; set; } = String.Empty;
    [Required]
    public long KRS { get; set; }
    [Required]
    public string Address { get; set; } = String.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = String.Empty;
    [Required]
    public string PhoneNumber { get; set; } = String.Empty;
}