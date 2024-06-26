using System.ComponentModel.DataAnnotations;

namespace project.Models.DTOs;

public class UpdateCompanyDTO
{
    [Required]
    public string Name { get; set; } = String.Empty;
    [Required]
    public string Address { get; set; } = String.Empty;
    [EmailAddress]
    public string Email { get; set; } = String.Empty;
    [Required]
    public string PhoneNumber { get; set; } = String.Empty;
}