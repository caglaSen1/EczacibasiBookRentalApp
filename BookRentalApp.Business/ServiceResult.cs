namespace BookRentalApp.Business
{
    public class ServiceResult<T>
    {
        public T Result { get; set; }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }

        public static ServiceResult<T> Succeeded(T data, string message, int code)
        {
            return new ServiceResult<T> { Success = true, Result = data, Message = message, StatusCode = code };
        }

        public static ServiceResult<T> Failed(T data, string message, int code)
        {
            return new ServiceResult<T> { Success = false, Result = default(T), Message = message, StatusCode = code};
        }
    }
}
