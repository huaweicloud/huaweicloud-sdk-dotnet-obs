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
using System.Collections.Generic;
using System.Text;

namespace OBS.Model
{
    /// <summary>
    /// SSE-C加解密方式头域信息
    /// </summary>
    public class SseCHeader : SseHeader
    {
        /// <summary>
        /// SSE-C加解密方式下的算法。
        /// </summary>
        public SseCAlgorithmEnum Algorithm
        {
            get;
            set;
        }

        /// <summary>
        /// SSE-C加解密方式下使用的密钥，用于加解密对象，该值是密钥进行base64encode后的值。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，不可与Key一起使用。
        /// </para>
        /// </remarks>
        public string KeyBase64
        {
            get;
            set;
        }

        /// <summary>
        /// SSE-C加解密方式下使用的密钥，用于加解密对象，该值是密钥未经过base64encode后的值
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，不可与KeyBase64一起使用。
        /// </para>
        /// </remarks>
        public byte[] Key
        {
            get;
            set;
        }
    }
}
