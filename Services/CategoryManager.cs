using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using Store.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _manager.Category.FindAll(trackChanges);
        }

        public void CreateCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null.");
            }

            _manager.Category.Create(category);
            _manager.Save();
        }

    }
}
