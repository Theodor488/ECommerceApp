using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models.DTO
{
    public class AddCustomerRequestDTO
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string First_Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Last_Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
