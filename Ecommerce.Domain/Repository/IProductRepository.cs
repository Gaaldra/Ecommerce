using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Repository;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(Category category);
    Task<Product?> GetByNameAsync(string productName);
}