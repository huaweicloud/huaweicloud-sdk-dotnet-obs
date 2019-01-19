

namespace OBS.Model
{
    /// <summary>
    /// 设置桶跨区域复制配置的请求参数。
    /// </summary>
    public class SetBucketReplicationRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "SetBucketReplication";
        }

        /// <summary>
        /// 桶的跨区域复制配置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public ReplicationConfiguration Configuration
        {
            get;
            set;
        }
    }
}
    
