

namespace OBS.Model
{
    /// <summary>
    /// 设置桶跨域资源共享配置的请求参数。
    /// </summary>
    public class SetBucketCorsRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "SetBucketCors";
        }

        /// <summary>
        /// 桶的跨域资源共享配置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public CorsConfiguration Configuration
        {
            get;
            set;
        }

    }
}
    
