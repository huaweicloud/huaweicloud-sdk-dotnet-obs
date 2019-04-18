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
using OBS.Internal;
using System;
namespace OBS.Model
{
    /// <summary>
    /// 下载对象的请求参数。
    /// </summary>
    public class GetObjectRequest : GetObjectMetadataRequest
    {

        internal override string GetAction()
        {
            return "GetObject";
        }

        private double _metric;

        /// <summary>
        /// 下载进度反馈方式，默认为ByBytes。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，仅在设置了DownloadProgress时有效。
        /// </para>
        /// </remarks>
        public ProgressTypeEnum ProgressType
        {
            get;
            set;
        }

        /// <summary>
        /// 下载进度反馈间隔，默认为100KB或1秒。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，仅在设置了DownloadProgress时有效。
        /// </para>
        /// </remarks>
        public double ProgressInterval
        {
            get
            {
                return this._metric <= 0 ? (ProgressType == ProgressTypeEnum.ByBytes ? Constants.DefaultProgressUpdateInterval : 1) : this._metric;
            }
            set
            {
                this._metric = value;
            }
        }

        /// <summary>
        /// 下载进度回调函数。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public EventHandler<TransferStatus> DownloadProgress
        {
            get;
            set;
        }

        /// <summary>
        /// 如果对象的ETag值与该参数值相同，则返回对象内容，否则返回异常码。
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
        /// 如果对象的修改时间晚于该参数值指定的时间，则返回对象内容，否则返回异常码。
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
        /// 如果对象的ETag值与该参数值不相同，则返回对象内容，否则返回异常码。
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
        /// 如果对象的修改时间早于该参数值指定的时间，则返回对象内容，否则返回异常码。
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
        /// 下载对象的范围。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public ByteRange ByteRange
        {
            get;
            set;
        }

        /// <summary>
        /// 重写的响应头信息。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public ResponseHeaderOverrides ResponseHeaderOverrides
        {
            get;
            set;
        }


        /// <summary>
        /// 图片处理参数。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string ImageProcess
        {
            get;
            set;
        }


    }
}
    
