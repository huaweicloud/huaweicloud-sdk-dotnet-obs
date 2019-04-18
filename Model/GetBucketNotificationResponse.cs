

namespace OBS.Model
{

    /// <summary>
    ///  获取桶消息通知配置的响应结果。
    /// </summary>
    public class GetBucketNotificationReponse : ObsWebServiceResponse
    {

        /// <summary>
        /// 桶的消息通知配置。
        /// </summary>
        public NotificationConfiguration Configuration
        {
            get;
            internal set;
        }

    }
}
    
