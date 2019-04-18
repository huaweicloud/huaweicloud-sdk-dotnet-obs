/*----------------------------------------------------------------------------------
// Copyright 2019 Huawei Technologies Co.,Ltd.
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License.  You may obtain a copy of the
// License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations under the License.
//----------------------------------------------------------------------------------*/
using System;
using System.Net;
using OBS.Model;
using System.Text;

namespace OBS
{
    /// <summary>
    ///  OBS服务异常。
    /// </summary>
    public class ObsException : ServiceException
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">OBS服务端错误描述。</param>
        public ObsException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">OBS服务端错误描述。</param>
        /// <param name="innerException">导致当前异常的异常。</param>
        public ObsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="innerException">导致当前异常的异常。</param>
        public ObsException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">OBS服务端错误描述。</param>
        /// <param name="errorType">错误类型。</param>
        /// <param name="errorCode">OBS服务端错误码。</param>
        public ObsException(string message, ErrorType errorType, string errorCode)
            : base(message, errorType, errorCode)
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">OBS服务端错误描述。</param>
        /// <param name="errorType">错误类型。</param>
        /// <param name="errorCode">OBS服务端错误码。</param>
        /// <param name="requestId">OBS服务端返回的请求Id。</param>
        public ObsException(string message, ErrorType errorType, string errorCode, string requestId)
            : base(message, errorType, errorCode, requestId)
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">OBS服务端错误描述。</param>
        /// <param name="errorType">错误类型。</param>
        /// <param name="errorCode">OBS服务端错误码。</param>
        /// <param name="requestId">OBS服务端返回的请求Id。</param>
        /// <param name="statusCode">HTTP状态码。</param>
        public ObsException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
            : base(message, errorType, errorCode, requestId, statusCode)
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">OBS服务端错误描述。</param>
        /// <param name="innerException">导致当前异常的异常。</param>
        /// <param name="errorType">错误类型。</param>
        /// <param name="errorCode">OBS服务端错误码。</param>
        /// <param name="requestId">OBS服务端返回的请求Id。</param>
        /// <param name="statusCode">HTTP状态码。</param>
        public ObsException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
            : base(message, innerException, errorType, errorCode, requestId, statusCode)
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">OBS服务端错误描述。</param>
        /// <param name="innerException">导致当前异常的异常。</param>
        /// <param name="errorType">错误类型。</param>
        /// <param name="errorCode">OBS服务端错误码。</param>
        /// <param name="requestId">OBS服务端返回的请求Id。</param>
        /// <param name="statusCode">HTTP状态码。</param>
        /// <param name="obsId2">标记。</param>
        public ObsException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode, string obsId2)
            : base(message, innerException, errorType, errorCode, requestId, statusCode)
        {
            this.ObsId2 = obsId2;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">错误信息。</param>
        /// <param name="errorType">错误类型。</param>
        /// <param name="errorCode">OBS服务端错误码。</param>
        /// <param name="errorMessage">OBS服务端错误描述。</param>
        /// <param name="requestId">OBS服务端返回的请求Id。</param>
        /// <param name="statusCode">HTTP状态码。</param>
        public ObsException(string message, ErrorType errorType, string errorCode, string errorMessage, string requestId, HttpStatusCode statusCode)
            : base(message, errorType, errorCode, requestId, statusCode)
        {
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="message">错误信息。</param>
        /// <param name="innerException">导致当前异常的异常。</param>
        /// <param name="errorType">错误类型。</param>
        /// <param name="errorCode">OBS服务端错误码。</param>
        /// <param name="errorMessage">OBS服务端错误描述。</param>
        /// <param name="requestId">OBS服务端返回的请求Id。</param>
        /// <param name="statusCode">HTTP状态码。</param>
        public ObsException(string message, Exception innerException, ErrorType errorType, string errorCode, string errorMessage, string requestId, HttpStatusCode statusCode)
            : base(message, innerException, errorType, errorCode, requestId, statusCode)
        {
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// OBS服务端返回的用于定位问题的特殊标记。
        /// </summary>
        [Obsolete]
        public string ObsId2 { get; set; }

        /// <summary>
        /// 服务端ID。
        /// </summary>
        public string HostId
        {
            get;
            set;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Message)
            .Append(", StatusCode:").Append(Convert.ToInt32(this.StatusCode))
                .Append(", ErrorCode:").Append(this.ErrorCode)
                .Append(", ErrorMessage:").Append(this.ErrorMessage)
                .Append(", RequestId:").Append(this.RequestId)
                .Append(", HostId:").Append(this.HostId);
            return sb.ToString();
        }
    }
}
