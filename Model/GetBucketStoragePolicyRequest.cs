

namespace OBS.Model
{
    /// <summary>
    /// 获取桶存储策略的请求参数。
    /// </summary>
    public class GetBucketStoragePolicyRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "GetBucketStoragePolicy";
        }

    }
}
    
