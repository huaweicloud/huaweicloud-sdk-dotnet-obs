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
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 获取桶元数据信息的请求参数。
    /// </summary>
    public class GetBucketMetadataRequest : ObsBucketWebServiceRequest
    {
        private IList<string> accessControlRequestHeaders;


        /// <summary>
        /// 预请求指定的跨域请求Origin（通常为域名）。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string Origin
        {
            get;
            set;
        }


        /// <summary>
        ///  跨域请求可以使用的HTTP头域。
        ///  </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public IList<string> AccessControlRequestHeaders
        {
            get { return this.accessControlRequestHeaders ?? (this.accessControlRequestHeaders = new List<string>()); }
            set { this.accessControlRequestHeaders = value; }
        }

        internal override string GetAction()
        {
            return "GetBucketMetadata";
        }

    }
}
    
