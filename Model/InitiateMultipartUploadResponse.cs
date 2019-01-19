


namespace OBS.Model
{
    /// <summary>
    /// 初始化分段上传任务的响应结果。
    /// </summary>
    public class InitiateMultipartUploadResponse : ObsWebServiceResponse
    {

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
        /// 分段上传任务的ID号
        /// </summary>
        public string UploadId
        {
            get;
            internal set;
        }

    }
}
    
