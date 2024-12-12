namespace EcommerceAPI.Models.DTO
{
    public class UpdateOrderRequestDTO
    {
        public Guid CustomerID { get; set; }
        public double TotalAmount { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? Delivered { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool? CancelOrder { get; set; }
    }
}