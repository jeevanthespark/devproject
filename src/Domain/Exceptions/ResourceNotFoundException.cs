namespace CleanArchitecture.MyShop.Domain.Exceptions
{
    public class ResourceNotFoundException : HttpRequestException
    {
        public ResourceNotFoundException() : base(null, null, System.Net.HttpStatusCode.NoContent) { }
        public ResourceNotFoundException(string message) : base(message, null, System.Net.HttpStatusCode.NoContent) { }
        public ResourceNotFoundException(string message, Exception inner) : base(message, inner, System.Net.HttpStatusCode.NoContent) { }
    }
}
