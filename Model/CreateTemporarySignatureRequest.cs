
using System;
using System.Collections.Generic;
namespace OBS.Model
{
    /// <summary>
    /// 临时鉴权请求参数。 
    /// </summary>
    public class CreateTemporarySignatureRequest : ObsBucketWebServiceRequest
    {

        private IDictionary<string, string> headers;
        private MetadataCollection metadataCollection;
        private IDictionary<string, string> parameters;

        internal override string GetAction()
        {
            return "CreateTemporarySignature";
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
        /// 过期时间，单位秒。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public long? Expires
        {
            get;
            set;
        }



        /// <summary>
        /// 请求方法。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public HttpVerb Method
        {
            get;
            set;
        }


        /// <summary>
        /// 请求头域。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public IDictionary<string, string> Headers
        {
            get
            {
                return this.headers ?? (this.headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
            }
            internal set
            {
                this.headers = value;
            }
        }


        /// <summary>
        /// 自定义元数据，仅在上传对象、初始化分段上传任务、复制对象时可用。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public MetadataCollection Metadata
        {
            get
            {
              
                return this.metadataCollection ?? (this.metadataCollection = new MetadataCollection());
            }
            internal set
            {
                this.metadataCollection = value;
            }
        }

        /// <summary>
        /// 子资源。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public SubResourceEnum? SubResource
        {
            get;
            set;
        }

        /// <summary>
        /// 请求查询参数。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public IDictionary<String, String> Parameters
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