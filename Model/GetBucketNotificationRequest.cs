

namespace OBS.Model
{
    /// <summary>
    /// 获取桶消息通知配置的请求参数。
    /// </summary>
    public class GetBucketNotificationRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "GetBucketNotification";
        }

    }
}
    
