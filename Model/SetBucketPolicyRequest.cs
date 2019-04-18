

namespace OBS.Model
{
    /// <summary>
    /// 设置桶策略的请求参数。
    /// </summary>
    public class SetBucketPolicyRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "SetBucketPolicy";
        }

        /// <summary>
        /// 桶策略内容的MD5值。 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string ContentMD5 { get; set; }


        /// <summary>
        /// 桶策略内容， JSON格式的字符串。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string Policy { get; set; }

    }
}
    
