

namespace OBS.Model
{
    /// <summary>
    /// 获取桶配额的请求参数。
    /// </summary>
    public class GetBucketQuotaRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "GetBucketQuota";
        }

    }
}
    
