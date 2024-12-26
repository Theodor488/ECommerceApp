using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models.DTO
{
    public class UpdateOrderRequestDTO
    {
        [Required]
        public Guid CustomerID { get; set; }
        [Required]
        [MaxLength(20)]
        public int? TotalAmount { get; set; }
        public bool? isCompleted { get; set; }
        [Required]
        public DateTime? OrderDate { get; set; }
        [Required]
        public bool? Delivered { get; set; }
        [Required]
        public DateTime? DeliveryDate { get; set; }
        public bool? CancelOrder { get; set; }
    }
}