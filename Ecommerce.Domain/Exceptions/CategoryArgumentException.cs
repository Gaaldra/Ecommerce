namespace Ecommerce.Domain.Exceptions;

public class CategoryArgumentException : ArgumentException
{
    public CategoryArgumentException() : base("Category argument is invalid.") { }
    public CategoryArgumentException(string message) : base(message) { }
    public CategoryArgumentException(string message, Exception innerException) : base(message, innerException) { }
    public CategoryArgumentException(string message, string paramName) : base(message, paramName) { }
    public CategoryArgumentException(string message, string paramName, Exception innerException) : base(message, paramName, innerException) { }
}
