using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapperTutorial.Domain;

namespace AutoMapperTutorial.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int productId);
        Task<bool> CreateProductAsync(Product product);
    }
}
