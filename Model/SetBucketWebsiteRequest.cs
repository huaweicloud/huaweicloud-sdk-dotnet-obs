

namespace OBS.Model
{
    /// <summary>
    /// 设置桶Website（托管）配置的请求参数。
    /// </summary>
    public class SetBucketWebsiteRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "SetBucketWebsite";
        }

        /// <summary>
        /// 桶的Website（托管）配置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public WebsiteConfiguration Configuration
        {
            get;
            set;
        }

    }
}
    
