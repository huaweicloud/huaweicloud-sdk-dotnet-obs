
using OBS.Internal;
using System;

namespace OBS.Model
{
	/// <summary>
	/// 上传文件的请求参数
	/// </summary>
    public class UploadFileRequest : ResumableUploadRequest
    {
        // 分段上传时的最大并发数，默认为1
        private int taskNum = 1;

        internal override string GetAction()
        {
            return "UploadFile";
        }

        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public UploadFileRequest()
        { }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名</param>
        /// <param name="objectKey">对象名</param>
        public UploadFileRequest(string bucketName, string objectKey) :base(bucketName, objectKey)
        {

        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="uploadFile">待上传的本地文件</param>
        /// <param name="bucketName">桶名</param>
        /// <param name="objectKey">对象名</param>
        public UploadFileRequest(string uploadFile,string bucketName, string objectKey) 
            : this(bucketName, objectKey)
        {
            this.UploadFile = uploadFile;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名</param>
        /// <param name="objectKey">对象名</param>
        /// <param name="uploadFile">待上传的本地文件</param>
        /// <param name="partSize">分片大小</param>
        public UploadFileRequest(string bucketName, string objectKey, string uploadFile, long partSize)
            :this(uploadFile, bucketName, objectKey)
        {
            this.UploadPartSize = partSize;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名</param>
        /// <param name="objectKey">对象名</param>
        /// <param name="uploadFile">待上传的本地文件</param>
        /// <param name="partSize">分片大小</param>
        /// <param name="taskNum">上传任务数</param>
        /// <param name="enableCheckpoint"></param>
        public UploadFileRequest(string bucketName, string objectKey, string uploadFile, long partSize, int taskNum,
                bool enableCheckpoint)
            : this(bucketName, objectKey, uploadFile, partSize, taskNum, enableCheckpoint, null)
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名</param>
        /// <param name="objectKey">对象名</param>
        /// <param name="uploadFile">待上传的本地文件</param>
        /// <param name="partSize">分片大小</param>
        /// <param name="taskNum">上传任务数</param>
        /// <param name="enableCheckpoint">是否开启断点续传模式</param>
        /// <param name="checkpointFile">断点续传模式下，记录上传进度的文件</param>
        public UploadFileRequest(string bucketName, string objectKey, string uploadFile, long partSize, int taskNum,
                bool enableCheckpoint, string checkpointFile)
            : this(bucketName, objectKey)
        { 
            this.UploadPartSize = partSize;
            this.UploadFile = uploadFile;
            this.EnableCheckpoint = enableCheckpoint;
            this.CheckpointFile = checkpointFile;
            this.TaskNum = taskNum;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名</param>
        /// <param name="objectKey">对象名</param>
        /// <param name="uploadFile">待上传的本地文件</param>
        /// <param name="partSize">分片大小</param>
        /// <param name="taskNum">上传任务数</param>
        /// <param name="enableCheckpoint">是否开启断点续传模式</param>
        /// <param name="checkpointFile">断点续传模式下，记录上传进度的文件</param>
        /// <param name="enableCheckSum">断点续传模式下，非首次上传时是否校验待上传文件的内容</param>
        public UploadFileRequest(string bucketName, string objectKey, string uploadFile, long partSize, int taskNum,
                bool enableCheckpoint, string checkpointFile, bool enableCheckSum)
            : this(bucketName, objectKey, uploadFile, partSize, taskNum, enableCheckpoint, checkpointFile)
        {   
            this.EnableCheckSum = enableCheckSum;
        }

        /// <summary>
        /// 待上传的本地文件。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string UploadFile
        {
            get;
            set;
        }

        /// <summary>
        /// 分段上传时的最大并发数
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


    }
}

