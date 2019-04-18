
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 桶的消息通知配置。
    /// </summary>
    public class NotificationConfiguration
    {

        private IList<TopicConfiguration> topicConfigurations;

        private IList<FunctionGraphConfiguration> functionGraphConfigurations;

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

        /// <summary>
        /// 函数工作流服务配置列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public IList<FunctionGraphConfiguration> FunctionGraphConfigurations
        {
            get
            {

                return this.functionGraphConfigurations ?? (this.functionGraphConfigurations = new List<FunctionGraphConfiguration>());
            }
            set { this.functionGraphConfigurations = value; }
        }
    }
}
