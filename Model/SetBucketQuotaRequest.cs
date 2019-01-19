

namespace OBS.Model
{
    /// <summary>
    /// 设置桶配额的请求参数。
    /// </summary>
    public class SetBucketQuotaRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "SetBucketQuota";
        }

        /// <summary>
        /// 配额。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选，为字符串类型，需要将整数值转化为字符串。
        /// 单位为字节，支持的最大值为2^63 - 1的字符串形式，配额值设为“0”表示桶的配额没有上限。
        /// </para>
        /// </remarks>
        public long StorageQuota
        {
            get;
            set;
        }

    }
}
    
