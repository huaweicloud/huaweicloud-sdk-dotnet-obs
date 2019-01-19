
namespace OBS.Model
{
    /// <summary>
    /// 重定向基础配置。
    /// </summary>
    public class RedirectBasic
    {
        

        /// <summary>
        /// 重定向请求时使用的主机名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string HostName
        {
            get;
            set;
        }



        /// <summary>
        /// 重定向请求时使用的协议。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public ProtocolEnum? Protocol
        {
            get;
            set;
        }




    }
}
