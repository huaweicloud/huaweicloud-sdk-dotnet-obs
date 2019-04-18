
using OBS.Internal;
using System;

namespace OBS.Model
{

    public abstract class ResumableUploadRequest : PutObjectBasicRequest
    {
        //首次调用：
        //默认enableCheckpoint和checkSum为false（默认均不开启）

        // 分片大小，单位字节，默认5MB
        protected long partSize = 1024 * 1024 * 5L;

        protected double _metric;

        internal override string GetAction()
        {
            return "ResumableUpload";
        }

        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public ResumableUploadRequest()
        { }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名</param>
        /// <param name="objectKey">对象名</param>
        public ResumableUploadRequest(string bucketName, string objectKey)
        {
            this.BucketName = bucketName;
            this.ObjectKey = objectKey;
        }


        /// <summary>
        /// 上传进度反馈方式，默认为ByBytes。
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
        /// 上传进度反馈间隔，默认为100KB或1秒。
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

        /// <summary>
        /// 上传进度回调函数。
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
        /// 上传事件回调函数。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public EventHandler<ResumableUploadEvent> UploadEventHandler
        {
            get;
            set;
        }
        

        /// <summary>
        /// 上传时的分段大小。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，单位字节，取值范围是100KB~5GB，默认为5M。
        /// </para>
        /// </remarks>
        public long UploadPartSize
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
        /// 是否开启断点续传模式标识。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public bool EnableCheckpoint
        {
            get;
            set;
        }

        /// <summary>
        /// 记录上传进度的文件。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，默认与UploadFile同目录。
        /// </para>
        /// </remarks>
        public virtual string CheckpointFile
        {
            get;
            set;
        }

        /// <summary>
        /// 是否校验待上传内容标识。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public bool EnableCheckSum
        {
            get;
            set;
        }


        /// <summary>
        /// 生成的最终对象的过期时间。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public int? Expires
        {
            get;
            set;
        }

    }
}

