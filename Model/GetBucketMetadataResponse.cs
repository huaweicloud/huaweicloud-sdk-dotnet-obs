
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 获取桶元数据的响应结果。
    /// </summary>
    public class GetBucketMetadataResponse : ObsWebServiceResponse
    {
        /// <summary>
        /// 桶的存储类型。
        /// </summary>
        public StorageClassEnum? StorageClass
        {
            get;
            internal set;
        }

        /// <summary>
        /// 桶的区域位置。
        /// </summary>
        public string Location
        {
            get;
            internal set;
        }

        /// <summary>
        /// OBS服务的版本。
        /// </summary>
        public string ObsVersion
        {
            get;
            internal set;
        }

        /// <summary>
        /// 桶的集群类型。
        /// </summary>
        public AvailableZoneEnum AvailableZone
        {
            get;
            internal set;
        }

    }
}
    
