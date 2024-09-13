using System.Diagnostics.CodeAnalysis;

namespace CleanArchitecture.MyShop.Domain.Exceptions;

[ExcludeFromCodeCoverage]
public class ResourceNotFoundException : HttpRequestException
{
    public ResourceNotFoundException() : base(null, null, System.Net.HttpStatusCode.NoContent) { }
    public ResourceNotFoundException(string message) : base(message, null, System.Net.HttpStatusCode.NoContent) { }
    public ResourceNotFoundException(string message, Exception inner) : base(message, inner, System.Net.HttpStatusCode.NoContent) { }
}
