using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;

        private readonly RepositoryContext _context;

        public RepositoryManager(IProductRepository productRepository, 
            ICategoryRepository categoryRepository, 
            RepositoryContext context, 
            IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _context = context;
            _orderRepository = orderRepository;
        }

        public IProductRepository Product => _productRepository;
        public ICategoryRepository Category => _categoryRepository;
        public IOrderRepository Order => _orderRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}