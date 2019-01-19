
namespace OBS.Model
{
    /// <summary>
    /// 下载或复制对象的范围
    /// </summary>
    public class ByteRange
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public ByteRange()
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="start">起始位置。</param>
        /// <param name="end">结束位置。</param>
        public ByteRange(long start, long end)
        {
            this.Start = start;
            this.End = end;
        }

        /// <summary>
        /// 起始位置，单位字节。
        /// </summary>
        public long Start
        {
            get;
            set;
        }

        /// <summary>
        /// 结束位置，单位字节。
        /// </summary>
        public long End
        {
            get;
            set;
        }

    }
}
