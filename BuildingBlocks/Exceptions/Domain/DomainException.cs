using BuildingBlocks.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.Exceptions.Domain
{
    public class DomainException : BaseAppException
    {
        public DomainException(string message)
            : base(message, StatusCodes.Status422UnprocessableEntity) { }
    }
}