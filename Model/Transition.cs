
using System;

namespace OBS.Model
{
    /// <summary>
    /// 对象转换策略。
    /// </summary>
    public class Transition
    {
        

        /// <summary>
        /// 对象转换日期， 表示对象转换的具体日期。
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
        /// 对象转换时间，表示在对象创建时间后第几天时自动转换。 
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


        /// <summary>
        /// 对象转换后的存储类别。
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
