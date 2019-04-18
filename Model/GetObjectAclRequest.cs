

namespace OBS.Model
{
    /// <summary>
    /// 获取对象访问权限的请求参数。
    /// </summary>
    public class GetObjectAclRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "GetObjectAcl";
        }

        /// <summary>
        /// 对象名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string ObjectKey { get; set; }

        /// <summary>
        /// 对象版本号。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string VersionId { get; set; }


    }
}
    
