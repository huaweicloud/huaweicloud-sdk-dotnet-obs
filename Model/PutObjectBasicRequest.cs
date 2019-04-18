using System;
using System.Collections.Generic;


namespace OBS.Model
{
    public abstract class PutObjectBasicRequest : ObsBucketWebServiceRequest
    {

        private IDictionary<ExtensionObjectPermissionEnum, IList<string>> extensionPermissionMap;

        private MetadataCollection metadataCollection;

        /// <summary>
        /// 对象的自定义元数据。
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
        /// 对象的MIME类型。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string ContentType
        {
            get;
            set;
        }

        /// <summary>
        /// 对象的存储类型。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public StorageClassEnum? StorageClass
        {
            get;
            set;
        }

        /// <summary>
        /// 对象的重定向链接，可以将获取这个对象的请求重定向到桶内另一个对象或一个外部的URL。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string WebsiteRedirectLocation
        {
            get;
            set;
        }

        /// <summary>
        /// 为用户授予OBS对象扩展权限。
        /// </summary>
        /// <param name="domainId">用户的domainId。</param>
        /// <param name="extensionPermissionEnum">OBS扩展权限。</param>
        public void GrantExtensionPermission(string domainId, ExtensionObjectPermissionEnum extensionPermissionEnum)
        {
            if (string.IsNullOrEmpty(domainId))
            {
                return;
            }

            IList<string> domainIds;

            ExtensionPermissionMap.TryGetValue(extensionPermissionEnum, out domainIds);

            if (domainIds == null)
            {
                domainIds = new List<string>();
                ExtensionPermissionMap.Add(extensionPermissionEnum, domainIds);
            }
            domainId = domainId.Trim();
            if (!domainIds.Contains(domainId))
            {
                domainIds.Add(domainId);
            }

        }

        /// <summary>
        /// 撤回用户的OBS对象扩展权限。
        /// </summary>
        /// <param name="domainId">用户的domainId。</param>
        /// <param name="extensionPermissionEnum">OBS扩展权限。</param>
        public void WithDrawExtensionPermission(string domainId, ExtensionObjectPermissionEnum extensionPermissionEnum)
        {
            if (string.IsNullOrEmpty(domainId))
            {
                return;
            }

            IList<string> domainIds;
            ExtensionPermissionMap.TryGetValue(extensionPermissionEnum, out domainIds);
            domainId = domainId.Trim();
            if (domainIds != null && domainIds.Contains(domainId))
            {
                domainIds.Remove(domainId);
            }
        }

        internal IDictionary<ExtensionObjectPermissionEnum, IList<string>> ExtensionPermissionMap
        {
            get
            {
                return extensionPermissionMap ?? (extensionPermissionMap = new Dictionary<ExtensionObjectPermissionEnum, IList<string>>());
            }
        }

        /// <summary>
        /// 对象的访问权限。
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
        /// 请求操作响应成功后的重定向地址。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string SuccessRedirectLocation
        {
            set;
            get;
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
        /// 对象内容SSE加密头域信息。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public SseHeader SseHeader
        {
            get;
            set;
        }
    }
}
    
