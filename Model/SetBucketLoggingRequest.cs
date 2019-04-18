

namespace OBS.Model
{
    /// <summary>
    /// 设置桶访问日志配置的请求参数。
    /// </summary>
    public class SetBucketLoggingRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "SetBucketLogging";
        }

        /// <summary>
        /// 桶的访问日志配置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public LoggingConfiguration Configuration { get; set; }

    }
}
    
