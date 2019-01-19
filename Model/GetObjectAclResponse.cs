

namespace OBS.Model
{
    /// <summary>
    /// 获取对象访问权限的响应结果。
    /// </summary>
    public class GetObjectAclResponse : ObsWebServiceResponse
    {
        /// <summary>
        /// 被授权用户权限信息列表。
        /// </summary>
        public AccessControlList AccessControlList { get; internal set; }
    }
}
    
