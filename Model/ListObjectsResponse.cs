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
    /// 列举桶内对象的响应结果。
    /// </summary>
    public class ListObjectsResponse : ObsWebServiceResponse
    {

        private IList<ObsObject> contents;

        private IList<string> commonPrefixes;


        /// <summary>
        /// 判断列举结果是否被截断。
        /// true表示截断，本次没有返回全部结果；false表示未截断，本次已经返回了全部结果。
        /// </summary>
        public bool IsTruncated
        {
            get;
            internal set;
        }

        /// <summary>
        /// 本次请求的起始位置。
        /// </summary>
        public string Marker
        {
            get;
            internal set;
        }

        /// <summary>
        /// 下次请求的起始位置。
        /// </summary>
        public string NextMarker
        {
            get;
            internal set;
        }

        /// <summary>
        /// 桶内对象列表。
        /// </summary>
        public IList<ObsObject> ObsObjects
        {
            get {
                
                return this.contents ?? (this.contents = new List<ObsObject>()); }
            internal set { this.contents = value; }
        }

        /// <summary>
        /// 桶名。
        /// </summary>
        public string BucketName
        {
            get;
            internal set;
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
        /// 本次请求的最大条目数。
        /// </summary>
        public int? MaxKeys
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分组后的对象名前缀列表。
        /// </summary>
        public IList<string> CommonPrefixes
        {
            get {
                
                return this.commonPrefixes ?? (this.commonPrefixes = new List<string>()); }
            internal set { this.commonPrefixes = value; }
        }


        /// <summary>
        /// 本次请求对对象名进行分组的字符。
        /// </summary>
        public string Delimiter
        {
            get;
            internal set;
        }

        /// <summary>
        /// 桶的区域位置
        /// </summary>
        public string Location
        {
            get;
            internal set;
        }

    }
   }
    
