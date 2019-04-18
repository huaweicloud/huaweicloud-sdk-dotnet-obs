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
    /// 跨区域复制配置规则。
    /// </summary>
    public class ReplicationRule
    {


        /// <summary>
        ///  规则ID，由不超过255个字符的字符串组成。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// 规则所匹配的对象名前缀。  
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选，用以标识哪些对象可以匹配到当前这条规则。可为空字符串，代表匹配桶内所有对象。
        /// </para>
        /// </remarks>
        public string Prefix
        {
            get;
            set;
        }

        /// <summary>
        /// 规则状态。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public RuleStatusEnum Status
        {
            get;
            set;
        }

        /// <summary>
        /// 目标桶名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string TargetBucketName
        {
            get;
            set;
        }

        /// <summary>
        /// 对象的存储类型。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public StorageClassEnum? TargetStorageClass
        {
            get;
            set;
        }

    }
}
