
namespace OBS.Model
{
    /// <summary>
    /// 历史版本对象转换策略。
    /// </summary>
    public class NoncurrentVersionTransition
    {

        /// <summary>
        /// 历史版本对象转换时间，表示对象在成为历史版本之后第几天时自动转换。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public int NoncurrentDays
        {
            get;
            set;
        }


        /// <summary>
        /// 历史版本对象转换后的存储类别。
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
