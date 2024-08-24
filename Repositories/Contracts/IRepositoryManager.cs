using Microsoft.EntityFrameworkCore.Diagnostics;
using Repositories.Contracts;

namespace Repositories
{
    public interface IRepositoryManager
    {
        IProductRepository Product{get; }
        ICategoryRepository Category{get;}
        IOrderRepository Order { get;}
        void Save();
    }
}