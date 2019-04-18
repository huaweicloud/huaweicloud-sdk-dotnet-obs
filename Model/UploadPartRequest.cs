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
using System.IO;

namespace OBS.Model
{
    /// <summary>
    /// 上传段的请求参数。
    /// </summary>

    public class UploadPartRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "UploadPart";
        }

        private bool _autoClose = true;

        private double _metric;

        /// <summary>
        /// 上传进度条统计方式，默认为ByBytes。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，仅在设置了UploadProgress时有效。
        /// </para>
        /// </remarks>
        public ProgressTypeEnum ProgressType
        {
            get;
            set;
        }

        /// <summary>
        /// 进度条统计标准，默认为100KB或1秒。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，仅在设置了UploadProgress时有效。
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

        [Obsolete]
        public double ProgressMetric
        {
            get
            {
                return this.ProgressInterval;
            }
            set
            {
                this.ProgressInterval = value;
            }
        }

        /// <summary>
        /// 上传数据进度条。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public EventHandler<TransferStatus> UploadProgress
        {
            get;
            set;
        }

        /// <summary>
        /// 是否自动关闭输入流，默认为true。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，仅在设置了InputStream时有效。
        /// </para>
        /// </remarks>
        public bool AutoClose
        {
            set
            {
                this._autoClose = value;
            }
            get
            {
                return this._autoClose;
            }
        }

        /// <summary>
        /// 待上传段的数据流。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，不可与FilePath一起使用。
        /// </para>
        /// </remarks>
        public Stream InputStream
        {
            get;
            set;
        }

        /// <summary>
        /// 待上传段的源文件路径，必须指定为文件的全路径。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，不可与InputStream一起使用。
        /// </para>
        /// </remarks>
        public string FilePath
        {
            get;
            set;
        }


        /// <summary>
        /// 对象名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string ObjectKey
        {
            get;
            set;
        }

        /// <summary>
        /// 分段号。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选，取值范围：1~10000。
        /// </para>
        /// </remarks>
        public int PartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 分段大小。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，除最后一段的大小范围是0~5GB外，其他段的大小范围是100KB~5GB。
        /// </para>
        /// </remarks>
        public long? PartSize
        {
            get;
            set;
        }

        /// <summary>
        /// 分段上传任务的ID号。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string UploadId
        {
            get;
            set;
        }


        /// <summary>
        /// 待上传段内容经过base64编码的MD5值，用于服务端校验一致性。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string ContentMd5
        {
            get;
            set;
        }

        /// <summary>
        /// 待上传文件中某一分段的起始偏移大小。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，默认值为0，单位为字节。
        /// </para>
        /// </remarks>
        public long? Offset
        {
            get;
            set;
        }

        /// <summary>
        /// 段内容SSE-C加密头域信息。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public SseCHeader SseCHeader
        {
            get;
            set;
        }


    }
}

