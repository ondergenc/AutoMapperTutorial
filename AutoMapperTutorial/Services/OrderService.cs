using System.Threading.Tasks;
using AutoMapperTutorial.Data;
using AutoMapperTutorial.Domain;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperTutorial.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _dataContext;

        public OrderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            await _dataContext.Orders.AddAsync(order);
            var createdRowCount = await _dataContext.SaveChangesAsync();
            return createdRowCount > 0;
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            var order = await _dataContext.Orders
                .Include(c => c.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(p => p.Product)
                .SingleOrDefaultAsync(s => s.OrderId == orderId);
            return order;
        }
    }
}
