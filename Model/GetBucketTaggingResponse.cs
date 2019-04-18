
using System.Collections.Generic;


namespace OBS.Model
{
    /// <summary>
    /// 获取桶标签的响应结果。
    /// </summary>
    public class GetBucketTaggingResponse : ObsWebServiceResponse
    {

        private IList<Tag> tags;
        /// <summary>
        /// 桶标签列表。
        /// </summary>
        public IList<Tag> Tags
        {
            get {
                
                return this.tags ?? (this.tags = new List<Tag>()); }
            internal set { this.tags = value; }
        }

    }
}
    
