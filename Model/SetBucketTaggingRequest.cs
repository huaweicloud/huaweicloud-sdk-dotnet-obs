
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 设置桶标签的请求参数。
    /// </summary>
    public class SetBucketTaggingRequest : ObsBucketWebServiceRequest
    {
        private IList<Tag> tags;

        internal override string GetAction()
        {
            return "SetBucketTagging";
        }

        /// <summary>
        /// 桶标签列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// 每个桶支持最多10个Tag。
        /// </para>
        /// </remarks>
        public IList<Tag> Tags
        {
            get {
                
                return this.tags ?? (this.tags = new List<Tag>());
            }
            set { this.tags = value; }
        }

    }
}
    
