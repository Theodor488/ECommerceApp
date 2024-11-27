using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models
{
    public partial class OrderDetail
    {
        [Key]
        public Guid OrderDetailsID { get; set; }
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}