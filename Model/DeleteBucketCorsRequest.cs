

namespace OBS.Model
{
    /// <summary>
    /// 删除桶跨域资源共享配置的请求参数。
    /// </summary>
    public class DeleteBucketCorsRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "DeleteBucketCors";
        }

    }
}
    
