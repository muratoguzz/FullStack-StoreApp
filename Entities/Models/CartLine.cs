using Store.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; } = new(); //new(); kısmı, Product özelliğini, CartLine sınıfından bir nesne oluşturulduğunda otomatik olarak yeni bir Product nesnesi ile başlatır.
        public int Quantity { get; set; }
    }
}
