using System;

namespace OBS.Model
{
    /// <summary>
    /// 分段的详细信息。
    /// </summary>
    public class PartDetail : PartETag
    {


        /// <summary>
        /// 分段的最后修改时间。
        /// </summary>
        public DateTime? LastModified
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段的大小。
        /// </summary>
        public long Size
        {
            get;
            internal set;
        }

    }
}
