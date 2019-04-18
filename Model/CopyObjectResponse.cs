
using System;

namespace OBS.Model
{
    /// <summary>
    /// 复制对象的响应结果。
    /// </summary>
    public class CopyObjectResponse : ObsWebServiceResponse
    {

        /// <summary>
        /// 目标对象的etag值。
        /// </summary>
        public string ETag
        {
            get;
            internal set;
        }

        /// <summary>
        /// 目标对象的最后修改时间。
        /// </summary>
        public DateTime? LastModified
        {
            get;
            internal set;
        }

        /// <summary>
        /// 目标对象的存储类型。
        /// </summary>
        public StorageClassEnum? StorageClass
        {
            get;
            internal set;
        }

        /// <summary>
        /// 源对象的版本号。
        /// </summary>
        public string SourceVersionId
        {
            get;
            internal set;
        }

        /// <summary>
        /// 目标对象的版本号。
        /// </summary>
        public string VersionId
        {
            get;
            internal set;
        }

    }
}
    
