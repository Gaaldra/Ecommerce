namespace Ecommerce.Domain.Exceptions;

public class ProductArgumentNullException : ArgumentNullException
{
    public ProductArgumentNullException() : base("Category argument cannot be null.") { }
    public ProductArgumentNullException(string message) : base(message) { }
    public ProductArgumentNullException(string message, Exception innerException) : base(message, innerException) { }
    public ProductArgumentNullException(string message, string paramName) : base(message, paramName) { }
}
