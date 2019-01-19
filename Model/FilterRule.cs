
namespace OBS.Model
{
    /// <summary>
    /// 事件通知配置的过滤规则。
    /// </summary>
    public class FilterRule
    {


        /// <summary>
        /// 按对象名的前缀或后缀进行过滤标识。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public FilterNameEnum? Name
        {
            get;
            set;
        }

        /// <summary>
        /// 对象名关键字。 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string Value
        {
            get;
            set;
        }

    }
}
