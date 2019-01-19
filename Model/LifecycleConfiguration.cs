
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 桶的生命周期配置。
    /// </summary>
    public class LifecycleConfiguration
    {

        private IList<LifecycleRule> rules;

        /// <summary>
        /// 桶的生命周期规则列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public IList<LifecycleRule> Rules
        {
            get {
               
                return this.rules ?? (this.rules = new List<LifecycleRule>()); }
            set { this.rules = value; }
        }

    }
}
