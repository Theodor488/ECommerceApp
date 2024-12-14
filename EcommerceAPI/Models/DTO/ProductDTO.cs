using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Models.DTO
{
    public class ProductDTO
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public Guid CategoryID { get; set; }
        public double UnitPrice { get; set; }
        public string? ShortDescription { get; set; }
        public bool? IsDiscontinued { get; set; }
    }
}