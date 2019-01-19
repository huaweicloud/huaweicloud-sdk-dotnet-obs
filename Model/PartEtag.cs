
using System;

namespace OBS.Model
{
    /// <summary>
    /// 分段的信息。
    /// </summary>
    public class PartETag : IComparable<PartETag>
    {

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public PartETag()
        {
        }


        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="partNumber">分段号</param>
        /// <param name="etag">分段的etag校验值</param>
        public PartETag(int partNumber, string etag)
        {
            this.PartNumber = partNumber;
            this.ETag = etag;
        }

        /// <summary>
        /// 与其他段信息比较。
        /// </summary>
        /// <param name="other">其他段信息</param>
        /// <returns>为真表示已两个段段号相等。</returns>
        public int CompareTo(PartETag other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.PartNumber.CompareTo(other.PartNumber);
        }

        /// <summary>
        /// 分段号。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        ///  </para> 
        /// </remarks>
        public int PartNumber
        {
            get;
            set;
        }


        /// <summary>
        /// 分段的etag校验值。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        ///  </para> 
        /// </remarks>
        public string ETag
        {
            get;
            set;
        }

    }
}
