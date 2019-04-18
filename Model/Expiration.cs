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

namespace OBS.Model
{
    /// <summary>
    /// 对象过期时间配置。
    /// </summary>
    public class Expiration
    {
        
        /// <summary>
        /// 对象过期日期， 表示对象过期的具体日期。 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 如果没有设置Days则必选。
        /// </para>
        /// </remarks>
        public DateTime? Date
        {
            get;
            set;
        }

        /// <summary>
        /// 对象过期时间，表示在对象创建时间后第几天时过期。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 如果没有设置Date则必选。
        /// </para>
        /// </remarks>
        public int? Days
        {
            get;
            set;
        }
    }
}
