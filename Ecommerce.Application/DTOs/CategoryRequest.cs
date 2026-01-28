namespace Ecommerce.Application.DTOs;

public class CategoryRequest
{
    public string Name { get; set; } = string.Empty;
    public int? ParentCategoryId { get; set; }
}