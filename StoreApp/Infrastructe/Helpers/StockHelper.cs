using AutoMapper;
using Entities.Dtos;
using Services.Contracts;
using Store.Entities.Models;

namespace StoreApp.Infrastructe.Helpers
{
    public static class StockHelper
    {
        public static void StockUp(Product? product, IServiceManager manager, IMapper mapper)
        {
            if (product != null)
            {
                product.Stock++;
                ProductDtoForUpdate productDto = mapper.Map<ProductDtoForUpdate>(product);
                manager.ProductService.UpdateOneProduct(productDto);
            }
        }

        public static void StockDown(Product? product, IServiceManager manager, IMapper mapper)
        {
            if (product != null)
            {
                product.Stock--;
                ProductDtoForUpdate productDto = mapper.Map<ProductDtoForUpdate>(product);
                manager.ProductService.UpdateOneProduct(productDto);
            }
        }
    }
}
