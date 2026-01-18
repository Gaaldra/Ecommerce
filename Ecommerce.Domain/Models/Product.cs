using Ecommerce.Domain.Exceptions;

namespace Ecommerce.Domain.Models;

public class Product
{
    public int Id { get; init; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public int Discount { get; private set; } = 0;
    public Category Category { get; private set; } = null!;

    private Product() { }

    private Product(string name, decimal price, Category category)
    {
        UpdateName(name);
        UpdatePrice(price);
        UpdateCategory(category);
    }

    public static Product Create(string name, decimal price, Category category) => new(name, price, category);

    public static Product Create(string name, decimal price, Category category, string description)
    {
        Product product = Create(name, price, category);

        product.UpdateDescription(description);

        return product;
    }

    public static Product Create(string name, decimal price, Category category, string description, int discount)
    {
        Product product = Create(name, price, category, description);

        product.UpdateDiscount(discount);

        return product;
    }

    public void UpdateName(string newName)
    {
        ProductArgumentException.ThrowIfNullOrWhiteSpace(newName);

        Name = newName;
    }

    public void UpdateDescription(string newDescription)
    {
        if (string.IsNullOrWhiteSpace(newDescription))
        {
            Description = null;
            return;
        }

        Description = newDescription;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (decimal.IsNegative(newPrice)) throw new ProductArgumentException("Product price cannot be negative.", nameof(newPrice));

        Price = newPrice;
    }

    public void UpdateDiscount(int newDiscount)
    {
        if (newDiscount is < 0 or > 100) throw new ProductArgumentException("Discount must be between 0 and 100.", nameof(newDiscount));

        Discount = newDiscount;
    }

    public void UpdateCategory(Category newCategory)
    {
        ProductArgumentNullException.ThrowIfNull(newCategory);

        Category = newCategory;
    }
}
