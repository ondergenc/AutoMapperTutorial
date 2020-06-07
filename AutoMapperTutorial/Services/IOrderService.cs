using System.Threading.Tasks;
using AutoMapperTutorial.Domain;

namespace AutoMapperTutorial.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrderAsync(int orderId);
        Task<bool> CreateOrderAsync(Order order);
    }
}
