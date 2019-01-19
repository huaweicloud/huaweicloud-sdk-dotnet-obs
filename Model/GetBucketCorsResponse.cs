

namespace OBS.Model
{
    /// <summary>
    /// 获取桶跨域资源共享配置的响应结果。
    /// </summary>
    public class GetBucketCorsResponse : ObsWebServiceResponse
    {

        /// <summary>
        /// 桶的跨域资源共享配置。
        /// </summary>
        public CorsConfiguration Configuration
        {
            get;
            internal set;
        }

    }
}
    
