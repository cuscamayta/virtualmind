using System;
namespace Virtualmind.Financial.Api.Exceptions
{
    public class UnprocessableRequestException : Exception
    {
        public UnprocessableRequestException(string message) : base(message)
        { }
    }
}
