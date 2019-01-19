

namespace OBS.Model
{
    /// <summary>
    /// 获取桶多版本配置的请求参数。
    /// </summary>
    public class GetBucketVersioningRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "GetBucketVersioning";
        }

    }
}
    
