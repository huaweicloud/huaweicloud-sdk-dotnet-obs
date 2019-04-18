

namespace OBS.Model
{
    /// <summary>
    /// 获取桶配额的响应结果。
    /// </summary>
    public class GetBucketQuotaResponse : ObsWebServiceResponse
    {

        /// <summary>
        /// 桶配额。
        /// </summary>
        public long StorageQuota
        {
            get;
            internal set;
        }

    }
}
    
