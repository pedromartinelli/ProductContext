namespace ProductContext.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(int statusCode, T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
            StatusCode = statusCode;
        }

        public ApiResponse(int statusCode, T data)
        {
            Data = data;
            StatusCode = statusCode;
        }

        public ApiResponse(int statusCode, List<string> errors)
        {
            Errors = errors;
            StatusCode = statusCode;
        }

        public ApiResponse(int statusCode, string error)
        {
            Errors.Add(error);
            StatusCode = statusCode;
        }

        public int StatusCode { get; private set; }
        public T? Data { get; private set; }
        public List<string> Errors { get; private set; } = new();
    }
}
