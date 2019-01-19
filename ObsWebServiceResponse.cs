

using OBS.Internal;
using System;
using System.Collections.Generic;
using System.Net;

namespace OBS
{
    /// <summary>
    /// 服务响应结果的基类。 
    /// </summary>
    public class ObsWebServiceResponse
    {

        private IDictionary<string, string> _headers;
        
        internal virtual void HandleObsWebServiceRequest(ObsWebServiceRequest request)
        {

        }

        /// <summary>
        /// OBS服务端返回的请求Id号，唯一的标识一个请求。
        /// </summary>
        public string RequestId
        {
            get;
            internal set;
        }

        /// <summary>
        ///  响应头域信息。
        /// </summary>
        public IDictionary<string, string> Headers
        {
            get
            {
                return this._headers ?? (this._headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
            }
            internal set
            {
                this._headers = value;
            }
        }

        /// <summary>
        /// HTTP响应内容长度。
        /// </summary>
        public virtual long ContentLength
        {
            get;
            internal set;
        }

        /// <summary>
        /// HTTP响应状态码。
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get;
            internal set;
        }
    }
}
