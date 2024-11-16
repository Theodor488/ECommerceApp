using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Username { get; set; }
    public required string Password { get; set; }
}