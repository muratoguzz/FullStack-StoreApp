using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

        [Required(ErrorMessage = "Name is required.")]
        public String? Name { get; set; }

        public string? OrderNumber { get; set; }

        public string? PaymentAmount { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public String? Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public String? City { get; set; }
        public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Note { get; set; }
        public string? Email { get; set; }
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpirationMonth { get; set; }
        public string? ExpirationYear { get; set; }
        public string? Cvc { get; set; }
    }
}
