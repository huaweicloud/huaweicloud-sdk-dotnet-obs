

namespace OBS.Model
{
    /// <summary>
    /// 设置对象访问权限的请求参数。
    /// </summary>
    public class SetObjectAclRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "SetObjectAcl";
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

     

        /// <summary>
        /// 对象名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string ObjectKey
        {
            get;
            set;
        }

        /// <summary>
        /// 对象版本号。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string VersionId
        {
            get;
            set;
        }

    }
}
    
