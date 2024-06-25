using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models;

public abstract class Client
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Address { get; set; } = String.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = String.Empty;
    [Required]
    public string PhoneNumber { get; set; } = String.Empty;

    public ICollection<Contract> Contracts = new List<Contract>();
}