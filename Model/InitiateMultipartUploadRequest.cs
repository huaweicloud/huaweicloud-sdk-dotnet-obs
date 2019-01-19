

namespace OBS.Model
{
    /// <summary>
    /// 初始化分段上传任务的请求参数。
    /// </summary>
    public class InitiateMultipartUploadRequest : PutObjectBasicRequest
    {
        internal override string GetAction()
        {
            return "InitiateMultipartUpload";
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
    
