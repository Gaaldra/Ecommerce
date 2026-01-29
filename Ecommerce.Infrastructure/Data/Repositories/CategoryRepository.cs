using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repository;
using Ecommerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Data.Repositories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await context.Categories.FindAsync(id);
    }

    public async Task AddAsync(Category entity)
    {
        await context.Categories.AddAsync(entity);
    }

    public void Update(Category entity)
    {
        context.Categories.Update(entity);
    }

    public void Delete(Category entity)
    {
        context.Categories.Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        var rowsAffected= await context.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public async Task<Category?> GetByNameAsync(string categoryName)
    {
        return await context.Categories.FirstOrDefaultAsync(x => x.Name == categoryName);
    }
}