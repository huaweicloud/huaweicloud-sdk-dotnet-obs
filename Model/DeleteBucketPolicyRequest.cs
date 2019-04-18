

namespace OBS.Model
{
    /// <summary>
    /// 删除桶策略的请求参数。
    /// </summary>
    public partial class DeleteBucketPolicyRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "DeleteBucketPolicy";
        }

    }
}
    
