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
    /// SSE-KMS加密方式头域信息。
    /// </summary>
    public class SseKmsHeader : SseHeader
    {
        /// <summary>
        /// SSE-KMS加密方式下的算法。
        /// </summary>
        public SseKmsAlgorithmEnum Algorithm
        {
            get;
            set;
        }

        /// <summary>
        /// SSE-KMS加密方式下使用的主密钥。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string Key
        {
            get;
            set;
        }
    }
}
