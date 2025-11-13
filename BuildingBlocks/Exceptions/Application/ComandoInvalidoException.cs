using BuildingBlocks.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.Exceptions.Application
{
    public class ComandoInvalidoException : BaseAppException
    {
        public ComandoInvalidoException(IEnumerable<string> erros)
            : base("Erro de validação no comando.", StatusCodes.Status400BadRequest, erros) { }
    }
}
