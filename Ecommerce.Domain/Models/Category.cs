using Ecommerce.Domain.Exceptions;
using System.Xml.Linq;

namespace Ecommerce.Domain.Models;

public class Category
{
    public int Id { get; init; }
    public string Name { get; private set; } = string.Empty;
    public Category? ParentCategory { get; private set; }

    private Category() { }

    public static Category Create(string name, Category? parentCategory)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new CategoryArgumentException("A category name cannot be empty.", nameof(name));

        var category = new Category { Name = name };
        category.SetParentCategory(parentCategory);
        
        return category;
    }

    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName)) throw new CategoryArgumentException("A category name cannot be empty.", nameof(newName));

        if (Name == newName) return;

        Name = newName;
    }

    public void SetParentCategory(Category? newParentCategory)
    {
        if(newParentCategory == null)
        {
            ParentCategory = null;
            return;
        }

        if (newParentCategory == this) throw new CategoryArgumentException("A category cannot be its own subcategory.", nameof(newParentCategory));

        ParentCategory = newParentCategory;
    }
}
