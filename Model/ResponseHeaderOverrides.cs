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

namespace OBS.Model
{
    /// <summary>
    /// 下载对象时可重写的响应消息头信息。 
    /// </summary>
    public class ResponseHeaderOverrides
    {

        /// <summary>
        /// 重写响应中的Content-Type头。
        /// </summary>

        public string ContentType
        {
            get;
            set;
        }

        /// <summary>
        /// 重写响应中的Content-Language头。
        /// </summary>
        public string ContentLanguage
        {
            get;
            set;
        }

        /// <summary>
        /// 重写响应中的Expires头。
        /// </summary>
        public string Expires
        {
            get;
            set;
        }

        /// <summary>
        /// 重写响应中的Cache-Control头。
        /// </summary>
        public string CacheControl
        {
            get;
            set;
        }

        /// <summary>
        /// 重写响应中的Content-Disposition头。
        /// </summary>
        public string ContentDisposition
        {
            get;
            set;
        }

        /// <summary>
        /// 重写响应中的Content-Encoding头。
        /// </summary>
        public string ContentEncoding
        {
            get;
            set;
        }
    }
}
