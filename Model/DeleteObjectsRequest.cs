
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OBS.Model
{
    /// <summary>
    /// 批量删除对象的请求参数。
    /// </summary>
    public partial class DeleteObjectsRequest : ObsBucketWebServiceRequest
    {
        private IList<KeyVersion> objects;

        internal override string GetAction()
        {
            return "DeleteObjects";
        }

        /// <summary>
        /// 待删除的对象列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public IList<KeyVersion> Objects
        {
            get 
            {
                return this.objects ?? (this.objects = new List<KeyVersion>()); 
            }
            set { this.objects = value; }
        }

        /// <summary>
        /// 批量删除对象的响应模式。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，为false时使用verbose模式, 为true时使用quiet模式，默认为verbose模式。
        /// </para>
        /// </remarks>
        public bool? Quiet
        {
            get;
            set;
        }

    }
}
    
