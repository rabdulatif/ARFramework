using System.Net;
using AR.AspNetCore.Logics.Helpers;
using SB.Common.Logics.SynonymProviders;

namespace AR.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiResponseError
    {
        /// <summary>
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     Response error model
        /// </summary>
        public ApiResponseError()
        {
        }

        /// <summary>
        ///     Response error model
        /// </summary>
        /// <param name="errorEnum">Error enum</param>
        public ApiResponseError(Enum errorEnum)
        {
            ErrorCode = (int)(object)errorEnum;
            ErrorMessage = EnumSynonymProvider.Get(errorEnum);
        }

        /// <summary>
        /// </summary>
        /// <param name="errorEnum"></param>
        /// <param name="errorMessage"></param>
        public ApiResponseError(Enum errorEnum, string errorMessage)
        {
            ErrorCode = (int)(object)errorEnum;
            ErrorMessage = $"{EnumSynonymProvider.Get(errorEnum)}  {errorMessage}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="errorMessage"></param>
        public ApiResponseError(HttpStatusCode statusCode, string errorMessage)
        {
            if (HttpContextHelper.Current?.Response != null)
                HttpContextHelper.Current.Response.StatusCode = (int)statusCode;

            ErrorCode = (int)statusCode;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        ///     Response error model
        /// </summary>
        /// <param name="errorCode">Response error code</param>
        /// <param name="errorMessage">Response error message</param>
        public ApiResponseError(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// </summary>
        /// <param name="httpStatusCode"></param>
        /// <param name="errorEnum"></param>
        public ApiResponseError(HttpStatusCode httpStatusCode, Enum errorEnum)
        {
            if (HttpContextHelper.Current?.Response != null)
                HttpContextHelper.Current.Response.StatusCode = (int)httpStatusCode;

            ErrorCode = (int)httpStatusCode;
            ErrorMessage = errorEnum.GetString();
        }
    }
}