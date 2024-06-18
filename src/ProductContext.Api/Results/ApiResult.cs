namespace ProductContext.Api.Results
{
    public class ApiResult<T>
    {
        public ApiResult(int statusCode, T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
            StatusCode = statusCode;
        }

        public ApiResult(int statusCode, T data)
        {
            Data = data;
            StatusCode = statusCode;
        }

        public ApiResult(int statusCode, List<string> errors)
        {
            Errors = errors;
            StatusCode = statusCode;
        }

        public ApiResult(int statusCode, string error)
        {
            Errors.Add(error);
            StatusCode = statusCode;
        }

        public int StatusCode { get; private set; }
        public T? Data { get; private set; }
        public List<string> Errors { get; private set; } = new();
    }
}
