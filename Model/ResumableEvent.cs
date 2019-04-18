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
    /// 断点续传下载事件。
    /// </summary>
    public class ResumableDownloadEvent : EventArgs
    {
        internal ResumableDownloadEvent()
        {

        }

        /// <summary>
        /// 事件类型。
        /// </summary>
        public ResumableDownloadEventTypeEnum EventType
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段号。
        /// </summary>
        public int PartNumber
        {
            get;
            internal set;
        }

    }

    /// <summary>
    /// 断点续传上传事件。
    /// </summary>
    public class ResumableUploadEvent : EventArgs
    {

        internal ResumableUploadEvent()
        {
           
        }
       
        /// <summary>
        /// 事件类型。
        /// </summary>
        public ResumableUploadEventTypeEnum EventType
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段上传任务ID。
        /// </summary>
        public string UploadId
        {
            get;
            internal set;
        }
    
        /// <summary>
        /// 分段号。
        /// </summary>
        public int PartNumber
        {
            get;
            internal set;
        }

        /// <summary>
        /// ETag值。
        /// </summary>
        public string ETag
        {
            get;
            internal set;
        }


    }
}
