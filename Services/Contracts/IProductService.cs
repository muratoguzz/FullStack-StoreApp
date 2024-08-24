using Entities.Dtos;
using Entities.RequestParameters;
using Store.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        IEnumerable<Product> GetLastestProducts(int n, bool trackChanges);
        IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
        IQueryable<Product> GetShowcaseProducts(bool trackChanges);
        Product? GetOneProduct(int id, bool trackChanges);
        void CreateOneProduct(ProductDtoForInsertion productDto);
        void UpdateOneProduct(ProductDtoForUpdate productDto);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
    }
}
