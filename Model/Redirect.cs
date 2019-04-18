
namespace OBS.Model
{
    /// <summary>
    /// 重定向配置。
    /// </summary>
    public class Redirect : RedirectBasic
    {

        /// <summary>
        /// HTTP状态码配置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string HttpRedirectCode
        {
            get;
            set;
        }



        /// <summary>
        /// 重定向请求时使用的对象名前缀。  
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string ReplaceKeyPrefixWith
        {
            get;
            set;
        }



        /// <summary>
        /// 重定向请求时使用的对象名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，不可与ReplaceKeyPrefixWith同时存在。
        /// </para>
        /// </remarks>
        public string ReplaceKeyWith
        {
            get;
            set;
        }


    }
}
