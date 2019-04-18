

namespace OBS.Model
{
    /// <summary>
    /// 获取桶策略的响应结果。
    /// </summary>
    public class GetBucketPolicyResponse : ObsWebServiceResponse
    {
        /// <summary>
        /// 策略内容，JSON格式的字符串。
        /// </summary>
        public string Policy { get; internal set; }

    }
}
    
