using Ecommerce.Models;

namespace Ecommerce.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);

        Task AddOrderItem(OrderItem orderItem);
    }
}
