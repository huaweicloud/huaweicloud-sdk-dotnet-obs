
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 桶的跨域资源共享规则（CORS）。
    /// </summary>
    public class CorsRule
    {
        private IList<HttpVerb> allowedMethods;
        private IList<string> allowedOrigins;
        private IList<string> exposeHeaders;
        private IList<string> allowedHeaders;

        /// <summary>
        /// 跨域规则中允许的方法列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public IList<HttpVerb> AllowedMethods
        {
            get {
                
                return this.allowedMethods ?? (this.allowedMethods = new List<HttpVerb>()); }
            set { this.allowedMethods = value; }
        }

        /// <summary>
        /// 跨域规则中允许的请求来源列表（表示域名的字符串）。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public IList<string> AllowedOrigins
        {
            get {
                
                return this.allowedOrigins ?? (this.allowedOrigins = new List<string>()); }
            set { this.allowedOrigins = value; }
        }

        /// <summary>
        /// 跨域规则ID。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// 由不超过255个字符的字符串组成。
        /// </para>
        /// </remarks>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// 跨域规则允许响应中可返回的头域列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public IList<string> ExposeHeaders
        {
            get {
                
                return this.exposeHeaders ?? (this.exposeHeaders = new List<string>()); }
            set { this.exposeHeaders = value; }
        }

        /// <summary>
        /// 客户端对请求结果的缓存时间，以秒为单位。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public int? MaxAgeSeconds
        {
            get;
            set;
        }


        /// <summary>
        /// 跨域规则中允许请求中可携带的头域列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public IList<string> AllowedHeaders
        {
            get {
               
                return this.allowedHeaders ?? (this.allowedHeaders = new List<string>()); }
            set { this.allowedHeaders = value; }
        }

    }
}
