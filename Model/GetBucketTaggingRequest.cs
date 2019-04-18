

namespace OBS.Model
{
    /// <summary>
    /// 获取桶标签的请求参数。
    /// </summary>
    public class GetBucketTaggingRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "GetBucketTagging";
        }

    }
}
    
