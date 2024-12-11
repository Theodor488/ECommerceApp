using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Models.DTO
{
    public class OrderDTO
    {
        public Guid OrderID { get; set; }
        public Guid CustomerID { get; set; }
        public int? TotalAmount { get; set; }
        public bool? isCompleted { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? Delivered { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool? CancelOrder { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
    }
}