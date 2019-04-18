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

namespace OBS
{

    /// <summary>
    /// 鉴权类型
    /// </summary>
    public enum AuthTypeEnum
    {
        /// <summary>
        /// V2协议。
        /// </summary>
        V2,

        /// <summary>
        /// V4协议。
        /// </summary>
        [Obsolete]
        V4,

        /// <summary>
        /// OBS协议。
        /// </summary>
        OBS
    }



    public enum ErrorType
    {

        Sender,

        Receiver,

        Unknown
    }
}