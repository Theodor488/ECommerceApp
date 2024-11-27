using System.ComponentModel.DataAnnotations;
using EcommerceAPI.Models.Domain;

namespace ECommerceAPI.Models
{
    public partial class Order
    {
        [Key]
        public Guid OrderID { get; set; }
        public Guid CustomerID { get; set; }
        public Nullable<int> TotalAmount { get; set; }
        public Nullable<bool> isCompleted { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<bool> Delivered { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<bool> CancelOrder { get; set; }

        public virtual Customer Customer { get; set; }
    }
}