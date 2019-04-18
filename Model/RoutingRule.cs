
namespace OBS.Model
{
    /// <summary>
    /// 请求重定向规则。
    /// </summary>
    public class RoutingRule
    {
        /// <summary>
        /// 请求重定向条件。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public Condition Condition
        {
            get;
            set;
        }


        /// <summary>
        /// 请求重定向配置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public Redirect Redirect
        {
            get;
            set;
        }

    }
}
