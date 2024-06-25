using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models;

public class Contract
{
    [Key]
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int SoftwareId { get; set; }
    [Required]
    public string Version { get; set; } = String.Empty;
    [Required]
    public double Price { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public bool IsSigned { get; set; }

    [ForeignKey(nameof(ClientId))]
    public Client Client = null!;
    [ForeignKey(nameof(SoftwareId))]
    public Software Software = null!;
    public ICollection<Payment> Payments = new List<Payment>();
}