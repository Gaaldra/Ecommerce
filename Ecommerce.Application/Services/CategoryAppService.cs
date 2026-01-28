using Ecommerce.Application.DTOs;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repository;

namespace Ecommerce.Application.Services;

public class CategoryAppService(ICategoryRepository categoryRepository)
{
    public async Task CreateAsync(CategoryRequest request)
    {
        var existingCategory = await categoryRepository.GetByNameAsync(request.Name);
        if (existingCategory != null)
            throw new Exception($"A category with name {request.Name} already exists");

        Category? parentCategory = null;
        if (request.ParentCategoryId.HasValue)
        {
            parentCategory = await categoryRepository.GetByIdAsync(request.ParentCategoryId.Value);

            if (parentCategory != null)
                throw new Exception("The specified parent category was not found.");
        }

        var category = Category.Create(request.Name, parentCategory);

        await categoryRepository.AddAsync(category);
        await categoryRepository.SaveChangesAsync();
    }
}