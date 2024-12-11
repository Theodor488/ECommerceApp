using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models.Domain
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public Guid CustomerID { get; set; }
        public int? TotalAmount { get; set; }
        public bool? isCompleted { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? Delivered { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool? CancelOrder { get; set; }
        public DateTime? Created { get; set; } = DateTime.Now;

        public virtual Customer Customer { get; set; }
    }
}