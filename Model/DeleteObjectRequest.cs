
using System;

namespace OBS.Model
{
    /// <summary>
    /// 删除对象的请求参数。
    /// </summary>
    public class DeleteObjectRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "DeleteObject";
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
        /// 待删除对象的版本号。
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
    
