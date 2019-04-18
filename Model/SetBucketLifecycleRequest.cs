

namespace OBS.Model
{
    /// <summary>
    /// 设置桶生命周期配置的请求参数。
    /// </summary>
    public class SetBucketLifecycleRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "SetBucketLifecycle";
        }

        /// <summary>
        /// 桶的生命周期配置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public LifecycleConfiguration Configuration
        {
            get;
            set;
        }

    }
}
    
