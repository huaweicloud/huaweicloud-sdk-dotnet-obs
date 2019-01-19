

namespace OBS.Model
{
    /// <summary>
    /// 获取桶跨区域复制配置的请求参数。
    /// </summary>
    public class GetBucketReplicationRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "GetBucketReplication";
        }

    }
}
    
