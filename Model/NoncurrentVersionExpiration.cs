
namespace OBS.Model
{
    /// <summary>
    /// 历史版本对象过期时间配置。
    /// </summary>
    public class NoncurrentVersionExpiration
    {

        /// <summary>
        /// 历史版本对象过期时间，表示对象在成为历史版本之后第几天时过期。
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

    }

}
