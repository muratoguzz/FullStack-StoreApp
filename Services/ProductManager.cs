using AutoMapper;
using Entities.Dtos;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories;
using Services.Contracts;
using Store.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateOneProduct(ProductDtoForInsertion productDto)
        {

            Product product = _mapper.Map<Product>(productDto);
            _manager.Product.Create(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            Product product = GetOneProduct(id, false) ?? new Product(); //Product null ise product oluşturup getir
            _manager.Product.DeleteOneProduct(product);
            _manager.Save();
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public IEnumerable<Product> GetLastestProducts(int n, bool trackChanges)
        {
            return _manager
               .Product
               .FindAll(trackChanges)
               .OrderByDescending(prd => prd.ProductId)
               .Take(n);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id, trackChanges);
            
            if (product is null)
            {
                throw new Exception("Product not found!");               
            }

            return product;
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product = GetOneProduct(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            var products = _manager.Product.GetShowcaseProducts(trackChanges);
            return products;
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            var entity = _mapper.Map<Product>(productDto);
            _manager.Product.UpdateOneProduct(entity);
            _manager.Save();
        }

        IEnumerable<Product> IProductService.GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _manager.Product.GetAllProductsWithDetails(p);
        }
    }
}
