using System.ComponentModel.DataAnnotations;
using EcommerceAPI.Models.Domain;

namespace ECommerceAPI.Models
{
    public partial class Review
    {
        [Key]
        public Guid ReviewID { get; set; }
        public Nullable<Guid> CustomerID { get; set; }
        public Nullable<Guid> ProductID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Review1 { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}