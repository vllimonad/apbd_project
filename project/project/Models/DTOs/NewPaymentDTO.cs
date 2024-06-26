using System.ComponentModel.DataAnnotations;

namespace project.Models.DTOs;

public class NewPaymentDTO
{
    [Required]
    public int ContractId { get; set; }
    [Required]
    public double Amount { get; set; }
    [Required]
    public DateTime Date { get; set; }
}