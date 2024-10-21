using Ecommerce.Data;
using Ecommerce.Models;

namespace Ecommerce.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context) { 
            _context = context;
        }

        public async Task AddOrder(Order order) { 
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task AddOrderItem(OrderItem orderItem) {
            await _context.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }
    }
}
