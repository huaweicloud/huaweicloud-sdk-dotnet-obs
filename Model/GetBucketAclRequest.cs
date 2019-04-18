

namespace OBS.Model
{
    /// <summary>
    /// 获取桶访问权限的请求参数。
    /// </summary>
    public class GetBucketAclRequest : ObsBucketWebServiceRequest
    {
        internal override string GetAction()
        {
            return "GetBucketAcl";
        }
    }
}
    
