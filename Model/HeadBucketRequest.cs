

namespace OBS.Model
{
    /// <summary>
    /// 查询桶是否存在的请求参数。
    /// </summary>
    public class HeadBucketRequest : ObsBucketWebServiceRequest
    {
        internal override string GetAction()
        {
            return "HeadBucket";
        }
    }
}
    
