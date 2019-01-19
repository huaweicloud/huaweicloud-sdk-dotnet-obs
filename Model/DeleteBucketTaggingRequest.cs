

namespace OBS.Model
{
    /// <summary>
    /// 删除桶标签的请求参数。
    /// </summary>
    public class DeleteBucketTaggingRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "DeleteBucketTagging";
        }

    }
}
    
