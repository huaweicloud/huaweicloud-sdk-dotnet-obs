

namespace OBS.Model
{
    /// <summary>
    /// 获取桶策略的请求参数。
    /// </summary>
    public class GetBucketPolicyRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "GetBucketPolicy";
        }

    }
}
    
