
using System;
namespace OBS.Model
{
    /// <summary>
    /// 获取对象元数据的请求参数。
    /// </summary>
    public class GetObjectMetadataRequest : ObsBucketWebServiceRequest
    {
        internal override string GetAction()
        {
            return "GetObjectMetadata";
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
        /// 对象版本号。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string VersionId
        {
            get;
            set;
        }

        /// <summary>
        /// 对象内容SSE-C解密头域信息
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public SseCHeader SseCHeader
        {
            get;
            set;
        }
    }
}
    
