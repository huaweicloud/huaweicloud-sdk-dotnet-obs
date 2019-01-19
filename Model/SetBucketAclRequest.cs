

namespace OBS.Model
{
    /// <summary>
    /// 设置桶访问权限的请求参数。
    /// </summary>
    public class SetBucketAclRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "SetBucketAcl";
        }

        /// <summary>
        /// 预定义访问策略。  
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public CannedAclEnum? CannedAcl
        {
            get;
            set;
        }


        /// <summary>
        /// 被授权者和访问权限列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public AccessControlList AccessControlList
        {
            get;
            set;
        }

    }
}
    
