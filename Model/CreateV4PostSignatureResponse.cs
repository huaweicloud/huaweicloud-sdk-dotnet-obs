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

namespace OBS.Model
{
    /// <summary>
    /// POST表单鉴权响应结果。
    /// </summary>
    public class CreateV4PostSignatureResponse : CreatePostSignatureResponse
    {
        /// <summary>
        /// 签名算法，用于填充表单。
        /// </summary>
        public string Algorithm
        {
            get;
            internal set;
        }

        /// <summary>
        /// Credential信息，用于填充表单。
        /// </summary>
        public string Credential
        {
            get;
            internal set;
        }

        /// <summary>
        /// ISO 8601格式日期，用于填充表单。
        /// </summary>
        public string Date
        {
            get;
            internal set;
        }

    }
}
    
