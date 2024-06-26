using System.ComponentModel.DataAnnotations;

namespace project.Models.DTOs;

public class UpdateIndividualDTO
{
    [Required]
    public string FirstName { get; set; } = String.Empty;
    [Required]
    public string LastName { get; set; } = String.Empty;
    [Required]
    public string Address { get; set; } = String.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = String.Empty;
    [Required]
    public string PhoneNumber { get; set; } = String.Empty;
}