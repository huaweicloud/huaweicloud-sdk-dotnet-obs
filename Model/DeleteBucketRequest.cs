
namespace OBS.Model
{
    /// <summary>
    /// 删除桶的请求参数。
    /// </summary>
    public class DeleteBucketRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "DeleteBucket";
        }

    }
}
    
