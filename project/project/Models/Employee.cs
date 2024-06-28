using System.ComponentModel.DataAnnotations;

namespace project.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Salt { get; set; }
}