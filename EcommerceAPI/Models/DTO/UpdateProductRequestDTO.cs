namespace EcommerceAPI.Models.DTO
{
    public class UpdateProductRequestDTO
    {
        public string ProductName { get; set; }
        public Guid CategoryID { get; set; }
        public double UnitPrice { get; set; }
        public string? ShortDescription { get; set; }
        public bool? IsDiscontinued { get; set; }
    }
}