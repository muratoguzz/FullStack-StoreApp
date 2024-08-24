using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager _manager;

        public OrderManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IQueryable<Order> Orders => _manager.Order.Orders;

        public int NumberOfInProcess => _manager.Order.NumberOfInProcess;

        public void Complete(int id)
        {
            _manager.Order.Complete(id);
            _manager.Save();
        }

        public Order? GetOneOrder(int id)
        {
            return _manager.Order.GetOneOrder(id);
        }

        public void SaveOrder(Order order)
        {
            order.OrderNumber = new Random().Next(111111,999999).ToString();
            _manager.Order.SaveOrder(order);
        }
    }
}
