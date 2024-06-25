using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models;

public class Payment
{
    [Key]
    public int Id { get; set; }
    public int ContractId { get; set; }
    [Required]
    public double Amount { get; set; }
    [Required]
    public DateTime Date { get; set; }

    [ForeignKey(nameof(ContractId))]
    public Contract Contract = null!;
}