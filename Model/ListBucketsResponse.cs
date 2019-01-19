
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 获取桶列表的响应结果。
    /// </summary>
    public class ListBucketsResponse : ObsWebServiceResponse
    {
        private IList<ObsBucket> buckets;

        /// <summary>
        /// 桶列表。
        /// </summary>
        public IList<ObsBucket> Buckets
        {
            get {
                
                return this.buckets ?? (this.buckets = new List<ObsBucket>()); }
            internal set { this.buckets = value; }
        }

        /// <summary>
        /// 桶的所有者。
        /// </summary>
        public Owner Owner
        {
            get;
            internal set;
        }

    }
}
    
