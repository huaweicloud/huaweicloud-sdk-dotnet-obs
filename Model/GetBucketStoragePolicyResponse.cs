

namespace OBS.Model
{
    /// <summary>
    /// 获取桶存储策略的响应结果。
    /// </summary>
    public class GetBucketStoragePolicyResponse : ObsWebServiceResponse
    {

        /// <summary>
        /// 桶的存储类型。
        /// </summary>
        public StorageClassEnum? StorageClass
        {
            get;
            internal set;
        }
    }
}
    
