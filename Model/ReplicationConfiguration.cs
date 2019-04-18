using System;
using System.Collections.Generic;
using System.Text;

namespace OBS.Model
{
    /// <summary>
    /// 桶的跨区域复制配置。
    /// </summary>
    public class ReplicationConfiguration
    {
        /// <summary>
        /// 委托名字
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string Agency
        {
            get;
            set;
        }

        private IList<ReplicationRule> rules;

        /// <summary>
        /// 桶的跨区域复制配置规则列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public IList<ReplicationRule> Rules
        {
            get
            {

                return this.rules ?? (this.rules = new List<ReplicationRule>());
            }
            set { this.rules = value; }
        }
    }
}
