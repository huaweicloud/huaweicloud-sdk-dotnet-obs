

namespace OBS.Model
{
    /// <summary>
    /// 获取桶多版本配置的响应结果。
    /// </summary>
    public class GetBucketVersioningResponse : ObsWebServiceResponse
    {

        /// <summary>
        /// 桶的多版本配置。
        /// </summary>
        public VersioningConfiguration Configuration
        {
            get;
            internal set;
        }
    }
}
    
