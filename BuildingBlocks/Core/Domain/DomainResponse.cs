using System.Net;

namespace BuildingBlocks.Core.Domain
{
    public class DomainResponse<T>
    {
        public bool Success { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }

        private DomainResponse(
            bool success,
            HttpStatusCode statusCode,
            string message,
            T data = default)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        // Sucesso com dados
        public static DomainResponse<T> Ok(
            T data,
            string message = "Operação realizada com sucesso.",
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new DomainResponse<T>(true, statusCode, message, data);
        }

        // Sucesso sem dados
        public static DomainResponse<T> Created(
            string message = "Operação realizada com sucesso.",
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new DomainResponse<T>(true, statusCode, message);
        }

        // Falha
        public static DomainResponse<T> Falied(
            string message,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new DomainResponse<T>(false, statusCode, message);
        }
    }
}
