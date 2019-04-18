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
    /// 分段上传任务。
    /// </summary>
    public class MultipartUpload
    {


        /// <summary>
        /// 分段上传任务的创建时间。 
        /// </summary>
        public DateTime? Initiated
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段上传任务的创建者。
        /// </summary>
        public Initiator Initiator
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象名。 
        /// </summary>
        public string ObjectKey
        {
            get;
            internal set;
        }


        /// <summary>
        /// 分段上传任务的所有者。
        /// </summary>
        public Owner Owner
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段上传任务对象的存储类型。  
        /// </summary>
        public StorageClassEnum? StorageClass
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段上传任务的ID号。
        /// </summary>
        public string UploadId
        {
            get;
            internal set;
        }

    }
}
