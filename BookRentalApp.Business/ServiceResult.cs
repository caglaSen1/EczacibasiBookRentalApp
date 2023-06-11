namespace BookRentalApp.Business
{
    public class ServiceResult<T>
    {
        public T Result { get; set; }

        public int ErrorCode { get; set; }

        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public static ServiceResult<T> Success(T data, string message)
        {
            return new ServiceResult<T> { IsSuccess = true, Result = data, Message = message };
        }

        public static ServiceResult<T> Failed(T data, string message, int code)
        {
            return new ServiceResult<T> { IsSuccess = false, Result = default(T), Message = message, ErrorCode = code};
        }
    }
}
