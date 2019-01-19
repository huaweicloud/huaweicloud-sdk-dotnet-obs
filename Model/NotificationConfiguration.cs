
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 桶的消息通知配置。
    /// </summary>
    public class NotificationConfiguration
    {

        private IList<TopicConfiguration> topicConfigurations;

        /// <summary>
        /// 事件通知配置列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public IList<TopicConfiguration> TopicConfigurations
        {
            get
            {
                
                return this.topicConfigurations ?? (this.topicConfigurations = new List<TopicConfiguration>());
            }
            set { this.topicConfigurations = value; }
        }
    }
}
