

namespace OBS.Model
{
    /// <summary>
    /// 设置桶存储类型的请求参数。
    /// </summary>
    public class SetBucketStoragePolicyRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "SetBucketStoragePolicy";
        }

        /// <summary>
        ///  桶的存储类型。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public StorageClassEnum? StorageClass
        {
            get;
            set;
        }

    }
}
    
