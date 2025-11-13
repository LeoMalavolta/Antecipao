using BuildingBlocks.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.Exceptions.Infrastructure
{
    public class InfrastructureException : BaseAppException
    {
        public InfrastructureException(string message)
            : base(message, StatusCodes.Status502BadGateway) { }
    }
}
