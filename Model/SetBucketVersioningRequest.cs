

namespace OBS.Model
{
    /// <summary>
    /// 设置桶多版本配置的请求参数。
    /// </summary>
    public class SetBucketVersioningRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "SetBucketVersioning";
        }

        /// <summary>
        /// 桶的多版本配置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public VersioningConfiguration Configuration
        {
            get;
            set;
        }

    }
}
    
