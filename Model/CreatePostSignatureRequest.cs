
using System;
using System.Collections.Generic;
namespace OBS.Model
{
    /// <summary>
    /// POST表单鉴权请求参数。 
    /// </summary>
    public class CreatePostSignatureRequest : ObsBucketWebServiceRequest
    {

        private IDictionary<string, string> parameters;

        internal override string GetAction()
        {
            return "CreatePostSignature";
        }

        /// <summary>
        /// 桶名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public override string BucketName
        {
            get;
            set;
        }

        /// <summary>
        /// 对象名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string ObjectKey
        {
            get;
            set;
        }


        /// <summary>
        /// 过期时间。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public DateTime? Expires
        {
            get;
            set;
        }


        /// <summary>
        /// 表单参数。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public IDictionary<String, String> FormParameters
        {
            get {
     
                return this.parameters ?? (this.parameters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
            }
            set
            {
                this.parameters = value;
            }
        }


    }
}