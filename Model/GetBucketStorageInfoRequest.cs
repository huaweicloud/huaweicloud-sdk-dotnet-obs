

namespace OBS.Model
{
    /// <summary>
    /// 获取桶存量信息的请求参数。
    /// </summary>
    public class GetBucketStorageInfoRequest: ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "GetBucketStorageInfo";
        }

    }
}
    
