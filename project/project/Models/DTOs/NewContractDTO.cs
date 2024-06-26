using System.ComponentModel.DataAnnotations;

namespace project.Models.DTOs;

public class NewContractDTO
{
    [Required]
    public int ClientId { get; set; }
    [Required]
    public int SoftwareId { get; set; }
    [Required]
    public string Version { get; set; } = String.Empty;
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be grater than 0")]
    public double Price { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
}