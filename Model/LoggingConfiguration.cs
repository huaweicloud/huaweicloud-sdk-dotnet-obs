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
    /// 桶的访问日志配置。
    /// </summary>
    public class LoggingConfiguration : AbstractAccessControlList
    {
        

        /// <summary>
        /// 生成日志的目标桶。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string TargetBucketName { get; set; }

        /// <summary>
        /// 在目标桶中生成日志对象的对象名前缀。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string TargetPrefix { get; set; }

        /// <summary>
        /// 委托名字
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string Agency
        {
            get;
            set;
        }

    }
}
