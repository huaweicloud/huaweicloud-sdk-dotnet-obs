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
    /// 列举分段上传任务的响应结果。
    /// </summary>
    public class ListMultipartUploadsResponse : ObsWebServiceResponse
    {

        private IList<MultipartUpload> multipartUploads;
        private IList<string> commonPrefixes;

        /// <summary>
        /// 桶名。
        /// </summary>
        public string BucketName
        {
            get;
            internal set;
        }

        /// <summary>
        /// 本次请求的起始位置（按对象名排序）。
        /// </summary>
        public string KeyMarker
        {
            get;
            internal set;
        }

        /// <summary>
        /// 本次请求的起始位置（按分段上传任务的ID号排序）。
        /// </summary>
        public string UploadIdMarker
        {
            get;
            internal set;
        }


        /// <summary>
        /// 下次请求的起始位置（按对象名排序）。
        /// </summary>
        public string NextKeyMarker
        {
            get;
            internal set;
        }


        /// <summary>
        /// 下次请求的起始位置（按分段上传任务ID号排序）。 
        /// </summary>
        public string NextUploadIdMarker
        {
            get;
            internal set;
        }

        /// <summary>
        /// 列举分段上传任务的最大条目数。 
        /// </summary>
        public int? MaxUploads
        {
            get;
            internal set;
        }

        /// <summary>
        /// 判断列举结果是否被截断。
        ///  true表示截断，本次没有返回全部结果；false表示未截断，本次已经返回了全部结果。
        /// </summary>
        public bool IsTruncated
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段上传任务列表。
        /// </summary>
        public IList<MultipartUpload> MultipartUploads
        {
            get 
            {
                

                return this.multipartUploads ?? (this.multipartUploads = new List<MultipartUpload>()); 
            }
            internal set { this.multipartUploads = value; }
        }

        /// <summary>
        /// 本次请求的对象名前缀。
        /// </summary>
        public string Prefix
        {
            get;
            internal set;
        }

        /// <summary>
        /// 本次请求的分组字符。
        /// </summary>
        public string Delimiter
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分组后的对象名前缀列表。
        /// </summary>
        public IList<string> CommonPrefixes
        {
            get
            {
               
                return this.commonPrefixes ?? (this.commonPrefixes = new List<string>());
            }
            internal set { this.commonPrefixes = value; }
        }
    }
}
    
