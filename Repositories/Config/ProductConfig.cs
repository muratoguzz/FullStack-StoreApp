using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(
                new Product() { ProductId = 1, CategoryId = 2, ImageUrl = "/images/7.jpg", ProductName = "Computer", Stock=20, Price = 40000, ShowCase = false },
                new Product() { ProductId = 2, CategoryId = 2, ImageUrl = "/images/1.jpg", ProductName = "Keyboard", Stock = 20, Price = 2000, ShowCase = false },
                new Product() { ProductId = 3, CategoryId = 2, ImageUrl = "/images/2.jpg", ProductName = "Mause", Stock = 20, Price = 800, ShowCase = false },
                new Product() { ProductId = 4, CategoryId = 2, ImageUrl = "/images/3.jpg", ProductName = "Monitor", Stock = 20, Price = 9000, ShowCase = false },
                new Product() { ProductId = 5, CategoryId = 2, ImageUrl = "/images/4.jpg", ProductName = "Deck", Stock = 20, Price = 2500, ShowCase = false },
                new Product() { ProductId = 6, CategoryId = 1, ImageUrl = "/images/5.jpg", ProductName = "History", Stock = 20, Price = 250, ShowCase = false },
                new Product() { ProductId = 7, CategoryId = 1, ImageUrl = "/images/6.jpg", ProductName = "Hamlet", Stock = 20, Price = 350, ShowCase = false },
                new Product() { ProductId = 8, CategoryId = 2, ImageUrl = "/images/4.jpg", ProductName = "X-Box", Stock = 20, Price = 55500, ShowCase = true },
                new Product() { ProductId = 9, CategoryId = 1, ImageUrl = "/images/5.jpg", ProductName = "Dune", Stock = 20, Price = 250, ShowCase = true },
                new Product() { ProductId = 10, CategoryId = 1, ImageUrl = "/images/3.jpg", ProductName = "LOTR", Stock = 20, Price = 350, ShowCase = true }
            );
        }
    }
}
