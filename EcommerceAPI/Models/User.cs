using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public required string Username { get; set; }
    public required string Password { get; set; }
}