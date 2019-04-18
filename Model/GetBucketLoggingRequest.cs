

namespace OBS.Model
{
    /// <summary>
    /// 获取桶访问日志配置的请求参数。
    /// </summary>
    public class GetBucketLoggingRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "GetBucketLogging";
        }

    }
}
    
