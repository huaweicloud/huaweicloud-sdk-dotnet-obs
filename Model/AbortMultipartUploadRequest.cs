
namespace OBS.Model
{
    /// <summary>
    /// 取消分段上传任务的请求参数。
    /// </summary>
    public class AbortMultipartUploadRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "AbortMultipartUpload";
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
        /// 分段上传任务ID号。
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

    }
}
    
