using Store.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record ProductDto 
    {
        public int ProductId { get; init; }

        [Required(ErrorMessage = "ProductName is required")]
        public String? ProductName { get; init; } = String.Empty;

        public int Stock { get; set; }

        [Required(ErrorMessage = "Pricee is required")]
        public decimal Price { get; init; }
        
        public String? Summary { get; init; } = String.Empty;
        public String? ImageUrl { get; set; } = String.Empty;
        public int? CategoryId { get; init; }
    }
}
