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
