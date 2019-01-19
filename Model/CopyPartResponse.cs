
using System;


namespace OBS.Model
{
    /// <summary>
    /// 复制段的响应结果。
    /// </summary>
    public class CopyPartResponse : ObsWebServiceResponse
    {

        /// <summary>
        /// 目标段的etag值。
        /// </summary>
        public string ETag
        {
            get;
            internal set;
        }

        /// <summary>
        /// 目标段的最后修改时间。
        /// </summary>
        public DateTime? LastModified
        {
            get;
            internal set;
        }

        /// <summary>
        /// 目标段的分段号。
        /// </summary>
        public int PartNumber
        {
            get;
            internal set;
        }


    }
}
    
