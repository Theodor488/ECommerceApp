using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models.DTO
{
    public class UpdateProductRequestDTO
    {
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }
        [Required]
        public Guid CategoryID { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        [MaxLength(200)]
        public string? ShortDescription { get; set; }
        public bool? IsDiscontinued { get; set; }
    }
}