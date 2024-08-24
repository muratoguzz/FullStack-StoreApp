using System.ComponentModel.DataAnnotations;

namespace Store.Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public String? ProductName { get; set; } = String.Empty;
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public String? Summary { get; set; } = String.Empty ;
        public String? ImageUrl { get; set; } = String.Empty;
        public int? CategoryId { get; set; } //Foreþng key
        public Category? Category { get; set; } //Navigation prop
        public bool ShowCase { get; set; }
    }
}