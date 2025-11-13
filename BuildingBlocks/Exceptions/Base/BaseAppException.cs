

namespace BuildingBlocks.Exceptions.Base
{
    public abstract class BaseAppException : Exception
    {
        public bool Success { get; }
        public int StatusCode { get; }
        public IEnumerable<string>? Errors { get; }

        protected BaseAppException(string message, int statusCode, IEnumerable<string>? errors = null)
            : base(message)
        {
            Success = false;
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}