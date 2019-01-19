
using System;

namespace OBS.Model
{
    /// <summary>
    /// 对象信息。
    /// </summary>
    public class ObsObject
    {

        /// <summary>
        /// 对象的etag校验值。
        /// </summary>
        public string ETag
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象名。
        /// </summary>
        public string ObjectKey
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象的最后修改时间。
        /// </summary>
        public DateTime? LastModified
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象的所有者。
        /// </summary>
        public Owner Owner
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象大小。
        /// </summary>
        public long Size
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象的存储类型。
        /// </summary>
        public StorageClassEnum? StorageClass
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象是否可被追加写。
        /// </summary>
        public bool Appendable
        {
            get;
            internal set;
        }

    }
}
