using BuildingBlocks.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.Exceptions.Application
{
    public class RegraNegocioValidacaoException : BaseAppException
    {
        public RegraNegocioValidacaoException(string message)
            : base(message, StatusCodes.Status422UnprocessableEntity) { }
    }
}
