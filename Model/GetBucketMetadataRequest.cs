
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 获取桶元数据信息的请求参数。
    /// </summary>
    public class GetBucketMetadataRequest : ObsBucketWebServiceRequest
    {
        private IList<string> accessControlRequestHeaders;


        /// <summary>
        /// 预请求指定的跨域请求Origin（通常为域名）。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string Origin
        {
            get;
            set;
        }


        /// <summary>
        ///  跨域请求可以使用的HTTP头域。
        ///  </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public IList<string> AccessControlRequestHeaders
        {
            get { return this.accessControlRequestHeaders ?? (this.accessControlRequestHeaders = new List<string>()); }
            set { this.accessControlRequestHeaders = value; }
        }

        internal override string GetAction()
        {
            return "GetBucketMetadata";
        }

    }
}
    
