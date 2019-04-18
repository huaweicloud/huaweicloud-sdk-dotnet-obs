

namespace OBS.Model
{
    /// <summary>
    /// 获取桶区域位置的请求参数。
    /// </summary>
    public class GetBucketLocationRequest : ObsBucketWebServiceRequest
    {
        internal override string GetAction()
        {
            return "GetBucketLocation";
        }
    }
}
    
