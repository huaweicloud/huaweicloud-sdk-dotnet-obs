
namespace OBS.Model
{
    /// <summary>
    /// 请求重定向条件。
    /// </summary>
    public class Condition
    {


        /// <summary>
        /// 重定向生效时的HTTP错误码配置。 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string HttpErrorCodeReturnedEquals
        {
            get;
            set;
        }



        /// <summary>
        /// 当重定向生效时对象名的前缀。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string KeyPrefixEquals
        {
            get;
            set;
        }


    }
}
