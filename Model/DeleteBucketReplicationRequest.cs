

namespace OBS.Model
{
    /// <summary>
    /// 删除桶跨区域复制配置的请求参数。
    /// </summary>
    public class DeleteBucketReplicationRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "DeleteBucketReplication";
        }

    }
}
    
