namespace Ecommerce.Domain.Exceptions;

public class ProductArgumentException : ArgumentException
{
    public ProductArgumentException() : base("Category argument is invalid.") { }
    public ProductArgumentException(string message) : base(message) { }
    public ProductArgumentException(string message, Exception innerException) : base(message, innerException) { }
    public ProductArgumentException(string message, string paramName) : base(message, paramName) { }
    public ProductArgumentException(string message, string paramName, Exception innerException) : base(message, paramName, innerException) { }
}
