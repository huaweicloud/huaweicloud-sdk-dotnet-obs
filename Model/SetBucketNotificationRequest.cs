

namespace OBS.Model
{
    /// <summary>
    /// 设置桶消息通知配置的请求参数。
    /// </summary>
    public class SetBucketNotificationRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "SetBucketNotification";
        }

        /// <summary>
        /// 桶的消息通知配置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public NotificationConfiguration Configuration
        {
            get;
            set;
        }
    }
}
    
