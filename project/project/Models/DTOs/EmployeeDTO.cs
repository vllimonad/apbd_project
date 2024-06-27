using System.ComponentModel.DataAnnotations;

namespace project.Models.DTOs;

public class EmployeeDTO
{
    [Required]
    public string Login { get; set; } 
    [Required]
    public string Password { get; set; }
}