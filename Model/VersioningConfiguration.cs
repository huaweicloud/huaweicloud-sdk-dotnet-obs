


namespace OBS.Model
{
    /// <summary>
    /// 桶的多版本配置。
    /// </summary>

    public class VersioningConfiguration
    {


        /// <summary>
        /// 桶的多版本状态。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选
        /// </para>
        /// </remarks>
        public VersionStatusEnum? Status
        {
            get;
            set;
        }
    }
}
