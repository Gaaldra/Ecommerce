using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Repository;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetByNameAsync(string categoryName);
}