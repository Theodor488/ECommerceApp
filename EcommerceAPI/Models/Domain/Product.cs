using System;
using System.ComponentModel.DataAnnotations;
using ECommerceAPI.Models;

namespace EcommerceAPI.Models.Domain
{
    public partial class Product
    {
        [Key]
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public Guid CategoryID { get; set; }
        public double UnitPrice { get; set; }
        public string? ShortDescription { get; set; }
        public bool? IsDiscontinued { get; set; } = false;
    }
}