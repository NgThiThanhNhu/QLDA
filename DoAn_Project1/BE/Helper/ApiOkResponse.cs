namespace BE.Helper
{
    public class ApiOkResponse : ApiResponse
    {
        public object Result { get; }
        public ApiOkResponse(object result) : base(true, 200)
        {
            Result = result;
        }

        public ApiOkResponse(object result, bool success, int statusCode, string message = null) : base(success, statusCode, message)
        {
            Result = result;
        }
    }
}
