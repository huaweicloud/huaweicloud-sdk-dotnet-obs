

namespace OBS.Model
{
    /// <summary>
    /// 删除桶Website（托管）配置的请求参数。
    /// </summary>
    public class DeleteBucketWebsiteRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "DeleteBucketWebsite";
        }

    }
}
    
