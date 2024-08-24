using System.Linq.Expressions;
using Repositories.Contracts;
using Store.Entities.Models;

namespace Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
            
        }
    }
}