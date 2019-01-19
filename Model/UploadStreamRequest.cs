
using OBS.Internal;
using System;
using System.IO;

namespace OBS.Model
{
	/// <summary>
	/// 上传数据流的请求参数
	/// </summary>
    public class UploadStreamRequest : ResumableUploadRequest
    {
        //UplaodStream方式不支持多线程并发上传，无taskNum参数

        private Stream uploadStream;

        internal override string GetAction()
        {
            return "UploadStream";
        }

        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public UploadStreamRequest()
        { }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名</param>
        /// <param name="objectKey">对象名</param>
        public UploadStreamRequest(string bucketName, string objectKey) :base(bucketName, objectKey)
        {

        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="uploadStream">待上传的数据流，必须可查找</param>
        /// <param name="bucketName">桶名</param>
        /// <param name="objectKey">对象名</param>
        public UploadStreamRequest(Stream uploadStream, string bucketName, string objectKey) 
            : this(bucketName, objectKey)
        {
            this.UploadStream = uploadStream;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名</param>
        /// <param name="objectKey">对象名</param>
        /// <param name="uploadStream">待上传的数据流，必须可查找</param>
        /// <param name="partSize">分片大小</param>
        public UploadStreamRequest(string bucketName, string objectKey, Stream uploadStream, long partSize)
            :this(uploadStream, bucketName, objectKey)
        {
            this.UploadPartSize = partSize;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名</param>
        /// <param name="objectKey">对象名</param>
        /// <param name="uploadStream">待上传的数据流，必须可查找</param>
        /// <param name="partSize">分片大小</param>
        /// <param name="enableCheckpoint"></param>
        public UploadStreamRequest(string bucketName, string objectKey, Stream uploadStream, long partSize, bool enableCheckpoint)
            : this(bucketName, objectKey, uploadStream, partSize, enableCheckpoint, null)
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="bucketName">桶名</param>
        /// <param name="objectKey">对象名</param>
        /// <param name="uploadStream">待上传的数据流，必须可查找</param>
        /// <param name="partSize">分片大小</param>
        /// <param name="enableCheckpoint">是否开启断点续传模式</param>
        /// <param name="checkpointFile">断点续传模式下，记录上传进度的文件</param>
        public UploadStreamRequest(string bucketName, string objectKey, Stream uploadStream, long partSize, bool enableCheckpoint, string checkpointFile)
            : this(bucketName, objectKey)
        { 
            this.UploadPartSize = partSize;
            this.UploadStream = uploadStream;
            this.EnableCheckpoint = enableCheckpoint;
            this.CheckpointFile = checkpointFile;
        }

        /// <summary>
        /// 记录上传进度的文件。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，默认为当前程序运行的目录。
        /// </para>
        /// </remarks>
        public override string CheckpointFile
        {
            get;
            set;
        }


        /// <summary>
        /// 待上传的数据流，必须可查找。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public Stream UploadStream
        {
            get { return this.uploadStream; }
            set { this.uploadStream = value; }
        }


    }
}

