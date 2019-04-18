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
    /// 获取桶元数据的响应结果。
    /// </summary>
    public class GetBucketMetadataResponse : ObsWebServiceResponse
    {
        /// <summary>
        /// 桶的存储类型。
        /// </summary>
        public StorageClassEnum? StorageClass
        {
            get;
            internal set;
        }

        /// <summary>
        /// 桶的区域位置。
        /// </summary>
        public string Location
        {
            get;
            internal set;
        }

        /// <summary>
        /// OBS服务的版本。
        /// </summary>
        public string ObsVersion
        {
            get;
            internal set;
        }

        /// <summary>
        /// 桶的集群类型。
        /// </summary>
        public AvailableZoneEnum AvailableZone
        {
            get;
            internal set;
        }

    }
}
    
