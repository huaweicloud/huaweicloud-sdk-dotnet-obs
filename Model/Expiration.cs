
using System;

namespace OBS.Model
{
    /// <summary>
    /// 对象过期时间配置。
    /// </summary>
    public class Expiration
    {
        
        /// <summary>
        /// 对象过期日期， 表示对象过期的具体日期。 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 如果没有设置Days则必选。
        /// </para>
        /// </remarks>
        public DateTime? Date
        {
            get;
            set;
        }

        /// <summary>
        /// 对象过期时间，表示在对象创建时间后第几天时过期。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 如果没有设置Date则必选。
        /// </para>
        /// </remarks>
        public int? Days
        {
            get;
            set;
        }
    }
}
