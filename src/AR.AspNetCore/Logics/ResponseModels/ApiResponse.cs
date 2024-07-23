namespace AR.AspNetCore
{
    /// <summary>
    /// </summary>
    public class ApiResponse<T> 
    {
        /// <summary>
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// </summary>
        public ApiResponseError Error { get; set; }

        /// <summary>
        /// </summary>
        public ApiResponse()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="result"></param>
        public ApiResponse(T result)
        {
            Result = result;
            IsSuccess = true;
        }

        /// <summary>
        /// </summary>
        /// <param name="error"></param>
        public ApiResponse(ApiResponseError error)
        {
            Error = error;
            IsSuccess = false;
        }

        /// <summary>
        /// </summary>
        /// <param name="result"></param>
        public static implicit operator ApiResponse<T>(T result)
        {
            return new ApiResponse<T>(result);
        }

        /// <summary>
        /// </summary>
        /// <param name="error"></param>
        public static implicit operator ApiResponse<T>(ApiResponseError error)
        {
            return new ApiResponse<T>(error);
        }
    }
}