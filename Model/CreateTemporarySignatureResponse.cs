
using System;
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 临时鉴权响应结果。
    /// </summary>
    public class CreateTemporarySignatureResponse
    {
        private IDictionary<string, string> actualSignedRequestHeaders;
            
        /// <summary>
        /// 临时鉴权URL
        /// </summary>
        public string SignUrl
        {
            get;
            internal set;
        }

        /// <summary>
        /// 实际用于鉴权的头域。
        /// </summary>
        public IDictionary<String,String> ActualSignedRequestHeaders
        {
            get {
                
                return this.actualSignedRequestHeaders ?? (this.actualSignedRequestHeaders = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)); }
            internal set { this.actualSignedRequestHeaders = value; }
        }

    }
}
    
