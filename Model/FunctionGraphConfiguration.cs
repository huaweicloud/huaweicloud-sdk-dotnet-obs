
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 函数工作流服务配置.
    /// </summary>
    public class FunctionGraphConfiguration
    {
        List<EventTypeEnum> _events;
        List<FilterRule> _filterRules;

        /// <summary>
        /// 函数工作流服务配置ID.
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string Id { get; set; }


        /// <summary>
        /// 函数工作流服务的URN，当OBS检测到桶中发生特定的事件后，将会发送消息至函数工作流服务调用执行该工作流。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string FunctionGraph { get; set; }


        /// <summary>
        /// 需要发送消息至函数工作流服务的事件类型列表。
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
        
       
        /// <summary>
        /// 函数工作流服务配置的过滤规则列表.
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
                return this._filterRules ?? (this._filterRules = new List<FilterRule>());
            }
            set { this._filterRules = value; }
        }
    }
}
