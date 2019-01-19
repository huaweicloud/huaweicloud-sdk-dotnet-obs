

namespace OBS.Model
{
    /// <summary>
    /// 获取桶存量信息的响应结果。
    /// </summary>
    public class GetBucketStorageInfoResponse : ObsWebServiceResponse
    {

        /// <summary>
        ///  桶的空间大小。
        /// </summary>
        public long Size
        {
            get;
            internal set;
        }

        /// <summary>
        /// 桶的对象个数。
        /// </summary>
        public long ObjectNumber
        {
            get;
            internal set;
        }
      
    }
}
    
