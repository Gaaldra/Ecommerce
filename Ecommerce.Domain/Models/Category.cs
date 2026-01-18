using Ecommerce.Domain.Exceptions;
using System.Xml.Linq;

namespace Ecommerce.Domain.Models;

public class Category
{
    public int Id { get; init; }
    public string Name { get; private set; } = string.Empty;
    public Category? Subcategory { get; private set; }

    private Category() { }

    public static Category Create(string name)
    {
        CategoryArgumentException.ThrowIfNullOrWhiteSpace(name);

        return new Category { Name = name };
    }

    public static Category Create(string name, Category subCategory)
    {
        Category category = Create(name);

        category.SetSubcategory(subCategory);

        return category;
    }

    public void UpdateName(string newName)
    {
        CategoryArgumentException.ThrowIfNullOrWhiteSpace(newName);

        if (Name == newName) return;

        Name = newName;
    }

    public void SetSubcategory(Category? newSubcategory)
    {
        if(newSubcategory == null)
        {
            Subcategory = null;
            return;
        }

        if (newSubcategory == this) throw new CategoryArgumentException("A category cannot be its own subcategory.", nameof(newSubcategory));

        Subcategory = newSubcategory;
    }
}
