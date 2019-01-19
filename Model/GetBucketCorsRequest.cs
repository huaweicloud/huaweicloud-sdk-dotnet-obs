

namespace OBS.Model
{
    /// <summary>
    /// 获取桶的跨域资源共享配置的请求参数。
    /// </summary>
    public class GetBucketCorsRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "GetBucketCors";
        }

    }
}
    
