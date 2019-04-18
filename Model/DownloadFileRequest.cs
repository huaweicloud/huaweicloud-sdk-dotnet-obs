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
    /// 下载文件的请求参数。
    /// </summary>
    public class DownloadFileRequest : GetObjectRequest
    {
        internal override string GetAction()
        {
            return "DownloadFile";
        }

        // 分段下载时的最大并发数，默认为1
        private int taskNum = 1;

        // 分片大小，单位字节，默认5M
        private long partSize = 5 * 1024 * 1024L;

        /// <summary>
        /// 构造函数。
        /// </summary>
        public DownloadFileRequest()
        { }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名。</param>
        /// <param name="objectKey">对象名。</param>
        public DownloadFileRequest(string bucketName, string objectKey)
        {
            this.BucketName = bucketName;
            this.ObjectKey = objectKey;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名。</param>
        /// <param name="objectKey">对象名。</param>
        /// <param name="downloadFile">下载对象的本地文件全路径。</param>
        public DownloadFileRequest(string bucketName, string objectKey, string downloadFile)
            : this(bucketName, objectKey)
        {
            this.DownloadFile = downloadFile;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名。</param>
        /// <param name="objectKey">对象名。</param>
        /// <param name="downloadFile">下载对象的本地文件全路径。</param>
        /// <param name="partSize">分段大小。</param>
        public DownloadFileRequest(string bucketName, string objectKey, string downloadFile, long partSize)
            :this(bucketName, objectKey)
        {
            this.DownloadFile = downloadFile;
            this.partSize = partSize;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名。</param>
        /// <param name="objectKey">对象名。</param>
        /// <param name="downloadFile">下载对象的本地文件全路径。</param>
        /// <param name="partSize">分段大小。</param>
        /// <param name="taskNum">分片上传线程数。</param>
        /// <param name="enableCheckpoint">是否开启断点续传模式。</param>
        public DownloadFileRequest(string bucketName, string objectKey, string downloadFile, long partSize, int taskNum,
                bool enableCheckpoint): this(bucketName, objectKey, downloadFile, partSize, taskNum, enableCheckpoint, null)
        {           
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名。</param>
        /// <param name="objectKey">对象名。</param>
        /// <param name="downloadFile">下载对象的本地文件全路径。</param>
        /// <param name="partSize">分段大小。</param>
        /// <param name="taskNum">分片上传线程数。</param>
        /// <param name="enableCheckpoint">是否开启断点续传模式。</param>
        /// <param name="checkpointFile">记录下载进度的文件。</param>
        public DownloadFileRequest(string bucketName, string objectKey, string downloadFile, long partSize, int taskNum,
                bool enableCheckpoint, string checkpointFile)
            : this(bucketName, objectKey)
        {
            this.partSize = partSize;
            this.DownloadFile = downloadFile;
            this.EnableCheckpoint = enableCheckpoint;
            this.CheckpointFile = checkpointFile;
            this.taskNum = taskNum;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名。</param>
        /// <param name="objectKey">对象名。</param>
        /// <param name="downloadFile">下载对象的本地文件全路径。</param>
        /// <param name="partSize">分段大小。</param>
        /// <param name="enableCheckpoint">是否开启断点续传模式。</param>
        /// <param name="checkpointFile">记录下载进度的文件。</param>
        /// <param name="versionId">对象版本号。</param>
        public DownloadFileRequest(string bucketName, string objectKey, string downloadFile, long partSize, 
                bool enableCheckpoint, string checkpointFile, string versionId)
            : this(bucketName, objectKey)
        {
            this.partSize = partSize;
            this.DownloadFile = downloadFile;
            this.EnableCheckpoint = enableCheckpoint;
            this.CheckpointFile = checkpointFile;
            this.VersionId = versionId;
        }


        /// <summary>
        /// 下载事件回调。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public EventHandler<ResumableDownloadEvent> DownloadEventHandler
        {
            get;
            set;
        }


        /// <summary>
        /// 分段下载时的最大并发数
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，默认为1
        /// </para>
        /// </remarks>
        public int TaskNum
        {
            get { return this.taskNum; }
            set
            {
                if (value < 1)
                    this.taskNum = 1;
                else
                    this.taskNum = value;
            }
        }

        /// <summary>
        /// 分段大小。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，单位字节，取值范围是100KB~5GB，默认为5M。
        /// </para>
        /// </remarks>
        public long DownloadPartSize
        {
            get { return this.partSize; }
            set
            {
                if (value < 100 * 1024L)
                    this.partSize = 100 * 1024L;
                else if (value > 5 * 1024 * 1024 * 1024L)
                    this.partSize = 5 * 1024 * 1024 * 1024L;
                else
                    this.partSize = value;
            }
        }

        /// <summary>
        /// 分段大小。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，单位字节，取值范围是100KB~5GB，默认为5M。
        /// </para>
        /// </remarks>
        [Obsolete]
        public long PartSize
        {
            get
            {
                return this.DownloadPartSize;
            }
            set
            {
                this.DownloadPartSize = value;
            }
        }

        /// <summary>
        /// 下载对象的本地文件全路径。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，当该值为空时，默认为当前程序的运行目录。
        /// </para>
        /// </remarks>
        public string DownloadFile
        {
            get;
            set;
        }

        /// <summary>
        /// 是否开启断点续传模式。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，默认为false，表示不开启。
        /// </para>
        /// </remarks>
        public bool EnableCheckpoint
        {
            get;
            set;
        }

        /// <summary>
        /// 记录下载进度的文件。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，只在断点续传模式下有效。当该值为空时，默认与下载对象的本地文件路径同目录。
        /// </para>
        /// </remarks>
        public string CheckpointFile
        {
            get;
            set;
        }

        /// <summary>
        /// 下载时的临时文件。
        /// </summary>
        public string TempDownloadFile
        {
            get { return DownloadFile + ".tmp"; }
        }
    }
}

