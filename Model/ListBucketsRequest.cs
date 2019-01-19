
namespace OBS.Model
{
    /// <summary>
    /// 获取桶列表的请求参数。
    /// </summary>
    public class ListBucketsRequest : ObsWebServiceRequest
    {
        private bool queryLocation = true;
        /// <summary>
        /// 是否列出所有桶的区域信息，默认为true。
        /// </summary>
        public bool IsQueryLocation
        {
            get
            {
                return this.queryLocation;
            }
            set
            {
                this.queryLocation = value;
            }
        }

        internal override string GetAction()
        {
            return "ListBuckets";
        }

    }
}
    
