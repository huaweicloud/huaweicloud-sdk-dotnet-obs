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
using System.Globalization;
using System.Text.RegularExpressions;

namespace OBS.Model
{
    /// <summary>
    /// 对象的详细过期信息。
    /// </summary>
    public class ExpirationDetail
    {

        /// <summary>
        /// 过期时间。
        /// </summary>
        public DateTime? ExpiryDate
        {
            get;
            set;
        }

        /// <summary>
        /// ID号。
        /// </summary>
        public string RuleId
        {
            get;
            set;
        }
    }
}
