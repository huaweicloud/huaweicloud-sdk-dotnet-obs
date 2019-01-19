

namespace OBS.Model
{
    /// <summary>
    /// 获取桶Website（托管）配置的请求参数。
    /// </summary>
    public class GetBucketWebsiteRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "GetBucketWebsite";
        }

    }
}
    
