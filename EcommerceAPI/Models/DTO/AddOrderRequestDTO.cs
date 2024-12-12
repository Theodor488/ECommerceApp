namespace EcommerceAPI.Models.DTO
{
    public class AddOrderRequestDTO
    {
        public Guid CustomerID { get; set; }
        public int? TotalAmount { get; set; }
        public bool? isCompleted { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? Delivered { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool? CancelOrder { get; set; }
    }
}
