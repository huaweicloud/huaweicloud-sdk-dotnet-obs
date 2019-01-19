
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 桶的Website（托管）配置。
    /// </summary>
    public class WebsiteConfiguration
    {

        private IList<RoutingRule> routingRules;
        /// <summary>
        /// 托管错误页面。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string ErrorDocument
        {
            get;
            set;
        }

        /// <summary>
        /// 托管首页。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选,该字段被追加在对文件夹的请求的末尾（例如：配置的是“index.html”，请求的是“samplebucket/images/”，
        /// 返回的数据将是“samplebucket”桶内名为“images/index.html”的对象的内容）。该字段不能为空或者包含“/”字符。
        /// </para>
        /// </remarks>
        public string IndexDocument
        {
            get;
            set;
        }

        /// <summary>
        ///所有请求重定向配置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public RedirectBasic RedirectAllRequestsTo
        {
            get;
            set;
        }

        /// <summary>
        /// 请求重定向规则列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，与ErrorDocument，IndexDocument配合使用，不可与RedirectAllRequestsTo一起使用。
        /// </para>
        /// </remarks>
        public IList<RoutingRule> RoutingRules
        {
            get {
                
                return this.routingRules ?? (this.routingRules = new List<RoutingRule>()); }
            set { this.routingRules = value; }
        }

    }
}
