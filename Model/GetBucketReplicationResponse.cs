

namespace OBS.Model
{
    /// <summary>
    /// 获取桶跨区域复制配置的响应结果。
    /// </summary>
    public class GetBucketReplicationResponse : ObsWebServiceResponse
    {

        /// <summary>
        /// 桶的跨区域复制配置。
        /// </summary>
        public ReplicationConfiguration Configuration
        {
            get;
            internal set;
        }
    }
}
    
