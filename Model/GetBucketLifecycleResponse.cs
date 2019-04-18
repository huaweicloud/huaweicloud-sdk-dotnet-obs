

namespace OBS.Model
{
    /// <summary>
    /// 获取桶生命周期配置的响应结果。
    /// </summary>
    public class GetBucketLifecycleResponse : ObsWebServiceResponse
    {


        /// <summary>
        /// 桶的生命周期配置。
        /// </summary>
        public LifecycleConfiguration Configuration
        {
            get;
            internal set;
        }
    }
}
    
