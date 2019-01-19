

namespace OBS.Model
{
    /// <summary>
    /// 获取桶Website（托管）配置的响应结果。
    /// </summary>
    public class GetBucketWebsiteResponse : ObsWebServiceResponse
    {

        /// <summary>
        /// 桶的Website（托管）配置。
        /// </summary>
        public WebsiteConfiguration Configuration
        {
            get;
            internal set;
        }

    }
}
    
