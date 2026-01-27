using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Repository;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetByCategoryAsync(Category category);
}