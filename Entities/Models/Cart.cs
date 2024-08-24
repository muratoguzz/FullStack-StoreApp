﻿using Store.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();
        }

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine? line = Lines.Where(l => l.Product.ProductId.Equals(product.ProductId))
            .FirstOrDefault();

            if (line is null)
            {
                Lines.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product)
        {
            CartLine? line = Lines.Where(l => l.Product.ProductId.Equals(product.ProductId))
            .FirstOrDefault();

            if (line is not null)
            {
                //product.Stock += line.Quantity;
                Lines.Remove(line);
            }
        }

        public virtual void RemoveItem(Product product)
            {
                CartLine? line = Lines.Where(l => l.Product.ProductId.Equals(product.ProductId))
                .FirstOrDefault();

                if (line != null)
                {
                    line.Quantity--;

                    if (line.Quantity <= 0)
                    {
                        Lines.Remove(line);
                    }
                }
            }

        public decimal ComputeTotalValue() =>
            Lines.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear()
        {
            //foreach (var line in Lines)
            //{
            //    line.Product.Stock += line.Quantity;
            //}
            Lines.Clear();
        }
    }
}
