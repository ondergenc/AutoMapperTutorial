using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapperTutorial.Domain;

namespace AutoMapperTutorial.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int customerId);
        Task<bool> CreateCustomerAsync(Customer customer);
    }
}
