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
    /// 复制对象的请求参数。
    /// </summary>
    public class CopyObjectRequest : PutObjectBasicRequest
    {

        internal override string GetAction()
        {
            return "CopyObject";
        }

        /// <summary>
        /// 源桶名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string SourceBucketName
        {
            get;
            set;
        }

        /// <summary>
        /// 源对象名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string SourceObjectKey
        {
            get;
            set;
        }

        /// <summary>
        /// 源对象的版本号。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string SourceVersionId
        {
            get;
            set;
        }


        /// <summary>
        /// 如果源对象的ETag值与该参数值相同，则进行复制，否则返回异常码。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string IfMatch
        {
            get;
            set;
        }


        /// <summary>
        /// 如果源对象的ETag值与该参数值不相同，则进行复制，否则返回异常码。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string IfNoneMatch
        {
            get;
            set;
        }

        /// <summary>
        /// 如果源对象的修改时间晚于该参数值指定的时间，则进行复制，否则返回异常码。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public DateTime? IfModifiedSince
        {
            get;
            set;
        }


        /// <summary>
        /// 如果源对象的修改时间早于该参数值指定的时间，则进行复制，否则返回异常码。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public DateTime? IfUnmodifiedSince
        {
            get;
            set;
        }


        /// <summary>
        /// 复制策略。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public MetadataDirectiveEnum MetadataDirective
        {
            get;
            set;
        }

        /// <summary>
        /// 源对象SSE-C解密头域信息。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public SseCHeader SourceSseCHeader
        {
            get;
            set;
        }

    }
}
    
