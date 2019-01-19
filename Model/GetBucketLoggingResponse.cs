

namespace OBS.Model
{
    /// <summary>
    /// 获取桶访问日志配置的响应结果。
    /// </summary>
    public class GetBucketLoggingResponse : ObsWebServiceResponse
    {

        /// <summary>
        /// 桶的访问日志配置。
        /// </summary>
        public LoggingConfiguration Configuration
        {
            get;
            internal set;
        }
    }
}
    
