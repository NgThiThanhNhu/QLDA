namespace Model.BASE
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public bool Error { get; set; } = false;
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; }
    }
}
