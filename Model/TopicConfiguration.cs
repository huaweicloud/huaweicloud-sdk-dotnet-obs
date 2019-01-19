
using System.Collections.Generic;

namespace OBS.Model
{   
    /// <summary>
    /// 事件通知配置.
    /// </summary>
    public class TopicConfiguration
    {
        List<EventTypeEnum> _events;

        /// <summary>
        /// 事件通知配置ID.
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string Id { get; set; }


        /// <summary>
        /// 事件通知主题的URN，当OBS检测到桶中发生特定的事件后，将会发布通知消息至该主题。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string Topic { get; set; }

       
        /// <summary>
        /// 需要发布通知消息的事件类型列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public List<EventTypeEnum> Events
        { 
            get
            {
                return this._events ?? (this._events = new List<EventTypeEnum>());
            }
            set { this._events = value; } 
        }
        
        public List<FilterRule> filterRules;
        /// <summary>
        /// 事件通知配置的过滤规则列表.
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public List<FilterRule> FilterRules
        {
            get
            {
                return this.filterRules ?? (this.filterRules = new List<FilterRule>());
            }
            set { this.filterRules = value; }
        }
    }
}
