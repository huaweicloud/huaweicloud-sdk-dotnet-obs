
using System;
using System.Net;
using OBS.Model;

namespace OBS
{
    /// <summary>
    /// OBS服务的异常基类。
    /// </summary>
    public abstract class ServiceException : Exception
    {

        /// <summary>
        ///  构造函数。
        /// </summary>
        public ServiceException()
            : base()
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">错误信息。</param>
        public ServiceException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">错误信息。</param>
        /// <param name="innerException">导致当前异常的异常。</param>
        public ServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">错误信息。</param>
        /// <param name="innerException">导致当前异常的异常。</param>
        /// <param name="statusCode">HTTP状态码。</param>
        public ServiceException(string message, Exception innerException, HttpStatusCode statusCode)
            : base(message, innerException)
        {
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="innerException">导致当前异常的异常。</param>
        public ServiceException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">错误信息。</param>
        /// <param name="errorType">错误类型。</param>
        /// <param name="errorCode">OBS服务端错误码。</param>
        public ServiceException(string message, ErrorType errorType, string errorCode)
            : base(message)
        {
            this.ErrorCode = errorCode;
            this.ErrorType = errorType;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">错误信息。</param>
        /// <param name="errorType">错误类型。</param>
        /// <param name="errorCode">OBS服务端错误码。</param>
        /// <param name="requestId">OBS服务端返回的请求Id。</param>
        public ServiceException(string message, ErrorType errorType, string errorCode, string requestId)
            : base(message)
        {
            this.ErrorCode = errorCode;
            this.ErrorType = errorType;
            this.RequestId = requestId;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">错误信息。</param>
        /// <param name="errorType">错误类型。</param>
        /// <param name="errorCode">OBS服务端错误码。</param>
        /// <param name="requestId">OBS服务端返回的请求Id。</param>
        /// <param name="statusCode">HTTP状态码。</param>
        public ServiceException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
            : base(message)
        {
            this.ErrorCode = errorCode;
            this.ErrorType = errorType;
            this.RequestId = requestId;
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">错误信息。</param>
        /// <param name="innerException">导致当前异常的异常。</param>
        /// <param name="errorType">错误类型。</param>
        /// <param name="errorCode">OBS服务端错误码。</param>
        /// <param name="requestId">OBS服务端返回的请求Id。</param>
        /// <param name="statusCode">HTTP状态码。</param>
        public ServiceException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
            : base(message, innerException)
        {
            this.ErrorCode = errorCode;
            this.ErrorType = errorType;
            this.RequestId = requestId;
            this.StatusCode = statusCode;
        }


        /// <summary>
        /// OBS服务端错误描述。
        /// </summary>
        public string ErrorMessage
        {
            get;
            set;
        }

        /// <summary>
        /// 错误类型。
        /// </summary>
        public ErrorType ErrorType
        {
            get;
            set;
        }

        /// <summary>
        /// OBS服务端错误码。
        /// </summary>
        public string ErrorCode
        {
            get;
            set;
        }

        /// <summary>
        /// OBS服务端返回的请求Id。
        /// </summary>
        public string RequestId
        {
            get;
            set;
        }

        /// <summary>
        /// 服务响应的HTTP状态码。
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get;
            set;
        }
    }
}
