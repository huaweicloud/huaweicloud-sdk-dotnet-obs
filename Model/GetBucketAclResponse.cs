

namespace OBS.Model
{
    /// <summary>
    /// 获取桶访问权限的响应结果。
    /// </summary>
    public class GetBucketAclResponse : ObsWebServiceResponse
    {
        /// <summary>
        /// 被授权用户权限信息列表。
        /// </summary>
        public AccessControlList AccessControlList { get; internal set; }
    }
}
    
