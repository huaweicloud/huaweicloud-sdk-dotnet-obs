
using System;

namespace OBS.Model
{
    /// <summary>
    /// 桶信息。
    /// </summary>
    public class ObsBucket
    {
        

        /// <summary>
        /// 桶的创建时间。
        /// </summary>
        public DateTime? CreationDate
        {
            get;
            internal set;
        }

        /// <summary>
        /// 桶名。
        /// </summary>
        public string BucketName
        {
            get;
            internal set;
        }

        /// <summary>
        /// 桶的区域位置
        /// </summary>
        public string Location
        {
            get;
            internal set;
        }

        public override string ToString()
        {
            return "BucketName:" + BucketName + ", CreationDate:" + CreationDate + ", Location:" + Location;
        }

    }
}
