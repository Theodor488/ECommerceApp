using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models
{
    public partial class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Review1 { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}