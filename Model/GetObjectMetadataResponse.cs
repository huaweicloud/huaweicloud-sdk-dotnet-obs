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
    /// 获取对象元数据的响应结果。
    /// </summary>
    public class GetObjectMetadataResponse : ObsWebServiceResponse
    {

        private MetadataCollection metadataCollection;

        private long _nextPosition = -1;


        /// <summary>
        /// 桶名。
        /// </summary>
        public string BucketName
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
        /// 对象自定义的元数据。
        /// </summary>
        public MetadataCollection Metadata
        {
            get
            {
                return this.metadataCollection ?? (this.metadataCollection = new MetadataCollection());
            }
            set { this.metadataCollection = value; }
        }

        /// <summary>
        /// 对象的MIME类型。
        /// </summary>
        public string ContentType
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象的长度。
        /// </summary>
        public override long ContentLength
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象的存储类型。
        /// </summary>
        public StorageClassEnum? StorageClass
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象删除标记。  
        /// </summary>
        public bool DeleteMarker
        {
            get;
            internal set;
        }


        /// <summary>
        /// 对象的详细过期信息。
        /// </summary>
        public ExpirationDetail ExpirationDetail
        {
            get;
            internal set;
        }

        /// <summary>
        /// 归档存储类型对象的取回状态，如果对象不为归档存储类型，则该值为空。
        /// </summary>
        public RestoreStatus RestoreStatus
        {
            get;
            set;
        }


        /// <summary>
        /// 对象的最后修改时间。
        /// </summary>
        public DateTime? LastModified
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象的etag校验值。
        /// </summary>
        public string ETag
        {
            get;
            internal set;
        }


        /// <summary>
        /// 对象版本号。
        /// </summary>
        public string VersionId
        {
            get;
            internal set;
        }


        /// <summary>
        /// 将请求重定向到该属性指定的桶内的另一个对象或外部的URL。
        /// 当桶设置了Website配置，就可以设置对象元数据的这个属性。
        /// </summary>
        public string WebsiteRedirectLocation
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象是否可被追加写。
        /// </summary>
        public bool Appendable
        {
            get;
            internal set;
        }

        /// <summary>
        /// 下次追加上传的位置, 仅在Appendable为true且大于0时有效。
        /// </summary>
        public long NextPosition
        {
            get
            {
                return _nextPosition;
            }
            internal set
            {
                this._nextPosition = value;
            }
        }

    }
}
    
