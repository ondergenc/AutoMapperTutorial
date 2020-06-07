using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapperTutorial.Data;
using AutoMapperTutorial.Domain;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperTutorial.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            await _dataContext.Products.AddAsync(product);
            var createdRowCount = await _dataContext.SaveChangesAsync();
            return createdRowCount > 0;
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            return await _dataContext.Products.SingleOrDefaultAsync(s => s.ProductId == productId);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _dataContext.Products.ToListAsync();
        }
    }
}
