


namespace OBS.Model
{
    /// <summary>
    /// 获取桶生命周期配置的请求参数。
    /// </summary>
    public class GetBucketLifecycleRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "GetBucketLifecycle";
        }

    }
}
    
