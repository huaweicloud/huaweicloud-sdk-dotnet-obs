
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 桶的跨域资源共享配置。
    /// </summary>
    public class CorsConfiguration
    {

        private IList<CorsRule> rules;

        /// <summary>
        /// 桶的跨域资源共享规则列表.
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public IList<CorsRule> Rules
        {
            get {
                
                return this.rules ?? (this.rules = new List<CorsRule>()); }
            set { this.rules = value; }
        }

    }
}
