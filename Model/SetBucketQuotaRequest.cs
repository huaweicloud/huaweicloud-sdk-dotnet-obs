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
    /// 设置桶配额的请求参数。
    /// </summary>
    public class SetBucketQuotaRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "SetBucketQuota";
        }

        /// <summary>
        /// 配额。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选，为字符串类型，需要将整数值转化为字符串。
        /// 单位为字节，支持的最大值为2^63 - 1的字符串形式，配额值设为“0”表示桶的配额没有上限。
        /// </para>
        /// </remarks>
        public long StorageQuota
        {
            get;
            set;
        }

    }
}
    
