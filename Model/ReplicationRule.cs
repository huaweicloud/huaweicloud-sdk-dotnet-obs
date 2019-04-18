
namespace OBS.Model
{
    /// <summary>
    /// 跨区域复制配置规则。
    /// </summary>
    public class ReplicationRule
    {


        /// <summary>
        ///  规则ID，由不超过255个字符的字符串组成。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// 规则所匹配的对象名前缀。  
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选，用以标识哪些对象可以匹配到当前这条规则。可为空字符串，代表匹配桶内所有对象。
        /// </para>
        /// </remarks>
        public string Prefix
        {
            get;
            set;
        }

        /// <summary>
        /// 规则状态。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public RuleStatusEnum Status
        {
            get;
            set;
        }

        /// <summary>
        /// 目标桶名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string TargetBucketName
        {
            get;
            set;
        }

        /// <summary>
        /// 对象的存储类型。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public StorageClassEnum? TargetStorageClass
        {
            get;
            set;
        }

    }
}
