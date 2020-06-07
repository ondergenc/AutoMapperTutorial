using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapperTutorial.Data;
using AutoMapperTutorial.Domain;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperTutorial.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _dataContext;

        public CustomerService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateCustomerAsync(Customer customer)
        {
            await _dataContext.Customers.AddAsync(customer);
            var createdRowCount = await _dataContext.SaveChangesAsync();
            return createdRowCount > 0;
        }

        public async Task<Customer> GetCustomerAsync(int customerId)
        {
            return await _dataContext.Customers.SingleOrDefaultAsync(s => s.CustomerId == customerId);
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _dataContext.Customers.ToListAsync();
        }
    }
}
