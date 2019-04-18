

namespace OBS.Model
{
    /// <summary>
    /// 删除桶生命周期配置的请求参数。
    /// </summary>
    public class DeleteBucketLifecycleRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "DeleteLifecycle";
        }

    }
}
    
